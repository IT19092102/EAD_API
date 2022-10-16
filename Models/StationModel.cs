using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace fuel_API.Models;

public class StationModel
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
 
    public string emasssail { get; set; } = null!;
    public string sasa { get; set; } = null!;
    public long phonsaseNumber { get; set; } = 0!;
    

 

}