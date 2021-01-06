using System.Linq;
using BugTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BugsController : ControllerBase
    {
        private readonly BugsDbContext _context;
        
        public BugsController(BugsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBugs()
        {
            return Ok(_context.Bugs.ToList());
        }
    }
}
