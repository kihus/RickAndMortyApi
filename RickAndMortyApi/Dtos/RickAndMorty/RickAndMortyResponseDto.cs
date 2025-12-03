using RickAndMortyApi.Dtos.Character;
using System.Text.Json.Serialization;

namespace RickAndMortyApi.Dtos.RickAndMorty;

public class RickAndMortyResponseDto
{
    [JsonPropertyName("info")]
    public InfoDto? Info { get; set; }

    [JsonPropertyName("results")]
    public required List<CharacterDto> Results { get; set; }
}
