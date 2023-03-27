using Microsoft.AspNetCore.Mvc;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services;
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

        [HttpGet]
        public async Task<ActionResult<List<SportFacilityDetailsModel>>> GetSportFacilities()
        {
            return Ok(await _homeService.getSportFacilities());
        }
    }
}
