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
                .ForMember(m => m.Country, c => c.MapFrom(s => s.Address.Country))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street));            
            CreateMap<CreateUserDto, User>()
                .ForMember(u => u.Address, c => c.MapFrom(dto => new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street, Country = dto.Country }));
            CreateMap<User, UpdateUserDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.Country, c => c.MapFrom(s => s.Address.Country))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street));
            CreateMap<TrainingDto, Training>();
            CreateMap<Training, TrainingDto>();
            CreateMap<ExerciseDto, Exercise>();
            CreateMap<Exercise, ExerciseDto>();
        }
    }
}
