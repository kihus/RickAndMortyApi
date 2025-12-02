using MongoDB.Driver;
using RickAndMorty.Models.Dtos.Character;
using RickAndMorty.Models.Entities;
using System.Runtime.CompilerServices;

namespace RickAndMortyApi.Repository;

public class CharacterRepository
{
    private readonly IMongoCollection<Character> _collection;

    public CharacterRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Character>("Characters");
    }

    public async Task<Character?> GetById(int id)
    {
        var character =  await _collection.FindAsync<Character>(c => c.RickMortyId == id);
        return character.FirstOrDefault();
    }

    public async Task AddAsync(Character character)
    {
        await _collection.InsertOneAsync(character);
    }
}
