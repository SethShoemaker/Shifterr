using System.ComponentModel.DataAnnotations;

namespace webapi.Requests
{
    public class OrgRegisterRequest
    {
        [Required]
        public string OrgName { get; set; } = null!;
        
        [Required]
        [MaxLength(40)]
        [MinLength(8)]
        public string AdminName { get; set; } = null!;  

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string AdminNickname { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string AdminEmail { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string AdminPassword { get; set; } = null!;
    }
}