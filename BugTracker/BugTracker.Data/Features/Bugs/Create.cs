using System;

namespace BugTracker.Data.Features.Bugs
{
    public class CreateBugModel
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string UserEmail { get; set; }

        public Bug MapToBug()
        {
            return new Bug
            {
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Title = Title,
                Details = Details,
                UserEmail = UserEmail
            };
        }
    }
    
    
}
