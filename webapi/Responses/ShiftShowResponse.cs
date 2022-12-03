using System.ComponentModel.DataAnnotations;

namespace webapi.Responses
{
    public class ShiftShowCoworkerDto
    {
        [Required]
        public int ShiftId { get; set; }

        [Required]
        public string Nickname { get; set; } = null!;
    }

    public class ShiftShowResponse
    {
        [Required]
        public string Worker { get; set; } = null!;

        public string? Position { get; set; }

        [Required]
        public string StartDate { get; set; } = null!;

        [Required]
        public string StartTime { get; set; } = null!;

        [Required]
        public string EndTime { get; set; } = null!;

        [Required]
        public int Hours { get; set; }

        [Required]
        public List<ShiftShowCoworkerDto> CoWorkers { get; set; } = null!;
    }
}