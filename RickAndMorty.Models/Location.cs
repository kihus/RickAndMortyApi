using System.Text.Json.Serialization;

namespace RickAndMorty.Models;

public class Location(
    string name,
    string url
    )
{
    [JsonPropertyName("name")]
    public string Name { get; private set; } = name;

    [JsonPropertyName("url")]
    public string Url { get; private set; } = url;
}