using System.Linq;
using System.Security.Claims;
using API.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace API.Infrastructure
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUserName()
        {
            var userName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(
                x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }
    }
}