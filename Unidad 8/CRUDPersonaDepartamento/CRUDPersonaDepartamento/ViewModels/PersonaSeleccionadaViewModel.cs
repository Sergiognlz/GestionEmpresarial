using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // necesario para IFormFile
using ListadoPersonasCRUD.Domain.Entities;

namespace ListadoPersonasCRUD.UI.ViewModels
{
    public class PersonaSeleccionadaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        [Display(Name = "Foto")]
        public string? Foto { get; set; } // nullable para que no sea obligatorio

        [Display(Name = "Subir foto")]
        public IFormFile? FotoFile { get; set; } // nullable y opcional

        public int? DepartamentoId { get; set; }

        public string? NombreDepartamento { get; set; }

        // Inicializamos la lista para evitar NullReferenceException
        public List<Departamento> Departamentos { get; set; } = new List<Departamento>();
    }
}
