using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using webapi.Models;

namespace webapi.Authentication
{
    public class TokenAuthenticationHandler : AuthenticationHandler<TokenAuthenticationSchemeOptions>
    {
        private UserCheckpointService _userCheckpointService;
        public TokenAuthenticationHandler(
            IOptionsMonitor<TokenAuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            UserCheckpointService userCheckpointService
        ) : base(options, logger, encoder, clock)
        {
            _userCheckpointService = userCheckpointService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string headerToken = this.Request.Headers.Authorization;

            if (string.IsNullOrEmpty(headerToken)) 
            {
                return Task.FromResult(AuthenticateResult.Fail("Auth Token Not Found"));
            }

            // Remove "Bearer" from headerToken string
            headerToken = headerToken.Substring(7);

            User? user = _userCheckpointService.GetTokenUser(headerToken);
            if (user == null) 
            {
                return Task.FromResult(AuthenticateResult.Fail("Auth Token Invalid"));
            }

            AuthenticationTicket ticket = _userCheckpointService.CreateTicket(user);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}