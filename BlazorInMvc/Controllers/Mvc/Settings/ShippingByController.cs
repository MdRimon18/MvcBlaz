using Azure.Core;
using Domain.CommonServices;
using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Mvc.Settings
{
    public class ShippingByController : Controller
    {

        private readonly ShippingByService _shippingByService;
        public ShippingByController(ShippingByService shippingByService)
        {
            _shippingByService = shippingByService;
        }

        public IActionResult Index()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("Index",new List<ShippingBy>()); // Return partial view for AJAX requests
            }

            return View("Index",new List<ShippingBy>());

        }
        public async Task<IActionResult> LoadTable(int page = 1,
           int pageSize = 10, string search = "",
           string sortColumn = "ShippingById",
           string sortDirection = "desc")
        {
            var shippingBy = await _shippingByService.GetShippingByAsync(page, pageSize, search, sortColumn, sortDirection);
            int totalRecords = shippingBy.Any() ? shippingBy.First().TotalCount : 0;
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var viewModel = new ShippingByViewModel
            {
                ShippingByList = shippingBy, // Corrected property name to match the ViewModel
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                Search = search,
                SortColumn = sortColumn,
                SortDirection = sortDirection
            };

            return PartialView("_ShippingList", viewModel);
        }
        [HttpGet]
        public async Task<bool> RemoveData(Guid id)
        {

            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                else
                {
                    var model = await _shippingByService.DeleteByKey(id);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> ManageShippingBy([FromBody] ShippingBy request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, errors = ModelState });
            }

            if (request.ShippingById > 0)
            {
                var shippingBy = await _shippingByService.GetById(request.ShippingById);
                if (shippingBy == null)
                {
                    return NotFound(new { success = false, message = MessageManager.NotFound });
                }

                shippingBy.ShippingByName = request.ShippingByName;
                shippingBy.LanguageId = 1; // Replace with actual language ID

                var isUpdated = await _shippingByService.Update(shippingBy);
                if (isUpdated)
                {
                    return Json(new { success = true, message = $"{request.ShippingByName} {MessageManager.UpdateSuccess}" });
                }
                return BadRequest(new { success = false, message = MessageManager.UpdateFaild });
            }
            else
            {
                var shippingBy = new ShippingBy
                {
                    ShippingByName = request.ShippingByName,
                    EntryDateTime = DateTime.Now,
                };

                var ShippingById = await _shippingByService.Save(shippingBy);
                if (ShippingById > 0)
                {
                    return Json(new { success = true, message = $"{request.ShippingByName} {MessageManager.SaveSuccess}" });
                }
                if (ShippingById == -1)
                {
                    return Json(new { success = false, message = $"{request.ShippingByName} {MessageManager.Exist}" });
                }
                return BadRequest(new { success = false, message = MessageManager.SaveFaild });
            }
        }
    }
}

