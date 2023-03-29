using SportFacilitiesReservationApp.Models;

namespace SportFacilitiesReservationApp.Services.Interfaces
{
    public interface ISportService
    {
        public Task<List<SportModel>> getSports();
    }
}
