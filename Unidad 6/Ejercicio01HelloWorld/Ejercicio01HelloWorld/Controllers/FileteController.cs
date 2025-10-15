using Microsoft.AspNetCore.Mvc;

namespace Ejercicio01HelloWorld.Controllers
{
    public class FileteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Empanado()
        {
            return View();
        }
    }
}
