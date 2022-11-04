using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using webapi.Data;
using webapi.Models;

namespace webapi.Services
{
    public class UserRegisterService
    {
        public ApplicationContext _context { get; set; }
        public UserRegisterService(ApplicationContext Context)
        {
            _context = Context;
            
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
            int existingUserCount = _context.Users.Where(u => u.UserName == UserName).Count();
            return existingUserCount > 0;
        }
    }
}