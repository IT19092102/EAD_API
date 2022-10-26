using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace fuel_API.Models;

public class StationModel
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
 
    public string stationName { get; set; } = null!;
    public string location { get; set; } = null!;
    public string brand { get; set; } = null!;
    

 

}