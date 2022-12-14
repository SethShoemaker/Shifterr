using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using webapi.Requests;
using webapi.Responses;
using webapi.Services;

namespace webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/shifts")]
    public class ShiftsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserInfoHelperService _userInfoHelperService;
        public ShiftsController(
            ApplicationContext Context,
            UserInfoHelperService UserInfoHelperService
        ){
            _context = Context;
            _userInfoHelperService = UserInfoHelperService;
        }

        [HttpGet]
        [Route("index")]
        public ActionResult<ShiftsIndexResponse> Index()
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);
            int UserId = _userInfoHelperService.GetUserId(HttpContext.User);        
                
            List<ShiftIndexShiftDto> Shifts = 
            (
                from shift in _context.Shifts
                    where 
                        shift.OrganizationId == UserOrgId &&
                        shift.Worker.Id == UserId && 
                        shift.End >= DateTime.Now
                    select new ShiftIndexShiftDto 
                        { 
                            Id = shift.Id,
                            WorkerId = shift.Worker.Id,
                            Worker = shift.Worker.UserName,
                            Position = shift.ShiftPosition.Name,
                            Start = shift.Start,
                            End = shift.End
                        }
            ).ToList();

            return (Shifts == null) ? NoContent() : new ShiftsIndexResponse { Shifts = Shifts };
        }

        [HttpGet]
        [Route("info")]
        public ActionResult<ShiftShowResponse> Info(int ShiftId)
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);
                
            ShiftShowResponse? Shift = 
            (
                from shift in _context.Shifts
                    where shift.OrganizationId == UserOrgId && shift.Id == ShiftId
                    select new ShiftShowResponse 
                        { 
                            Worker = shift.Worker.UserName,
                            Position = shift.ShiftPosition.Name,
                            StartDate = shift.Start.ToString(),
                            StartTime = TimeOnly.FromDateTime(shift.Start).ToString(),
                            EndTime = TimeOnly.FromDateTime(shift.End).ToString(),
                            Hours = (shift.End - shift.Start).Hours,
                            CoWorkers = 
                            (
                                from coWorkerShift in _context.Shifts
                                    where coWorkerShift.OrganizationId == UserOrgId &&
                                    coWorkerShift.Id != shift.Id &&
                                    // Find Overlapping Shifts
                                    coWorkerShift.Start <= shift.End && coWorkerShift.End >= shift.Start
                                    select new ShiftShowCoworkerDto
                                        {
                                            ShiftId = coWorkerShift.Id,
                                            Nickname = coWorkerShift.Worker.UserName
                                        }
                            ).ToList()
                        }
            ).FirstOrDefault();

            return (Shift == null) ? NotFound("Shift Not Found") : Shift;
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult Create(ShiftCreateRequest request)
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            User? User = _context.Users
                .Where(u => u.OrganizationId == UserOrgId)
                .Where(u => u.Id == request.WorkerId)
                .FirstOrDefault();
            if(User == null) return BadRequest("Invalid Worker Id");

            ShiftPosition? ShiftPosition = null;
            if(request.ShiftPositionId != null)
            {
                ShiftPosition = _context.ShiftPositions
                    .Where(sp => sp.OrganizationId == UserOrgId)
                    .Where(sp => sp.Id == request.ShiftPositionId)
                    .FirstOrDefault();
                if(ShiftPosition == null) return BadRequest("Invalid Shift Position Id");
            }

            DateTime Start;
            if(!DateTime.TryParse(request.Start, out Start)) return BadRequest("Start Invalid");

            DateTime End;
            if(!DateTime.TryParse(request.End, out End)) return BadRequest("End Invalid");

            if (Start.CompareTo(End) > 0) return BadRequest("End Time Must Be After Start Time");

            Shift NewShift = new Shift
            {
                OrganizationId = UserOrgId,
                Worker = User,
                ShiftPosition = ShiftPosition,
                Start = Start,
                End = End
            };

            _context.Shifts.Add(NewShift);
            _context.SaveChanges();

            return Ok(new { ResponseText = "Created"});
        }

        // This method returns information (like user Ids, names) the client needs to create shift
        [HttpGet]
        [Route("create/info")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult<ShiftCreateInfoResponse> CreateInfo()
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            List<ShiftCreateShiftPositionDto> ShiftPositions = 
                (
                    from shiftPosition in _context.ShiftPositions
                    where shiftPosition.OrganizationId == UserOrgId
                    select new ShiftCreateShiftPositionDto
                        {
                            Id = shiftPosition.Id,
                            name = shiftPosition.Name
                        }
                ).ToList();

            List<ShiftCreateWorkerDto> Workers = 
                (
                    from worker in _context.Users
                    where worker.OrganizationId == UserOrgId
                    select new ShiftCreateWorkerDto
                        {
                            Id = worker.Id,
                            nickname = worker.Nickname,
                            userName = worker.UserName
                        }
                ).ToList();

            return Ok(new ShiftCreateInfoResponse{ Positions = ShiftPositions, Workers = Workers });
        }

        [HttpGet]
        [Route("delete")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult Delete(int ShiftId)
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            Shift? ShiftToDelete = _context.Shifts
                .Where(s => s.OrganizationId == UserOrgId)
                .Where(s => s.Id == ShiftId)
                .FirstOrDefault();
            if(ShiftToDelete == null) return BadRequest(new { ResponseText = "Shift Not Found" });

            _context.Shifts.Remove(ShiftToDelete);
            _context.SaveChanges();

            return Ok(new { ResponseText = "Shift Deleted" });
        }
    }
}