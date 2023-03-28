using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp.Services.Interfaces
{
    public interface IAccountService
    {
        public void Registration(RegistrationModel registration);
        public LoginResponseModel Login(LoginModel login);
    }
}
