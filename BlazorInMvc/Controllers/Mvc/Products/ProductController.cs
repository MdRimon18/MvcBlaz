using Domain.CommonServices;
using Domain.Entity.Settings;
using Domain.Services;
using Domain.Services.Inventory;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace BlazorInMvc.Controllers.Mvc.Products
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly UnitService _unitService;
        private readonly SupplierService _supplierService;
        private readonly CurrencyService _currencyService;
        private readonly ShippingByService _shippingByService;
        private readonly ColorService _colorService;
        private readonly CountryServiceV2 _countryServiceV2;
        private readonly StatusSettingService _statusSettingService;
        private readonly ProductSubCategoryService _productSubCategoryService;
        private readonly BrandService _brandService;
        private readonly ProductCategoryService _productCategoryService;
         
        private readonly ProductSizeService _productSizeService;
        private readonly WarehouseService _warehouseService;
        private readonly BodyPartService _bodyPartService;

        public ProductController(ProductService ProductService,
              UnitService unitService,
            SupplierService supplierService,
            CurrencyService currencyService,
            ShippingByService shippingByService,
            ColorService colorService,
            CountryServiceV2 countryServiceV2,
            StatusSettingService statusSettingService,
            ProductSubCategoryService productSubCategoryService,
            BrandService brandService,
            ProductCategoryService productCategoryService,
            ProductService productService,
            ProductSizeService productSizeService,
            WarehouseService warehouseService,
            BodyPartService bodyPartService
          )
        {
            _productService = ProductService;
            _unitService = unitService;
            _supplierService = supplierService;
            _currencyService = currencyService;
            _shippingByService = shippingByService;
            _colorService = colorService;
            _countryServiceV2 = countryServiceV2;
            _statusSettingService = statusSettingService;
            _productSubCategoryService = productSubCategoryService;
            _brandService = brandService;
            _productCategoryService = productCategoryService;
            
            _productSizeService = productSizeService;
            _warehouseService = warehouseService;
            _bodyPartService = bodyPartService;
        }


        public async Task<IActionResult> Index(bool isPartial = false)
        {
            var viewModel = new ProductViewModel();
            var model = new Domain.Entity.Settings.Products();
            model.SupplierList = (await _supplierService.Get(null, null, null, null, null, null, 1, 1000)).ToList();
            model.UnitList = (await _unitService.Get(null, null, null, null, 1, 1000)).ToList();
            model.CurrencyList = (await _currencyService.Get(null, null, null, null, null, null, null, null, 1, 1000)).ToList();
            model.ShippingByList = (await _shippingByService.Get(null, null, null, null, 1, 1000)).ToList();
            model.ColorList = (await _colorService.Get(null, null, null, null, 1, 1000)).ToList();
            model.CountryList = (await _countryServiceV2.Get(null, null, null, null, null, null, null, null, null, null, 1, 1000)).ToList();
            model.StatusSettingList = (await _statusSettingService.Get(null, null, null, null, "Product", null, 1, 1000)).ToList();
            model.ImportStatusSettingList = (await _statusSettingService.Get(null, null, null, null, null, null, 1, 1000)).ToList();
            model.ProductSubCategoryList = (await _productSubCategoryService.Get(null, null, null, null, null, 1, 1000)).ToList();
            model.BrandList = (await _brandService.Get(null, null, null, 1, 1000)).ToList();
            model.ProductCategoryList = (await _productCategoryService.Get(null, null, null, null, 1, 1000)).ToList();
            model.ProductSizeList = (await _productSizeService.Get(null, null, null, null, 1, 1000)).ToList();
            model.WarehouseList = (await _warehouseService.Get(null, null, null, null, null, null, null, null, null, 1, 1000)).ToList();
            model.BodyParts = await _bodyPartService.GetBodyPartsAsync();

            viewModel.ProductList = await FetchModelList();
            viewModel.Product = model;
            return PartialView("Index", viewModel);

        }
        public async Task<List<Domain.Entity.Settings.Products>> FetchModelList()
        {
            //var list = await _productService.Get(
            //    null,
            //    null,
            //    null,
            //    "",
            //    GlobalPageConfig.PageNumber,
            //    GlobalPageConfig.PageSize
            //);
            var list = (await _productService.Get(null, null, null, null, null,
                null, null, null, null, null, null, null, 
                null, null, null, null, GlobalPageConfig.PageNumber,
                GlobalPageConfig.PageSize)).ToList();

            return list.ToList(); // Convert and return as List<Unit>
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveOrUpdate(Domain.Entity.Settings.Products model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                // Return the AddForm partial view with validation errors
                return PartialView("_AddForm", model); // Returning partial view directly
            }

            try
            {

                long responseId = await _productService.SaveOrUpdate(model);
                if (responseId == -1)
                {
                    //model.rowsAffected = -1;
                    model.ProductId = 0;
                    Response.StatusCode = 409;
                    return PartialView("_AddForm", model); // Returning partial view directly

                }


                var list = await FetchModelList();
                // Return the _SearchResult partial view with the updated list
                return PartialView("_SearchResult", list); // Returning partial view directly
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                // In case of an error, render the AddForm partial view again
                return PartialView("_AddForm", model); // Returning partial view directly
            }
        }


        [HttpGet]
        public async Task<IActionResult> LoadEditModeData(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Domain.Entity.Settings.Products obj = (await _productService.GetById(id));

            return PartialView("_AddForm", obj);
        }
        [HttpGet]
        public async Task<IActionResult> AddNewForm()
        {
            ProductSze obj = new();
            if (obj == null)
            {
                return NotFound();
            }

            return PartialView("_AddForm", obj);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid ID provided.");
            }

            try
            {
                if (id > 0)
                {
                    var isDeleted = await _productService.Delete(id);

                }

            }
            catch (Exception)
            {
                // It's better to log the exception and provide a meaningful response to the user
                return StatusCode(500, "An error occurred while deleting the pipeline.");
            }



            var list = await FetchModelList();

            return PartialView("_SearchResult", list);


        }
    }
}
