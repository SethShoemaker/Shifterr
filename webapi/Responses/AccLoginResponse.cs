using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Responses
{
    public class AccLoginResponse
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Expiration { get; set; }
    }
}