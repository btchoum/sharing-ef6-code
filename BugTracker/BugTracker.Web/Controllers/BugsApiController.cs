using System.Web.Http;

namespace BugTracker.Web.Controllers
{
    [RoutePrefix("api/bugs")]
    public class BugsApiController : ApiController
    {

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBugs()
        {
            return Ok();
        }
    }
}
