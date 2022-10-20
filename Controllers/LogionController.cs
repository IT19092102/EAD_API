using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;

namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class LoginController : Controller
{

    private readonly MongoDBService _mongoDBService;

    public LoginController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }


    [HttpGet]
    public async Task<List<StationModel>> Get()
    {

        return await _mongoDBService.getStation();
    }

    // [HttpPost]
    // public async Task<IActionResult> Post( [FromBody] string movieId , int name , [FromBody] string id)
    // {
    //    await _mongoDBService.updateStation(id, movieId);
    //     return NoContent();
    // }

    // [HttpPut]
    // public async Task<IActionResult> updateStation( [FromBody] string movieId , int  zxd , [FromBody] string id)
    // {
    //     await _mongoDBService.updateStation(id, movieId);
    //     return NoContent();
    // }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteStation(string id)
    {
        Console.WriteLine("inside delllllllllll ------------ :" + id);
        await _mongoDBService.deleteStation(id);
        return NoContent();
    }


}