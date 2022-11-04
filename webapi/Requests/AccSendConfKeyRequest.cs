using System.ComponentModel.DataAnnotations;

namespace webapi.Requests
{
    public class AccSendConfKeyRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string? NewEmail { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}