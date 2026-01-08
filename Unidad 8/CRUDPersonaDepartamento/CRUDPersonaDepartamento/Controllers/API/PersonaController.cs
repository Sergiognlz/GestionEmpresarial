using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ListadoPersonasCRUD.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class PersonasController : ControllerBase
{
    private readonly IPersonaRepository _repo;

    public PersonasController(IPersonaRepository repo)
    {
        _repo = repo;
    }

    // GET: api/personas
    [HttpGet]
    public IActionResult GetAll()
    {
        var personas = _repo.GetListadoPersonas();
        return Ok(personas);
    }

    // GET: api/personas/5
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var persona = _repo.GetPersonaById(id);
        return persona == null ? NotFound() : Ok(persona);
    }

    // POST: api/personas
    [HttpPost]
    public IActionResult Create(Persona persona)
    {
        var nueva = _repo.CreatePersona(persona);
        return CreatedAtAction(nameof(GetById), new { id = nueva.ID }, nueva);
    }

    // PUT: api/personas/5
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Persona persona)
    {
        if (id != persona.ID) return BadRequest("El ID no coincide");

        var existente = _repo.GetPersonaById(id);
        if (existente == null) return NotFound();

        var editada = _repo.EditPersona(persona);
        return NoContent();
    }

    // DELETE: api/personas/5
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existe = _repo.GetPersonaById(id);
        if (existe == null) return NotFound();

        _repo.DeletePersona(id);
        return NoContent();
    }
}
