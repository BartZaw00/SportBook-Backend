namespace SportFacilitiesReservationApp.Models
{
    public class SportFacilityDetailsModel
    {
        public int IdsportFacility { get; set; }
        public string SportFacilityName { get; set; }
        public string SportFacilityDescription { get; set; }
        public string SportFacilityAddress { get; set; }
        public string SportFacilityCity { get; set; }
        public string SportFacilityCountry { get; set; }
        public TimeSpan SportFacilityOpenTime { get; set; }
        public TimeSpan SportFacilityCloseTime { get; set; }
        public List<string> PhotoUrls { get; set; } = new List<string>();
    }
}
