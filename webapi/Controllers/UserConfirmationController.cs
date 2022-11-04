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
        ){
            _context = Context;
            _userLoginService = UserLoginService;
            _userConfirmationService = UserConfirmationService;
            _emailService = EmailService;
        }

        [HttpPost]
        [Route("send")]
        public ActionResult Send(AccSendConfKeyRequest request)
        {
            User? User = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if(User == null) return BadRequest("User Not Found");

            bool valid = _userLoginService.ValidateCredentials(request.UserName, request.Password);
            if(!valid) return Unauthorized("Bad Credentials");

            if(User.EmailIsConfirmed) return BadRequest("User Already Confirmed");

            if(request.NewEmail != null)
            {
                User.Email = request.NewEmail;
                _context.SaveChanges();
            }

            string ConfirmationKey = _userConfirmationService.GenerateConfirmationKeySaved(User);

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
            User? User = _context.Users.FirstOrDefault(u => u.Id == request.UserId);
            if(User == null) return Unauthorized("Invalid");

            if(User.EmailIsConfirmed) return Unauthorized("Invalid");

            bool IsValid = _userConfirmationService.ValidateUserConfirmationKey(User, request.ConfirmationKey);
            if(!IsValid) return Unauthorized("Invalid");

            bool UserConfirmed = _userConfirmationService.ConfirmUserSaved(User);
            if(!UserConfirmed) return BadRequest("Error Confirming User");

            return Ok("User Confirmed");
        }
    }
}