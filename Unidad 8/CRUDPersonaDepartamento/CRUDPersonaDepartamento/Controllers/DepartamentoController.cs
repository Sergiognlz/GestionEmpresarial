using Microsoft.AspNetCore.Mvc;
using ListadoPersonasCRUD.Domain.UseCasesInterfaces;
using ListadoPersonasCRUD.UI.ViewModels;
using ListadoPersonasCRUD.Domain.Entities;
using System.Linq;

namespace ListadoPersonasCRUD.UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoUseCase _departamentoUseCase;

        public DepartamentoController(IDepartamentoUseCase departamentoUseCase)
        {
            _departamentoUseCase = departamentoUseCase;
        }

        public IActionResult Index()
        {
            var departamentos = _departamentoUseCase.GetListadoDepartamento();

            var vmList = departamentos.Select(d => new DepartamentoSeleccionadoViewModel
            {
                Id = d.ID,
                Nombre = d.Nombre
            }).ToList();

            IActionResult result = View(vmList);
            return result;
        }

        public IActionResult Details(int id)
        {
            var d = _departamentoUseCase.GetDepartamentoById(id);

            DepartamentoSeleccionadoViewModel vm = d == null
                ? null
                : new DepartamentoSeleccionadoViewModel
                {
                    Id = d.ID,
                    Nombre = d.Nombre
                };

            IActionResult result = vm == null ? NotFound() : View(vm);
            return result;
        }

        public IActionResult Create()
        {
            var vm = new DepartamentoSeleccionadoViewModel();
            IActionResult result = View(vm);
            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartamentoSeleccionadoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var departamento = new Departamento
                {
                    ID = 0,
                    Nombre = model.Nombre
                };

                _departamentoUseCase.CreateDepartamento(departamento);
                IActionResult result = RedirectToAction(nameof(Index));
                return result;
            }

            // Si no es válido
            IActionResult fallback = View(model);
            return fallback;
        }

        public IActionResult Edit(int id)
        {
            var d = _departamentoUseCase.GetDepartamentoById(id);

            var vm = d == null
                ? null
                : new DepartamentoSeleccionadoViewModel
                {
                    Id = d.ID,
                    Nombre = d.Nombre
                };

            IActionResult result = vm == null ? NotFound() : View(vm);
            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartamentoSeleccionadoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var departamento = new Departamento
                {
                    ID = model.Id,
                    Nombre = model.Nombre
                };

                _departamentoUseCase.EditDepartamento(departamento);
                IActionResult result = RedirectToAction(nameof(Index));
                return result;
            }

            // Si no es válido
            IActionResult fallback = View(model);
            return fallback;
        }

        public IActionResult Delete(int id)
        {
            var d = _departamentoUseCase.GetDepartamentoById(id);

            var vm = d == null
                ? null
                : new DepartamentoSeleccionadoViewModel
                {
                    Id = d.ID,
                    Nombre = d.Nombre
                };

            IActionResult result = vm == null ? NotFound() : View(vm);
            return result;
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _departamentoUseCase.DeleteDepartamento(id);
            IActionResult result = RedirectToAction(nameof(Index));
            return result;
        }
    }
}
