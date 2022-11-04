using Microsoft.AspNetCore.Mvc;
using webapi.Authentication;
using webapi.Data;
using webapi.Models;
using webapi.Requests;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/organization")]
    public class OrganizationController : ControllerBase
    {
        public readonly ApplicationContext _context;
        private readonly UserRegisterService _userRegisterService;
        public OrganizationController(
            ApplicationContext ApplicationContext, 
            UserRegisterService UserRegisterService
        ){
            _context = ApplicationContext;
            _userRegisterService = UserRegisterService;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(OrgRegisterRequest request)
        {
            Organization Organization = new Organization 
            { 
                Name = request.OrgName
            };

            _context.Organizations.Add(Organization);

            bool registered = _userRegisterService.RegisterUser(
                request.ExecName,
                request.ExecEmail,
                request.ExecPassword,
                Organization,
                OrganizationRole.Administrator
            );

            if(!registered) return BadRequest("Username Taken");

            _context.SaveChanges();

            return Ok();
        }
    }
}