using Ejercicio4.Models;
using Ejercicio4.Models.DAL.Data;
using Ejercicio4.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ejercicio4.Controllers
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
            Persona persona = new Persona(1, "Sergio", "González", 3);

            // Pasar el objeto a la vista como modelo
            return View(persona);


        }

        public IActionResult ListadoP3()
        {
            Persona persona  = ListadoPersonas.ObtenerPersona3();

            // Pasar la lista a la vista como modelo
            return View(persona);


        }

        public IActionResult ListadoAleatorio() {
            Persona persona = ListadoPersonas.ObtenerPersonaAleatoria();

            // Pasar la lista a la vista como modelo
            return View(persona);
        }
}}


