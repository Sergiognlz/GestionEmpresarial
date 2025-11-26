using System.Diagnostics;
using Madaloriano.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presenters.UI.Controllers
{
    public class MisionController : Controller
    {
        private readonly ILogger<MisionController> _logger;

        public MisionController(ILogger<MisionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
