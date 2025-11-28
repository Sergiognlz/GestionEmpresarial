
using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;

namespace ListadoPersonasCRUD.Domain.DTOs
{
    public class PersonaListaDepartamento
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public Persona Persona { get; }
        public List<Departamento> ListadoDepartamento { get; }

        public PersonaListaDepartamento(Persona persona, IDepartamentoRepository departamentoRepository)
        {
            Persona = persona;
            _departamentoRepository = departamentoRepository;
            ListadoDepartamento = _departamentoRepository.GetListadoDepartamento();
        }
    }
}
