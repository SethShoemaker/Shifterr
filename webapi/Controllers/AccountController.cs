using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using webapi.Services;
using webapi.ResourceModels;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<Worker> _userManager;
        public SignInManager<Worker> _signInManager { get; }
        public JwtService _jwtService { get; }

        public AccountController(
            ILogger<AccountController> Logger, 
            UserManager<Worker> UserManager , 
            SignInManager<Worker> signInManager,
            JwtService JwtService
            ){
            _logger = Logger;
            _userManager = UserManager;
            _signInManager = signInManager;
            _jwtService = JwtService;
        }

        [HttpPost("bearerToken")]
        public async Task<ActionResult<AccLoginResponse>> CreateBearerToken(AccLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _jwtService.CreateToken(user);

            return Ok(token);
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