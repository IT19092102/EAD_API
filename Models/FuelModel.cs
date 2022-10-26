using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fuel_API.Models;

public class FuelModel
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string petrol { get; set; }
    public string superPetrol { get; set; }
    public string diesel { get; set; }
    public string superDiesel { get; set; }
    public string stationName { get; set; }


}