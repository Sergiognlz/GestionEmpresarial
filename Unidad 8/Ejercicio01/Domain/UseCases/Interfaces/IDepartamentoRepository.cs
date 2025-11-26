using Domain.Entities;
using System.Collections.Generic;

namespace DOMAIN.UseCases.Interfaces
{
    public interface IDepartamentoRepository
    {
        List<Departamento> GetDepartamentos();
    }
}
