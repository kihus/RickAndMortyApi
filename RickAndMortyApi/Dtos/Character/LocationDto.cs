using System.Text.Json.Serialization;

namespace RickAndMortyApi.Dtos.Character;

public class LocationDto
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }
}