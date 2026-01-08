using Domain.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace UI.ViewModels
{
    public class HomeViewModel
    {
        public List<PersonaSeleccionadaViewModel> Personas { get; set; } = new();
        public List<SelectListItem> Departamentos { get; set; } = new();
        public CheckResultDto? Resultado { get; set; }

        // Diccionario de colores de pista por departamento
        public Dictionary<int, string>? DeptColorMap { get; set; }
    }
}
