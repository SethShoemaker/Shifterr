using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HealthCheckController : ControllerBase
    {
        /* 
            This is a route that will be used for health checks
            all other routes in this api include user credentials
            this route ensures that health checks aren't done with user credentials.
        */
        [Route("/")]
        public ActionResult Check()
        {
            return Ok("Healthy");
        }
    }
}