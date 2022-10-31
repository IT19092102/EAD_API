using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;

namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class FuelController : Controller
{

    private readonly FuelServices _fuelService;

    public FuelController(FuelServices mongoDBService)
    {
        _fuelService = mongoDBService;
    }

    //Retreiving all  fuel data from  the Database
    [HttpGet]
    public async Task<List<FuelModel>> Get()
    {

        return await _fuelService.GetAllFuel();
    }


    //Inserting  fuel to the Database
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FuelModel playlist)
    {
        await _fuelService.CreateFuel(playlist);
        return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
    }

    //Updating  fuel to the Database
    [HttpPut("{stationName}")]
    public async Task<IActionResult> updatefuel(string stationName, [FromBody] FuelModel fuel)
    {
        await _fuelService.UpdateFuel(stationName, fuel);
        return NoContent();
    }

    //Deleteing  fuel from  the Database
    [HttpDelete("{id}")]
    public async Task<IActionResult> deletefuel(string id)
    {
        await _fuelService.DeleteFuel(id);
        return NoContent();
    }


}