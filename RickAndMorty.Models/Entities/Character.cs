using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RickAndMorty.Models.Entities;

public class Character(
    int rickMortyId,
    string name,
    string status,
    string species,
    string type,
    string gender,
    Origin origin,
    Location location,
    string image,
    List<string> episodes,
    string url
        )
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; }
    public int RickMortyId { get; private set; } = rickMortyId;
    public string Name { get; private set; } = name;
    public string Status { get; private set; } = status;
    public string Species { get; private set; } = species;
    public string Type { get; private set; } = type;
    public string Gender { get; private set; } = gender;
    public Origin Origin { get; private set; } = origin;
    public Location Location { get; private set; } = location;
    public string Image { get; private set; } = image;
    public List<string> Episodes { get; private set; } = episodes;
    public string Url { get; private set; } = url;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
