using fuel_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace fuel_API.Services;

public class UserServices
{
    private readonly IMongoCollection<Users> _usercollection;


    public UserServices(IOptions<FuelAPISettings> FuelAPISettings)
    {
        MongoClient client = new MongoClient(FuelAPISettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(FuelAPISettings.Value.DatabaseName);
        _usercollection = database.GetCollection<Users>("Users");

    }


    //Inserting  users to the Database
    public async Task CreateUser(Users users)
    {
        await _usercollection.InsertOneAsync(users);
        return;
    }
    //Retreiving all  users data from  the Database
    public async Task<List<Users>> GetAllUsers()
    {
        return await _usercollection.Find(new BsonDocument()).ToListAsync();
    }

 public async Task<String> FindUser(string email)
    {
        Users user = _usercollection.Find(m => m.email.Equals(email)).FirstOrDefault();
        if (user == null)
        {
            Console.WriteLine("user nulll 2222222222");
            return "user doesnt exist 22222";
        }
        else
        {
if( user.userRole=="user"){
    return "user";
}

          
              return "admin";
            // return user.userRole;

        }
    }
    
    

    //Deleteing  users from  the Database
    public async Task DeleteUser(string id)
    {
        FilterDefinition<Users> filter = Builders<Users>.Filter.Eq("Id", id);
        await _usercollection.DeleteOneAsync(filter);
        return;
    }

    //Updating  users to the Database
    public async Task UpdateUser(string id, string email, string phoneNumber,string drivingLicenceNo,string password)
    {
        FilterDefinition<Users> filter = Builders<Users>.Filter.Eq("Id", id);
        UpdateDefinition<Users> emailupdate = Builders<Users>.Update.Set("email", email);
        UpdateDefinition<Users> phoneNumberupdate = Builders<Users>.Update.Set("phoneNumber", phoneNumber);
                UpdateDefinition<Users> drivingLicenceNoupdate = Builders<Users>.Update.Set("drivingLicenceNo", drivingLicenceNo);
                  UpdateDefinition<Users> passwordupdate = Builders<Users>.Update.Set("password", password);

        await
         _usercollection.UpdateOneAsync(filter, emailupdate); 
        _usercollection.UpdateOneAsync(filter, phoneNumberupdate);
        _usercollection.UpdateOneAsync(filter, drivingLicenceNoupdate);
           _usercollection.UpdateOneAsync(filter, passwordupdate);
     
        return;
    }

}
