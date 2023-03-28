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
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => p.PhotoUrl).ToList()));
            CreateMap<Photo, PhotoModel>();
            CreateMap<Type, TypeModel>();
            CreateMap<SportFacilityDetailsModel, SportFacility>().ReverseMap();
        }
    }
}
