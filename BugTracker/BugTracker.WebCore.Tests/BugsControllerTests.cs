using System.Collections.Generic;
using BugTracker.Data;
using BugTracker.Data.Features.Bugs;
using BugTracker.WebCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BugTracker.WebCore.Tests
{
    public class BugsControllerTests
    {
        private readonly string _connectionString
            = "Server=(localdb)\\mssqllocaldb;Database=BugsDbContextTestsCore";
        
        [Fact]
        public void Tickets_Can_Be_Created_And_Read_Back()
        {
            InitializeDatabase();

            var inputController = MakeController();
            var firstBug = new CreateBugModel
            {
                Title = "some title 1",
                Details = "some details 1",
                UserEmail = "test@test.com"
            };

            var createResult = inputController.Create(firstBug) as OkResult;
            Assert.NotNull(createResult);
            var bugs = GetAllBugs();
                
            Assert.Single(bugs);
        }


        private BugsController MakeController()
        {
            return new BugsController(new BugsDbContext(_connectionString));
        }

        private List<Bug> GetAllBugs()
        {
            var readController = MakeController();
            var result = readController.GetBugs() as OkObjectResult;

            Assert.NotNull(result);
            var bugs = result.Value as List<Bug>;
            Assert.NotNull(bugs);

            return bugs;
        }

        private void InitializeDatabase()
        {
            var context = new BugsDbContext(_connectionString);
            context.Database.CreateIfNotExists();
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.Bugs");
        }
    }
}
