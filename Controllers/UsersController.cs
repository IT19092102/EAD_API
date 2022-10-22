using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;

namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserController: Controller{
  
    private readonly UserServices _userService;

    public UserController(UserServices mongoDBService){
        _userService = mongoDBService;
    }
    



    [HttpGet]
    public async Task<List<Users>> Get(){
          Console.WriteLine("inside gettttttttttttttt ------------");
    return await _userService.GetAllUsers();
    }

    [HttpPost]
    public async Task<IActionResult> Post ([FromBody] Users playlist){
  
    await _userService.CreateUser(playlist);
    return CreatedAtAction(nameof(Get), new{id = playlist.Id}, playlist);
    }


//     [HttpPost]
//     public async Task<IActionResult> Login ([FromBody] string email){
  
//    await _userService.DeleteUser(email);
//     return NoContent();
//     }





   [HttpPost("{email}")]
    public async Task<String> Post (string email, string password){
  
   return await _userService.FindUser(email,password);

   
    // return CreatedAtAction(nameof(Get), new{id = playlist.Id}, playlist);
    }



 [HttpPut("{id}")]
    public async Task<IActionResult> updateQueue(string id, [FromBody] Users playlistr)
    {
        await _userService.UpdateUser(id, playlistr.email, playlistr.phoneNumber);
        return NoContent();
    }






     [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser (string id){
     Console.WriteLine("inside delllllllllll ------------ :"+id);
      await _userService.DeleteUser(id);
     return NoContent();
    }



}