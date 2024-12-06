
using Microsoft.AspNetCore.Mvc;

namespace DocTimes.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index(bool isPartial = false)
        {
            // If the request is an AJAX request, return the partial view only
            //if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //{
            //    return PartialView("Index");
            //}
            if (isPartial)
            {
                return PartialView("Index");
            }
            return View("Index");
            
        }
        public IActionResult List(bool isPartial = false)
        {
            // If the request is an AJAX request, return the partial view only
            if (isPartial)
            {
                return PartialView("List");
            }

            return View();

        }
        public IActionResult PaymentHistory(bool isPartial = false)
        {
            // If the request is an AJAX request, return the partial view only
            if (isPartial)
            {
                return PartialView("List");
            }

            return View();

        }
        public IActionResult CreateProfile(bool isPartial = false)
        {
            // If the request is an AJAX request, return the partial view only
            if (isPartial)
            {
                return PartialView("CreateProfile");
            }

            return View();

        }
    }
}
