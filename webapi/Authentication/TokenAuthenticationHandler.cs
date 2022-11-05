using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

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
        // 5291f071-9dbf-4d15-bb57-f74856a59b22

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string headerToken = this.Request.Headers.Authorization;
            if (string.IsNullOrEmpty(headerToken)) 
            {
                return Task.FromResult(AuthenticateResult.Fail("Auth Token Not Found"));
            }

            if (!_userCheckpointService.VerifyToken(headerToken)) 
            {
                return Task.FromResult(AuthenticateResult.Fail("Auth Token Invalid"));
            }

            AuthenticationTicket ticket = _userCheckpointService.CreateTicket(headerToken);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}