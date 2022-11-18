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
    [Route("api/user/confirmation")]
    [AllowAnonymous]
    public class UserConfirmationController : ControllerBase
    {
        private ApplicationContext _context;
        private UserLoginService _userLoginService;
        private readonly UserConfirmationService _userConfirmationService;
        private readonly EmailService _emailService;
        public UserConfirmationController
        (
            ApplicationContext Context,
            UserLoginService UserLoginService,
            UserConfirmationService UserConfirmationService,
            EmailService EmailService
        )
        {
            _context = Context;
            _userLoginService = UserLoginService;
            _userConfirmationService = UserConfirmationService;
            _emailService = EmailService;
        }

        [HttpPost]
        [Route("send")]
        public ActionResult Send(AccSendConfKeyRequest request)
        {
            User? user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if(user == null) return Unauthorized("User Not Found");

            bool valid = _userLoginService.ValidatePassword(user, request.Password);
            if(!valid) return Unauthorized("Bad Credentials");

            if(user.EmailIsConfirmed) return Unauthorized("User Already Confirmed");

            if(request.NewEmail != null)
            {
                user.Email = request.NewEmail;
                _context.SaveChanges();
            }

            string ConfirmationKey = _userConfirmationService.GenerateConfirmationKeySaved(user);

            _emailService.SendEmail
            (
                To: "SethTo",
                From: "SethFrom",
                Subject: "Confirmation",
                Message: ConfirmationKey
            );

            return Ok("Sent Confirmation");
        }

        [HttpGet]
        [Route("validate")]
        public ActionResult Validate([FromQuery]AccValidateConfKeyRequest request)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Id == request.UserId);
            if(user == null) return Unauthorized("Invalid");

            if(user.EmailIsConfirmed) return Unauthorized("Invalid");

            bool IsValid = _userConfirmationService.ValidateUserConfirmationKey(user, request.ConfirmationKey);
            if(!IsValid) return Unauthorized("Invalid");

            bool UserConfirmed = _userConfirmationService.ConfirmUserSaved(user);
            if(!UserConfirmed) return BadRequest("Error Confirming User");

            return Ok("User Confirmed");
        }
    }
}