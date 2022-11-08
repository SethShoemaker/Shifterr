namespace webapi.Responses
{
    public class ShiftIndexShiftDto
    {
        public int Id { get; set; }

        public int PositionId { get; set; }

        public string Position { get; set; } = string.Empty;

        public int WorkerId { get; set; }

        public string Worker { get; set; } = string.Empty;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }

    public class ShiftsIndexResponse
    {
        public List<ShiftIndexShiftDto> Shifts { get; set; } = null!;
    }
}