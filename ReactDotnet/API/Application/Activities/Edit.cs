using System;
using System.Threading;
using System.Threading.Tasks;
using API.Persistence;
using MediatR;

namespace API.Application.Activities
{
    public class Edit
    {
        public class Command : IRequest  // not returnning any thing from command
        {
            public Guid Id {get;set;}
            public string Title{get;set;}
            public string  Description {get;set;}
            public string Category {get;set;}
            public DateTime? Date {get;set;} // date not allow null previously
            public string City {get;set;}
            public string Venue {get;set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var getActivity =await _context.Activities.FindAsync(request.Id);

                if(getActivity == null)
                    throw new Exception("not find any activity");
               /* if(getActivity == null)
                   throw new RestException(HttpStatusCode.NotFound, new {getActivity = "not found"});*/
                   

                getActivity.Title = request.Title ?? getActivity.Title; // change value ?? previous value 
                getActivity.Description = request.Description ?? getActivity.Description;
                getActivity.Date = request.Date ?? getActivity.Date;
                getActivity.Category = request.Category ?? getActivity.Category;
                getActivity.City = request.City ?? getActivity.City;
                getActivity.Venue = request.Venue ?? getActivity.Venue;
                

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception("problem when save");
            }

            
        }
    }
}

