using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Profiles
{
    public class Details
    {
        public class Query : IRequest<Profile>
        {
            public string Username { get; set; }
        }

        public class Hadler : IRequestHandler<Query, Profile>
        {
            private readonly DataContext _context;

            public Hadler(DataContext context)
            {
                _context = context;
            }
            public async Task<Profile> Handle(Query request, CancellationToken cancellationToken)
            {
                var finduser = await _context.Users.SingleOrDefaultAsync(x => x.UserName == request.Username);

                return new Profile{
                    DisplayName = finduser.DisplayName,
                    Bio = finduser.Bio,
                    Image = finduser.Photos.FirstOrDefault( x => x.IsMain).Url,
                    Photos = finduser.Photos
                };
            }
        }
    }
}