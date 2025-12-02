using System.Text.Json;
using RickAndMorty.Models.Dtos.Character;
using RickAndMorty.Models.Dtos.Page;
using RickAndMorty.Models.Entities;
using RickAndMorty.Utils;
using RickAndMortyApi.Repository;

namespace RickAndMortyApi.Services;

public class CharacterService
{
    private readonly HttpClient _client;
    private readonly CharacterRepository _repository;
    private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

    public CharacterService(HttpClient client, CharacterRepository repository)
    {
        _client = client;
        _repository = repository;
    }

    public async Task<List<CharacterDto>> GetAll(PageDto page)
    {
        var result = await _client.GetAsync($"character/{(string.IsNullOrEmpty(page.Page) ? "" : $"?page={page.Page}")}");

        var charactersJson = await result.Content.ReadAsStringAsync();

        var characters = JsonSerializer.Deserialize<CharacterResponseDto>(charactersJson, _options)!;
        var charactersList = new List<CharacterDto>();

        foreach (var character in characters.Results)
        {
            var characterNotFormated = await _repository.GetById(character.Id);
            if (characterNotFormated is not null)
            {
                var characterFormated = Helpers.ConvertCharacterToCharacterDto(characterNotFormated);
                characterFormated.From = "Veio do mongo";
                charactersList.Add(characterFormated);
                continue;
            }

            var characterForm = Helpers.ConvertCharacterDtoToCharacter(character);
            await _repository.AddAsync(characterForm);
            character.From = "Veio da api";
            charactersList.Add(character);
        }

        return charactersList;
    }

    public async Task<List<CharacterDto>> GetManyById(string ids)
    {
        var listCharacter = new List<CharacterDto>();
        var listIds = ids.Split(',')
                         .Select(int.Parse)
                         .ToList();

        foreach (var id in listIds)
        {
            var characterNotFormated = await _repository.GetById(id);
            if (characterNotFormated is not null)
            {
                var characterFormated = Helpers.ConvertCharacterToCharacterDto(characterNotFormated);
                characterFormated.From = "Veio do mongo";
                listCharacter.Add(characterFormated);
                continue;
            }

            var result = await _client.GetAsync($"character/{id}");

            var characterJson = await result.Content.ReadAsStringAsync();

            if (characterJson == null)
                continue;

            var character = JsonSerializer.Deserialize<CharacterDto>(characterJson, _options);

            var characterMongo = new Character
            {
                RickMortyId = id,
                Name = character.Name,
                Status = character.Status,
                Species = character.Species,
                Type = character.Type,
                Gender = character.Gender,
                Origin = character.Origin,
                Location = character.Location,
                Image = character.Image,
                Episodes = character.Episodes,
                Url = character.Url,
                Created = character.Created
            };

            await _repository.AddAsync(characterMongo);
            character.From = "veio da api";
            listCharacter.Add(character);
        }

        return listCharacter;
    }

    public async Task<List<CharacterDto>> GetByFilter(CharacterFilter filter)
    {
        var result = await _client.GetAsync($"character/?{(string.IsNullOrEmpty(filter.Name) ? "" : $"name={filter.Name}")}" +
                                                      $"{(string.IsNullOrEmpty(filter.Status) ? "" : $"&status={filter.Status}")}" +
                                                      $"{(string.IsNullOrEmpty(filter.Species) ? "" : $"&species={filter.Species}")}" +
                                                      $"{(string.IsNullOrEmpty(filter.Type) ? "" : $"&status={filter.Type}")}" +
                                                      $"{(string.IsNullOrEmpty(filter.Gender) ? "" : $"&gender={filter.Gender}")}");

        var characterJson = await result.Content.ReadAsStringAsync();

        var character = JsonSerializer.Deserialize<CharacterResponseDto>(characterJson, _options);
        return character.Results;
    }

}
