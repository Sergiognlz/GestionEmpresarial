using System;
using System.Collections.Generic;
using Ejercicio4.Models.Entities;

namespace Ejercicio4.Models.DAL.Data
{
    public static class ListadoDepartamentos
    {
        // Lista estática de departamentos
        public static List<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento(1, "Recursos Humanos"),
            new Departamento(2, "Finanzas"),
            new Departamento(3, "Tecnología"),
            new Departamento(4, "Marketing"),
            new Departamento(5, "Ventas"),
            new Departamento(6, "Legal"),
            new Departamento(7, "Operaciones"),
            new Departamento(8, "Atención al Cliente")
        };

        // Método para obtener un departamento aleatorio
        public static Departamento ObtenerDepartamentoAleatorio()
        {
            Random rnd = new Random();
            int index = rnd.Next(departamentos.Count);
            return departamentos[index];
        }

        // Método opcional para obtener toda la lista
        public static List<Departamento> ObtenerTodos()
        {
            return new List<Departamento>(departamentos); // Devuelve una copia para proteger la lista original
        }
        
    }
     

}
