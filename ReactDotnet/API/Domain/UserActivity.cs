using System;

namespace API.Domain
{
    public class UserActivity
    {
        public string AppUserId {get;set;}

        public virtual AppUser AppUser {get;set;} // use Virtual for Lazy Loading

        public Guid ActivityId {get;set;}

        public virtual Activity Activity {get; set;} // use Virtual for Lazy Loading

        public DateTime DateJoined  {get;set;}
        public bool IsHost {get;set;}
    }
}