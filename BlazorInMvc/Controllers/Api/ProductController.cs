using Azure;
using Domain.CommonServices;
using Domain.Entity.Inventory;
using Domain.Entity.Settings;
using Domain.Helper;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Net;

namespace BlazorInMvc.Controllers.Api
{
   // [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductMediaService _productMediaService;
        private readonly ProductSpecificationService _productSpecificationService;
        private readonly ProductService _productService;
        private readonly ProductVariantService _productVariantService;
        public ProductController(ProductMediaService productMediaService,
            ProductSpecificationService productSpecificationService,
            ProductService productService, ILogger<ProductController> logger, ProductVariantService productVariantService)
        {
            _productMediaService = productMediaService;
            _productSpecificationService = productSpecificationService;
            _productService = productService;
            _logger = logger;
            _productVariantService = productVariantService;
        }
        [HttpGet]
        [Route("api/GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var product_list = (await _productService.Get(null, null, null, null, null,
                            null, null, null, null, null, null, null,
                            null, null, null, null, GlobalPageConfig.PageNumber,
                            GlobalPageConfig.PageSize)).ToList();
                //var productImage = await _productMediaService.GetById(productMediaId);
                //if (productImage == null)
                //{
                //    return NotFound(new { isSuccess = false, message = "Product image not found" });
                //}
                return Ok(new
                {
                    product_list,
                    code = HttpStatusCode.OK,
                    message = "Success",
                    isSuccess = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving Products with");
                var errorDetails = new
                {
                    Message = ex.Message,
                    InnerException = ex.InnerException?.Message
                };
                return StatusCode(500, new
                {
                    code = HttpStatusCode.InternalServerError,
                    message = "An error occurred while processing your request.",
                    details = errorDetails, // Optional: You can include this for debugging purposes.
                    isSuccess = false
                });
            }
        }
        [HttpGet]
        [Route("api/v1/Product/GetProductsWithExpandingVariants")]
        public async Task<IActionResult> GetProductByExpandingVariants(string? search, int page, int pageSize)
        {
            try
            {
                if (page <= 0) page = 1;
                if (pageSize <= 0) pageSize = 10;
                var product_list = (await _productService.Get(null, null, null, null, null,
                            null, null, null, null, null, null, null,
                            null, null, null, null, page,
                            pageSize)).ToList();
                foreach (var item in product_list)
                {
                    item.ProductVariants = (await _productVariantService.Get(null, item.ProductId, null, null, null, null, null, 1, 500)).ToList();
                }
                if (product_list.Count == 0)
                {
                    return Ok(new
                    {
                        items = product_list,
                        currentPage = page,
                        totalPages = 0,
                        totalRecord = 0
                    });
                }
                var totalRecord = product_list[0].total_row;
                var totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

                return Ok(new
                {
                    items = product_list,
                    currentPage = page,
                    totalPages,
                    totalRecord
                });
                //var productImage = await _productMediaService.GetById(productMediaId);
                //if (productImage == null)
                //{
                //    return NotFound(new { isSuccess = false, message = "Product image not found" });
                //}
                 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving Products with");
                var errorDetails = new
                {
                    Message = ex.Message,
                    InnerException = ex.InnerException?.Message
                };
                return StatusCode(500, new
                {
                    code = HttpStatusCode.InternalServerError,
                    message = "An error occurred while processing your request.",
                    details = errorDetails, // Optional: You can include this for debugging purposes.
                    isSuccess = false
                });
            }
        }

        [HttpGet]
        [Route("api/GetProductsWithVariants")]
        public async Task<IActionResult> GetProductsWithVariants()
        {
            try
            {
                var product_list = (await _productService.GetProductWithVariants(null, null, null, null, null,
                            null, null, null, null, null, null, null,
                            null, null, null, null, GlobalPageConfig.PageNumber,
                            GlobalPageConfig.PageSize)).ToList();
                //var productImage = await _productMediaService.GetById(productMediaId);
                //if (productImage == null)
                //{
                //    return NotFound(new { isSuccess = false, message = "Product image not found" });
                //}
                return Ok(new
                {
                    product_list,
                    code = HttpStatusCode.OK,
                    message = "Success",
                    isSuccess = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving Products with");
                var errorDetails = new
                {
                    Message = ex.Message,
                    InnerException = ex.InnerException?.Message
                };
                return StatusCode(500, new
                {
                    code = HttpStatusCode.InternalServerError,
                    message = "An error occurred while processing your request.",
                    details = errorDetails, // Optional: You can include this for debugging purposes.
                    isSuccess = false
                });
            }
        }



        [HttpPost]
        [Route("api/Product/SaveProductImage")]
        public async Task<IActionResult> SaveProductImage([FromForm] ProductImage model)
        {
            List<ProductImage> productImages = new List<ProductImage>(); 
            if (model.file != null || model.file?.Length> 0)
            {
                // Get the base URL
                var request = HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}";

                string extension = Path.GetExtension(model.file.FileName);
                var bytes = await new MediaHelper().GetBytes(model.file);

                // Upload file and get its relative path
                var relativePath = MediaHelper.UploadAnyFile(bytes, "/Content/Images", extension);

                model.ImageUrl = baseUrl + relativePath;
                
            }

            try
            {
                long responseId = await _productMediaService.SaveOrUpdate(model);
                model.ProductMediaId = responseId;

                productImages=(List<ProductImage>)await _productMediaService.Get(null, null, model.ProductId, null);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    code = HttpStatusCode.InternalServerError,
                    message = "An error occurred while saving the product image. Please try again later.",
                    isSuccess = false
                });
            }

            return Ok(new
            {
                Data = new
                {
                    productImages
                },
                code = HttpStatusCode.OK,
                message = "Success",
                isSuccess = true
           });
        }
        
        [HttpGet]
        [Route("api/Product/GetProductImageById")]
        public async Task<IActionResult> GetProductImageById(long productMediaId)
        {
            var productImage = await _productMediaService.GetById(productMediaId);
            if (productImage == null)
            {
                return NotFound(new { isSuccess = false, message = "Product image not found" });
            }

            return Ok(new
            {
                isSuccess = true,
                data = productImage
            });
        }

        [HttpDelete]
        [Route("api/Product/DeleteProductImage")]
        public async Task<IActionResult> DeleteProductImage(long productMediaId)
        {
            if (productMediaId <=0)
            {
                return BadRequest(new { isSuccess = false, message = "Invalid ProductMediaId." });
            }

            try
            {
                var result = await _productMediaService.DeleteImageItem(productMediaId);
                if (result)
                {
                    return Ok(new { isSuccess = true, message = "Product image deleted successfully." });
                }
                else
                {
                    return NotFound(new { isSuccess = false, message = "Product image not found." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception (using a logging library or framework)
                return StatusCode(500, new { isSuccess = false, message = "An error occurred while deleting the product image.", details = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/Product/AddSpecification")]
        public async Task<IActionResult> AddSpecification([FromBody] ProductSpecifications specification)
        {
            long responseId = 0;
            if (ModelState.IsValid)
            {
                List<ProductSpecifications> specification_list = new List<ProductSpecifications>();
                try
                {
                    responseId= await _productSpecificationService.SaveOrUpdate(specification);
                  specification_list= (await _productSpecificationService.Get(null, null, specification.ProductId, null, null,GlobalPageConfig.PageNumber,
                        GlobalPageConfig.PageSize)).ToList();

                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new
                    {
                        code = HttpStatusCode.InternalServerError,
                        message = "An error occurred while saving the Product Specification. Please try again later.",
                        isSuccess = false
                    });

                }
                        

                return Ok(new
                {
                    Data = new
                    {
                        specification_list 
                      
                    },
                    code = HttpStatusCode.OK,
                    message = "Success",
                    isSuccess = true,
                    responseId = responseId

                });
            }

            // Return failure response
            return BadRequest(new { success = false, message = "Invalid data!" });
        }

        [HttpDelete]
        [Route("api/Product/DeleteSpecification")]
        public async Task<IActionResult> DeleteSpecification(long id)
        {
            try
            {
                bool isDeleted = await _productSpecificationService.Delete(id);
                if (isDeleted)
                {
                    return Ok(new
                    {
                        code = HttpStatusCode.OK,
                        message = "Specification deleted successfully.",
                        isSuccess = true
                    });
                }

                return NotFound(new
                {
                    code = HttpStatusCode.NotFound,
                    message = "Specification not found.",
                    isSuccess = false
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    code = HttpStatusCode.InternalServerError,
                    message = "An error occurred while deleting the specification.",
                    isSuccess = false
                });
            }
        }


        [HttpGet]
        [Route("api/Product/categories")]
        public IActionResult GetCategories()
        {
            var categories = new List<object>
            {
                new { Id = "free", Name = "Free", Icon = "fas fa-file-alt" },
                new { Id = "paid", Name = "Paid", Icon = "fas fa-file-invoice-dollar" },
                new { Id = "on-sale", Name = "On Sale", Icon = "fas fa-tags" }
            };

            return Ok(categories);
        }

        [HttpGet]
        [Route("api/Product/subjects")]
        public IActionResult GetSubjects()
        {
            var subjects = new List<object>
            {
                new { Id = "design", Name = "Design", Icon = "fas fa-brush" },
                new { Id = "web-development", Name = "Web Development", Icon = "fas fa-globe" },
                new { Id = "software", Name = "Software", Icon = "fas fa-code" },
                new { Id = "business", Name = "Business", Icon = "fas fa-balance-scale-left" },
                new { Id = "miscellaneous", Name = "Miscellaneous", Icon = "fas fa-thumbtack" }
            };

            return Ok(subjects);
        }

        [HttpPost]
        [Route("api/Product/filter-products")]
        public IActionResult GetFilteredProducts([FromBody] FilterModel filters)
        {
            // Dummy data
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "UI Design Basics", Price = 0, Category = "Free", Subject = "Design" },
            new Product { Id = 2, Name = "Advanced Web Dev", Price = 49.99, Category = "Paid", Subject = "Web Development" },
            new Product { Id = 3, Name = "Business Strategy", Price = 29.99, Category = "On Sale", Subject = "Business" },
            new Product { Id = 4, Name = "Software Patterns", Price = 39.99, Category = "Paid", Subject = "Software" }
        };

            // Filter logic
            var filtered = products.Where(p =>
                (filters.Free && p.Category == "Free") ||
                (filters.Paid && p.Category == "Paid") ||
                (filters.OnSale && p.Category == "On Sale") ||
                (filters.Subjects?.Contains(p.Subject) == true)
                ).ToList();

            return Ok(new FilterResult
            {
                Products = filtered,
                ActiveFilters = GetActiveFilters(filters)
            });
        }

        private List<string> GetActiveFilters(FilterModel filters)
        {
            var active = new List<string>();
            if (filters.Free) active.Add("Free");
            if (filters.Paid) active.Add("Paid");
            if (filters.OnSale) active.Add("On Sale");
            if (filters.Subjects?.Any() == true) active.AddRange(filters.Subjects);
            return active;
        }


        [HttpGet]
        [Route("api/Product/filters")]
        public async Task<IActionResult> GetFilters()
        {
            var product_list = (await _productService.Get(null, null, null, null, null,
                            null, null, null, null, null, null, null,
                            null, null, null, null, GlobalPageConfig.PageNumber,
                            GlobalPageConfig.PageSize)).ToList();

            var categories = product_list
                .GroupBy(p => p.ProdCtgName)
                .Select(g => new { Name = g.Key, Count = g.Count() })
             .Where(w => w.Name is not null).ToList();

            var brands = product_list
                .GroupBy(p => p.BrandName)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .Where(w => w.Name is not null).ToList();

            return Ok(new { categories, brands });
        }
    }
    public class FilterModel
    {
        public bool Free { get; set; }
        public bool Paid { get; set; }
        public bool OnSale { get; set; }
        public List<string> Subjects { get; set; }
    }

    public class FilterResult
    {
        public List<Product> Products { get; set; }
        public List<string> ActiveFilters { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Subject { get; set; }
    }
}
