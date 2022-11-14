namespace webapi.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; } = null!;

        public string OrganizationName { get; set; } = null!;

        public string OrganizationRole { get; set; } = null!;

        public string UserName { get; set; } = null!;
    }
}