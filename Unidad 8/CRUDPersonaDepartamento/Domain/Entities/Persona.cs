namespace Domain.Entities
{
    public class Persona
    {
        private int _id;
        private string _nombre;
        private string _apellidos;
        private DateTime _fechaNacimiento;
        private String _direccion;
        private String _telefono;
    

    public Persona(int id, string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _fechaNacimiento = fechaNacimiento;
            _direccion = direccion;
            _telefono = telefono;
        }


        public int getId() {
            return _id;

        }
        public string getNombre() {
            return _nombre;
        }

        public void setNombre(string nombre) {
            _nombre = nombre;
        }
        public string getApellidos() {
            return _apellidos;
        }

        public void setApellidos(string apellidos) {
            _apellidos = apellidos;
        }

        public DateTime getFechaNacimiento() {
            return _fechaNacimiento;
        }

        public string getDireccion() {
            return _direccion;
        }

        public void setDireccion(string direccion) {
            _direccion = direccion;
        }

        public string getTelefono() {
            return _telefono;

        }

        public void setTelefono(string telefono) {
            _telefono = telefono;
        }


        public String toString() {
            return "ID: " + _id + ", Nombre: " + _nombre + ", Apellidos: " + _apellidos + ", Fecha de Nacimiento: " + _fechaNacimiento.ToString("dd/MM/yyyy") + ", Direccion: " + _direccion + ", Telefono: " + _telefono;
        }



    }
}