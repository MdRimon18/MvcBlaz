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
        private readonly ProductMediaService _productMediaService;
        private readonly ProductSpecificationService _productSpecificationService;
        public EcomProductsController(IMemoryCache cache,
            ProductService ProductService,
            ProductVariantService productVariantService,
             ProductMediaService productMediaService,
             ProductSpecificationService productSpecificationService)
        {
            _cache = cache;
            _productService = ProductService;  
            _productVariantService= productVariantService;
            _productMediaService = productMediaService;
            _productSpecificationService = productSpecificationService;
        }
        public async Task<IActionResult> Index(bool isPartial = false)
        {
            var list  = await FetchModelList();
      // var list2 =list.Where(x => x.VariantImageUrl is not null);
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
        public async Task<IActionResult> Details(string key)
        {
           var product =   await  _productService.GetByKey(key);
            if(product is not null)
            {
                product.ProductVariants = (await _productVariantService.Get(null, product.ProductId,
                  null, null, null, null,
                  null, GlobalPageConfig.PageNumber,
                 GlobalPageConfig.PageSize)).ToList();


                product.ProductImages = (await _productMediaService.Get(null, null, product.ProductId, null)).ToList();
                product.Specification_list = (await _productSpecificationService.Get(null, null, product.ProductId, null, null, GlobalPageConfig.PageNumber, GlobalPageConfig.PageSize)).ToList();
            }

            return View(product);
        }
    }
}
