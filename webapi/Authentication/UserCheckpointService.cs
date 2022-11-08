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

        public User? GetTokenUser(string inputToken)
        {
            return (
                from token in _context.UserTokens
                    where token.Value == inputToken
                    select token.User
            ).FirstOrDefault();
        }

        public AuthenticationTicket CreateTicket(User user)
        {
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