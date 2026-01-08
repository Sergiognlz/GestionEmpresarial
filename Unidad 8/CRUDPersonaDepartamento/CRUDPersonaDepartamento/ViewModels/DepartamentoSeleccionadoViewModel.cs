using System.ComponentModel.DataAnnotations;

namespace ListadoPersonasCRUD.UI.ViewModels
{
    public class DepartamentoSeleccionadoViewModel
    {
        // Constructor vacío obligatorio para el model binding en ASP.NET Core
        public DepartamentoSeleccionadoViewModel() { }

        public DepartamentoSeleccionadoViewModel(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty; // Inicializado para evitar NullReferenceException
    }
}
