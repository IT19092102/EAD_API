using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;

namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserController: Controller{
  
    private readonly MongoDBService _mongoDBService;

    public UserController(MongoDBService mongoDBService){
        _mongoDBService = mongoDBService;
    }
    



    [HttpGet]
    public async Task<List<Users>> Get(){
          Console.WriteLine("inside gettttttttttttttt ------------");
    return await _mongoDBService.GetAllUsers();
    }

    [HttpPost]
    public async Task<IActionResult> Post ([FromBody] Users playlist){
  
    await _mongoDBService.CreateUser(playlist);
    return CreatedAtAction(nameof(Get), new{id = playlist.Id}, playlist);
    }



   [HttpPost("{email,password}")]
    public async Task<String> Post (string email, string password){
  
   return await _mongoDBService.FindUser(email,password);

   
    // return CreatedAtAction(nameof(Get), new{id = playlist.Id}, playlist);
    }








     [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser (string id){
     Console.WriteLine("inside delllllllllll ------------ :"+id);
      await _mongoDBService.DeleteUser(id);
     return NoContent();
    }



}