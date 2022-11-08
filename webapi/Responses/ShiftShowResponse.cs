namespace webapi.Responses
{
    public class ShiftShowCoworkerDto
    {
        public int ShiftId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;
    }

    public class ShiftShowResponse
    {
        public string Worker { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public List<ShiftShowCoworkerDto> CoWorkers { get; set; } = null!;
    }
}