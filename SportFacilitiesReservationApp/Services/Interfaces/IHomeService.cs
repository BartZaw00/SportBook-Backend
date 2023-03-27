using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp.Services.Interfaces
{
    public interface IHomeService
    {
        public Task<List<SportFacilityDetailsModel>> getSportFacilities();
    }
}
