using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using API.Application.Error;
using API.Domain;
using API.Persistence;
using MediatR;

namespace API.Application.Activities
{
    public class details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id {get;set;}
        }

         public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);
                 if(activity == null)
                    throw new Exception("not find any activity");
                /*
                if(activity == null)
                    throw new RestException(HttpStatusCode.NotFound, new {activity = "not found"});*/
                  
                return activity;
            }
        }
    }

   
}