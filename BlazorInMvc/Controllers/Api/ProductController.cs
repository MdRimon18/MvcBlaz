using Azure;
using Domain.CommonServices;
using Domain.Entity.Inventory;
using Domain.Entity.Settings;
using Domain.Helper;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
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
        public ProductController(ProductMediaService productMediaService,
            ProductSpecificationService productSpecificationService,
            ProductService productService, ILogger<ProductController> logger)
        {
            _productMediaService = productMediaService;
            _productSpecificationService = productSpecificationService;
            _productService = productService;
            _logger = logger;
        }
        [HttpGet]
        [Route("api/GetProducts")]
        public async Task<IActionResult> GetProductImageById()
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


    }

}
