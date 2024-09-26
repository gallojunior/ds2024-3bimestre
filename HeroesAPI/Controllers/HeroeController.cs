
using HeroesAPI.Collections;
using HeroesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeroeController : ControllerBase
{
    private readonly IHeroeRepository _repo;

    public HeroeController(IHeroeRepository repository)
    {
        _repo = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var Heroes = await _repo.GetAllAsync();
        return Ok(Heroes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var Heroe = await _repo.GetByIdAsync(id);
        if (Heroe == null)
            return NotFound("Heroe não encontrado");
        return Ok(Heroe);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Heroe Heroe)
    {
        await _repo.CreateAsync(Heroe);
        return CreatedAtAction(nameof(Get), new { id = Heroe.Id }, Heroe);
    }

    [HttpPut]
    public async Task<IActionResult> Edit(Heroe Heroe)
    {
        var prod = await _repo.GetByIdAsync(Heroe.Id);
        if (prod == null)
            return NotFound("Heroe não encontrado");
        
        await _repo.UpdateAsync(Heroe);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var prod = await _repo.GetByIdAsync(id);
        if (prod == null)
            return NotFound("Heroe não encontrado");
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}