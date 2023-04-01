using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<SportFacilityBoxModel>>> GetSportFacilities()
        {
            return Ok(await _homeService.getSportFacilities());
        }

        [HttpGet("getBySport")]
        public async Task<ActionResult<List<SportFacilityBoxModel>>> GetSportFacilitiesBySport(int sportID)
        {
            return Ok(await _homeService.getSportFacilitiesBySport(sportID));
        }
    }
}
