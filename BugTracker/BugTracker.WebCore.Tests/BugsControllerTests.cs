using System;
using System.Collections.Generic;
using BugTracker.Data;
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
            
            var controller = new BugsController(context);

            var result = controller.GetBugs() as OkObjectResult;
            Assert.NotNull(result);
            var bugs = result.Value as List<Bug>;
            Assert.NotNull(bugs);
            Assert.Equal(2, bugs.Count);
        }
    }
}
