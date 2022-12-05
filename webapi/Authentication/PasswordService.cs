using System.Security.Cryptography;
using System.Text;
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
            out string PasswordHash, 
            out string PasswordSalt
        )
        {
            var hmac = new HMACSHA512();
            byte[] PasswordHashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(PasswordPlainText));
            byte[] PasswordSaltByte = hmac.Key;
            PasswordHash = Convert.ToBase64String(PasswordHashBytes);
            PasswordSalt = Convert.ToBase64String(PasswordSaltByte);
        }
    }
}