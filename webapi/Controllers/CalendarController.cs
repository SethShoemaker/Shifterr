using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using webapi.Responses;
using webapi.Services;

namespace webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/calendar")]
    public class CalendarController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserInfoHelperService _userInfoHelperService;
        public CalendarController(
            ApplicationContext Context,
            UserInfoHelperService UserInfoHelperService
        ){
            _context = Context;
            _userInfoHelperService = UserInfoHelperService;
        }

        [HttpGet]
        [Route("index")]
        public ActionResult Index(DateTime From, DateTime To)
        {
            Organization UserOrg = _userInfoHelperService.GetUserOrg(HttpContext.User);

            List<CalendarIndexUserDto> Workers = 
                (
                    from worker in _context.Users
                    where worker.Organization == UserOrg
                    select new CalendarIndexUserDto
                    {
                        Nickname = worker.Nickname,
                        Shifts = 
                            (
                                from shift in _context.Shifts
                                where 
                                    shift.Worker == worker &&
                                    shift.Start >= From &&
                                    shift.Start <= To
                                select new CalendarIndexShiftDto
                                {
                                    Id = shift.Id,
                                    StartDate = DateOnly.FromDateTime(shift.Start).ToString(),
                                    StartTime = TimeOnly.FromDateTime(shift.Start).ToString(),
                                    EndTime = TimeOnly.FromDateTime(shift.End).ToString(),
                                    Position = shift.ShiftPosition.Name
                                }
                            ).ToList()
                    }
                ).ToList();

            return Ok(new CalendarIndexResponse{ Workers = Workers });
        }
    }
}