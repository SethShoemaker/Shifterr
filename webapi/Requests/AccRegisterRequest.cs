using System.ComponentModel.DataAnnotations;

namespace webapi.Requests
{
    public class AccRegisterRequest
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public string Role {get; set; } = null!;
    }
}