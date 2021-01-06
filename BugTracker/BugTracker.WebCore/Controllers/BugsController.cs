using System.Linq;
using BugTracker.Data;
using BugTracker.Data.Features.Bugs;
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

        [HttpPost]
        public IActionResult Create(CreateBugModel model)
        {
            var bug = model.MapToBug();

            _context.Bugs.Add(bug);

            _context.SaveChanges();
            
            return Ok();
        }
    }
}
