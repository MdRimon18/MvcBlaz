using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Mvc.Products
{
    public class ProductSizeController : Controller
    {
        public IActionResult Index()
        {
            return PartialView("Index");

        }
    }
}
