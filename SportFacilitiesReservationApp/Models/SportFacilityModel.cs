namespace SportFacilitiesReservationApp.Models
{
    public class SportFacilityModel
    {
        public int SportFacilityId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Type Type { get; set; }
        public List<PhotoModel> Photos { get; set; } = new List<PhotoModel>();
    }
}
