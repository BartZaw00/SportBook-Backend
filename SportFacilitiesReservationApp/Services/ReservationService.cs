using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SportFacilitiesReservationApp.Services
{
    public class ReservationService : IReservationService
    {

        //private readonly SportFacilitiesDbContext _dbContext;
        //private readonly IMapper _mapper;

        //public ReservationService(SportFacilitiesDbContext dbContext, IMapper mapper)
        //{
        //    _dbContext = dbContext;
        //    _mapper = mapper;
        //}

        //public async Task<List<ReservationDetailsModel>> getReservations()
        //{
        //    var reservations = await _dbContext.Reservations.ToListAsync();
        //    return _mapper.Map<List<ReservationDetailsModel>>(reservations);
        //}

        //public async Task<List<ReservationDetailsModel>> addReservation(ReservationDetailsModel obj, int idUser)
        //{
        //    obj.ReservationUser = idUser;
        //    _dbContext.Reservations.Add(_mapper.Map<Reservation>(obj));
        //    await _dbContext.SaveChangesAsync();
        //    var reservations = await _dbContext.Reservations.ToListAsync();
        //    return _mapper.Map<List<ReservationDetailsModel>>(reservations);
        //}
        //public async Task<int?> updateReservation(ReservationDetailsModel obj)
        //{
        //    var reservations = await _dbContext.Reservations.FindAsync(obj.Idreservation);

        //    if (reservations == null)
        //        return null;

        //    reservations.StartTime = Convert.ToDateTime(obj.ReservationStartTime);
        //    reservations.EndTime = Convert.ToDateTime(obj.ReservationEndTime);

        //    return await _dbContext.SaveChangesAsync();
        //}

        //public async Task<int?> deleteReservation(int id)
        //{
        //    var reservations = await _dbContext.Reservations.FindAsync(id);
        //    if (reservations == null)
        //        return null;
        //    _dbContext.Reservations.Remove(reservations);

        //    return await _dbContext.SaveChangesAsync();
        //}

        //private void DeleteExpiredReservations()
        //{
        //    var expiredReservations = _dbContext.Reservations.Where(r => r.EndTime < DateTime.Today).ToArray();

        //    _dbContext.RemoveRange(expiredReservations);
        //    _dbContext.SaveChanges();
        //}

    }
}
