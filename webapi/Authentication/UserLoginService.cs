using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
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
        ){
            _context = ApplicationContext;
            _configuration = Configuration;
        }
        public string CreateToken(User User)
        {
            List<Claim> Claims = CreateClaims(User);
            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);
            var Token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: Claims,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: Creds
            );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
        public bool ValidateCredentials(
            string UserName,
            string PasswordPlainText
        ){
            User UserToVerify = _context.Users.First(u => u.UserName == UserName);
            if(UserToVerify == null) return false;

            var hmac = new HMACSHA512(UserToVerify.PasswordSalt);
            var attemptedPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(PasswordPlainText));
            return attemptedPasswordHash.SequenceEqual(UserToVerify.PasswordHash);
        }
        private List<Claim> CreateClaims(User User)
        {
            return new List<Claim>
            {
                new Claim(type: "UserOrgId", value: User.OrganizationId.ToString()),
                new Claim(ClaimTypes.Role, value: User.OrganizationRole.ToString()),
                new Claim(ClaimTypes.Name, value: User.UserName.ToString()),
            };
        }
    }
}