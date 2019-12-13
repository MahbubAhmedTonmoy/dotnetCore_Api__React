using System.Threading.Tasks;

namespace API.Application.Profiles
{
    public interface IProfileReader
    {
         Task<Profile> ReadProfie(string username);
    }
}