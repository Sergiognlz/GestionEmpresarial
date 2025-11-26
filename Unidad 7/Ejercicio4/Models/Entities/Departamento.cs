namespace Ejercicio4.Models.Entities

{
    public class Departamento
    {
        #region atributos privados
        private int idDepartamento;
        private string nombreDepartamento;
     
        #endregion

        #region  #region getters y setters
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }

        public string NombreDepartamento
        {
            get { return nombreDepartamento; }
            set { nombreDepartamento = value; }
        }
     

        #endregion



        #region constructores
      
        public Departamento() {     
            this.nombreDepartamento = "";

        }


        public Departamento(int idDepartamento, string nombreDepartamento)
        {
            this.idDepartamento = idDepartamento;
            this.nombreDepartamento = nombreDepartamento;
        }


        #endregion




    }
}