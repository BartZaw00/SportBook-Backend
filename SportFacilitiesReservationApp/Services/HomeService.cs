using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Services
{
    public class HomeService : IHomeService
    {
        private readonly SportFacilitiesDbContext _dbContext;
        private readonly IMapper _mapper;

        public HomeService(SportFacilitiesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<SportFacilityBoxModel>> getSportFacilities()
        {
            var sportFacilities = await _dbContext.SportFacilities
                .Include(sf => sf.Photos)
                .Include(sf => sf.Sport)
                .Include(sf => sf.Type)
                .ToListAsync();
            return _mapper.Map<List<SportFacilityBoxModel>>(sportFacilities);
        }

        public async Task<List<SportFacilityBoxModel>> getSportFacilitiesBySport(int sportID)
        {
            var sportFacilities = await _dbContext.SportFacilities
                .Include(sf => sf.Photos)
                .Include(sf => sf.Sport)
                .Include(sf => sf.Type)
                .Where(sf => sf.SportId == sportID)
                .ToListAsync();

            return _mapper.Map<List<SportFacilityBoxModel>>(sportFacilities);
        }
    }
}
