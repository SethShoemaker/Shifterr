using System.ComponentModel.DataAnnotations;

namespace webapi.Requests
{
    public class AccRegisterRequest
    {
        [Required]
        [MaxLength(40)]
        [MinLength(8)]
        public string UserName { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Nickname { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = null!;

        [Required]
        public string Role {get; set; } = null!;
    }
}