using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class UserConfirmationGuid
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; } = null!;
        [Required]
        public Guid ConfirmationKey { get; set; }
    }
}