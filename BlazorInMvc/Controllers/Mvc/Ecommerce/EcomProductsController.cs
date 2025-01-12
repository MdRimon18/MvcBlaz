using Domain.CommonServices;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BlazorInMvc.Controllers.Mvc.Ecommerce
{
    public class EcomProductsController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ProductService _productService;
        public EcomProductsController(IMemoryCache cache,
            ProductService ProductService)
        {
            _cache = cache;
            _productService = ProductService;   
        }
        public async Task<IActionResult> Index(bool isPartial = false)
        {
            var list  = await FetchModelList();
            if (isPartial)
            {
                return PartialView("Index", list);
            }
            return View("Index", list);
        }
        public async Task<List<Domain.Entity.Settings.Products>> FetchModelList(int? pageSize=9)
        {
            
            var list = (await _productService.Get(null, null, null, null, null,
                null, null, null, null, null, null, null,
                null, null, null, null, GlobalPageConfig.PageNumber,
                pageSize)).ToList();

            return list.ToList(); // Convert and return as List<Unit>
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
