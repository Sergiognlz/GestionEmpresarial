using ListadoPersonasCRUD.Domain.Entities;

namespace ListadoPersonasCRUD.Domain.DTOs
{
    public class PersonaDepDTO
    {
        public Persona Persona { get; set; } // información completa de la persona
        public string NombreDepartamento { get; set; } // nombre del departamento

        public PersonaDepDTO(Persona persona, string nombreDepartamento)
        {
            Persona = persona;
            NombreDepartamento = nombreDepartamento;
        }
    }
}
