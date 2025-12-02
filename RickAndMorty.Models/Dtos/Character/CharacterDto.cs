using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace RickAndMorty.Models.Dtos.Character;

public class CharacterDto(
    int id, 
    string name, 
    string status, 
    string species, 
    string type, 
    string gender, 
    Origin origin, 
    Location location, 
    string image, 
    List<string> episodes, 
    string url, 
    string created
    )
{
    [JsonPropertyName("id")]
    public int Id { get; private set; } = id;

    [JsonPropertyName("name")]
    public string Name { get; private set; } = name;

    [JsonPropertyName("status")]
    public string Status { get; private set; } = status;

    [JsonPropertyName("species")]
    public string Species { get; private set; } = species;

    [JsonPropertyName("type")]
    public string Type { get; private set; } = type;

    [JsonPropertyName("gender")]
    public string Gender { get; private set; } = gender;

    [JsonPropertyName("origin")]
    public Origin Origin { get; private set; } = origin;

    [JsonPropertyName("location")]
    public Location Location { get; private set; } = location;

    [JsonPropertyName("image")]
    public string Image { get; private set; } = image;

    [JsonPropertyName("episode")]
    public List<string> Episodes { get; private set; } = episodes;

    [JsonPropertyName("url")]
    public string Url { get; private set; } = url;

    [JsonPropertyName("created")]
    public string Created { get; private set; } = created;
    public string From { get; set; }
}
