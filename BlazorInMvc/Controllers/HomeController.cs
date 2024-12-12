using BlazorInMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlazorInMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string component = null, bool isPartial = false)
        {
            ViewData["Component"] = component;

            if (isPartial)
            {
                return PartialView("Index");
            }

            return View();
        }


        public IActionResult Privacy()
        {
            return PartialView("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
