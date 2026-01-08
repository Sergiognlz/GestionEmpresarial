
using ListadoPersonasCRUD.Domain.DTOs;
using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;
using ListadoPersonasCRUD.Domain.UseCasesInterfaces;

namespace ListadoPersonasCRUD.Domain.UseCases
{
    public class PersonaUseCase : IPersonaUseCase
    {
        private readonly IPersonaRepository _repositorioPersonas;
        private readonly IDepartamentoRepository _departamentoRepository;

        public PersonaUseCase(IPersonaRepository repositorioPersonas, IDepartamentoRepository departamentoRepository)
        {
            _repositorioPersonas = repositorioPersonas;
            _departamentoRepository = departamentoRepository;
        }

        public List<Persona> GetListadoPersonas()
        {
            return _repositorioPersonas.GetListadoPersonas();
        }

        public Persona? GetPersonaById(int id)
        {
            return _repositorioPersonas.GetPersonaById(id);
        }

        public int DeletePersona(int id)
        {
            return _repositorioPersonas.DeletePersona(id);
        }

        public Persona CreatePersona(Persona persona)
        {
            // Validaciones (SRP / OCP): si necesitas más validación, extraer a un servicio
            return _repositorioPersonas.CreatePersona(persona);
        }

        public Persona EditPersona(Persona personaEditada)
        {
            return _repositorioPersonas.EditPersona(personaEditada);
        }

        public PersonaListaDepartamento GetPersonaConDepartamentos(int id)
        {
            Persona persona = _repositorioPersonas.GetPersonaById(id);

            List<Departamento> listaDepartamentos = _departamentoRepository.GetListadoDepartamento();


            PersonaListaDepartamento personaDepDTO = new PersonaListaDepartamento(persona, listaDepartamentos);



            return personaDepDTO;

        }

        public PersonaDepDTO GetPersonaDepDTO(int id)
        {

            Persona persona = _repositorioPersonas.GetPersonaById(id);

            Departamento dept = _departamentoRepository.GetDepartamentoById(persona.IDDepartamento ?? 0);

            PersonaDepDTO personaDepDTO = new PersonaDepDTO(persona, dept.Nombre);

            return personaDepDTO;
        }
    }
}
