namespace Formulario.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }


        

        public int CalcularEdad()
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }
    }
}
