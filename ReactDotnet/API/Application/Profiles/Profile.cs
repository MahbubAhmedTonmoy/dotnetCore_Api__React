using System.Collections.Generic;
using API.Domain;
using Newtonsoft.Json;

namespace API.Application.Profiles
{
    public class Profile
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public ICollection<Photo> Photos {get; set;}

        [JsonProperty("Following")]
        public bool IsFollowed {get;set;}

        public int FollowersCount {get;set;}

        public int FollowingCount {get;set;}

    }
}