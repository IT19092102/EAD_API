using fuel_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace fuel_API.Services;

public class UserServices
{
    private readonly IMongoCollection<Users> _usercollection;

    //mogo
    public UserServices(IOptions<FuelAPISettings> FuelAPISettings)
    {

        MongoClient client = new MongoClient(FuelAPISettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(FuelAPISettings.Value.DatabaseName);
        _usercollection = database.GetCollection<Users>("Users");

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

    public async Task UpdateUser(string id, string email,long phoneNumber)
    {

        FilterDefinition<Users> filter = Builders<Users>.Filter.Eq("Id", id);
        UpdateDefinition<Users> update = Builders<Users>.Update.Set("email",email);
         UpdateDefinition<Users> update1 = Builders<Users>.Update.Set("phoneNumber",phoneNumber);
          

        await _usercollection.UpdateOneAsync(filter, update) ;_usercollection.UpdateOneAsync(filter, update1);
 
    //             await _usercollection.UpdateManyAsync(filter, update,update1);

    //  await _usercollection. (filter, update,update1);

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






   

}
