using System.Collections.Generic;
using Ejercicio2.Models.Entities;

namespace Ejercicio2.Models.DAL.Data
{
    public static class Listado
    {
        // Método que devuelve la lista de personas
        public static List<Persona> ObtenerListado()
        {
            List<Persona> personas = new List<Persona>()
            {
                new Persona(1, "Sergio", "González"),
                new Persona(2, "María", "Pérez"),
                new Persona(3, "Juan", "López"),
                new Persona(4, "Ana", "Torres"),
                new Persona(5, "Luis", "Fernández"),
                new Persona(6, "Carla", "Ramírez")
            };

            return personas;
        }
    }
}