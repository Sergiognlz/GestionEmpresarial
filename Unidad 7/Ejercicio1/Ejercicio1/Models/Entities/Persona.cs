namespace Ejercicio1.Models.Entities
{
    public class Persona
    {
        #region atributos privados
        private int id;
        private string nombre;
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
        #endregion

           
        #region constructores
        public Persona()
        {
          this.nombre="";
        }
        public Persona(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
         
        }
        #endregion




    }
}
