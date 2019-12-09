using Microsoft.AspNetCore.Identity;

namespace API.Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName {get; set;}
    }
}