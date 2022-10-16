using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;

namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class PlaylistController: Controller{
  
    private readonly MongoDBService _mongoDBService;

    public PlaylistController(MongoDBService mongoDBService){
        _mongoDBService = mongoDBService;
    }



    [HttpGet]
    public async Task<List<Playlist>> Get(){
    return await _mongoDBService.GetAllPlayList();
    }

    [HttpPost]
    public async Task<IActionResult> Post ([FromBody] Playlist playlist){
  
    await _mongoDBService.CreatePlayList(playlist);
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
    public async Task<IActionResult> Delete (string id){
      await _mongoDBService.DeleteAsync(id);
     return NoContent();
    }



}