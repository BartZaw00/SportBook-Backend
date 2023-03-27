﻿using AutoMapper;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SportFacility, SportFacilityDetailsModel>()
               .ForMember(dest => dest.PhotoUrls, opt => opt.MapFrom(src => src.Photos.Select(p => p.PhotoUrl).ToList()));
            CreateMap<SportFacilityDetailsModel, SportFacility>().ReverseMap();
        }
    }
}
