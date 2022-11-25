using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Shift
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public Organization Organization { get; set; } = null!;

        [Required]
        public User Worker { get; set; } = null!;

        public int? ShiftPositionId { get; set; }

        public ShiftPosition? ShiftPosition { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }
    }
}