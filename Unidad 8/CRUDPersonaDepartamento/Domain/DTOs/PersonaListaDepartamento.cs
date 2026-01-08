
using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;

namespace ListadoPersonasCRUD.Domain.DTOs
{
    public class PersonaListaDepartamento
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public Persona Persona { get; }
        public List<Departamento> ListadoDepartamento { get; }

        public PersonaListaDepartamento(Persona persona, List<Departamento>listaDepartamentos)
        {
            Persona = persona;

            ListadoDepartamento = listaDepartamentos;
        }
    }
}
