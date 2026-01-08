using Domain.DTOs;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using UI.ViewModels;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetGameDataUseCase _getGameData;
        private readonly ICheckDepartmentsUseCase _checkDepartments;

        public HomeController(
            IGetGameDataUseCase getGameData,
            ICheckDepartmentsUseCase checkDepartments)
        {
            _getGameData = getGameData;
            _checkDepartments = checkDepartments;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Obtenemos los datos del juego
            var data = _getGameData.Execute();

            // Construimos el ViewModel
            var vm = new HomeViewModel
            {
                Personas = data.Personas.Select(p => new PersonaSeleccionadaViewModel
                {
                    PersonaId = p.Id,
                    NombreCompleto = $"{p.Nombre} {p.Apellidos}",
                    DepartamentoSeleccionado = null, // Sin selección al inicio
                    ColorDepartamento = p.IDDepartamento.HasValue && data.DepartamentoColores.ContainsKey(p.IDDepartamento.Value)
                                        ? data.DepartamentoColores[p.IDDepartamento.Value]
                                        : "white" // color por defecto
                }).ToList(),

                Departamentos = data.Departamentos
                    .Select(d => new SelectListItem
                    {
                        Value = d.Key.ToString(), // Id del departamento
                        Text = d.Value            // Nombre del departamento
                    })
                    .ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel model)
        {
            // Diccionario de selecciones del usuario
            var selections = model.Personas
                .Where(p => p.DepartamentoSeleccionado.HasValue)
                .ToDictionary(p => p.PersonaId, p => p.DepartamentoSeleccionado!.Value);

            // Comprobamos aciertos
            var resultado = _checkDepartments.Execute(selections);
            model.Resultado = resultado;

            // Recuperamos los datos del juego de nuevo
            var data = _getGameData.Execute();

            // Reconstruimos las personas en el ViewModel
            model.Personas = data.Personas.Select(p => new PersonaSeleccionadaViewModel
            {
                PersonaId = p.Id,
                NombreCompleto = $"{p.Nombre} {p.Apellidos}",
                DepartamentoSeleccionado = selections.ContainsKey(p.Id) ? selections[p.Id] : null,
                // Color fijo de pista según el departamento
                ColorDepartamento = p.IDDepartamento.HasValue && data.DepartamentoColores.ContainsKey(p.IDDepartamento.Value)
                                    ? data.DepartamentoColores[p.IDDepartamento.Value]
                                    : "white"
            }).ToList();

            // Reconstruimos SelectListItem con nombres de departamentos
            model.Departamentos = data.Departamentos
                .Select(d => new SelectListItem
                {
                    Value = d.Key.ToString(),
                    Text = d.Value
                })
                .ToList();

            return View(model);
        }
    }
}
