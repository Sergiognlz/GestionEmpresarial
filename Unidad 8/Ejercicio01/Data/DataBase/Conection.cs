

using Microsoft.Data.SqlClient;

namespace Data.DataBase
{
    public class Conection
    {
        public static string GetConnectionString()
        {
            return "Server=tuservidor.database.windows.net;Database=NombreDB;User Id=usuario;Password=contraseña;TrustServerCertificate=True;";
        }
    }
}
