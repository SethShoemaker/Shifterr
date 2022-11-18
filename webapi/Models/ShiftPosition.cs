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
        [Column(TypeName="varchar(20)")]
        public string Name { get; set; } = null!;

        [Column(TypeName="varchar(275)")]
        public string? Description { get; set; }
    }
}