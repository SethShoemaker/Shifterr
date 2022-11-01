using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.ResourceModels;

namespace webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("shifts")]
    public class ShiftsController : ControllerBase
    {
        public ApplicationContext _context { get; }

        public ShiftsController(ApplicationContext Context)
        {
            _context = Context;
        }

        [HttpGet]
        [Route("index")]
        public ActionResult<ShiftsIndexResponse> Index()
        {
            ShiftsIndexResponse responce = _context.Shifts.
            return new ShiftsIndexResponse();
        }
    }
}