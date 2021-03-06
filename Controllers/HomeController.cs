using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PB_JAW.Models;
using System.Diagnostics;

namespace PB_JAW.Controllers
{
    public class HomeController : Controller
    {
        // default .NET methods for home controller
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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

        public IActionResult BathDining()
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
