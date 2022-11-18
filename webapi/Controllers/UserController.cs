using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Authentication;
using webapi.Data;
using webapi.Models;
using webapi.Requests;
using webapi.Responses;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/user")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserRegisterService _userRegisterService;
        private readonly UserLoginService _userLoginService;
        private readonly UserInfoHelperService _userInfoHelperService;
        public UserController(
            ApplicationContext Context, 
            UserRegisterService UserRegisterService,
            UserLoginService UserLoginService,
            UserInfoHelperService UserManagerService
        ){
            _context = Context;
            _userRegisterService = UserRegisterService;
            _userLoginService = UserLoginService;
            _userInfoHelperService = UserManagerService;
        } 

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult Register(AccRegisterRequest request)
        {
            bool registered = _userRegisterService.RegisterUserUnsaved(
                Username: request.UserName,
                Email: request.Email,
                Password: request.Password,
                Organization: _userInfoHelperService.GetUserOrg(HttpContext.User),
                OrganizationRole: OrganizationRole.Crew
            );

            if(!registered) return BadRequest("Username Taken");

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponse> Login(AccLoginRequest request)
        {
            User? user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if(user == null) return Unauthorized("User Not Found");
            
            bool valid = _userLoginService.ValidatePassword(user, request.Password);
            if(!valid) return Unauthorized("Bad Credentials");

            bool emailConfirmed = user.EmailIsConfirmed;
            if(!emailConfirmed) return Unauthorized("User Not Confirmed");

            string token = _userLoginService.CreateTokenSaved(user);

            string userOrgName;
            string userRole;
            _userInfoHelperService.GetUserOrgNameAndRole(user, out userOrgName, out userRole);

            return Ok(new LoginResponse{
                Token = token,
                OrganizationName = userOrgName,
                OrganizationRole = userRole,
                UserName = user.UserName
            });
        }
    }
}