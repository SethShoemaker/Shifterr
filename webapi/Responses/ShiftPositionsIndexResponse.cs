namespace webapi.Responses
{
    public class ShiftPositionIndexPositionDto{

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }

    public class ShiftPositionsIndexResponse
    {
        public List<ShiftPositionIndexPositionDto> Positions { get; set; } = null!;
    }
}