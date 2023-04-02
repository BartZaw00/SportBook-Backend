using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp.Services.Interfaces
{
    public interface IAccountService
    {
        public void Registration(RegistrationModel registration);
        public LoginResponseModel Login(LoginModel login);
        public Task<UserDetailsModel> updateUser(UserDetailsModel obj, int currentUserId);
        public string BuildToken(LoginModel login);
        //public bool IsTokenValid(string key, string issuer, string token);
    }
}
