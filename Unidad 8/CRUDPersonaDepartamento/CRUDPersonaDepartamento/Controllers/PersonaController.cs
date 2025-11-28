using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.UseCasesInterfaces;
using ListadoPersonasCRUD.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace ListadoPersonasCRUD.UI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaUseCase _personaUseCase;
        private readonly IDepartamentoUseCase _departamentoUseCase;

        public PersonaController(IPersonaUseCase personaUseCase, IDepartamentoUseCase departamentoUseCase)
        {
            _personaUseCase = personaUseCase;
            _departamentoUseCase = departamentoUseCase;
        }

        public IActionResult List()
        {
            var listado = _personaUseCase.GetListadoPersonas();
            return View(listado);
        }

        public IActionResult Details(int id)
        {
            var persona = _personaUseCase.GetPersonaById(id);
            if (persona == null) return NotFound();
            return View(persona);
        }

        public IActionResult Create()
        {
            var vm = new PersonaSeleccionadaViewModel
            {
                Departamentos = _departamentoUseCase.GetListadoDepartamento()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonaSeleccionadaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Departamentos = _departamentoUseCase.GetListadoDepartamento();
                return View(model);
            }

            var persona = new Persona(0, model.Nombre, model.Apellido, model.FechaNacimiento, model.Direccion, model.Telefono, model.DepartamentoId);
            _personaUseCase.CreatePersona(persona);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Edit(int id)
        {
            var p = _personaUseCase.GetPersonaById(id);
            if (p == null) return NotFound();

            var vm = new PersonaSeleccionadaViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                FechaNacimiento = p.FechaNacimiento,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                DepartamentoId = p.DepartamentoId,
                Departamentos = _departamentoUseCase.GetListadoDepartamento()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PersonaSeleccionadaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Departamentos = _departamentoUseCase.GetListadoDepartamento();
                return View(model);
            }

            var persona = new Persona(model.Id, model.Nombre, model.Apellido, model.FechaNacimiento, model.Direccion, model.Telefono, model.DepartamentoId);
            _personaUseCase.EditPersona(persona);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete(int id)
        {
            var p = _personaUseCase.GetPersonaById(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _personaUseCase.DeletePersona(id);
            return RedirectToAction(nameof(List));
        }
    }
}
