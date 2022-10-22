using fuel_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace fuel_API.Services;

public class QueueService
{

    private IMongoCollection<Users> _usercollection;
    private readonly IMongoCollection<StationModel> _stationcollection;
    private readonly IMongoCollection<QueueModel> _queueCollection;
    //mogo
    public QueueService(IOptions<FuelAPISettings> FuelAPISettings)
    {

        MongoClient client = new MongoClient(FuelAPISettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(FuelAPISettings.Value.DatabaseName);

        _usercollection = database.GetCollection<Users>("Users");
        _stationcollection = database.GetCollection<StationModel>("Station");
        _queueCollection = database.GetCollection<QueueModel>("Queue");

    }





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
