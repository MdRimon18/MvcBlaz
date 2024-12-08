using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Mvc
{
    public class UnitController : Controller
    {
        public IActionResult Index(bool isPartial = false)
        {
            if (isPartial)
            {
                return PartialView("Index");
            }
            return View("Index");

        }
    }
}
