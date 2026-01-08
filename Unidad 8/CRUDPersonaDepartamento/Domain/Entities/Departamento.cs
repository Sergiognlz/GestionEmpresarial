
using System.ComponentModel.DataAnnotations;

namespace ListadoPersonasCRUD.Domain.Entities
{
    public class Departamento
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [MaxLength(30)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }



        // Constructor vacío necesario para Model Binding
        public Departamento() { }

        public Departamento(int id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }

        public Departamento(string nombre)
        {
            Nombre = nombre;
        }
    }
}
