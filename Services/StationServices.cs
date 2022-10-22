using fuel_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace fuel_API.Services;

public class StationServices
{
    private readonly IMongoCollection<StationModel> _stationcollection;

    //mogo
    public StationServices(IOptions<FuelAPISettings> FuelAPISettings)
    {

        MongoClient client = new MongoClient(FuelAPISettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(FuelAPISettings.Value.DatabaseName);
        _stationcollection = database.GetCollection<StationModel>("Station");

    }


    //--------------------------------------STATION SERVICES START-----------------------------------------------
    public async Task createStation(StationModel users)
    {

        await _stationcollection.InsertOneAsync(users);
        return;
    }
    public async Task<List<StationModel>> getStation()
    {
        return await _stationcollection.Find(new BsonDocument()).ToListAsync();
    }

  

    public async Task deleteStation(string id)
    {
        Console.WriteLine("Current services........ : ");
        FilterDefinition<StationModel> filter = Builders<StationModel>.Filter.Eq("Id", id);
        await _stationcollection.DeleteOneAsync(filter);
        return;
    }

    public async Task updateStation(string id, string location)
    {Console.WriteLine("inside  services location ------------ :" + location);
        FilterDefinition<StationModel> filter = Builders<StationModel>.Filter.Eq("Id", id);
        UpdateDefinition<StationModel> update = Builders<StationModel>.Update.SetOnInsert<string>("email", location);
        await _stationcollection.UpdateOneAsync(filter, update);
        return;
    }

    //--------------------------------------STATION SERVICES END-----------------------------------------------






   

}
