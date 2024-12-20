using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Mvc.Ecommerce
{
    public class EcomProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
