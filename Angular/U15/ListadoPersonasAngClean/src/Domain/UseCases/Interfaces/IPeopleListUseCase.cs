using Domain.Entities;



namespace DOMAIN.UseCases.interfaces
{
    // Esta interfaz es la que deberá implementar el caso de uso
    public interface IPeopleListUseCase
    {
        public List<Persona> getPeopleList();
    }
}


