using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Mvc.Settings
{
    public class InvoicTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("Index2"); // Return partial view for AJAX requests
            }

            return View("Index2");
            
        }


    }
}
