
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
            using (var conn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("SELECT Id, Nombre, Apellido, FechaNacimiento, Direccion, Telefono, DepartamentoId FROM Persona", conn))
            {
                conn.Open();
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Persona(
                        rdr.GetInt32(0),
                        rdr.GetString(1),
                        rdr.GetString(2),
                        rdr.GetDateTime(3),
                        rdr.IsDBNull(4) ? null : rdr.GetString(4),
                        rdr.IsDBNull(5) ? null : rdr.GetString(5),
                        rdr.IsDBNull(6) ? (int?)null : rdr.GetInt32(6)
                    ));
                }
            }
            return list;
        }

        public Persona? GetPersonaById(int id)
        {
            using (var conn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("SELECT Id, Nombre, Apellido, FechaNacimiento, Direccion, Telefono, DepartamentoId FROM Persona WHERE Id = @Id", conn))
            {
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
                        rdr.IsDBNull(6) ? (int?)null : rdr.GetInt32(6)
                    );
                }
            }
            return null;
        }

        public int DeletePersona(int id)
        {
            using (var conn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("DELETE FROM Persona WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public Persona CreatePersona(Persona persona)
        {
            using (var conn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("INSERT INTO Persona (Nombre, Apellido, FechaNacimiento, Direccion, Telefono, DepartamentoId) OUTPUT INSERTED.Id VALUES (@Nombre,@Apellido,@FechaNacimiento,@Direccion,@Telefono,@DepartamentoId)", conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Direccion", (object?)persona.Direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", (object?)persona.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartamentoId", (object?)persona.DepartamentoId ?? DBNull.Value);

                conn.Open();
                var newId = (int)cmd.ExecuteScalar();
                return new Persona(newId, persona.Nombre, persona.Apellido, persona.FechaNacimiento, persona.Direccion, persona.Telefono, persona.DepartamentoId);
            }
        }

        public Persona EditPersona(Persona personaEditada)
        {
            using (var conn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("UPDATE Persona SET Nombre=@Nombre, Apellido=@Apellido, Direccion=@Direccion, Telefono=@Telefono, DepartamentoId=@DepartamentoId WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", personaEditada.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", personaEditada.Apellido);
                cmd.Parameters.AddWithValue("@Direccion", (object?)personaEditada.Direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", (object?)personaEditada.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartamentoId", (object?)personaEditada.DepartamentoId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", personaEditada.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
                // Devolver la entidad actualizada (puedes volver a consultar si necesitas campos calculados)
                return personaEditada;
            }
        }
    }
}
