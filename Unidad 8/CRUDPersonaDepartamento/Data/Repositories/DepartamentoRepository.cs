using ListadoPersonasCRUD.Data.DataBase;
using ListadoPersonasCRUD.Domain.Entities;
using ListadoPersonasCRUD.Domain.RepositoriesInterfaces;
using Microsoft.Data.SqlClient;

namespace ListadoPersonasCRUD.Data.Repositories
{
    public class DepartamentosRepository : IDepartamentoRepository
    {
        private readonly Conection _coneccion;
        private readonly string _cs;

        public DepartamentosRepository(Conection coneccion)
        {
            _coneccion = coneccion;
            _cs = _coneccion.GetConnectionString();
        }

        public List<Departamento> GetListadoDepartamento()
        {
            var list = new List<Departamento>();
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("SELECT Id, Nombre FROM Departamento", conn);
            conn.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Departamento(rdr.GetInt32(0), rdr.GetString(1)));
            }
            return list;
        }

        public Departamento? GetDepartamentoById(int id)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("SELECT Id, Nombre FROM Departamento WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            using var rdr = cmd.ExecuteReader();
            if (rdr.Read()) return new Departamento(rdr.GetInt32(0), rdr.GetString(1));
            return null;
        }

        public int DeleteDepartamento(int id)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("DELETE FROM Departamento WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public Departamento CreateDepartamento(Departamento departamento)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand(
                "INSERT INTO Departamento (Nombre) OUTPUT INSERTED.Id VALUES (@Nombre)", conn);
            cmd.Parameters.AddWithValue("@Nombre", departamento.Nombre);
            conn.Open();
            var newId = (int)cmd.ExecuteScalar();
            return new Departamento(newId, departamento.Nombre);
        }

        public Departamento EditDepartamento(Departamento departamento)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("UPDATE Departamento SET Nombre=@Nombre WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Nombre", departamento.Nombre);
            cmd.Parameters.AddWithValue("@Id", departamento.ID);
            conn.Open();
            cmd.ExecuteNonQuery();
            return departamento;
        }

        // Contar personas en un departamento para validaciones antes de eliminar
        public int ContarPersonasDept(int idDepartamento)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("SELECT COUNT(1) FROM Persona WHERE IDDepartamento = @DeptId", conn);
            cmd.Parameters.AddWithValue("@DeptId", idDepartamento);
            conn.Open();
            return (int)cmd.ExecuteScalar();
        }
    }
}
