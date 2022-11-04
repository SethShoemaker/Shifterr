using System.ComponentModel.DataAnnotations;

namespace webapi.Requests
{
    public class ShiftPositionCreateRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}