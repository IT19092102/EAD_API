using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoExample.Services;

public class UserService
{
    private readonly IMongoCollection<Users> _usercollection;

    //mogo
    public UserService(IOptions<MongoDBSettings> mongoDBSettings)
    {

        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _usercollection = database.GetCollection<Users>("Users_teting");

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
