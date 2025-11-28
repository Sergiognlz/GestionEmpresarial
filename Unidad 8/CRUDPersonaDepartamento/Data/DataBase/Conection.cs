using Microsoft.Extensions.Configuration;

namespace ListadoPersonasCRUD.Data.DataBase
{
    public class Conection
    {
        private readonly IConfiguration _configuration;
        public Conection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Lee "DefaultConnection" de appsettings.json (configurable en Azure App Service/Key Vault)
        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
