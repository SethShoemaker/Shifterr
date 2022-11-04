using System.ComponentModel.DataAnnotations;

namespace webapi.Requests
{
    public class AccValidateConfKeyRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string ConfirmationKey { get; set; } = string.Empty;
    }
}