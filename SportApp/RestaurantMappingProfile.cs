using AutoMapper;
using SportApp.Models;

namespace SportApp
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.County, c => c.MapFrom(s => s.Address.County))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street));
            CreateMap<Training, TrainingDto>();
                
        }
    }
}
