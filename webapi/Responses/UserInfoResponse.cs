using System.ComponentModel.DataAnnotations;

namespace webapi.Responses
{
    public class UserInfoResponse
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Nickname { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}