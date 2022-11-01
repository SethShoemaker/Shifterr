using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class ShiftPosition
    {
        public int Id { get; set; }
        public Organization Organization { get; set; } = null!;
        [Column(TypeName="char(10)")]
        public string Name { get; set; } = null!;
        [Column(TypeName="varchar(275)")]
        public string? Description { get; set; }
    }
}