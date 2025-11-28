
using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;
using ListadoPersonasCRUD.Domain.UseCasesInterfaces;

namespace ListadoPersonasCRUD.Domain.UseCases
{
    public class PersonaUseCase : IPersonaUseCase
    {
        private readonly IPersonaRepository _repositorioPersonas;

        public PersonaUseCase(IPersonaRepository repositorioPersonas)
        {
            _repositorioPersonas = repositorioPersonas;
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
    }
}
