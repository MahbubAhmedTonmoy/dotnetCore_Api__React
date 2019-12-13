using System;
using System.Threading;
using System.Threading.Tasks;
using API.Application.Interfaces;
using API.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Followers
{
    public class Delete
    {
         public class Command : IRequest
        {
            public string UserName { get; set; }
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
                // find currrent login user which will follow other
                var observer  = await _context.Users.SingleOrDefaultAsync(x=>x.UserName == _userAccessor.GetCurrentUserName());

                //find other they call tergate
                var tergate = await _context.Users.SingleOrDefaultAsync(x => x.UserName == request.UserName);
                if(tergate == null)
                    throw new Exception("your tergeted people can not find");
                
                //check already follow?
                var following = await _context.Followings.SingleOrDefaultAsync
                                        (x => x.ObserverId == observer.Id && x.TergetId == tergate.Id);

                if(following == null)
                    throw new Exception("you are not follow this terget pepple");
               if(following != null){
                   _context.Followings.Remove(following);
               }


                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}