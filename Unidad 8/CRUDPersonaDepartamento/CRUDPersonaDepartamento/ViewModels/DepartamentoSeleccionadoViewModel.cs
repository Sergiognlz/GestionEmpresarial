using System.ComponentModel.DataAnnotations;

namespace ListadoPersonasCRUD.UI.ViewModels
{
    public class DepartamentoSeleccionadoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
