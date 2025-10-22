using System.Collections.Generic;
using Ejercicio3.Models.Entities;

namespace Ejercicio3.Models.DAL.Data
{
    public static class Listado
    {
        // Método que devuelve la lista de personas
     
            public static List<Persona> personas = new List<Persona>()
            {
                new Persona(1, "Sergio", "González"),
                new Persona(2, "María", "Pérez"),
                new Persona(3, "Juan", "López"),
                new Persona(4, "Ana", "Torres"),
                new Persona(5, "Luis", "Fernández"),
                new Persona(6, "Carla", "Ramírez")
            };

       
        public static Persona ObtenerPersona3()
        {
            return personas[2];
        }
    }
}