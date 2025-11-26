using Domain.Entities;



namespace DOMAIN.UseCases.interfaces
{
    // Esta interfaz es la que deberá implementar el repositorio del proyecto Data
    public interface IRepository
    {
        public List<Persona> getPeopleListRep();
    }
}



