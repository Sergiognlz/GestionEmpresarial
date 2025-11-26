

using Domain.Entities;


namespace DOMAIN.UseCases.Interfaces
{
    public interface IPersonaRepository
    {
        List<Persona> GetPersonas();
    }
}
