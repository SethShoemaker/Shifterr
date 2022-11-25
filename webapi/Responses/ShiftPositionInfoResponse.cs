using System.ComponentModel.DataAnnotations;

namespace webapi.Responses
{
    public class ShiftPositionInfoResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}