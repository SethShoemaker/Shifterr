using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using webapi.Data;
using webapi.Models;

namespace webapi.Services
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
        public bool CheckCredentialValidity(
            string UserName,
            string PasswordPlainText
        ){
            User UserToVerify = _context.Users.First(u => u.UserName == UserName);
            if(UserToVerify == null) return false;

            var hmac = new HMACSHA512(UserToVerify.PasswordSalt);
            var attemptedPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(PasswordPlainText));
            return attemptedPasswordHash.SequenceEqual(UserToVerify.PasswordHash);
        }
        public string CreateToken(User User)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(type: "UserOrgId", value: User.OrganizationId.ToString()),
                new Claim(ClaimTypes.Role, value: User.OrganizationRole.ToString()),
                new Claim(ClaimTypes.Name, value: User.UserName.ToString()),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}