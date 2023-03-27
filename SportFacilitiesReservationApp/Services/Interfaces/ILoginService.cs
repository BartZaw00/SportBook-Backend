using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<LoginResponseModel> Login(LoginModel user);
    }
}
