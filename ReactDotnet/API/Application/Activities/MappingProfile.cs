using API.Domain;
using System.Linq;
using AutoMapper;
namespace API.Application.Activities
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){

            CreateMap<Activity, ActivityDTO>(); //<from object, to object>
        
            CreateMap<UserActivity, AttendeeDTO>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName)); // destination , option, source
        }
    }
}