using System.Text.RegularExpressions;
using webapi.Data;
using webapi.Models;

namespace webapi.Authentication
{
    public class UserRegisterService
    {
        public readonly ApplicationContext _context;
        public PasswordService _passwordService;
        public UserRegisterService(
            ApplicationContext Context,
            PasswordService PasswordService
        )
        {
            _context = Context;
            _passwordService = PasswordService;
        }
        
        public List<string> AttemptUserRegistration(
            string UserName, 
            string Nickname,
            string Email, 
            string Password, 
            Organization Organization,
            OrganizationRole Role
        )
        {

            List<string> Errors = this.ValidateUser(
                UserName: UserName,
                Nickname: Nickname,
                Email: Email,
                Password: Password,
                Organization: Organization,
                Role: Role
            );

            if(!Errors.Any()){
                byte[] passwordHash;
                byte[] passwordSalt;
                this._passwordService.CreatePasswordHashAndSalt(Password, out passwordHash, out passwordSalt);

                User User = new User 
                {
                    UserName = UserName,
                    Email = Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Organization = Organization,
                    OrganizationRole = Role
                };
                _context.Users.Add(User);

                _context.SaveChanges();
            }

            return Errors;
        }

        private List<string> ValidateUser(            
            string UserName, 
            string Nickname,
            string Email, 
            string Password, 
            Organization Organization,
            OrganizationRole Role
        )
        {

            List<string> Errors = new List<string>();

            if(UserName.Length < 8) Errors.Add("Username Not Long Enough");

            if(UserName.Length > 40) Errors.Add("Username Too Long");

            User? ExistingUser = _context.Users.FirstOrDefault(u => u.UserName == UserName);
            if(ExistingUser != null) Errors.Add("Username is Taken");


            if(Nickname.Length < 4) Errors.Add("Nickname Not Long Enough");

            if(Nickname.Length > 20) Errors.Add("Nickname Too Enough");


            if(Email.Length < 8) Errors.Add("Email Not Long Enough");
            
            Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match EmailRegexMatch = EmailRegex.Match(Email);
            if(!EmailRegexMatch.Success) Errors.Add("Invalid Email Address");


            if(Password.Length < 8) Errors.Add("Password Not Long Enough");


            Organization? ExistingOrganization = _context.Organizations.Where(o => o.Id == Organization.Id).FirstOrDefault();
            if(ExistingOrganization == null)  Errors.Add("Organization Does Not Exist");


            if(Role == OrganizationRole.Undefined) Errors.Add("Role is Invalid");

            if(ExistingOrganization != null && Role == OrganizationRole.Administrator){
                User? ExistingAdmin = _context.Users.Where(u => (u.OrganizationId == ExistingOrganization.Id) && u.OrganizationRole == OrganizationRole.Administrator).FirstOrDefault();
                if(ExistingAdmin != null) Errors.Add("Organization Administrator Already Exists");
            }

            return Errors;
        }
    }
}