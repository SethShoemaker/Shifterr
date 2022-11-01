using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public Worker Worker { get; set; } = null!;
        public int? ShiftPositionId { get; set; }
        public ShiftPosition? ShiftPosition { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }
    }
}