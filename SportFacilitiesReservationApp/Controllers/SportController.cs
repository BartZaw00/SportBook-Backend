using Microsoft.AspNetCore.Mvc;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportController : ControllerBase
    {
        private readonly ISportService _sportService;

        public SportController(ISportService sportService)
        {
            _sportService = sportService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SportModel>>> GetSports()
        {
            return Ok(await _sportService.getSports());
        }
    }
}
