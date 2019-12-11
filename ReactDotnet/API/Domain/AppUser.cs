using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName {get; set;}
        public string  Bio { get; set; }
        public virtual ICollection<UserActivity> UserActivities {get;set;} // use Virtual for Lazy Loading

        public virtual ICollection<Photo> Photos{get;set;}
    }
}