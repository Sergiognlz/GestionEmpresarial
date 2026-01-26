using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase
{
    internal class Conection
    {

        public static string GetConnectionString()
        {
            // Retorna la cadena de conexión a la base de datos
            return  "server=pruebaservidor1987;database=PersonasDB;uid=Sergio;pwd=contraseña1234@;trustServerCertificate = true;";
        }



    }
}
