namespace Ejercicio3.Models.Entities

{
    public class Persona
    {
        #region atributos privados
        private int id;
        private string nombre;
        private string apellidos;
        #endregion

        #region  #region getters y setters
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

        #endregion


        #region constructores
        public Persona()
        {
            this.nombre = "";
        }
        public Persona(int id, string nombre, string apellidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;

        }
        #endregion




    }
}