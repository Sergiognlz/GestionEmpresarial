using DOMAIN.UseCases;
using DOMAIN.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class Root
    {
        /// <summary>
        /// Método de extensión para registrar todas las dependencias de la solución.
        /// </summary>
        /// <param name="services">IServiceCollection de ASP.NET Core</param>
        public static void AddProjectDependencies(this IServiceCollection services)
        {
            // ------------------------------
            // Repositorios
            // ------------------------------
            services.AddScoped<IPersonaRepository>();
            services.AddScoped<IDepartamentoRepository>();

            // ------------------------------
            // Servicios de conexión
            // ------------------------------
            services.AddScoped<IConnectionService>();
            services.AddScoped<IConnectionCheckUseCase, ConnectionCheckUseCase>();

            // ------------------------------
            // Otros servicios (si los hubiera)
            // ------------------------------
            // services.AddScoped<IOtroServicio, OtroServicio>();
        }
    }
}
