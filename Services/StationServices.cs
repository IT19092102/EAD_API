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


    //Inserting  station to the Database
    public async Task createStation(StationModel users)
    {

        await _stationcollection.InsertOneAsync(users);
        return;
    }
    //Retreiving all  station data from  the Database
    public async Task<List<StationModel>> getStation()
    {
        return await _stationcollection.Find(new BsonDocument()).ToListAsync();
    }


    //Deleteing  station from  the Database
    public async Task deleteStation(string id)
    {
        Console.WriteLine("Current services........ : ");
        FilterDefinition<StationModel> filter = Builders<StationModel>.Filter.Eq("Id", id);
        await _stationcollection.DeleteOneAsync(filter);
        return;
    }

    //Updating  station to the Database
    public async Task updateStation(string id, string stationName, string location, string brand)
    {
        Console.WriteLine("inside  services location ------------ :" + location);
        FilterDefinition<StationModel> filter = Builders<StationModel>.Filter.Eq("Id", id);

        UpdateDefinition<StationModel> stationNameUpdate = Builders<StationModel>.Update.Set("stationName", stationName);
        UpdateDefinition<StationModel> locationUpdate = Builders<StationModel>.Update.Set("location", location);
        UpdateDefinition<StationModel> brandUpdate = Builders<StationModel>.Update.Set("brand", brand);


        await 
        _stationcollection.UpdateOneAsync(filter, stationNameUpdate);
        _stationcollection.UpdateOneAsync(filter, locationUpdate);
        _stationcollection.UpdateOneAsync(filter, brandUpdate);
        return;
    }










}
