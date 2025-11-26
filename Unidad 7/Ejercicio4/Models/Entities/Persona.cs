namespace Ejercicio4.Models.Entities
{
    public class Persona
    {
        #region Atributos privados
        private int id;
        private string nombre;
        private string apellidos;
        private int idDepartamento;
        #endregion

        #region Getters y Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
        #endregion

        #region Constructores
        public Persona()
        {
            this.nombre = "";
        }

        public Persona(int id, string nombre, string apellidos, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idDepartamento = idDepartamento;
        }
        #endregion
    }
}
