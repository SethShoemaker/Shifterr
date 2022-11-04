using System.ComponentModel.DataAnnotations;

namespace webapi.Requests
{
    public class ShiftCreateRequest
    {
        [Required]
        public int WorkerId { get; set; }

        public int? ShiftPositionId { get; set; }

        [Required]
        public string Start { get; set; } = string.Empty;

        [Required]
        public string End { get; set; } = string.Empty;
    }
}