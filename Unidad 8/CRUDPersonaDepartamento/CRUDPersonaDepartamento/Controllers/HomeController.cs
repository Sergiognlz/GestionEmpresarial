using Microsoft.AspNetCore.Mvc;

namespace ListadoPersonasCRUD.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
