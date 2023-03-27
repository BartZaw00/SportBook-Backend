using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Services
{
    public class SportFacilityService : ISportFacilityService
    {
        //private readonly SportFacilitiesDbContext _dbContext;
        //private readonly IMapper _mapper;

        //public SportFacilityService(SportFacilitiesDbContext dbContext, IMapper mapper)
        //{
        //    _dbContext = dbContext;
        //    _mapper = mapper;
        //}

        //public async Task<List<SportFacilityDetailsModel>> getSportFacilities()
        //{
        //    var sportFacilities = await _dbContext.SportFacilities.ToListAsync();
        //    return _mapper.Map<List<SportFacilityDetailsModel>>(sportFacilities);
        //}

        //public async Task<List<SportFacilityDetailsModel>> addSportFacility(SportFacilityDetailsModel obj)
        //{
        //    _dbContext.SportFacilities.Add(_mapper.Map<SportFacility>(obj));
        //    await _dbContext.SaveChangesAsync();
        //    var sportFacilities = await _dbContext.SportFacilities.ToListAsync();
        //    return _mapper.Map<List<SportFacilityDetailsModel>>(sportFacilities);
        //}

        //public async Task<int?> updateSportFacility(SportFacilityDetailsModel obj)
        //{
        //    var sportFacilities = await _dbContext.SportFacilities.FindAsync(obj.IdsportFacility);

        //    if (sportFacilities == null)
        //        return null;

        //    sportFacilities.Name = obj.SportFacilityName;
        //    sportFacilities.Address = obj.SportFacilityAddress;
        //    sportFacilities.City = obj.SportFacilityCity;
        //    sportFacilities.Country = obj.SportFacilityCountry;
        //    sportFacilities.OpenTime = obj.SportFacilityOpenTime;
        //    sportFacilities.CloseTime = obj.SportFacilityCloseTime;

        //    return await _dbContext.SaveChangesAsync();
        //}

        //public async Task<int?> deleteSportFacility(int id)
        //{
        //    var sportFacilities = await _dbContext.SportFacilities.FindAsync(id);
        //    if (sportFacilities == null)
        //        return null;
        //    _dbContext.SportFacilities.Remove(sportFacilities);

        //    return await _dbContext.SaveChangesAsync();
        //}
    }
}