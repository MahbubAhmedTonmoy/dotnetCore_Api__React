using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Domain;
using API.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Activities
{
    public class list
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var a = await _context.Activities.ToListAsync();
                return a;
            }
        }

    }
}