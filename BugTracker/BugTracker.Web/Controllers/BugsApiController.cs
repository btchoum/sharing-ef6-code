using System.Linq;
using System.Web.Http;
using BugTracker.Data;
using BugTracker.Data.Features.Bugs;

namespace BugTracker.Web.Controllers
{
    [RoutePrefix("api/bugs")]
    public class BugsApiController : ApiController
    {
        private readonly BugsDbContext _context;

        public BugsApiController(BugsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBugs()
        {
            var bugs = _context.Bugs.ToList();
            return Ok(bugs);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(CreateBugModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var bug = model.MapToBug();

            _context.Bugs.Add(bug);

            _context.SaveChanges();
            
            return Ok();
        }
    }
}
