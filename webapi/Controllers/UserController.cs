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
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserRegisterService _userRegisterService;
        private readonly UserLoginService _userLoginService;
        private readonly UserInfoHelperService _userInfoHelperService;
        private readonly UserUpdateService _userUpdateService;
        private readonly UserRoleService _userRoleService;
        public UserController(
            ApplicationContext Context, 
            UserRegisterService UserRegisterService,
            UserLoginService UserLoginService,
            UserInfoHelperService UserManagerService,
            UserUpdateService UserUpdateService,
            UserRoleService UserRoleService
        ){
            _context = Context;
            _userRegisterService = UserRegisterService;
            _userLoginService = UserLoginService;
            _userInfoHelperService = UserManagerService;
            _userUpdateService = UserUpdateService;
            _userRoleService = UserRoleService;
        } 

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Register(AccRegisterRequest request)
        {
            List<string> Errors = _userRegisterService.AttemptUserRegistration(
                UserName: request.UserName,
                Email: request.Email,
                Password: request.Password,
                Organization: _userInfoHelperService.GetUserOrg(HttpContext.User),
                Role: this._userRoleService.GetRoleFromString(request.Role)
            );

            return (Errors.Any()) ? BadRequest(new { ResponseText = Errors }) : Ok(new { ResponseText = "Registered"});
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
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

        [HttpGet]
        [Route("index")]
        public ActionResult<UserIndexResponse> Index()
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            List<UserIndexUserDto> Workers = (
                from users in _context.Users
                where users.OrganizationId == UserOrgId
                select new UserIndexUserDto
                    {
                        Id = users.Id,
                        UserName = users.UserName,
                        Email = users.Email,
                        Role = users.OrganizationRole.ToString()
                    }
                ).ToList();

            return new UserIndexResponse{ Workers = Workers };
        }

        [HttpGet]
        [Route("info")]
        public ActionResult<UserInfoResponse> Info(int UserId){

            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            User? User = _context.Users.Where(u => (u.OrganizationId == UserOrgId) && (u.Id == UserId)).FirstOrDefault();
            if(User == null) return BadRequest("User Not Found");

            UserInfoResponse Response = new UserInfoResponse{
                userName = User.UserName,
                email = User.Email,
                Role = User.OrganizationRole.ToString()
            };

            return Ok(Response);
        }

        [HttpPost]
        [Route("update")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Update(int UserId, AccUpdateRequest request){

            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            User? UserToUpdate = _context.Users.Where(u => (u.OrganizationId == UserOrgId) && (u.Id == UserId)).FirstOrDefault();
            if(UserToUpdate == null) return BadRequest("User Not Found");

            if(request.Role != null && UserToUpdate.OrganizationRole == OrganizationRole.Administrator) return BadRequest("Cannot Deassign Administrator Role");

            this._userUpdateService.UpdateUserSaved(
                    User: UserToUpdate,
                    Email: request.Email,
                    Password: request.Password,
                    Role: request.Role
                );

            return Ok(new { ResponseText = "Updated" });
        }

        [HttpGet]
        [Route("delete")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int UserId){

            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            User? UserToDelete = _context.Users.Where(u => (u.OrganizationId == UserOrgId) && (u.Id == UserId)).FirstOrDefault();
            if(UserToDelete == null) return BadRequest("User Not Found");

            _context.Users.Remove(UserToDelete);
            _context.SaveChanges();

            return Ok(new { ResponseText = "Deleted" });
        }
    }
}