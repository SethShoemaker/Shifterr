using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Authentication;
using webapi.Data;
using webapi.Models;
using webapi.Requests;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserRegisterService _userRegisterService;
        private readonly UserLoginService _userLoginService;
        private readonly UserInfoHelperService _userInfoHelperService;
        public AuthController(
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
        [Route("login")]
        public ActionResult Login(AccLoginRequest request)
        {
            User User = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if(User == null) return BadRequest("User Not Found");
            
            bool valid = _userLoginService.ValidateCredentials(request.UserName, request.Password);
            if(!valid) return Unauthorized("Bad Credentials");

            string token = _userLoginService.CreateToken(User);
            return Ok(token);
        }

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Manager,Administrator")]
        public ActionResult Register(AccRegisterRequest request)
        {
            bool registered = _userRegisterService.RegisterUser(
                request.UserName,
                request.Email,
                request.Password,
                _userInfoHelperService.GetUserOrg(HttpContext.User),
                OrganizationRole.Crew
            );

            if(!registered) return BadRequest("Username Taken");

            _context.SaveChanges();

            return Ok();
        }
    }
}