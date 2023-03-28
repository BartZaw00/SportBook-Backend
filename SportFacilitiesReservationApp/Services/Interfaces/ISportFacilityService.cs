using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp.Services.Interfaces
{
    public interface ISportFacilityService
    {
        public Task<List<SportFacilityDetailsModel>> getSportFacilities();
    }
}
