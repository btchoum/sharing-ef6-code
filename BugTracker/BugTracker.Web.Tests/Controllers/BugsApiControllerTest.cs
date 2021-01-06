using System;
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
            
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=BugsDbContextTests";
            
            var context = new BugsDbContext(connectionString);
            context.Database.CreateIfNotExists();
            
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.Bugs");
            context.Bugs.Add(new Bug
            {
                Title = "some title 1",
                Details = "some details 1",
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                UserEmail = "test@test.com"
            });
            context.Bugs.Add(new Bug
            {
                Title = "some title 2",
                Details = "some details 2",
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                UserEmail = "test@test.com"
            });

            context.SaveChanges();

            var controller = new BugsApiController(new BugsDbContext(connectionString));
            
            var result = controller.GetBugs() as OkNegotiatedContentResult<List<Bug>>;
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(2, result.Content.Count);
        }
    }
}
