using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace fuel_API.Models;

public class Users
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
 
    public string email { get; set; } = null!;
    public string password { get; set; } = null!;
    public long phoneNumber { get; set; } = 0!;
    

 

}