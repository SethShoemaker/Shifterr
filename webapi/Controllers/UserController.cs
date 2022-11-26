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

            OrganizationRole Role = this._userRoleService.GetRoleFromString(request.Role);
            if(Role == OrganizationRole.Administrator) return BadRequest(new { ResponseText = "Cannot Assign Multiple Administrators" });

            List<string> Errors = _userRegisterService.AttemptUserRegistration(
                UserName: request.UserName,
                Nickname: request.Nickname,
                Email: request.Email,
                Password: request.Password,
                Organization: _userInfoHelperService.GetUserOrg(HttpContext.User),
                Role: Role
            );

            return (Errors.Any()) ? BadRequest(new { ResponseText = Errors }) : Ok(new { ResponseText = "Registered"});
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<LoginResponse> Login(AccLoginRequest request)
        {
            User? User = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if(User == null) return Unauthorized(new { ResponseText = "User Not Found" } );
            
            bool valid = _userLoginService.ValidatePassword(User, request.Password);
            if(!valid) return Unauthorized(new { ResponseText = "Bad Credentials" } );

            bool emailConfirmed = User.EmailIsConfirmed;
            if(!emailConfirmed) return Unauthorized(new { ResponseText = "User Not Confirmed" } );

            string token = _userLoginService.CreateToken(User);

            string UserOrgName;
            string UserRole;
            _userInfoHelperService.GetUserOrgNameAndRole(User, out UserOrgName, out UserRole);

            return Ok(new LoginResponse{
                Token = token,
                OrganizationName = UserOrgName,
                OrganizationRole = UserRole,
                UserName = User.UserName,
                Nickname = User.Nickname
            });
        }

        [HttpGet]
        [Route("index")]
        public ActionResult<UserIndexResponse> Index()
        {
            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            List<UserIndexUserDto> Workers = (
                from user in _context.Users
                where user.OrganizationId == UserOrgId
                select new UserIndexUserDto
                    {
                        Id = user.Id,
                        Nickname = user.Nickname,
                        Email = user.Email,
                        Role = user.OrganizationRole.ToString()
                    }
                ).ToList();

            return new UserIndexResponse{ Workers = Workers };
        }

        [HttpGet]
        [Route("info")]
        public ActionResult<UserInfoResponse> Info(int UserId){

            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            User? User = _context.Users.Where(u => (u.OrganizationId == UserOrgId) && (u.Id == UserId)).FirstOrDefault();
            if(User == null) return BadRequest(new { ResponseText = "User Not Found" });

            UserInfoResponse Response = new UserInfoResponse{
                UserName = User.UserName,
                Nickname = User.Nickname,
                Email = User.Email,
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
            if(UserToUpdate == null) return BadRequest(new { ResponseText = "User Not Found" });

            List<string> Errors = this._userUpdateService.AttemptUpdateUser(
                    User: UserToUpdate,
                    Nickname: request.Nickname,
                    Email: request.Email,
                    Password: request.Password,
                    RoleString: request.Role
                );

            return Ok(new { ResponseText = "Updated" });
        }

        [HttpGet]
        [Route("delete")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int UserId){

            int UserOrgId = _userInfoHelperService.GetUserOrgId(HttpContext.User);

            User? UserToDelete = _context.Users.Where(u => (u.OrganizationId == UserOrgId) && (u.Id == UserId)).FirstOrDefault();
            if(UserToDelete == null) return BadRequest(new { ResponseText = "User Not Found" });

            if(UserToDelete.OrganizationRole == OrganizationRole.Administrator) return BadRequest(new { ResponseText = "Cannot Delete Administrator" });

            _context.Users.Remove(UserToDelete);
            _context.SaveChanges();

            return Ok(new { ResponseText = "Deleted" });
        }
    }
}