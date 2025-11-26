using DOMAIN.UseCases.Interfaces;
using Data.DataBase;
using Microsoft.Data.SqlClient;

namespace DATA.Services
{
    public class ConnectionService : IConnectionService
    {
        public string CheckConnection()
        {
            string estado = "Desconocido";
            try
            {
                using (SqlConnection conn = new SqlConnection(Conection.GetConnectionString()))
                {
                    conn.Open();
                    estado = conn.State.ToString();
                }
            }
            catch (SqlException ex)
            {
                estado = "Error: " + ex.Message;
            }
            return estado;
        }
    }
}
