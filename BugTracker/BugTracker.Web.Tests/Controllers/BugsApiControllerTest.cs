using System.Collections.Generic;
using System.Web.Http.Results;
using BugTracker.Data;
using BugTracker.Data.Features.Bugs;
using BugTracker.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTracker.Web.Tests.Controllers
{
    [TestClass]
    public class BugsApiControllerTest
    {
        private readonly string _connectionString 
            = "Server=(localdb)\\mssqllocaldb;Database=BugsDbContextTests";

        [TestInitialize]
        public void SetUp()
        {
            InitializeDatabase();
        }

        [TestMethod]
        public void Tickets_Can_Be_Created_And_Read_Back()
        {
            // Create a ticket
            var inputController = MakeController();
            var firstBug = new CreateBugModel
            {
                Title = "some title 1",
                Details = "some details 1",
                UserEmail = "test@test.com"
            };

            var createResult = inputController.Create(firstBug) as OkResult;
            Assert.IsNotNull(createResult);
            
            var bugs = GetAllBugs();

            // Ensure things were saved correctly
            Assert.IsNotNull(bugs);
            Assert.AreEqual(1, bugs.Count);
        }

        private BugsApiController MakeController()
        {
            return new BugsApiController(new BugsDbContext(_connectionString));
        }

        private List<Bug> GetAllBugs()
        {
            var readController = MakeController();
            var result = readController.GetBugs() as OkNegotiatedContentResult<List<Bug>>;
            Assert.IsNotNull(result);
            return result.Content;
        }

        private void InitializeDatabase()
        {
            var context = new BugsDbContext(_connectionString);
            context.Database.CreateIfNotExists();
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.Bugs");
        }
    }
}
