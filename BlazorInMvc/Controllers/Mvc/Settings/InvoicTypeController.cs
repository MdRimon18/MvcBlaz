using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorInMvc.Controllers.Mvc.Settings
{
    public class InvoicTypeController : Controller
    {
        private readonly InvoiceTypeService _invoiceTypeService;
        public InvoicTypeController(InvoiceTypeService invoiceTypeService)
        {
            _invoiceTypeService= invoiceTypeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("Index2",new List<InvoiceType>()); // Return partial view for AJAX requests
            }

            return View("Index2",new List<InvoiceType>());
            
        }
        public async Task<IActionResult> LoadTable(int page = 1,
            int pageSize = 10, string search = "",  
            string sortColumn = "InvoiceTypeId",
            string sortDirection = "desc")
        {
            var invoiceTypes = await _invoiceTypeService.GetInvoiceTypesAsync(page, pageSize, search, sortColumn, sortDirection);
            int totalRecords = invoiceTypes.Any() ? invoiceTypes.First().TotalCount : 0;
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var viewModel = new InvoiceTypeViewModel
            {
                InvoiceTypes = invoiceTypes,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                Search = search,
                SortColumn = sortColumn,
                SortDirection = sortDirection
            };

            return PartialView("_InvoiceList", viewModel);
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
                    var model = await _invoiceTypeService.DeleteByKey(id);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> ManageInvoiceType([FromBody] InvoiceType request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, errors = ModelState });
            }

            if (request.InvoiceTypeId > 0)
            {
                var invoiceType = await _invoiceTypeService.GetById(request.InvoiceTypeId);
                if (invoiceType == null)
                {
                    return NotFound(new { success = false, message = "Invoice type not found" });
                }

                invoiceType.InvoiceTypeName = request.InvoiceTypeName;
                invoiceType.LanguageId = 1; // Replace with actual language ID

                var isUpdated = await _invoiceTypeService.Update(invoiceType);
                if (isUpdated)
                {
                    return Json(new { success = true });
                }
                return BadRequest(new { success = false, message = "Failed to update invoice type" });
            }
            else
            {
                var invoiceType = new InvoiceType
                {
                    InvoiceTypeName = request.InvoiceTypeName,
                    EntryDateTime = DateTime.Now,
                };

                var invoiceTypeId = await _invoiceTypeService.Save(invoiceType);
                if (invoiceTypeId > 0)
                {
                    return Json(new { success = true });
                }
                return BadRequest(new { success = false, message = "Failed to create invoice type" });
            }
        }
    }
}
