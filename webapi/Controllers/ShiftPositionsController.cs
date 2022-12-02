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
        public ActionResult<ShiftPositionsIndexResponse> Index()
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            List<ShiftPositionIndexPositionDto> positions = 
            (
                from position in _context.ShiftPositions
                    where position.OrganizationId == UserOrgId
                    select new ShiftPositionIndexPositionDto 
                        { 
                            Id = position.Id,
                            Name = position.Name,
                            Description = position.Description
                        }
            ).ToList();

            return new ShiftPositionsIndexResponse{Positions = positions};
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult<List<ShiftPosition>> Create(ShiftPositionCreateRequest request)
        {

            if(request.Name.Length == 0) return BadRequest(new { ResponseText = "No Position Name Specified"} );
            if(request.Name.Length < 3) return BadRequest(new { ResponseText = "Position Name Not Long Enough, Minimum of 3 characters"} );
            if(request.Name.Length > 20) return BadRequest(new { ResponseText = "Position Name Too Long, Maximum of 20 characters"} );

            if(request.Description != null){
                if(request.Description.Length > 275) return BadRequest(new { ResponseText = "Position Description Too Long, Maximum of 275 characters"} );
                if(request.Description.Length == 0) request.Description = null;
            } 

            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            ShiftPosition NewShiftPosition = new ShiftPosition
            {
                OrganizationId = UserOrgId,
                Name = request.Name,
                Description = request.Description
            };

            _context.ShiftPositions.Add(NewShiftPosition);
            _context.SaveChanges();

            return Ok( new { ResponseText = "Created"});
        }

        [HttpGet]
        [Route("info")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult<ShiftPositionInfoResponse> Info(int ShiftPositionId)
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            ShiftPosition? ShiftPosition = _context.ShiftPositions.Where(sp => (sp.OrganizationId == UserOrgId) && (sp.Id == ShiftPositionId)).FirstOrDefault();
            if(ShiftPosition == null) return BadRequest(new { ResponseText = "Shift Position Not Found"});

            return Ok(new ShiftPositionInfoResponse{ 
                Id = ShiftPosition.Id,
                Name = ShiftPosition.Name,
                Description = ShiftPosition.Description
            });
        }

        [HttpPost]
        [Route("update")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult Update(int ShiftPositionId, ShiftPositionUpdateRequest request)
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            ShiftPosition? ShiftPositionToUpdate = _context.ShiftPositions.Where(sp => (sp.OrganizationId == UserOrgId) && (sp.Id == ShiftPositionId)).FirstOrDefault();
            if(ShiftPositionToUpdate == null) return BadRequest(new { ResponseText = "Shift Position Not Found"});

            if(request.Name != null){
                if(request.Name.Length == 0) return BadRequest(new { ResponseText = "No Position Name Specified"} );
                if(request.Name.Length < 3) return BadRequest(new { ResponseText = "Position Name Not Long Enough, Minimum of 3 characters"} );
                if(request.Name.Length > 20) return BadRequest(new { ResponseText = "Position Name Too Long, Maximum of 20 characters"} );
                ShiftPositionToUpdate.Name = request.Name;
            } 

            if(request.Description != null){
                if(request.Description.Length > 275) return BadRequest(new { ResponseText = "Position Description Too Long, Maximum of 275 characters"} );
                if(request.Description.Length == 0) request.Description = null;
                ShiftPositionToUpdate.Description = request.Description;
            } 

            _context.SaveChanges();

            return Ok(new { ResponseText = "Updated"} );
        }

        [HttpGet]
        [Route("delete")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult Delete(int ShiftPositionId)
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            ShiftPosition? ShiftPositionToDelete = _context.ShiftPositions
                .Where(sp => sp.OrganizationId == UserOrgId)
                .Where(sp => sp.Id == ShiftPositionId)
                .FirstOrDefault();
            if(ShiftPositionToDelete == null) return BadRequest(new { ResponseText = "Position Not Found" });

            Shift? ShiftWithPosition = _context.Shifts
                .Where(s => s.ShiftPosition == ShiftPositionToDelete)
                .FirstOrDefault();
            if(ShiftWithPosition != null) return BadRequest(new { ResponseText = "Position has associated shifts" });

            _context.ShiftPositions.Remove(ShiftPositionToDelete);
            _context.SaveChanges();

            return Ok(new { responseText = "Shift Position Deleted" });
        }
    }
}