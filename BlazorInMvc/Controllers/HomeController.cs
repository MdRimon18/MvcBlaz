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

        public IActionResult SignUp(bool isPartial = false)
        {
           

            if (isPartial)
            {
                return PartialView("SignUp");
            }

            return View();
        }
        public IActionResult Login(bool isPartial = false)
        {


            if (isPartial)
            {
                return PartialView("Login");
            }

            return View();
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetOrderDetails()
        {
            var orderDetails = new
            {
                OrderId = "ORD123456",
                EstimatedDelivery = "3-5 Business Days",
                PaymentStatus = "Paid"
            };
            return Json(orderDetails);
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
