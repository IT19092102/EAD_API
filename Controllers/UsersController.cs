using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;


namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserController : Controller
{

    private readonly UserServices _userService;

    public UserController(UserServices mongoDBService)
    {
        _userService = mongoDBService;
    }



    //Retreiving all  users data from  the Database
    [HttpGet]
    public async Task<List<Users>> Get()
    {

        return await _userService.GetAllUsers();
    }

    //Inserting  users to the Database
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Users playlist)
    {

        await _userService.CreateUser(playlist);
        return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
    }


    //Updating  users to the Database
    [HttpPut("{id}")]
    public async Task<IActionResult> updateQueue(string id, [FromBody] Users playlistr)
    {
        await _userService.UpdateUser(id, playlistr.email, playlistr.phoneNumber);
        return NoContent();
    }

    //Deleteing  users from  the Database
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {

        await _userService.DeleteUser(id);
        return NoContent();
    }



}