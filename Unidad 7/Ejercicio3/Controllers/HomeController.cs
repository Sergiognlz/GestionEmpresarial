using Ejercicio3.Models;
using Ejercicio3.Models.DAL.Data;
using Ejercicio3.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ejercicio3.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int hora = DateTime.Now.Hour;

            if (hora >= 6 && hora < 12)
                ViewBag.Saludo = "¡Buenos días!";
            else if (hora >= 12 && hora < 20)
                ViewBag.Saludo = "¡Buenas tardes!";
            else
                ViewBag.Saludo = "¡Buenas noches!";

            ViewBag.FechaLarga = DateTime.Now.ToString("D");

            // Crear un objeto clsPersona
            Persona persona = new Persona(1, "Sergio", "González");

            // Pasar el objeto a la vista como modelo
            return View(persona);


        }

        public IActionResult ListadoP3()
        {
            Persona persona  = Listado.ObtenerPersona3();

            // Pasar la lista a la vista como modelo
            return View(persona);


        }
    }
}


