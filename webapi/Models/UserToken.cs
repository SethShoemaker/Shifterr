using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class UserToken
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public Organization Organization { get; set; } = null!;

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; } = null!;

        [Required]
        public string Value { get; set; } = string.Empty;
    }
}