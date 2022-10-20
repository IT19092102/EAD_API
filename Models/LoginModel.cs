using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace fuel_API.Models;

public class LoginModel
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
 
    public string email { get; set; } = null!;
    public string password { get; set; } = null!;
  
    

 

}