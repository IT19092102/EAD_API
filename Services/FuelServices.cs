using fuel_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace fuel_API.Services;

public class FuelServices
{
    private readonly IMongoCollection<FuelModel> _Fuelcollection;


    public FuelServices(IOptions<FuelAPISettings> FuelAPISettings)
    {

        MongoClient client = new MongoClient(FuelAPISettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(FuelAPISettings.Value.DatabaseName);
        _Fuelcollection = database.GetCollection<FuelModel>("Fuel_test");

    }

    //Inserting  fuel to the Database
    public async Task CreateFuel(FuelModel fuelModel)
    {
        await _Fuelcollection.InsertOneAsync(fuelModel);
        return;
    }

    //Retreiving all  fuel data from  the Database
    public async Task<List<FuelModel>> GetAllFuel()
    {
        return await _Fuelcollection.Find(new BsonDocument()).ToListAsync();
    }

    //Deleteing  fuel from  the Database
    public async Task DeleteFuel(string id)
    {
        Console.WriteLine("Current services........ : ");
        FilterDefinition<FuelModel> filter = Builders<FuelModel>.Filter.Eq("Id", id);
        await _Fuelcollection.DeleteOneAsync(filter);
        return;
    }

    //Updating  fuel to the Database
    public async Task UpdateFuel(string stationName, FuelModel fuelModel)
    {
        FilterDefinition<FuelModel> filter = Builders<FuelModel>.Filter.Eq("stationName", fuelModel.stationName);

        if (fuelModel.petrol == "No" || fuelModel.petrol == "Yes")
        {
            Console.WriteLine("petrol..................................... : "+fuelModel.petrol);
              Console.WriteLine("petrolTime..................................... : "+fuelModel.petrolTime);
                Console.WriteLine("stationName..................................... : "+fuelModel.stationName);
            UpdateDefinition<FuelModel> updatepetrol = Builders<FuelModel>.Update.Set("petrol", fuelModel.petrol);
            UpdateDefinition<FuelModel> updatePetrolTime = Builders<FuelModel>.Update.Set("petrolTime", fuelModel.petrolTime);
            await _Fuelcollection.UpdateOneAsync(filter, updatepetrol);
            _Fuelcollection.UpdateOneAsync(filter, updatePetrolTime);

               return;

        }
        if (fuelModel.superPetrol == "No" || fuelModel.superPetrol == "Yes")
        {
            Console.WriteLine("superPetrol..................................... : "+fuelModel.superPetrolTime);
            UpdateDefinition<FuelModel> updateSuperPetrol = Builders<FuelModel>.Update.Set("superPetrol", fuelModel.superPetrol);
            UpdateDefinition<FuelModel> updateSuperPetrolTime = Builders<FuelModel>.Update.Set("superPetrolTime", fuelModel.superPetrolTime);
            await _Fuelcollection.UpdateOneAsync(filter, updateSuperPetrol);
            _Fuelcollection.UpdateOneAsync(filter, updateSuperPetrolTime);

               return;

           
        }
        if (fuelModel.diesel == "No" || fuelModel.diesel == "Yes")
        {
            Console.WriteLine("diesel..................................... : "+fuelModel.dieselTime);
            UpdateDefinition<FuelModel> updatediesel = Builders<FuelModel>.Update.Set("diesel", fuelModel.diesel);
            UpdateDefinition<FuelModel> updateDieselTime = Builders<FuelModel>.Update.Set("dieselTime", fuelModel.dieselTime);
            await _Fuelcollection.UpdateOneAsync(filter, updatediesel);
            _Fuelcollection.UpdateOneAsync(filter, updateDieselTime);

               return;

            


        }
        if (fuelModel.superDiesel == "No" || fuelModel.superDiesel == "Yes")
        {
            Console.WriteLine("superDiesel..................................... : "+fuelModel.superDieselTime);

            UpdateDefinition<FuelModel> updateSuperdiesel = Builders<FuelModel>.Update.Set("diesel", fuelModel.superDiesel);
            UpdateDefinition<FuelModel> updateSuperDieselTime = Builders<FuelModel>.Update.Set("dieselTime", fuelModel.superDieselTime);
            await _Fuelcollection.UpdateOneAsync(filter, updateSuperdiesel);
            _Fuelcollection.UpdateOneAsync(filter, updateSuperDieselTime);

             return;

        }




       
    }












}
