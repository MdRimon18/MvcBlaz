using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Mvc.Supplier
{
    public class SupplierController : Controller
    {
        private readonly SupplierService _supplierService;
        private readonly CountryServiceV2 _countryServiceV2;
        private readonly BusinessTypesService _businessTypesService;

        public SupplierController(SupplierService supplierService, CountryServiceV2 countryServiceV2, BusinessTypesService businessTypesService)
        {
            _supplierService = supplierService;
            _countryServiceV2 = countryServiceV2;
            _businessTypesService = businessTypesService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid? key)
        {
            var model = new Suppliers();
            ViewBag.SubmitButtonText = key.HasValue ? "Update" : "Create";
            ViewBag.CountryList = (await _countryServiceV2.Get(null, null, null, null, null, null, null, null, null, null, 1, 1000)).ToList();
            ViewBag.BusinessTypesList = (await _businessTypesService.Get(null, null, null, null, 1, 1000)).ToList();

            if (key.HasValue)
            {
                model = await _supplierService.GetByKey(key.ToString());
                if (model == null)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(Suppliers supplier, IFormFile SupplrImgLink)
        {
            if (ModelState.IsValid)
            {
                if (SupplrImgLink != null)
                {
                    // Handle file upload
                    var filePath = Path.Combine("wwwroot/assets/SupplierImage", SupplrImgLink.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await SupplrImgLink.CopyToAsync(stream);
                    }
                    supplier.SupplrImgLink = $"/assets/SupplierImage/{SupplrImgLink.FileName}";
                }

                if (supplier.SupplierId == 0)
                {
                    supplier.EntryDateTime = DateTime.Now;
                    supplier.EntryBy = 1; // Replace with actual user ID
                    supplier.BranchId = 1; // Replace with actual branch ID
                    await _supplierService.SaveOrUpdate(supplier);
                }
                else
                {
                    supplier.LastModifyDate = DateTime.Now;
                    supplier.LastModifyBy = 1; // Replace with actual user ID
                    await _supplierService.SaveOrUpdate(supplier);
                }

                return RedirectToAction("Index");
            }

            ViewBag.CountryList = (await _countryServiceV2.Get(null, null, null, null, null, null, null, null, null, null, 1, 1000)).ToList();
            ViewBag.BusinessTypesList = (await _businessTypesService.Get(null, null, null, null, 1, 1000)).ToList();
            ViewBag.SubmitButtonText = supplier.SupplierId == 0 ? "Create" : "Update";
            return View("Edit", supplier);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.Get(null, null, null, null, null, null, 1, 10);
            return View(suppliers);
        }
    }
}
