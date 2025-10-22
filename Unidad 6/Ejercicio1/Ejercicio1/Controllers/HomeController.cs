using System.Diagnostics;
using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    namespace HolaMundoMVC.Controllers
    {
        public class HomeController : Controller
        {
            // Acción Index
            public ActionResult Index()
            {
                ViewBag.Mensaje = "¡Hola Mundo!"; // Pasamos el mensaje a la vista
                return View();
            }
        }
    }
}