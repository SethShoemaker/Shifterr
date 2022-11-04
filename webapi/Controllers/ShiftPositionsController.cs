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
    [Route("api/shifts/positions")]
    public class ShiftPositionsController : ControllerBase
    {
        private ApplicationContext _context;
        private UserInfoHelperService _userInfoHelperService;
        public ShiftPositionsController(
            ApplicationContext Context,
            UserInfoHelperService UserInfoHelperService
        ){
            _context = Context;
            _userInfoHelperService = UserInfoHelperService;
        }

        [HttpGet]
        [Route("index")]
        public ActionResult<List<ShiftPosition>> Index()
        {
            Organization UserOrg = _userInfoHelperService.GetUserOrg(HttpContext.User);
            return _context.ShiftPositions
                .Where(s => s.Organization == UserOrg)
                .ToList();
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult<List<ShiftPosition>> Create(ShiftPositionCreateRequest request)
        {
            Organization UserOrg = _userInfoHelperService.GetUserOrg(HttpContext.User);

            ShiftPosition NewShiftPosition = new ShiftPosition
            {
                Organization = UserOrg,
                Name = request.Name,
                Description = request.Description
            };

            _context.ShiftPositions.Add(NewShiftPosition);
            _context.SaveChanges();

            return Ok("Created");
        }

        [HttpGet]
        [Route("delete")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult Delete(int ShiftPositionId)
        {
            Organization UserOrg = _userInfoHelperService.GetUserOrg(HttpContext.User);

            ShiftPosition? ShiftPositionToDelete = _context.ShiftPositions
                .Where(sp => sp.Organization == UserOrg)
                .Where(sp => sp.Id == ShiftPositionId)
                .FirstOrDefault();
            if(ShiftPositionToDelete == null) return BadRequest("Shift Position Not Found");

            _context.ShiftPositions.Remove(ShiftPositionToDelete);
            _context.SaveChanges();

            return Ok("Shift Position Deleted");
        }
    }
}