using System.ComponentModel.DataAnnotations;

namespace webapi.Responses
{
    public class ShiftCreateShiftPositionDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string name { get; set; } = null!;
    }

    public class ShiftCreateWorkerDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string nickname { get; set; } = null!;

        [Required]
        public string userName { get; set; } = null!;
    }

    public class ShiftCreateInfoResponse
    {
        public List<ShiftCreateShiftPositionDto>? Positions { get; set; }

        [Required]
        public List<ShiftCreateWorkerDto> Workers { get; set; } = null!;
    }
}