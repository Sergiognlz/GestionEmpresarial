using Microsoft.AspNetCore.Mvc;
using System;
using Ejercicio1.Models;
using Ejercicio1.Models.Entities;   

namespace Ejercicio1.Controllers
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
            Persona persona = new Persona(1, "Sergio González");

            // Pasar el objeto a la vista como modelo
            return View(persona);
            
        }

    }
}
