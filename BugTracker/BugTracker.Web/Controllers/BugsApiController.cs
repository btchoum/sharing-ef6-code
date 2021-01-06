using System.Linq;
using System.Web.Http;
using BugTracker.Data;

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
    }
}
