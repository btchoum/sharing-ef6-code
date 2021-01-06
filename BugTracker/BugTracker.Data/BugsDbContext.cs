using System.Data.Entity;

namespace BugTracker.Data
{
    public class BugsDbContext : DbContext
    {
        public BugsDbContext(string connectionString) 
            : base(connectionString)
        {
            Database.SetInitializer(new NullDatabaseInitializer<BugsDbContext>());
        }
        
        public DbSet<Bug> Bugs { get; set; }
    }
}
