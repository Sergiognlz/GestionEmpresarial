using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mision
    {
        private int id;
        private string nombre;
        private string descripcion;
        private double recompensa;

   

    public Mision(int id, string nombre, string descripcion, double recompensa)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.recompensa = recompensa;
        }




    } }
