using System.Text.Json;
using RickAndMortyApi.Dtos.Page;
using RickAndMortyApi.Dtos.RickAndMorty;
using RickAndMortyApi.Repository;
using RickAndMortyApi.Dtos.Character;

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
        var result = await _client.GetAsync($"character/{(page.Page is 0 ? "" : $"?page={page.Page}")}");

        var charactersJson = await result.Content.ReadAsStringAsync();

        var characters = JsonSerializer.Deserialize<RickAndMortyResponseDto>(charactersJson, _options)!;
        var charactersList = new List<CharacterDto>();


        var characterNotFormated = await _repository.GetById(characters.Results.Select(x => x.Id).ToList());
        return charactersList;
    }

    public async Task<List<CharacterDto>> GetManyById(string ids)
    {
        var listCharacter = new List<CharacterDto>();
        var listIds = ids.Split(',')
                         .Select(int.Parse)
                         .ToList();

        return listCharacter;
    }

    public async Task<List<CharacterDto>> GetByFilter(CharacterFilterDto filter)
    {
        var result = await _client.GetAsync($"character/?{(string.IsNullOrEmpty(filter.Name) ? "" : $"name={filter.Name}")}" +
                                                      $"{(string.IsNullOrEmpty(filter.Status) ? "" : $"&status={filter.Status}")}" +
                                                      $"{(string.IsNullOrEmpty(filter.Species) ? "" : $"&species={filter.Species}")}" +
                                                      $"{(string.IsNullOrEmpty(filter.Type) ? "" : $"&status={filter.Type}")}" +
                                                      $"{(string.IsNullOrEmpty(filter.Gender) ? "" : $"&gender={filter.Gender}")}");

        var characterJson = await result.Content.ReadAsStringAsync();

        var character = JsonSerializer.Deserialize<RickAndMortyResponseDto>(characterJson, _options);
        return character.Results;
    }

}
