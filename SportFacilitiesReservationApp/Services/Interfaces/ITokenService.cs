using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp.Services.Interfaces
{
    public interface ITokenService
    {
        public string BuildToken(string key, string issuer, LoginResponseModel user);
        public bool IsTokenValid(string key, string issuer, string token);
    }
}
