using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager { get; }
        public AccountController(ILogger<AccountController> Logger, UserManager<IdentityUser> UserManager , SignInManager<IdentityUser> signInManager)
        {
            _logger = Logger;
            _userManager = UserManager;
            _signInManager = signInManager;
            
        }

        

        // [AllowAnonymous]
        // [HttpPost("login")]
        // public ActionResult Login([FromBody] LoginRequest request)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest();
        //     }

            // if (!_userManager.IsValidUserCredentials(request.UserName, request.Password))
            // {
            //     return Unauthorized();
            // }

            // var role = _userManager.GetUserRole(request.UserName);
            // var claims = new[]
            // {
            //     new Claim(ClaimTypes.Name,request.UserName),
            //     new Claim(ClaimTypes.Role, role)
            // };

            // var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            // _logger.LogInformation($"User [{request.UserName}] logged in the system.");
            // return Ok(new LoginResult
            // {
            //     UserName = request.UserName,
            //     Role = role,
            //     AccessToken = jwtResult.AccessToken,
            //     RefreshToken = jwtResult.RefreshToken.TokenString
            // });
        // }
    }
}