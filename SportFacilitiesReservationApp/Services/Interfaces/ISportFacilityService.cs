using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp.Services.Interfaces
{
    public interface ISportFacilityService
    {
        public Task<SportFacilityDetailsModel> getSportFacilityById(int sportFacilityID);
    }
}
