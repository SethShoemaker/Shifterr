using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Organization
    {
        public int Id { get; set; }
        [Column(TypeName="char(20)")]
        public string Name { get; set; } = string.Empty;
    }
}