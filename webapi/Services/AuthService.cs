using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using webapi.Data;
using webapi.Models;

namespace webapi.Services
{
    public class AuthService
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(
            ApplicationContext ApplicationContext,
            IConfiguration Configuration
        ){
            _context = ApplicationContext;
            _configuration = Configuration;
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
            return attemptedPasswordHash.SequenceEqual(existingUser.PasswordHash);
        }
        public string CreateToken(User User)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(type: "UserOrgId", value: User.OrganizationId.ToString()),
                new Claim(type: "UserRole", value: User.OrganizationRole.ToString()),
                new Claim(type: "UserName", value: User.UserName.ToString()),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
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