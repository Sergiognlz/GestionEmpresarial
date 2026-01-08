using ListadoPersonasCRUD.Domain.DTOs;
using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.UseCasesInterfaces;
using ListadoPersonasCRUD.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        // =========================
        // INDEX
        // =========================
        public IActionResult Index()
        {
            var listado = _personaUseCase.GetListadoPersonas();
            var departamentos = _departamentoUseCase.GetListadoDepartamento();

            // Crear lista de DTO combinando Persona y nombre del Departamento
            var dtoList = listado.Select(p =>
            {
                var dept = departamentos.FirstOrDefault(d => d.ID == p.IDDepartamento);
                return new PersonaDepDTO(p, dept?.Nombre ?? "");
            }).ToList();

            // Mapear DTO a ViewModel
            var vmList = dtoList.Select(d => new PersonaSeleccionadaViewModel
            {
                Id = d.Persona.ID,
                Nombre = d.Persona.Nombre,
                Apellidos = d.Persona.Apellidos,
                FechaNacimiento = d.Persona.FechaNacimiento,
                Direccion = d.Persona.Direccion,
                Telefono = d.Persona.Telefono,
                Foto = d.Persona.Foto,
                DepartamentoId = d.Persona.IDDepartamento,
                NombreDepartamento = d.NombreDepartamento // <- agregamos aquí
            }).ToList();

            IActionResult result = View(vmList);
            return result;
        }



        // =========================
        // DETAILS
        // =========================
        public IActionResult Details(int id)
        {
            var p = _personaUseCase.GetPersonaById(id);

            PersonaSeleccionadaViewModel vm = p == null
                ? null
                : new PersonaSeleccionadaViewModel
                {
                    Id = p.ID,
                    Nombre = p.Nombre,
                    Apellidos = p.Apellidos,
                    FechaNacimiento = p.FechaNacimiento,
                    Direccion = p.Direccion,
                    Telefono = p.Telefono,
                    Foto = p.Foto,
                    DepartamentoId = p.IDDepartamento
                };

            IActionResult result = vm == null ? NotFound() : View(vm);
            return result;
        }

        // =========================
        // CREATE (GET)
        // =========================
        public IActionResult Create()
        {
            var vm = new PersonaSeleccionadaViewModel
            {
                Departamentos = _departamentoUseCase.GetListadoDepartamento()
            };

            IActionResult result = View(vm);
            return result;
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonaSeleccionadaViewModel model)
        {
            IActionResult result;

            if (ModelState.IsValid)
            {
                var persona = new Persona(
                    id: 0,
                    nombre: model.Nombre,
                    apellidos: model.Apellidos,
                    fechaNacimiento: model.FechaNacimiento,
                    direccion: model.Direccion,
                    foto: model.Foto,
                    telefono: model.Telefono,
                    departamentoId: model.DepartamentoId
                );

                _personaUseCase.CreatePersona(persona);
                result = RedirectToAction(nameof(Index));
            }
            else
            {
                model.Departamentos = _departamentoUseCase.GetListadoDepartamento();
                result = View(model);
            }

            return result;
        }

        // =========================
        // EDIT (GET)
        // =========================
        public IActionResult Edit(int id)
        {
            var p = _personaUseCase.GetPersonaById(id);

            PersonaSeleccionadaViewModel vm = p == null
                ? null
                : new PersonaSeleccionadaViewModel
                {
                    Id = p.ID,
                    Nombre = p.Nombre,
                    Apellidos = p.Apellidos,
                    FechaNacimiento = p.FechaNacimiento,
                    Direccion = p.Direccion,
                    Telefono = p.Telefono,
                    Foto = p.Foto,
                    DepartamentoId = p.IDDepartamento,
                    Departamentos = _departamentoUseCase.GetListadoDepartamento() ?? new List<Departamento>()
                };

            IActionResult result = vm == null ? NotFound() : View(vm);
            return result;
        }

        // =========================
        // EDIT (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PersonaSeleccionadaViewModel model)
        {
            IActionResult result;

            if (ModelState.IsValid)
            {
                var persona = new Persona(
                    id: model.Id,
                    nombre: model.Nombre,
                    apellidos: model.Apellidos,
                    fechaNacimiento: model.FechaNacimiento,
                    direccion: model.Direccion,
                    foto: model.Foto,
                    telefono: model.Telefono,
                    departamentoId: model.DepartamentoId
                );

                _personaUseCase.EditPersona(persona);
                result = RedirectToAction(nameof(Index));
            }
            else
            {
                model.Departamentos = _departamentoUseCase.GetListadoDepartamento() ?? new List<Departamento>();
                result = View(model);
            }

            return result;
        }

        // =========================
        // DELETE (GET)
        // =========================
        public IActionResult Delete(int id)
        {
            var p = _personaUseCase.GetPersonaById(id);

            PersonaSeleccionadaViewModel vm = p == null
                ? null
                : new PersonaSeleccionadaViewModel
                {
                    Id = p.ID,
                    Nombre = p.Nombre,
                    Apellidos = p.Apellidos,
                    FechaNacimiento = p.FechaNacimiento,
                    Direccion = p.Direccion,
                    Telefono = p.Telefono,
                    Foto = p.Foto,
                    DepartamentoId = p.IDDepartamento
                };

            IActionResult result = vm == null ? NotFound() : View(vm);
            return result;
        }

        // =========================
        // DELETE (POST)
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _personaUseCase.DeletePersona(id);
            IActionResult result = RedirectToAction(nameof(Index));
            return result;
        }
    }
}
