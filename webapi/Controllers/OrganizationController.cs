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
        public ApplicationContext _context { get; }
        private readonly AuthService _authService;
        public OrganizationController(
            ApplicationContext ApplicationContext, 
            AuthService AuthService
        ){
            _context = ApplicationContext;
            _authService = AuthService;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(OrgRegisterRequest request)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Request");

            Organization Organization = new Organization { Name = request.OrgName };

            _context.Organizations.Add(Organization);

            bool registered = _authService.RegisterUser(
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