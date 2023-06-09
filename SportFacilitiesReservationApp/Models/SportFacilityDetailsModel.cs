﻿using SportFacilitiesReservationApp.Entities;
using Type = SportFacilitiesReservationApp.Entities.Type;

namespace SportFacilitiesReservationApp.Models
{
    public class SportFacilityDetailsModel
    {
        public int SportFacilityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public SportModel Sport { get; set; }
        public TypeModel Type { get; set; }
        public List<PhotoModel> Photos { get; set; } = new List<PhotoModel>();
    }
}
