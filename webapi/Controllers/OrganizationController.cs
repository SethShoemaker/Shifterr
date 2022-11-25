using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Authentication;
using webapi.Data;
using webapi.Models;
using webapi.Requests;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/organization")]
    [AllowAnonymous]
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

            Organization Organization = new Organization { Name = request.OrgName };
            _context.Organizations.Add(Organization);
            _context.SaveChanges();

            List<string> Errors = _userRegisterService.AttemptUserRegistration(
                UserName: request.ExecName,
                Email: request.ExecEmail,
                Password: request.ExecPassword,
                Organization: Organization,
                Role: OrganizationRole.Administrator
            );

            return (Errors.Any()) ? BadRequest(new { ResponseText = Errors }) : Ok(new { ResponseText = "Registered"});
        }
    }
}