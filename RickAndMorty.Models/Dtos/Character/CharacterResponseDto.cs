using System.Text.Json.Serialization;

namespace RickAndMorty.Models.Dtos.Character;

public class CharacterResponseDto
{
    [JsonPropertyName("results")]
    public List<CharacterDto> Results { get; set; }
}
