using SportFacilitiesReservationApp.Entities;
using Type = SportFacilitiesReservationApp.Entities.Type;

namespace SportFacilitiesReservationApp.Models
{
    public class SportFacilityBoxModel
    {
        public int SportFacilityId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public SportModel Sport { get; set; }
        public TypeModel Type { get; set; }
        public List<PhotoModel> Photos { get; set; } = new List<PhotoModel>();
    }
}
