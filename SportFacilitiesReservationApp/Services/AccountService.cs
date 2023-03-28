using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportFacilitiesReservationApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly SportFacilitiesDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(SportFacilitiesDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public void Registration(RegistrationModel registration)
        {
            User user = new User();

            user.Username = registration.Username;
            user.Email = registration.Email;
            user.Password = _passwordHasher.HashPassword(user, registration.Password);
            user.RoleId = 3;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public LoginResponseModel Login(LoginModel login)
        {
            //var login = await _dbContext.Users.FirstOrDefaultAsync<User>(user => user.Email == loginModel.Email && user.Password == loginModel.Password);
            //if (login == null)
            //    return null;
            var response = new LoginResponseModel();
            response.Token = BuildToken(login);
            string username = _dbContext.Users.Where(u => u.Email == login.Email).Select(x => x.Username).FirstOrDefault();
            response.Username = username;
            response.Email = login.Email;
            int id = _dbContext.Users.Where(u => u.Email == login.Email).Select(x => x.RoleId).FirstOrDefault();
            response.RoleId = id;

            return response;
        }

        public string BuildToken(LoginModel login)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == login.Email);

            if (user == null)
            {
                throw new BadHttpRequestException("Invalid email or password - user null");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, login.Password);
            Debug.WriteLine($"result: {result}");
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadHttpRequestException("Invalid email or password - password");
            }

            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, 
                _authenticationSettings.JwtIssuer, 
                claims,
                expires: expires, 
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        //public bool IsTokenValid(string key, string issuer, string token)
        //{
        //    var mySecret = Encoding.UTF8.GetBytes(key);
        //    var mySecurityKey = new SymmetricSecurityKey(mySecret);
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    try
        //    {
        //        tokenHandler.ValidateToken(token,
        //        new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            ValidIssuer = issuer,
        //            ValidAudience = issuer,
        //            IssuerSigningKey = mySecurityKey,
        //        }, out SecurityToken validatedToken); ;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
