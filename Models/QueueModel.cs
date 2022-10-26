using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fuel_API.Models;

public class QueueModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public DateTime arivalTime { get; set; }
    public DateTime departureTime { get; set; }
    public string reason { get; set; }
    public string vehicleType { get; set; }
    public string stationName { get; set; }

}