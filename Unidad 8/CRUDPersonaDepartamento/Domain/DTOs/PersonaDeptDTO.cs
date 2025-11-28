namespace ListadoPersonasCRUD.Domain.DTOs
{
    public class PersonaDepDTO
    {
        public int IdPersona { get; }
        public int NDepartamento { get; }

        public PersonaDepDTO(int idPersona, int nDepartamento)
        {
            IdPersona = idPersona;
            NDepartamento = nDepartamento;
        }
    }
}
