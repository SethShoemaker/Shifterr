using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.ResourceModels
{
    public class OrgRegisterModel
    {
        [Required]
        public string OrgName { get; set; } = string.Empty;
        [Required]
        public string ExecName { get; set; } = string.Empty;        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ExecEmail { get; set; } = string.Empty;
        [Required]
        public string ExecPassword { get; set; } = string.Empty;
    }
}