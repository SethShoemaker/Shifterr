using System.ComponentModel.DataAnnotations;

namespace webapi.Responses
{
    public class CalendarIndexShiftDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string StartDate { get; set; } = null!;

        [Required]
        public string StartTime { get; set; } = null!;

        [Required]
        public string EndTime { get; set; } = null!;

        public string? Position { get; set; }
    }

    public class CalendarIndexUserDto
    {
        [Required]
        public string Nickname { get; set; } = null!;

        [Required]
        public List<CalendarIndexShiftDto?> Shifts { get; set; } = null!;
    }

    public class CalendarIndexResponse
    {
        [Required]
        public List<CalendarIndexUserDto> Workers { get; set; } = null!;
    }
}