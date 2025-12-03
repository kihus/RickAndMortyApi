using System.Text.Json.Serialization;

namespace RickAndMorty.Models.Dtos.Character;

public class OriginDto
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; } 
}