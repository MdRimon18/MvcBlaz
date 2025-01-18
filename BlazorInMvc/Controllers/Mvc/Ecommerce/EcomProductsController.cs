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
        private readonly ProductVariantService _productVariantService;
        public EcomProductsController(IMemoryCache cache,
            ProductService ProductService,
            ProductVariantService productVariantService)
        {
            _cache = cache;
            _productService = ProductService;  
            _productVariantService= productVariantService;
        }
        public async Task<IActionResult> Index(bool isPartial = false)
        {
            var list  = await FetchModelList();
       var list2 =list.Where(x => x.VariantImageUrl is not null);
            if (isPartial)
            {
                return PartialView("Index", list);
            }
            return View("Index", list);
        }
        public async Task<List<Domain.Entity.Settings.Products>> FetchModelList(int? pageSize=100)
        {
            
            var list = (await _productService.Get(null, null, null, null, null,
                null, null, null, null, null, null, null,
                null, null, null, null, GlobalPageConfig.PageNumber,
                pageSize)).ToList();
            foreach (var item in list)
            {
                item.ProductVariants = (await _productVariantService.Get(null, item.ProductId,
                    null, null, null, null,
                    null, GlobalPageConfig.PageNumber,
                   GlobalPageConfig.PageSize)).ToList();
            }
           

            return list.ToList(); // Convert and return as List<Unit>
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
