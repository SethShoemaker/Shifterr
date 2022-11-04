using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using webapi.Requests;
using webapi.Responses;
using webapi.Services;

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
            Organization Organization = new Organization { Name = request.OrgName };

            _context.Organizations.Add(Organization);

            bool registered = _userRegisterService.RegisterUser(
                request.ExecName,
                request.ExecEmail,
                request.ExecPassword,
                Organization,
                OrganizationRole.Administrator
            );

            _context.SaveChanges();

            return registered ? Ok() : BadRequest();
        }
    }
}