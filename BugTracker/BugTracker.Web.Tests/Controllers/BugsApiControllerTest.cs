using System.Collections.Generic;
using System.Web.Http.Results;
using BugTracker.Data;
using BugTracker.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTracker.Web.Tests.Controllers
{
    [TestClass]
    public class BugsApiControllerTest
    {
        [TestMethod]
        public void GetTickets()
        {
            var controller = new BugsApiController(new BugsDbContext());
            
            var result = controller.GetBugs() as OkNegotiatedContentResult<List<Bug>>;
            
            Assert.IsNotNull(result);
        }
    }
}