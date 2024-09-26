
using HeroesAPI.Collections;

namespace HeroesAPI.Repositories;

public interface IHeroeRepository
{
    Task<List<Heroe>> GetAllAsync();
    Task<Heroe> GetByIdAsync(string id);
    Task CreateAsync(Heroe heroe);
    Task UpdateAsync(Heroe heroe);
    Task DeleteAsync(string id);
}
