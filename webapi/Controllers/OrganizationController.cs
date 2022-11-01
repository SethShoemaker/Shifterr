using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using webapi.ResourceModels;

namespace webapi.Controllers
{
    [ApiController]
    [Route("organization")]
    public class OrganizationController : ControllerBase
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly ApplicationContext _context;
        private readonly UserManager<Worker> _userManager;
        public SignInManager<Worker> _signInManager { get; }
        public OrganizationController(
            ILogger<OrganizationController> Logger,
            ApplicationContext Context, 
            UserManager<Worker> UserManager, 
            SignInManager<Worker> signInManager
        ){
            _context = Context;
            _logger = Logger;
            _userManager = UserManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Worker>> Register(OrgRegisterRequest request)
        {
            if (!ModelState.IsValid){ return BadRequest(ModelState); }

            Organization newOrg = new Organization{ Name = request.OrgName };
            _context.Organizations.Add(newOrg);
            _context.SaveChanges();

            var result = await _userManager.CreateAsync(
                new Worker() { 
                    OrganizationId = newOrg.Id,
                    UserName = request.ExecName, 
                    Email = request.ExecEmail,
                    OrganizationRole = OrganizationRole.Administrator,
                    },
                request.ExecPassword
            );

            if (!result.Succeeded){ return BadRequest(result.Errors); }

            request.ExecPassword = string.Empty;
            return Created("", request);
        }
    }
}