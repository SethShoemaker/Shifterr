using System.Security.Cryptography;
using webapi.Data;
using webapi.Models;

namespace webapi.Authentication
{
    public class PasswordService
    {

        public ApplicationContext _context {get; set;}

        public PasswordService(ApplicationContext Context)
        {
            _context = Context;
        }

        public void CreatePasswordHashAndSalt( 
            string PasswordPlainText, 
            out byte[] PasswordHash, 
            out byte[] PasswordSalt
        )
        {
            var hmac = new HMACSHA512();
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(PasswordPlainText));
            PasswordSalt = hmac.Key;
        }
    }
}