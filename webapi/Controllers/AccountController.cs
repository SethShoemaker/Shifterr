using Microsoft.AspNetCore.Mvc;
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
        private readonly AuthService _authService;
        public AuthController(
            ApplicationContext Context, 
            AuthService AuthService   
        ){
            _context = Context;
            _authService = AuthService;
        } 

        [HttpPost]
        [Route("login")]
        public ActionResult Login(AccLoginRequest request)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Request");

            User User = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if(User == null) return BadRequest("User Not Found");
            
            bool valid = _authService.checkCredentialValidity(request.UserName, request.Password);
            if(!valid) return Unauthorized("Bad Credentials");

            string token = _authService.CreateToken(User);
            return Ok(token);
        }
    }
}