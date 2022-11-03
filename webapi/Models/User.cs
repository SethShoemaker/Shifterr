using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public enum OrganizationRole
    {
        Crew, Manager, Administrator
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
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public byte[] PasswordHash { get; set; } = null!;

        [Required]
        public byte[] PasswordSalt { get; set; } = null!;
        
        [Required]
        [Column(TypeName="ENUM('Crew','Manager','Administrator')")]
        public OrganizationRole OrganizationRole { get; set; }

        [Column(TypeName="varchar(255)")]
        public string? Bio { get; set;}

        public ICollection<Shift> Shifts { get; set;} = null!;
    }
}