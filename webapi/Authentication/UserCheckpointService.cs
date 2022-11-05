using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using webapi.Data;
using webapi.Models;

namespace webapi.Authentication
{
    public class UserCheckpointService
    {
        public ApplicationContext _context { get; }
        
        public UserCheckpointService(ApplicationContext Context)
        {
            _context = Context;
        }

        public bool VerifyToken(string token)
        {
            UserToken? userToken = _context.UserTokens.FirstOrDefault(ut => ut.Value == token);
            if(userToken == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public AuthenticationTicket CreateTicket(string token)
        {
            UserToken userToken = _context.UserTokens.First(ut => ut.Value == token);
            User user = _context.Users.First(u => u.Id == userToken.UserId);

            List<Claim> claims = CreateClaims(user);
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, nameof(TokenAuthenticationHandler));
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            AuthenticationTicket authTicket = new AuthenticationTicket(claimsPrincipal, TokenAuthenticationSchemeOptions.Name);

            return authTicket;
        } 

        private List<Claim> CreateClaims(User User)
        {
            return new List<Claim>
            {
                new Claim(type: "UserOrgId", value: User.OrganizationId.ToString()),
                new Claim(ClaimTypes.Role, value: User.OrganizationRole.ToString()),
                new Claim(ClaimTypes.NameIdentifier, value: User.Id.ToString()),
                new Claim(ClaimTypes.Name, value: User.UserName.ToString()),
            };
        }
    }
}