using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;

namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class StationController : Controller
{

    private readonly StationServices _stationService;

    public StationController(StationServices mongoDBService)
    {
        _stationService = mongoDBService;
    }


    //Retreiving all  station data from  the Database
    [HttpGet]
    public async Task<List<StationModel>> Get()
    {

        return await _stationService.getStation();
    }

    //Inserting  station to the Database

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StationModel playlist)
    {
        await _stationService.createStation(playlist);
        return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
    }


    //Updating  station to the Database
    [HttpPut("{id}")]
    public async Task<IActionResult> updateStation(string id, [FromBody] string movieId)
    {
        await _stationService.updateStation(id, movieId);
        return NoContent();
    }

    //Deleteing  station from  the Database

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteStation(string id)
    {
        Console.WriteLine("inside delllllllllll ------------ :" + id);
        await _stationService.deleteStation(id);
        return NoContent();
    }


}