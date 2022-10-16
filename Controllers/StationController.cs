using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;

namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class StationController: Controller{
  
    private readonly MongoDBService _mongoDBService;

    public StationController(MongoDBService mongoDBService){
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


// //users........ start



//     [HttpGet]
//     // public async Task<List<Users>> Get1(){
//     // return await _mongoDBService.GetAllUsers();
//     // }

//         [HttpPost]
//     public async Task<IActionResult> Post ([FromBody] Users users){
//     Console.WriteLine("This is C#...........inside controller.........");
//     await _mongoDBService.CreateUser(users);
//     return CreatedAtAction(nameof(Get), new{id = users.Id}, users);
//     }

// //users........ end


    [HttpPut("{id}")]
    public async Task<IActionResult> Playlist (string id, [FromBody] string movieId){
     await _mongoDBService.AddToPlaylistAsync(id,movieId);
     return NoContent();
    }

     [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser (string id){
     Console.WriteLine("inside delllllllllll ------------ :"+id);
      await _mongoDBService.DeleteUser(id);
     return NoContent();
    }



}