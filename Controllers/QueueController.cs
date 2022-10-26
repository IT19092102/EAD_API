using System;
using Microsoft.AspNetCore.Mvc;
using fuel_API.Services;
using fuel_API.Models;

namespace fuel_API.Controllers;

[Controller]
[Route("api/[controller]")]
public class QueueController : Controller
{

    private readonly QueueService _mongoDBService;
    public QueueController(QueueService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }


    //Retreiving all  queue data from  the Database
    [HttpGet]
    public async Task<List<QueueModel>> Get()
    {
        return await _mongoDBService.getQueue();
    }

    //Inserting  queue to the Database
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] QueueModel queue)
    {
        await _mongoDBService.createQueue(queue);
        return CreatedAtAction(nameof(Get), new { id = queue.Id }, queue);
    }

    //Updating  queue to the Database
    [HttpPut("{id}")]
    public async Task<IActionResult> updateQueue(string id, [FromBody] QueueModel queue)
    {

        await _mongoDBService.updateQueue(id, queue.departureTime, queue.reason);
        return NoContent();
    }

    //Deleteing  queue from  the Database
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteQueue(string id)
    {

        await _mongoDBService.deleteQueue(id);
        return NoContent();
    }


}