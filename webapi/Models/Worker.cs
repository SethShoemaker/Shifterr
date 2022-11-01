using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace webapi.Models
{
    public enum OrganizationRole
    {
        Crew, Manager, Administrator
    }

    public class Worker : IdentityUser
    {
        public int OrganizationId { get; set;}
        public Organization Organization { get; set;} = null!;
        [Column(TypeName="ENUM('Crew','Manager','Administrator')")]
        public OrganizationRole OrganizationRole { get; set; }    
        [Column(TypeName="char(50)")]
        public string Nickname { get; set;} = null!;
        [Column(TypeName="varchar(255)")]
        public string? Bio { get; set;}
        public ICollection<Shift> Shifts { get; set;} = null!;
    }
}