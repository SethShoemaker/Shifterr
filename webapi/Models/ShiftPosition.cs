using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class ShiftPosition
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public Organization Organization { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; } = null!;

        [MaxLength(275)]
        public string? Description { get; set; }
    }
}