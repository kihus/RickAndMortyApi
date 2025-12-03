using System.Text.Json.Serialization;

namespace RickAndMortyApi.Dtos.Character;

public class InfoDto
{
    [JsonPropertyName("count")]
    public int Count { get; init; }

    [JsonPropertyName("pages")]
    public int Pages { get; init; }

    [JsonPropertyName("next")]
    public string? Next { get; init; }

    [JsonPropertyName("prev")]
    public string? Previous { get; init; }
}