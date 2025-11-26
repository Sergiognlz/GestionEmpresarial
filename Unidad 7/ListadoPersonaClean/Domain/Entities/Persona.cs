namespace Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Persona(int id, string nombre, string apellido, DateTime fecha, String direccion, String telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fecha;
            this.Direccion = direccion;
            this.Telefono = telefono;

        }

        

        public int CalcularEdad()
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }
    }
}
