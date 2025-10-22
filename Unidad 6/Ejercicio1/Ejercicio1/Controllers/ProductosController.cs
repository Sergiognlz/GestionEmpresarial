using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    
    
        public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Acción para mostrar el listado de productos
        public IActionResult ListadoProductos()
        {
            return View(); // MVC buscará la vista Views/ProductosController/ListadoProductos.cshtml
        }
    }
}
