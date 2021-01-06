using System.Web.Http.Results;
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
            var controller = new BugsApiController();
            
            var result = controller.GetBugs() as OkResult;
            
            Assert.IsNotNull(result);
        }
    }
}