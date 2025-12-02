using RickAndMorty.Models.Dtos.Character;
using RickAndMorty.Models.Entities;

namespace RickAndMorty.Utils;

public class Helpers
{
    /// <summary>
    /// Recive type <see cref="Character.cs"/>
    /// </summary>
    /// <param name="character"></param>
    /// <returns><see cref="CharacterDto.cs"/></returns>
    public static CharacterDto ConvertCharacterToCharacterDto(Character character)
    {
        var characterDto = new CharacterDto(
            character.RickMortyId,
            character.Name,
            character.Status,
            character.Species,
            character.Type,
            character.Gender,
            character.Origin,
            character.Location,
            character.Image,
            character.Episodes,
            character.Url,
            character.Created
            );

        return characterDto;
    }
    public static Character ConvertCharacterDtoToCharacter(CharacterDto characterDto)
    {
        var character = new Character
        {
            RickMortyId = characterDto.Id,
            Name = characterDto.Name,
            Status = characterDto.Status,
            Species = characterDto.Species,
            Type = characterDto.Type,
            Gender = characterDto.Gender,
            Origin = characterDto.Origin,
            Location = characterDto.Location,
            Image = characterDto.Image,
            Episodes = characterDto.Episodes,
            Url = characterDto.Url,
            Created = characterDto.Created
        };

        return character;
    }

}
