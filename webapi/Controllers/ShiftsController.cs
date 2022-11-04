using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using webapi.Requests;
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
        public ActionResult<List<Shift>> Index()
        {
            Organization UserOrg = _userInfoHelperService.GetUserOrg(HttpContext.User);
            int UserId = _userInfoHelperService.GetUserId(HttpContext.User);
            return _context.Shifts
                .Where(s => s.Organization == UserOrg)
                .Where(s => s.Worker.Id == UserId)
                .ToList();
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult Create(ShiftCreateRequest request)
        {
            Organization UserOrg = _userInfoHelperService.GetUserOrg(HttpContext.User);

            User? User = _context.Users
                .Where(u => u.Organization == UserOrg)
                .Where(u => u.Id == request.WorkerId)
                .FirstOrDefault();
            if(User == null) return BadRequest("Invalid Worker Id");

            ShiftPosition? ShiftPosition = null;
            if(request.ShiftPositionId != null)
            {
                ShiftPosition = _context.ShiftPositions
                    .Where(sp => sp.Organization == UserOrg)
                    .Where(sp => sp.Id == request.ShiftPositionId)
                    .FirstOrDefault();
                if(ShiftPosition == null) return BadRequest("Invalid Shift Position Id");
            }

            DateTime Start;
            if(!DateTime.TryParse(request.Start, out Start)) return BadRequest("Start Invalid");

            DateTime End;
            if(!DateTime.TryParse(request.End, out End)) return BadRequest("End Invalid");

            Shift NewShift = new Shift
            {
                Organization = UserOrg,
                Worker = User,
                ShiftPosition = ShiftPosition,
                Start = Start,
                End = End
            };

            _context.Shifts.Add(NewShift);
            _context.SaveChanges();

            return Ok("Created");
        }

        [HttpGet]
        [Route("delete")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult Delete(int ShiftId)
        {
            Organization UserOrg = _userInfoHelperService.GetUserOrg(HttpContext.User);

            Shift? ShiftToDelete = _context.Shifts
                .Where(s => s.Organization == UserOrg)
                .Where(s => s.Id == ShiftId)
                .FirstOrDefault();
            if(ShiftToDelete == null) return BadRequest("Shift Not Found");

            _context.Shifts.Remove(ShiftToDelete);
            _context.SaveChanges();

            return Ok("Shift Deleted");
        }
    }
}