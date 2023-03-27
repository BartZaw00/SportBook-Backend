using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly SportFacilitiesDbContext _dbContext;
        private readonly IMapper _mapper;

        public LoginService(SportFacilitiesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<LoginResponseModel> Login(LoginModel user)
        {
            var login = await _dbContext.Users.FirstOrDefaultAsync<User>(x => x.Email == user.UserEmail && x.Password == user.UserPassword);
            if (login == null)
                return null;
            var response = new LoginResponseModel();
            response.UserNick = login.Username;
            response.Role = login.RoleId;

            return response;
        }
    }
}
