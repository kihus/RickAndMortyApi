using MongoDB.Driver;
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

    public async Task<List<Character?>> GetById(List<int> id)
    {
        var filter = Builders<Character>.Filter.In(c => c.RickMortyId, id);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task AddAsync(Character character)
    {
        await _collection.InsertOneAsync(character);
    }
}
