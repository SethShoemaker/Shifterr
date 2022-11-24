using System.ComponentModel.DataAnnotations;

namespace webapi.Responses
{
    public class UserInfoResponse
    {
        [Required]
        public string userName { get; set; } = null!;

        [Required]
        public string email { get; set; } = null!;

        public string organizationRole { get; set; } = null!;
    }
}