using Data.DataBase;
using Domain.Entities;
using DOMAIN.UseCases.Interfaces;
using Microsoft.Data.SqlClient;

namespace DATA.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        public List<Persona> GetPersonas()
        {
            List<Persona> personas = new List<Persona>();
            string connectionString = Conection.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono FROM Personas";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Persona p = new Persona(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDateTime(3),
                            reader.GetString(4),
                            reader.GetString(5)
                        );
                        personas.Add(p);
                    }
                }
            }
            return personas;
        }
    }
}
