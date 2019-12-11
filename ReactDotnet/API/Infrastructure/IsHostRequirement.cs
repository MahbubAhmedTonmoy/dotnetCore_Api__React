using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Infrastructure
{
    public class IsHostRequirement : IAuthorizationRequirement
    {
        
    }

    public class IsHostRequirementHandler : AuthorizationHandler<IsHostRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;

        public IsHostRequirementHandler(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsHostRequirement requirement)
        {
            if(context.Resource is AuthorizationFilterContext authContext)
            {
                var currentUser = _httpContextAccessor.HttpContext.User?.Claims?
                                .SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                
                var activityId = authContext.RouteData.Values["id"].ToString();

                var activity = _context.Activities.FindAsync(activityId).Result;

                var IsHost = _context.UserActivities.FirstOrDefault(x => x.IsHost);

                if(IsHost?.AppUser?.UserName == currentUser)
                {
                    context.Succeed(requirement);
                }
            }else{
                    context.Fail();
                }
            return Task.CompletedTask;
        }
    }
}