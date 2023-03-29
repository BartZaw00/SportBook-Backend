using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp.Services.Interfaces
{
    public interface IHomeService
    {
        public Task<List<SportFacilityBoxModel>> getSportFacilities();
        public Task<List<SportFacilityBoxModel>> getSportFacilitiesBySport(int sportID);
    }
}
