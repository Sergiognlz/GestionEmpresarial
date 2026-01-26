using System.Collections.Generic;
using ListadoPersonasCRUD.Domain.Entities;

namespace ListadoPersonasCRUD.Domain.RepositoriesInterfaces
{
    public interface IPersonaRepository
    {
        List<Persona> GetListadoPersonas();
        Persona? GetPersonaById(int id);
        int DeletePersona(int id);
        Persona CreatePersona(Persona persona);
        int EditPersona(Persona personaEditada);
    }
}
