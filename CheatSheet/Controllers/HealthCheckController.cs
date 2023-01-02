using Microsoft.AspNetCore.Mvc;

namespace CheatSheet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public ObjectResult GetAsync()
        {
            return Ok("Server is up and running.");
        }
    }
}