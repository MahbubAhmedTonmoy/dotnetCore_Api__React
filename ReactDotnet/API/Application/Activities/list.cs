using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Domain;
using API.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Activities
{
    public class list
    {
        public class Query : IRequest<List<ActivityDTO>> { }

        public class Handler : IRequestHandler<Query, List<ActivityDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ActivityDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                /* //Eager Loading
                var a = await _context.Activities
                                        .Include(x => x.UserActivities)
                                        .ThenInclude(x => x.AppUser)
                                        .ToListAsync();
                                        */
                // Lazy Loading
                var a = await _context.Activities.ToListAsync();
                
                return _mapper.Map<List<Activity>,List<ActivityDTO>>(a);
            }
        }

    }
}