using System;

namespace ListadoPersonasCRUD.Domain.Entities
{
    public class Persona
    {
        public int Id { get; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int? DepartamentoId { get; set; }

        public Persona(int id, string nombre, string apellido, DateTime fechaNacimiento, string direccion, string telefono, int? departamentoId = null)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Telefono = telefono;
            DepartamentoId = departamentoId;
        }
    }
}