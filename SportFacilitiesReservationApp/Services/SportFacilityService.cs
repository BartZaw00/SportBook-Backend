using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Services
{
    public class SportFacilityService : ISportFacilityService
    {
        private readonly SportFacilitiesDbContext _dbContext;
        private readonly IMapper _mapper;

        public SportFacilityService(SportFacilitiesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SportFacilityDetailsModel> getSportFacilityById(int sportFacilityID)
        {
            var sportFacilities = await _dbContext.SportFacilities
                .Include(sf => sf.Photos)
                .Include(sf => sf.Sport)
                .Include(sf => sf.Type)
                .FirstOrDefaultAsync(sf => sf.SportFacilityId == sportFacilityID);
            return _mapper.Map<SportFacilityDetailsModel>(sportFacilities);
        }
    }
}
