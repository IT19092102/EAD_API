using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fuel_API.Models;

public class FuelModel
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string petrol { get; set; } = null;
    public string superPetrol { get; set; } = null;
    public string diesel { get; set; } = null;
    public string superDiesel { get; set; } = null;
    public string stationName { get; set; } = null!;

    


}