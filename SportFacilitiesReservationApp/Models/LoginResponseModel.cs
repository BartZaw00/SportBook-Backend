namespace SportFacilitiesReservationApp.Models
{
    public class LoginResponseModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
    }
}
