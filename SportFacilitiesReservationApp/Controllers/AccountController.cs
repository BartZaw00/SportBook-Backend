
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _config;

        public AccountController(IAccountService accountService, IConfiguration config)
        {
            _accountService = accountService;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegistrationModel registration)
        {
            _accountService.Registration(registration);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginModel user)
        {
            LoginResponseModel response = _accountService.Login(user);

            return Ok(response);
        }

        [HttpPut("update/{currentUserId}")]
        [Authorize]
        public async Task<ActionResult<UserDetailsModel>> UpdateUser(int currentUserId, [FromBody] UserDetailsModel user)
        {
            var updatedUser = await _accountService.updateUser(user, currentUserId);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
    }
}
