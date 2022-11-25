using System.ComponentModel.DataAnnotations;

namespace webapi.Responses
{
    public class LoginResponse
    {
        [Required]
        public string Token { get; set; } = null!;

        [Required]
        public string OrganizationName { get; set; } = null!;

        [Required]
        public string OrganizationRole { get; set; } = null!;

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Nickname { get; set; } = null!;
    }
}