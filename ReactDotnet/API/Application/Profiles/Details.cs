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
            private readonly IProfileReader _profileReader;

            public Hadler(IProfileReader profileReader)
            {
                _profileReader = profileReader;
            }
            public async Task<Profile> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _profileReader.ReadProfie(request.Username);
            }
        }
    }
}