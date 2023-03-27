namespace SportFacilitiesReservationApp.Models
{
    public class ReservationDetailsModel
    {
        public int Idreservation { get; set; }
        public string? ReservationStartTime { get; set; }
        public string? ReservationEndTime { get; set; }
        public int ReservationSportFacility { get; set; }
        public int ReservationUser { get; set; }
    }
}
