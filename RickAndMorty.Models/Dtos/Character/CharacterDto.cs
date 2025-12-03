using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace RickAndMorty.Models.Dtos.Character;

public class CharacterDto
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; } 

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("species")]
    public string? Species { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; } 

    [JsonPropertyName("gender")]
    public string? Gender { get; init; } 

    [JsonPropertyName("origin")]
    public OriginDto? Origin { get; init; } 

    [JsonPropertyName("location")]
    public LocationDto? Location { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; } 

    [JsonPropertyName("episode")]
    public List<string>? Episodes { get; init; } 

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("created")]
    public string? Created { get; init; }
    public string? From { get; set; }
}
