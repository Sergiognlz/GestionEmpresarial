using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ListadoPersonasCRUD.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class DepartamentosController : ControllerBase
{
    private readonly IDepartamentoRepository _repo;

    public DepartamentosController(IDepartamentoRepository repo)
    {
        _repo = repo;
    }

    // GET: api/departamentos
    [HttpGet]
    public IActionResult GetAll()
    {
        var departamentos = _repo.GetListadoDepartamento();
        return Ok(departamentos);
    }

    // GET: api/departamentos/5
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var departamento = _repo.GetDepartamentoById(id);
        return departamento == null ? NotFound() : Ok(departamento);
    }

    // POST: api/departamentos
    [HttpPost]
    public IActionResult Create(Departamento departamento)
    {
        var nuevo = _repo.CreateDepartamento(departamento);
        return CreatedAtAction(nameof(GetById), new { id = nuevo.ID }, nuevo);
    }

    // PUT: api/departamentos/5
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Departamento departamento)
    {
        if (id != departamento.ID) return BadRequest("El ID no coincide");

        var existente = _repo.GetDepartamentoById(id);
        if (existente == null) return NotFound();

        _repo.EditDepartamento(departamento);
        return NoContent();
    }

    // DELETE: api/departamentos/5
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existe = _repo.GetDepartamentoById(id);
        if (existe == null) return NotFound();

        _repo.DeleteDepartamento(id);
        return NoContent();
    }
}
