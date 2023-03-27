
using Microsoft.AspNetCore.Mvc;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public LoginController(ILoginService loginService, ITokenService tokenService, IConfiguration config)
        {
            _loginService = loginService;
            _tokenService = tokenService;
            _config = config;
        }
        [HttpPost]
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginModel user)
        {
            LoginResponseModel response = await _loginService.Login(user);
            if (response == null)
                return BadRequest();

            var jwt = _tokenService.BuildToken(_config["JWT:Key"].ToString(), _config["JWT:Issuer"], response);

            response.JWTBearer = jwt;

            return Ok(response);
        }

    }
}
