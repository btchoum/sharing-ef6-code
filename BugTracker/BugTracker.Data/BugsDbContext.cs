using System.Data.Entity;

namespace BugTracker.Data
{
    public class BugsDbContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
    }
}
