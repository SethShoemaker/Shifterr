namespace mauiclient.Services.Dashboard.Shifts.GetShifts
{
    public class GetShiftsResponse
    {
        public IReadOnlyList<ShiftDto> Shifts { get; set; }

        public GetShiftsError? Error { get; set; }
    }

    public class ShiftDto
    {
        public int Id { get; set; }

        public int PositionId { get; set; }

        public string Position { get; set; } = "";

        public int WorkerId { get; set; }

        public string Worker { get; set; } = "";

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }

    public enum GetShiftsError
    {
        Unauthorized,
        CouldNotConnectToServer
    }
}