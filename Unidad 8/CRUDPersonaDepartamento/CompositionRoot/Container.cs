using Microsoft.Extensions.DependencyInjection;
using ListadoPersonasCRUD.Data.DataBase;
using ListadoPersonasCRUD.Data.Repositories;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;
using ListadoPersonasCRUD.Domain.UseCases;
using ListadoPersonasCRUD.Domain.UseCasesInterfaces;

namespace ListadoPersonasCRUD.DI
{
    public static class Container
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Conection
            services.AddSingleton<Conection>();

            // Repositorios
            services.AddScoped<IPersonaRepository, PersonasRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentosRepository>();

            // UseCases
            services.AddScoped<IPersonaUseCase, PersonaUseCase>();
            services.AddScoped<IDepartamentoUseCase, DepartamentoUseCase>();
        }
    }
}
