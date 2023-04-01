using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportFacilitiesReservationApp.Entities;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services;
using SportFacilitiesReservationApp.Services.Interfaces;
using System.Data;
using System.Security.Claims;

namespace ReservationAppApi.Controllers
{
    [ApiController]
    [Route("Reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ReservationDetailsModel>>> GetAll()
        {
            return Ok(await _reservationService.getReservations());
        }

        //    ////[HttpGet("reservationsWithDetails")]
        //    ////public async Task<ActionResult<List<ReservationDetailsModel>>> GetReservationsWithDetails()
        //    ////{
        //    ////   // return Ok(await _reservationService.getReservationsWithDetails());
        //    ////}

        //    //[HttpPost]
        //    //public async Task<ActionResult<List<ReservationDetailsModel>>> Post(ReservationDetailsModel obj)
        //    //{
        //    //    string? userIDFromToken = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    //    //Console.Write("przed: " + userIDFromToken);

        //    //    Int32.TryParse(userIDFromToken, out int idUser);
        //    //    //Console.Write("po: " + idUser);

        //    //    return Ok(_reservationService.addReservation(obj, idUser));
        //    //}

        //    //[HttpPut]
        //    //public async Task<ActionResult<List<ReservationDetailsModel>>> Put(ReservationDetailsModel obj)
        //    //{
        //    //    var check = await _reservationService.updateReservation(obj);
        //    //    if (check == null)
        //    //        return BadRequest("Reservation Not Found");

        //    //    return Ok(check);
        //    //}

        //    //[HttpDelete("{id}")]
        //    //public async Task<ActionResult<List<ReservationDetailsModel>>> Delete(int id)
        //    //{
        //    //    var check = await _reservationService.deleteReservation(id);
        //    //    if (check == null)
        //    //        return BadRequest("Reservation Not Found");

        //    //    return Ok(check);
        //    //}
        //}
    }
}
