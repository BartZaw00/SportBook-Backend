namespace SportFacilitiesReservationApp.Models
{
    public class LoginResponseModel
    {
        public string Username { get; set; }
        public int RoleId { get; set; }
        public string token { get; set; }
    }
}
