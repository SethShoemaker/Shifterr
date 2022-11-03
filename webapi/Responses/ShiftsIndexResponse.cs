using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Responses
{
    public class ShiftsIndexResponse
    {
        public ICollection<Shift> Shifts { get; set; } = null!;
    }
}