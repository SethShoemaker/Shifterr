using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public enum OrganizationRole
    {
        Undefined, Crew, Manager, Administrator
    }

    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int OrganizationId { get; set;}

        [Required]
        public Organization Organization { get; set;} = null!;

        [Required]
        [MaxLength(40)]
        [MinLength(8)]
        public string UserName { get; set; } = null!;

        [Required] 
        [MaxLength(20)]
        [MinLength(4)]
        public string Nickname { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        public bool EmailIsConfirmed { get; set; } = false;

        [Required]
        public byte[] PasswordHash { get; set; } = null!;

        [Required]
        public byte[] PasswordSalt { get; set; } = null!;
        
        [Required]
        [Column(TypeName="ENUM('Crew','Manager','Administrator')")]
        public OrganizationRole OrganizationRole { get; set; }

        public ICollection<Shift> Shifts { get; set;} = null!;
    }
}