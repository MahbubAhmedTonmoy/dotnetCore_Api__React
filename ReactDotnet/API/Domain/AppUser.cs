using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName {get; set;}
        public ICollection<UserActivity> UserActivities {get;set;}
    }
}