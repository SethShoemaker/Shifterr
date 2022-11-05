using Microsoft.AspNetCore.Authentication;

namespace webapi.Authentication
{
    public class TokenAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public const string Name = "TokenAuthenticationScheme";
    }
}