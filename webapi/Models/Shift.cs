using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Shift
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Worker Worker { get; set; } = null!;
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