using System;

namespace BugTracker.Data
{
    public class Bug
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string UserEmail { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
