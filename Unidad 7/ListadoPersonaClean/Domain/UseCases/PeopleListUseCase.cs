using System.Data.SqlClient;
using Data.DataBase;

namespace DOMAIN.UseCases
{
    public interface IConnectionCheckUseCase
    {
        string CheckConnection();
    }

    public class ConnectionCheckUseCase : IConnectionCheckUseCase
    {
        public string CheckConnection()
        {
            string estadoConexion = "Desconocido";

            try
            {
                using (SqlConnection conn = new SqlConnection(Conection.GetConnectionString()))
                {
                    conn.Open();
                    estadoConexion = conn.State.ToString(); // Conexión abierta correctamente
                }
            }
            catch (SqlException ex)
            {
                estadoConexion = "Error: " + ex.Message;
            }

            return estadoConexion;
        }
    }
}
