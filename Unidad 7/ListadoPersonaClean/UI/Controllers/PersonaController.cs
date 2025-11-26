using DOMAIN.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComprobarConexion([FromServices] IConnectionCheckUseCase connectionCheckUseCase)
        {
            string estado = connectionCheckUseCase.CheckConnection();
            ViewBag.EstadoConexion = estado;
            return View("Index");
        }
    }
}
