using fuel_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace fuel_API.Services;

public class FuelServices
{
    private readonly IMongoCollection<FuelModel> _Fuelcollection;

    //mogo
    public FuelServices(IOptions<FuelAPISettings> FuelAPISettings)
    {

        MongoClient client = new MongoClient(FuelAPISettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(FuelAPISettings.Value.DatabaseName);
        _Fuelcollection = database.GetCollection<FuelModel>("Fuel");

    }



    public async Task CreateFuel(FuelModel fuelModel)
    {

        await _Fuelcollection.InsertOneAsync(fuelModel);
        return;
    }
    public async Task<List<FuelModel>> GetAllFuel()
    {
        return await _Fuelcollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task DeleteFuel(string id)
    {
        Console.WriteLine("Current services........ : ");
        FilterDefinition<FuelModel> filter = Builders<FuelModel>.Filter.Eq("Id", id);
        await _Fuelcollection.DeleteOneAsync(filter);
        return;
    }

    public async Task UpdateFuel(string stationName, string petrol, string superPetrol, string diesel, string superDiesel)
    {

        FilterDefinition<FuelModel> filter = Builders<FuelModel>.Filter.Eq("stationName", stationName);
        UpdateDefinition<FuelModel> updatepetrol = Builders<FuelModel>.Update.Set("petrol",petrol);
         UpdateDefinition<FuelModel> updatesuperPetrol = Builders<FuelModel>.Update.Set("superPetrol",superPetrol);
          UpdateDefinition<FuelModel> updatediesel = Builders<FuelModel>.Update.Set("diesel",diesel);
           UpdateDefinition<FuelModel> updatesuperDiesel = Builders<FuelModel>.Update.Set("superDiesel",superDiesel);

          

        await _Fuelcollection.UpdateOneAsync(filter, updatepetrol) ;
            _Fuelcollection.UpdateOneAsync(filter, updatesuperPetrol) ;
            _Fuelcollection.UpdateOneAsync(filter, updatediesel) ;
            _Fuelcollection.UpdateOneAsync(filter, updatepetrol) ;
              _Fuelcollection.UpdateOneAsync(filter, updatesuperDiesel) ;
 
  

        return;
    }










   

}
