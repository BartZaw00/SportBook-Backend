using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportFacilitiesReservationApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly SportFacilitiesDbContext _dbContext;
        private readonly IMapper _mapper;
        private const double EXPIRY_DURATION_MINUTES = 30;

        public AccountService(SportFacilitiesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<LoginResponseModel> Login(LoginModel loginModel)
        {
            var login = await _dbContext.Users.FirstOrDefaultAsync<User>(user => user.Email == loginModel.Email && user.Password == loginModel.Password);
            if (login == null)
                return null;
            var response = new LoginResponseModel();
            response.Username = login.Username;
            response.RoleId = login.RoleId;

            return response;
        }

        public string BuildToken(string key, string issuer, LoginResponseModel login)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Username == login.Username);

            var claims = new[] {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.RoleId.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
    };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public bool IsTokenValid(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken); ;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
