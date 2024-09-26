using HeroesAPI.Collections;
using MongoDB.Driver;

namespace HeroesAPI.Repositories;

public class HeroeRepository : IHeroeRepository
{
    private readonly IMongoCollection<Heroe> _collection;
    public HeroeRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Heroe>("heroes");
    }

    public async Task CreateAsync(Heroe heroe) =>
        await _collection.InsertOneAsync(heroe);

    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(p => p.Id == id);

    public async Task<List<Heroe>> GetAllAsync() =>
        await _collection.Find(p => true).ToListAsync();

    public async Task<Heroe> GetByIdAsync(string id) =>
        await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(Heroe heroe) =>
        await _collection.ReplaceOneAsync(p => p.Id == heroe.Id, heroe);
}