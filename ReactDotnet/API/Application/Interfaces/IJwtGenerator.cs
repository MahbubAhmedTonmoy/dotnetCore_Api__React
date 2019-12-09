using API.Domain;

namespace API.Application.Interfaces
{
    public interface IJwtGenerator
    {
         string CreateToken(AppUser user); //this back a string token
    }
}