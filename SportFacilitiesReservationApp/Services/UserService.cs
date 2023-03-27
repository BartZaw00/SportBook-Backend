using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Services
{
    public class UserService : IUserService
    {
        //private readonly SportFacilitiesDbContext _dbContext;
        //private readonly IMapper _mapper;

        //public UserService(SportFacilitiesDbContext dbContext, IMapper mapper)
        //{
        //    _dbContext = dbContext;
        //    _mapper = mapper;
        //}

        //public async Task<List<UserDetailsModel>> getUsers()
        //{
        //    var users = await _dbContext.Users.ToListAsync();
        //    return _mapper.Map<List<UserDetailsModel>>(users);
        //}

        //public async Task<List<UserDetailsModel>> addUser(UserDetailsModel obj)
        //{
        //    _dbContext.Users.Add(_mapper.Map<User>(obj));
        //    await _dbContext.SaveChangesAsync();
        //    var users = await _dbContext.Users.ToListAsync();
        //    return _mapper.Map<List<UserDetailsModel>>(users);
        //}

        //public async Task<int?> updateUser(UserDetailsModel obj)
        //{
        //    var users = await _dbContext.Users.FindAsync(obj.Iduser);

        //    if (users == null)
        //        return null;

        //    users.Username = obj.Nick;
        //    users.Name = obj.Name;
        //    users.Surname = obj.Surname;
        //    users.Email = obj.Email;
        //    //users.Password = obj.UserPassword;

        //    return await _dbContext.SaveChangesAsync();
        //}

        //public async Task<int?> deleteUser(int id)
        //{
        //    var users = await _dbContext.Users.FindAsync(id);
        //    if (users == null)
        //        return null;
        //    _dbContext.Users.Remove(users);


        //    return await _dbContext.SaveChangesAsync();
        //}
    }
}