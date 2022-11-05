using System.Security.Cryptography;
using webapi.Data;
using webapi.Models;

namespace webapi.Authentication
{
    public class UserLoginService
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;

        public UserLoginService(
            ApplicationContext ApplicationContext,
            IConfiguration Configuration
        )
        {
            _context = ApplicationContext;
            _configuration = Configuration;
        }

        public string CreateTokenSaved(User user)
        {
            string token = Guid.NewGuid().ToString();
            UserToken userToken = new UserToken
            {
                OrganizationId = user.OrganizationId,
                User = user,
                Value = token
            };

            _context.UserTokens.Add(userToken);
            _context.SaveChanges();

            return token;
        }
        
        public bool ValidatePassword(
            User user,
            string password
        )
        {
            var hmac = new HMACSHA512(user.PasswordSalt);
            var attemptedPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return attemptedPasswordHash.SequenceEqual(user.PasswordHash);
        }
    }
}