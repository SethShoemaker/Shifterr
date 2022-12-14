using System.ComponentModel.DataAnnotations;

namespace webapi.Responses
{

    public class UserIndexUserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nickname { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;
    }

    public class UserIndexResponse
    {
        public List<UserIndexUserDto> Workers { get; set; } = null!;
    }
}