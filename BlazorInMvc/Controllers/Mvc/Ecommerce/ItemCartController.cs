using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Mvc.Ecommerce
{
    public class ItemCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
