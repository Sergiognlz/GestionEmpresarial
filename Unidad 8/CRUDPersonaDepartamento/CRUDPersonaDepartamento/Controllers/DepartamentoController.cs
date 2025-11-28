using Microsoft.AspNetCore.Mvc;
using ListadoPersonasCRUD.Domain.UseCasesInterfaces;
using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.UI.ViewModels;
using System;

namespace ListadoPersonasCRUD.UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoUseCase _departamentoUseCase;

        public DepartamentoController(IDepartamentoUseCase departamentoUseCase)
        {
            _departamentoUseCase = departamentoUseCase;
        }

        public IActionResult List()
        {
            var list = _departamentoUseCase.GetListadoDepartamento();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var d = _departamentoUseCase.GetDepartamentoById(id);
            if (d == null) return NotFound();
            return View(d);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            if (!ModelState.IsValid) return View(departamento);
            _departamentoUseCase.CreateDepartamento(departamento);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Edit(int id)
        {
            var d = _departamentoUseCase.GetDepartamentoById(id);
            if (d == null) return NotFound();
            return View(d);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento)
        {
            if (!ModelState.IsValid) return View(departamento);
            _departamentoUseCase.EditDepartamento(departamento);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete(int id)
        {
            var d = _departamentoUseCase.GetDepartamentoById(id);
            if (d == null) return NotFound();
            return View(d);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _departamentoUseCase.DeleteDepartamento(id);
                return RedirectToAction(nameof(List));
            }
            catch (InvalidOperationException ex)
            {
                // Mostrar error en vista
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Details), new { id });
            }
        }
    }
}
