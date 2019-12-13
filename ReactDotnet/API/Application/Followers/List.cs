using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Application.Profiles;
using API.Domain;
using API.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Followers
{
    public class List
    {
        public class Query : IRequest<List<Profile>>
        {
            public string  UserName { get; set; }

            public string Predicate { get; set; }
        }


        public class Handler : IRequestHandler<Query, List<Profile>>
        {
            private readonly DataContext _context;
            private readonly IProfileReader _profileReader;

            public Handler(DataContext context, IProfileReader profileReader)
            {
                _context = context;
                _profileReader = profileReader;
            }
            public async Task<List<Profile>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Followings.AsQueryable();

                var userFollowings = new List<UserFollowing>();

                var Profiles = new List<Profile>();

                switch(request.Predicate)
                {
                    case "followers": // amake j j follow kore
                        userFollowings = await queryable.Where(x => x.tergate.UserName == request.UserName).ToListAsync();
                        
                        foreach(var follower in userFollowings)
                        {
                            Profiles.Add(await _profileReader.ReadProfiel(follower.Observer.UserName));
                        }
                        
                        break;
                    case "following": // ami jare follow kori
                        userFollowings = await queryable.Where(x => x.Observer.UserName == request.UserName).ToListAsync();
                        
                        foreach(var follower in userFollowings)
                        {
                            Profiles.Add(await _profileReader.ReadProfiel(follower.tergate.UserName));
                        }
                        break;
                }
                return Profiles;
            }
        }
    }
}