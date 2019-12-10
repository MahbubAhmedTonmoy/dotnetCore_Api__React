using System;
using System.Threading;
using System.Threading.Tasks;
using API.Domain;
using API.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Activities
{
    public class details
    {
        public class Query : IRequest<ActivityDTO>
        {
            public Guid Id {get;set;}
        }

         public class Handler : IRequestHandler<Query, ActivityDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<ActivityDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                /* //Eager loading
                var activity = await _context.Activities
                                        .Include(x => x.UserActivities)
                                        .ThenInclude(x => x.AppUser)
                                        .SingleOrDefaultAsync(x => x.Id == request.Id);
                                        */
                //Lazy Loading
                var activity = await _context.Activities
                                        .FindAsync(request.Id);
                 if(activity == null)
                    throw new Exception("not find any activity");
                /*
                if(activity == null)
                    throw new RestException(HttpStatusCode.NotFound, new {activity = "not found"});*/
                  
                return _mapper.Map<Activity,ActivityDTO>(activity);
            }
        }
    }

   
}