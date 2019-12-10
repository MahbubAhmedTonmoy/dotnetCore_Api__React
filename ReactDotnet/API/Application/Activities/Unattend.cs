using System;
using System.Threading;
using System.Threading.Tasks;
using API.Application.Interfaces;
using API.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Activities
{
    public class Unattend
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);

                if(activity == null)
                    throw new Exception("not activity found");
                var user = await _context.Users.SingleOrDefaultAsync(x
                                     => x.UserName == _userAccessor.GetCurrentUserName());
                
                //find alreay attend ?

                var attendence = await _context.UserActivities.SingleOrDefaultAsync(
                    x=> x.ActivityId == activity.Id && x.AppUserId == user.Id);

                if(attendence == null)
                    return Unit.Value; // exit this handler
                if(attendence.IsHost)
                    throw new Exception ("you are the host so can not delelte");
                _context.UserActivities.Remove(attendence);

                var success = await _context.SaveChangesAsync() > 0;
                if(success) return Unit.Value;

                throw new System.NotImplementedException();
            }
        }
    }
}