namespace ListadoPersonasCRUD.Domain.Entities
{
    public class Departamento
    {
        public int Id { get; }
        public string Nombre { get; set; }

        public Departamento(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
