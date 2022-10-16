using fuel_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace fuel_API.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Playlist> _playlistcollection;
    private readonly IMongoCollection<Users> _usercollection;

    //mogo
    public MongoDBService(IOptions<FuelAPISettings> FuelAPISettings)
    {

        MongoClient client = new MongoClient(FuelAPISettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(FuelAPISettings.Value.DatabaseName);
        _playlistcollection = database.GetCollection<Playlist>("playlist");
        _usercollection = database.GetCollection<Users>("Users");

    }

    public async Task CreatePlayList(Playlist playlist)
    {

        await _playlistcollection.InsertOneAsync(playlist);
        return;
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

    //--------------------------------------USER SERVICES END-----------------------------------------------

    public async Task<List<Playlist>> GetAllPlayList()
    {
        return await _playlistcollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddToPlaylistAsync(string id, string items)
    {
        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
        UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("items", items);
        await _playlistcollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeletePlaylist(string id)
    {
        FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("Id", id);
        await _playlistcollection.DeleteOneAsync(filter);
        return;
    }

}
