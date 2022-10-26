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


    [HttpGet]
    public async Task<List<FuelModel>> Get()
    {

        return await _fuelService.GetAllFuel();
    }







    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FuelModel playlist)
    {
        await _fuelService.CreateFuel(playlist);
        return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
    }

    [HttpPut("{stationName}")]
    public async Task<IActionResult> updatefuel(string stationName, [FromBody] FuelModel fuel)
    {
        await _fuelService.UpdateFuel(stationName, fuel.petrol,fuel.superPetrol,fuel.diesel,fuel.superDiesel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deletefuel(string id)
    {
        Console.WriteLine("inside delllllllllll ------------ :" + id);
        await _fuelService.DeleteFuel(id);
        return NoContent();
    }


}