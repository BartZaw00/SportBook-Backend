using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Models.Validators;
using SportFacilitiesReservationApp.Services.Interfaces;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static SportFacilitiesReservationApp.Models.Validators.UserDetailsModelValidator;

namespace SportFacilitiesReservationApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly SportFacilitiesDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IMapper _mapper;

        public AccountService(SportFacilitiesDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IMapper mapper)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _mapper = mapper;
        }

        public void Registration(RegistrationModel registration)
        {
            var validator = new RegistrationModelValidator(_dbContext);
            var validationResult = validator.Validate(registration);

            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join("; ", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException($"Błędy walidacji: {errorMessages}");
            }

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
            response.Email = login.Email;
            string username = _dbContext.Users.Where(u => u.Email == login.Email).Select(x => x.Username).FirstOrDefault();
            response.Username = username;
            string name = _dbContext.Users.Where(u => u.Email == login.Email).Select(x => x.Name).FirstOrDefault();
            response.Name = name;
            string surname = _dbContext.Users.Where(u => u.Email == login.Email).Select(x => x.Surname).FirstOrDefault();
            response.Surname = surname;
            int id = _dbContext.Users.Where(u => u.Email == login.Email).Select(x => x.RoleId).FirstOrDefault();
            response.RoleId = id;

            return response;
        }

        public async Task<UserDetailsModel> updateUser(UserDetailsModel obj, int currentUserId)
        {
            var currentUserData = new UserContext
            {
                CurrentUserId = currentUserId,
                CurrentUsername = obj.Username,
                CurrentEmail = obj.Email
            };

            var validator = new UserDetailsModelValidator(_dbContext, currentUserData);
            var validationResult = validator.Validate(obj);

            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join("; ", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException($"Błędy walidacji: {errorMessages}");
            }

            var currentUser = await _dbContext.Users.FindAsync(currentUserId);

            if (currentUser == null)
                return null;

            currentUser.PhotoUrl = obj.PhotoUrl;
            currentUser.Username = obj.Username;
            currentUser.Name = obj.Name;
            currentUser.Surname = obj.Surname;
            currentUser.Email = obj.Email;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<UserDetailsModel>(currentUser);
        }

        public async Task ChangePassword(ChangePasswordModel model, int currentUserId)
        {
            var currentUser = await _dbContext.Users.FindAsync(currentUserId);

            if (currentUser == null)
                return;

            var validator = new ChangePasswordModelValidator();
            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
                throw new Exception(string.Join("; ", validationResult.Errors));

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(currentUser, currentUser.Password, model.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                throw new Exception("Nowe hasło musi się różnić od poprzedniego hasła.");
            }

            currentUser.Password = _passwordHasher.HashPassword(currentUser, model.Password);

            await _dbContext.SaveChangesAsync();
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
