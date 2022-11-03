using System.Security.Cryptography;
using webapi.Data;
using webapi.Models;

namespace webapi.Services
{
    public class AuthService
    {
        private readonly ApplicationContext _context;
        public AuthService(ApplicationContext ApplicationContext)
        {
            _context = ApplicationContext;
        }
        public bool RegisterUser(
            string Username, 
            string Email, 
            string Password, 
            Organization Organization,
            OrganizationRole OrganizationRole
        ){

            if(UsernameExists(Username)) return false; 

            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePassword(Password, out passwordHash, out passwordSalt);

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

        public bool checkCredentialValidity(
            string UserName,
            string PasswordPlainText
        ){
            User existingUser = _context.Users.First(u => u.UserName == UserName);
            if(existingUser == null) return false;

            var hmac = new HMACSHA512(existingUser.PasswordSalt);
            var attemptedPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(PasswordPlainText));

            return attemptedPasswordHash == existingUser.PasswordHash;
        }

        private void CreatePassword( 
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
            int existingUser = _context.Users.Where(u => u.UserName == UserName).Count();
            return existingUser > 0;
        }
    }
}