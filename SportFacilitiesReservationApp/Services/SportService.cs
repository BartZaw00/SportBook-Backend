using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Services
{
    public class SportService : ISportService
    {
        private readonly SportFacilitiesDbContext _dbContext;
        private readonly IMapper _mapper;

        public SportService(SportFacilitiesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<SportModel>> getSports()
        {
            var sports = await _dbContext.Sports.ToListAsync();
            return _mapper.Map<List<SportModel>>(sports);
        }
    }
}
