namespace SportFacilitiesReservationApp.Models
{
    public class LoginResponseModel
    {
        public int UserId { get; set; }
        public string PhotoUrl { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
    }
}
