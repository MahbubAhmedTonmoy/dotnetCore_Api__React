using System;
using System.Linq;
using System.Threading.Tasks;
using API.Application.Interfaces;
using API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Profiles
{
    public class ProfileReader : IProfileReader
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public ProfileReader(DataContext context, IUserAccessor userAccessor )
        {
            _context = context;
            _userAccessor = userAccessor;
        }
        public async Task<Profile> ReadProfiel(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName  == username);
            if(user == null)
                throw new Exception("not found this user");

            var currentUser = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUserName());

            var profile = new Profile{
                DisplayName = user.DisplayName,
                Username = user.UserName,
                Bio = user.Bio,
                FollowersCount = user.Followers.Count(),
                FollowingCount = user.Followings.Count(),
                Image = user.Photos.FirstOrDefault(x => x.IsMain).Url
            };


            if(currentUser.Followings.Any(x => x.TergetId == user.Id)){
                profile.IsFollowed = true;
            }
            return profile;
        }
    }
}