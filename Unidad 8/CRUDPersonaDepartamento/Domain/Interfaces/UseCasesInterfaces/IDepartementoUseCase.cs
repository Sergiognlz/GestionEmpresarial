using System.Collections.Generic;
using ListadoPersonasCRUD.Domain.Entities;

namespace ListadoPersonasCRUD.Domain.UseCasesInterfaces
{
    public interface IDepartamentoUseCase
    {
        List<Departamento> GetListadoDepartamento();
        Departamento? GetDepartamentoById(int id);
        int DeleteDepartamento(int id);
        Departamento CreateDepartamento(Departamento departamento);
        Departamento EditDepartamento(Departamento departamento);
    }
}
