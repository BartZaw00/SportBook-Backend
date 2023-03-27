using Microsoft.AspNetCore.Mvc;
using SportFacilitiesReservationApp.Models;
using SportFacilitiesReservationApp.Services;
using SportFacilitiesReservationApp.Services.Interfaces;

namespace SportFacilitiesReservationApp.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class UserController : ControllerBase
    //{
    //    private readonly IUserService _userService;

    //    public UserController(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    [HttpGet]
    //    public async Task<ActionResult<List<UserDetailsModel>>> GetAll()
    //    {
    //        return Ok(await _userService.getUsers());
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<List<UserDetailsModel>>> Post(UserDetailsModel obj)
    //    {
    //        //obj.Role = "Admin";
    //        return Ok(await _userService.addUser(obj));
    //    }

    //    [HttpPut]
    //    public async Task<ActionResult<List<UserDetailsModel>>> Put(UserDetailsModel obj)
    //    {
    //        var check = await _userService.updateUser(obj);
    //        if (check == null)
    //            return BadRequest("User Not Found");

    //        return Ok(check);
    //    }

    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<List<UserDetailsModel>>> Delete(int id)
    //    {
    //        var check = await _userService.deleteUser(id);
    //        if (check == null)
    //            return BadRequest("User Not Found");

    //        return Ok(check);
    //    }
    //}
}