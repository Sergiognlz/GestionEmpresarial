using System.Collections.Generic;
using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;
using ListadoPersonasCRUD.Domain.UseCasesInterfaces;

namespace ListadoPersonasCRUD.Domain.UseCases
{
    public class DepartamentoUseCase : IDepartamentoUseCase
    {
        private readonly IDepartamentoRepository _repositorioDepartamento;

        public DepartamentoUseCase(IDepartamentoRepository repositorioDepartamento)
        {
            _repositorioDepartamento = repositorioDepartamento;
        }

        public List<Departamento> GetListadoDepartamento()
        {
            return _repositorioDepartamento.GetListadoDepartamento();
        }

        public Departamento? GetDepartamentoById(int id)
        {
            return _repositorioDepartamento.GetDepartamentoById(id);
        }

        public int DeleteDepartamento(int id)
        {
            var count = _repositorioDepartamento.ContarPersonasDept(id);
            if (count > 0)
            {
                // No borrar: devolver 0 o lanzar excepción según convención
                // Mejor: lanzar excepción de dominio para que la capa UI muestre mensaje
                throw new InvalidOperationException("No se puede borrar el departamento porque contiene personas.");
            }
            return _repositorioDepartamento.DeleteDepartamento(id);
        }

        public Departamento CreateDepartamento(Departamento departamento)
        {
            return _repositorioDepartamento.CreateDepartamento(departamento);
        }

        public Departamento EditDepartamento(Departamento departamento)
        {
            return _repositorioDepartamento.EditDepartamento(departamento);
        }
    }
}
