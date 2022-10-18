using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;

namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class StationController : Controller
{

    private readonly MongoDBService _mongoDBService;

    public StationController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }


    [HttpGet]
    public async Task<List<StationModel>> Get()
    {

        return await _mongoDBService.getStation();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StationModel playlist)
    {
        await _mongoDBService.createStation(playlist);
        return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> updateStation(string id, [FromBody] string movieId)
    {
        await _mongoDBService.updateStation(id, movieId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteStation(string id)
    {
        Console.WriteLine("inside delllllllllll ------------ :" + id);
        await _mongoDBService.deleteStation(id);
        return NoContent();
    }


}