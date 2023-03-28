using Microsoft.AspNetCore.Mvc;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportFacilityController : ControllerBase
    {
        private readonly ISportFacilityService _sportFacilityService; 

        public SportFacilityController(ISportFacilityService sportFacilityService)
        {
            _sportFacilityService = sportFacilityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SportFacilityDetailsModel>>> GetSportFacilities()
        {
            return Ok(await _sportFacilityService.getSportFacilities());
        }
    }
}
