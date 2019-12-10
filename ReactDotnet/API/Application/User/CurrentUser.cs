using System.Threading;
using System.Threading.Tasks;
using API.Application.Interfaces;
using API.Domain;
using API.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace API.Application.User
{
    public class CurrentUser
    {
        public class Query : IRequest<User>
        {
            
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IUserAccessor _userAccessor;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(UserManager<AppUser> userManager, IUserAccessor userAccessor, IJwtGenerator jwtGenerator)
            {
                _userManager  = userManager;
                _userAccessor = userAccessor;
                _jwtGenerator = jwtGenerator;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUserName());

                return new User{
                    DisplayName = user.DisplayName,
                    UserName = user.UserName,
                    Image = null,
                    Token = _jwtGenerator.CreateToken(user)
                };
            }
        }
    }
}