using fuel_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace fuel_API.Services;

public class UserService
{
    private readonly IMongoCollection<Users> _usercollection;

    //mogo
    public UserService(IOptions<FuelAPISettings> FuelAPISettings)
    {

        MongoClient client = new MongoClient(FuelAPISettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(FuelAPISettings.Value.DatabaseName);
        _usercollection = database.GetCollection<Users>("Users_teting11");

    }


    //users........ start
    public async Task CreateTestingUser(Users users)
    {
        await _usercollection.InsertOneAsync(users);
        return;
    }
    public async Task<List<Users>> GetAllTestingUsers()
    {
        return await _usercollection.Find(new BsonDocument()).ToListAsync();
    }

    //users........ end

   

}
