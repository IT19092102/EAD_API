using fuel_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace fuel_API.Services;

public class MongoDBService
{

    private IMongoCollection<Users> _usercollection;
    private readonly IMongoCollection<StationModel> _stationcollection;
    private readonly IMongoCollection<QueueModel> _queueCollection;
    //mogo
    public MongoDBService(IOptions<FuelAPISettings> FuelAPISettings)
    {

        MongoClient client = new MongoClient(FuelAPISettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(FuelAPISettings.Value.DatabaseName);

        _usercollection = database.GetCollection<Users>("Users");
        _stationcollection = database.GetCollection<StationModel>("Station");
        _queueCollection = database.GetCollection<QueueModel>("Queue");

    }
















    //--------------------------------------USER SERVICES START-----------------------------------------------
    public async Task CreateUser(Users users)
    {

        await _usercollection.InsertOneAsync(users);
        return;
    }
    public async Task<List<Users>> GetAllUsers()
    {
        return await _usercollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task DeleteUser(string id)
    {
        Console.WriteLine("Current services........ : ");
        FilterDefinition<Users> filter = Builders<Users>.Filter.Eq("Id", id);
        await _usercollection.DeleteOneAsync(filter);
        return;
    }

    public async Task UpdateUser(string id, string email)
    {
        FilterDefinition<Users> filter = Builders<Users>.Filter.Eq("Id", id);
        UpdateDefinition<Users> update = Builders<Users>.Update.AddToSet<string>("email", email);
        await _usercollection.UpdateOneAsync(filter, update);
        return;
    }



    public async Task<String> FindUser(string email, string password)
    {
        // FilterDefinition<Users> filter = Builders<Users>.Filter.Eq("Id", id);
        // UpdateDefinition<Users> update = Builders<Users>.Update.AddToSet<string>("email", email);

        Users user = _usercollection.Find(m => m.email.Equals(email)).FirstOrDefault();

        if (user == null)
        {
            Console.WriteLine("user nulll ...............");
            return "user doesnt exist";
        }
        else
        {
            Console.WriteLine("incoming email gettttttttttttttt ------------" + email);
            Console.WriteLine("inside gettttttttttttttt ------------" + user.email);
            if (user.email == email)
            {
                Console.WriteLine("trueeeeeeeeee ------------");
                 return "user  trueeeeeeee";
            }
            else
            {
                Console.WriteLine("falseeeeeeeee ------------");
                return "user false";
            }

        }



    }

    //--------------------------------------USER SERVICES END-----------------------------------------------











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

    public async Task updateStation(string id, string email)
    {
        FilterDefinition<StationModel> filter = Builders<StationModel>.Filter.Eq("Id", id);
        UpdateDefinition<StationModel> update = Builders<StationModel>.Update.AddToSet<string>("email", email);
        await _stationcollection.UpdateOneAsync(filter, update);
        return;
    }

    //--------------------------------------STATION SERVICES END-----------------------------------------------





















    //--------------------------------------QUEUE SERVICES START-----------------------------------------------
    public async Task createQueue(QueueModel queue)
    {

        await _queueCollection.InsertOneAsync(queue);
        return;
    }
    public async Task<List<QueueModel>> getQueue()
    {
        return await _queueCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task deleteQueue(string id)
    {
        Console.WriteLine("Current services........ : ");
        FilterDefinition<QueueModel> filter = Builders<QueueModel>.Filter.Eq("Id", id);
        await _queueCollection.DeleteOneAsync(filter);
        return;
    }

    public async Task updateQueue(string id, string email)
    {
        FilterDefinition<QueueModel> filter = Builders<QueueModel>.Filter.Eq("Id", id);
        UpdateDefinition<QueueModel> update = Builders<QueueModel>.Update.AddToSet<string>("email", email);
        await _queueCollection.UpdateOneAsync(filter, update);
        return;
    }

    //--------------------------------------QUEUE SERVICES END-----------------------------------------------












}
