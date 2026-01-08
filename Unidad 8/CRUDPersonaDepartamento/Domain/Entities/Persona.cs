using System;


using System.ComponentModel.DataAnnotations;

namespace ListadoPersonasCRUD.Domain.Entities
{
    public class Persona
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [MaxLength(30)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [MaxLength(60)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [MaxLength(15)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [MaxLength(60)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [MaxLength(225)]
        [Display(Name = "Foto")]
        public string Foto { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int? IDDepartamento { get; set; }
  



        public Persona() { }

        public Persona(int id, string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string foto, string telefono, int? departamentoId = null)
        {
            ID = id;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Foto= foto;
            Telefono = telefono;
            IDDepartamento = departamentoId;
        }
    }
}