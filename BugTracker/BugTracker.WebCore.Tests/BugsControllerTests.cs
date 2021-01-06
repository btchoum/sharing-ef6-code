using BugTracker.WebCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BugTracker.WebCore.Tests
{
    public class BugsControllerTests
    {
        [Fact]
        public void GetBugs()
        {
            var controller = new BugsController();

            var result = controller.GetBugs() as OkResult;
            
            Assert.NotNull(result);
        }
    }
}
