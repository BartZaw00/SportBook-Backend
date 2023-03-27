using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace ReservationAppApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class SportFacilityController : ControllerBase
    //{
    //    private readonly ISportFacilityService _sportFacilityService;

    //    public SportFacilityController(ISportFacilityService sportFacilityService)
    //    {
    //        _sportFacilityService = sportFacilityService;
    //    }

    //    [HttpGet]

    //    public async Task<ActionResult<List<SportFacilityDetailsModel>>> GetAll()
    //    {
    //        return Ok(await _sportFacilityService.getSportFacilities());
    //    }

    //    [HttpPost]
    //    [Authorize(Roles = "1,2")]
    //    public async Task<ActionResult<List<SportFacilityDetailsModel>>> Post(SportFacilityDetailsModel obj)
    //    {
    //        return Ok(await _sportFacilityService.addSportFacility(obj));
    //    }

    //    [HttpPut]
    //    [Authorize]
    //    public async Task<ActionResult<List<SportFacilityDetailsModel>>> Put(SportFacilityDetailsModel obj)
    //    {
    //        var check = await _sportFacilityService.updateSportFacility(obj);
    //        if (check == null)
    //            return BadRequest("Sport Facility Not Found");

    //        return Ok(check);
    //    }

    //    [HttpDelete("{id}")]
    //    [Authorize]
    //    public async Task<ActionResult<List<SportFacilityDetailsModel>>> Delete(int id)
    //    {
    //        var check = await _sportFacilityService.deleteSportFacility(id);
    //        if (check == null)
    //            return BadRequest("Sport Facility Not Found");

    //        return Ok(check);
    //    }
    //}
}