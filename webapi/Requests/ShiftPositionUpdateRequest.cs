using System.ComponentModel.DataAnnotations;

namespace webapi.Requests
{
    public class ShiftPositionUpdateRequest
    {
        public string? Name { get; set; } = null!;

        public string? Description { get; set; } = null!;
    }
}