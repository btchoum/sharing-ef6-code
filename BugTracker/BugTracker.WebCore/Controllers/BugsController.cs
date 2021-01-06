using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BugsController : ControllerBase
    {
        public BugsController()
        {
        }

        [HttpGet]
        public IActionResult GetBugs()
        {
            return Ok();
        }
    }
}
