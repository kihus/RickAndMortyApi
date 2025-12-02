using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RickAndMorty.Models.Entities;

public class Character
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public required int RickMortyId { get; set; }
    public required string Name { get; set; }
    public string Status { get; set; }
    public string Species { get; set; }
    public string Type { get; set; }
    public string Gender { get; set; }
    public Origin Origin { get; set; }
    public Location Location { get; set; }
    public string Image { get; set; }
    public List<string> Episodes { get; set; }
    public string Url { get; set; }
    public string Created { get; set; }
    
}
