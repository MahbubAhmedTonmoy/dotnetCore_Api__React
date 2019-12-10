using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Application.Interfaces;
using API.Domain;
using API.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Activities
{
    public class Attend
    {
        public class Command : IRequest
        {
            public Guid Id {get; set;}
        }

        public class Handeler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handeler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
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

                if(attendence != null)
                    throw new Exception ("already this user attend this activity");
                
                attendence = new UserActivity{
                    Activity = activity,
                    AppUser = user,
                    DateJoined = DateTime.Now,
                    IsHost = false
                };
                _context.UserActivities.Add(attendence); //in memory

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;
                
                throw new System.NotImplementedException();
            }
        }
    }
}