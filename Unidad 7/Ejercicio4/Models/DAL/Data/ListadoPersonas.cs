using System.Collections.Generic;
using Ejercicio4.Models.Entities;

namespace Ejercicio4.Models.DAL.Data
{
    public static class ListadoPersonas
    {
        // Método que devuelve la lista de personas
     
            public static List<Persona> personas = new List<Persona>()
            {
                new Persona(1, "Sergio", "González",3),
                new Persona(2, "María", "Pérez",1),
                new Persona(3, "Juan", "López",2),
                new Persona(4, "Ana", "Torres",5),
                new Persona(5, "Luis", "Fernández",6),
                new Persona(6, "Carla", "Ramírez",8)
            };

       
        public static Persona ObtenerPersona3()
        {
            Random rnd = new Random();
            int index = rnd.Next(personas.Count); // Genera un índice entre 0 y personas.Count - 1
            return personas[index];
        }

        public static Persona ObtenerPersonaAleatoria()
        {
            Random rnd = new Random();
            int index = rnd.Next(personas.Count); // Genera un índice entre 0 y personas.Count - 1
            return personas[index];
        }
    }
}