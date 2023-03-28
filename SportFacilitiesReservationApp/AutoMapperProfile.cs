using AutoMapper;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using Type = SportFacilitiesReservationApp.Entities.Type;

namespace SportFacilitiesReservationApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SportFacility, SportFacilityDetailsModel>()
                .ForMember(dest => dest.Sport, opt => opt.MapFrom(src => src.Sport))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => p.PhotoUrl).ToList()));
            CreateMap<SportFacility, SportFacilityBoxModel>()
                .ForMember(dest => dest.Sport, opt => opt.MapFrom(src => src.Sport))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => p.PhotoUrl).ToList()));
            CreateMap<SportFacilityDetailsModel, SportFacility>().ReverseMap();
            CreateMap<SportFacilityBoxModel, SportFacility>().ReverseMap();

            CreateMap<User, LoginModel>();
            CreateMap<User, RegistrationModel>();
            CreateMap<User, LoginResponseModel>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId));

            CreateMap<Photo, PhotoModel>();
            CreateMap<Sport, SportModel>();
            CreateMap<Role, RoleModel>();
            CreateMap<Type, TypeModel>();
        }
    }
}
