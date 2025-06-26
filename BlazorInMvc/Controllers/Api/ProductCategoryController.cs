using Domain.CommonServices;
using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api
{
     
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ProductCategoryService _productCategoryService;

        public ProductCategoryController(ProductCategoryService productCategoryService
          )
        {
            _productCategoryService = productCategoryService;

        }

        [HttpGet]
        [Route("api/ProductCategory/GetAll")]
        public async Task<IActionResult> GetAll(string? search, int page, int pageSize)
        {
            
            // Sending null for all filters
            var users = await _productCategoryService.FetchModelList();
            //   var test =users.Where(w=>w.Address is not null).ToList();
            if (users.Count == 0)
            {
                return Ok(new
                {
                    items = users,
                    currentPage = page,
                    totalPages = 0,
                    totalRecord = 0
                });
            }

            var totalRecord = users[0].total_row;
            var totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

            return Ok(new
            {
                items = users,
                currentPage = page,
                totalPages,
                totalRecord
            });
        }

        

    }
}
