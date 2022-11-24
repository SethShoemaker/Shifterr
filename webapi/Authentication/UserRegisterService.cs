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
        
        public bool RegisterUserUnsaved(
            string Username, 
            string Email, 
            string Password, 
            Organization Organization,
            OrganizationRole Role
        )
        {
            if(Role == OrganizationRole.Undefined) return false;
            if(UsernameExists(Username)) return false; 

            byte[] passwordHash;
            byte[] passwordSalt;
            this._passwordService.CreatePasswordHashAndSalt(Password, out passwordHash, out passwordSalt);

            User User = new User 
            {
                UserName = Username,
                Email = Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Organization = Organization,
                OrganizationRole = Role
            };
            _context.Users.Add(User);
            
            return true;
        }

        private bool UsernameExists(string UserName)
        {
            User? existingUser = _context.Users.FirstOrDefault(u => u.UserName == UserName);
            return existingUser != null;
        }
    }
}