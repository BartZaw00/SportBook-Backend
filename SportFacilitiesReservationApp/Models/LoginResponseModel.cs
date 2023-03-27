namespace SportFacilitiesReservationApp.Models
{
    public class LoginResponseModel
    {
        public string? UserNick { get; set; }
        public int? Role { get; set; }
        public string JWTBearer { get; set; }
    }
}
