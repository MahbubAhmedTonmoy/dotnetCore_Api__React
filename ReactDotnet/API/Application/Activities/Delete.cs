using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using API.Application.Error;
using API.Persistence;
using MediatR;

namespace API.Application.Activities
{
    public class Delete
    {
        public class Command: IRequest
        {
            public Guid Id{get;set;}
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

                /*if(getActivity == null)
                    throw new RestException(HttpStatusCode.NotFound, new {getActivity = "not found"});
                 */   
                _context.Remove(getActivity);

                var success =await _context.SaveChangesAsync() > 0;
                if(success) return Unit.Value;

                throw new Exception("bad request");

            }
        }
    }

    
}