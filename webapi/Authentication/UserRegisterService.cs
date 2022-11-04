using System.Security.Cryptography;
using webapi.Data;
using webapi.Models;

namespace webapi.Authentication
{
    public class UserRegisterService
    {
        public readonly ApplicationContext _context;
        public UserRegisterService(ApplicationContext Context)
        {
            _context = Context;
        }
        public bool RegisterUserUnsaved(
            string Username, 
            string Email, 
            string Password, 
            Organization Organization,
            OrganizationRole OrganizationRole
        ){
            if(UsernameExists(Username)) return false; 

            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHashAndSalt(Password, out passwordHash, out passwordSalt);

            User User = new User 
            {
                UserName = Username,
                Email = Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Organization = Organization,
                OrganizationRole = OrganizationRole
            };
            _context.Users.Add(User);
            
            return true;
        }
        private void CreatePasswordHashAndSalt( 
            string PasswordPlainText, 
            out byte[] PasswordHash, 
            out byte[] PasswordSalt
        ){
            var hmac = new HMACSHA512();
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(PasswordPlainText));
            PasswordSalt = hmac.Key;
        }
        private bool UsernameExists(string UserName)
        {
            User? existingUser = _context.Users.FirstOrDefault(u => u.UserName == UserName);
            return existingUser != null;
        }
    }
}