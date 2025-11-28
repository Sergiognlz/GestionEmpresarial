using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ListadoPersonasCRUD.Domain.Entities;

namespace ListadoPersonasCRUD.UI.ViewModels
{
    public class PersonaSeleccionadaViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public int? DepartamentoId { get; set; }
        public List<Departamento> Departamentos { get; set; }
    }
}
