using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Departamento
    {
       
            // Propiedad para el ID del departamento
            public int ID { get; set; }

            // Propiedad para el nombre del departamento
            public string Nombre { get; set; }

            // Constructor vacío opcional
            public Departamento() { }

            // Constructor con parámetros opcional
            public Departamento(int id, string nombre)
            {
                ID = id;
                Nombre = nombre;
            }
        }

    }

