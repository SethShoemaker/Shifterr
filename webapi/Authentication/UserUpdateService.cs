using System.Text.RegularExpressions;
using webapi.Data;
using webapi.Models;

namespace webapi.Authentication
{
    public class UserUpdateService
    {
        private readonly ApplicationContext _context;
        private readonly PasswordService _passwordService;
        private readonly UserRoleService _userRoleService;
        public UserUpdateService(
            ApplicationContext Context,
            PasswordService PasswordService,
            UserRoleService UserRoleService
        )
        {
            _context = Context;
            _passwordService = PasswordService;
            _userRoleService = UserRoleService;
        }

        public List<string> AttemptUpdateUser(
            User User, 
            string? Nickname, 
            string? Email, 
            string? Password, 
            string? RoleString
        )
        {
            List<string> Errors = new List<string>();

            if(Nickname != null && Nickname != User.Nickname){

                if(Nickname.Length < 4) Errors.Add("Nickname Not Long Enough");

                if(Nickname.Length > 20) Errors.Add("Nickname Too Enough");

                User.Nickname = Nickname;
            }

            if(Email != null && Email != User.Email){

                if(Email.Length < 8) Errors.Add("Email Not Long Enough");
            
                Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match EmailRegexMatch = EmailRegex.Match(Email);
                if(!EmailRegexMatch.Success) Errors.Add("Invalid Email Address");

                User.Email = Email;
                User.EmailIsConfirmed = false;
            }

            if(Password != null){

                if(Password.Length < 8) Errors.Add("Password Not Long Enough");

                byte[] passwordHash = null!;
                byte[] passwordSalt = null!;
                this._passwordService.CreatePasswordHashAndSalt(Password, out passwordHash, out passwordSalt);
                User.PasswordHash = passwordHash;
                User.PasswordSalt = passwordSalt;
            }

            if(RoleString != null){
                OrganizationRole RoleEnum = this._userRoleService.GetRoleFromString(RoleString);

                if(RoleEnum == OrganizationRole.Undefined) Errors.Add("User Role Invalid");

                if(RoleEnum == OrganizationRole.Administrator) Errors.Add("Cannot Assign Administrator Role");

                if(User.OrganizationRole == OrganizationRole.Administrator && RoleEnum != OrganizationRole.Administrator) Errors.Add("Cannot Deassign Administrator Role");

                User.OrganizationRole = RoleEnum;
            }

            if(!Errors.Any()) _context.SaveChanges();

            return Errors;
        }
    }
}