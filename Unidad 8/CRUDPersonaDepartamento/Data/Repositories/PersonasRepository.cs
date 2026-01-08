using System.Data;
using ListadoPersonasCRUD.Data.DataBase;
using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;
using Microsoft.Data.SqlClient;

namespace ListadoPersonasCRUD.Data.Repositories
{
    public class PersonasRepository : IPersonaRepository
    {
        private readonly Conection _coneccion;
        private readonly string _cs;

        public PersonasRepository(Conection coneccion)
        {
            _coneccion = coneccion;
            _cs = _coneccion.GetConnectionString();
        }

        public List<Persona> GetListadoPersonas()
        {
            var list = new List<Persona>();
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand(
                "SELECT ID, Nombre, Apellidos, FechaNacimiento, Direccion, Foto, Telefono, IDDepartamento FROM Persona", conn);

            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Persona(
                    rdr.GetInt32(0),                                      // ID
                    rdr.GetString(1),                                     // Nombre
                    rdr.GetString(2),                                     // Apellidos
                    rdr.GetDateTime(3),                                   // FechaNacimiento
                    rdr.IsDBNull(4) ? null : rdr.GetString(4),           // Direccion
                    rdr.IsDBNull(5) ? null : rdr.GetString(5),           // Foto
                    rdr.IsDBNull(6) ? null : rdr.GetString(6),           // Telefono
                    rdr.IsDBNull(7) ? null : rdr.GetInt32(7)             // IDDepartamento
                ));
            }
            return list;
        }

        public Persona? GetPersonaById(int id)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand(
                "SELECT ID, Nombre, Apellidos, FechaNacimiento, Direccion, Foto, Telefono, IDDepartamento FROM Persona WHERE ID = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return new Persona(
                    rdr.GetInt32(0),
                    rdr.GetString(1),
                    rdr.GetString(2),
                    rdr.GetDateTime(3),
                    rdr.IsDBNull(4) ? null : rdr.GetString(4),
                    rdr.IsDBNull(5) ? null : rdr.GetString(5),
                    rdr.IsDBNull(6) ? null : rdr.GetString(6),
                    rdr.IsDBNull(7) ? null : rdr.GetInt32(7)
                );
            }
            return null;
        }

        public int DeletePersona(int id)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("DELETE FROM Persona WHERE ID = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public Persona CreatePersona(Persona persona)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand(@"
                INSERT INTO Persona 
                    (Nombre, Apellidos, FechaNacimiento, Direccion, Foto, Telefono, IDDepartamento) 
                OUTPUT INSERTED.ID 
                VALUES (@Nombre,@Apellidos,@FechaNacimiento,@Direccion,@Foto,@Telefono,@IDDepartamento)", conn);

            cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
            cmd.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Direccion", (object?)persona.Direccion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Foto", (object?)persona.Foto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefono", (object?)persona.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IDDepartamento", (object?)persona.IDDepartamento ?? DBNull.Value);

            conn.Open();
            var newId = (int)cmd.ExecuteScalar();
            return new Persona(newId, persona.Nombre, persona.Apellidos, persona.FechaNacimiento,
                               persona.Direccion, persona.Foto, persona.Telefono, persona.IDDepartamento);
        }

        public Persona EditPersona(Persona personaEditada)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand(@"
                UPDATE Persona 
                SET Nombre=@Nombre, Apellidos=@Apellidos, Direccion=@Direccion, Foto=@Foto, Telefono=@Telefono, IDDepartamento=@IDDepartamento 
                WHERE ID=@ID", conn);

            cmd.Parameters.AddWithValue("@Nombre", personaEditada.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", personaEditada.Apellidos);
            cmd.Parameters.AddWithValue("@Direccion", (object?)personaEditada.Direccion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Foto", (object?)personaEditada.Foto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefono", (object?)personaEditada.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IDDepartamento", (object?)personaEditada.IDDepartamento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ID", personaEditada.ID);

            conn.Open();
            cmd.ExecuteNonQuery();
            return personaEditada;
        }
    }
}
