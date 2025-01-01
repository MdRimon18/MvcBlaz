using Domain.Entity.Inventory;
using Domain.Helper;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Net;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductMediaService _productMediaService;
        public ProductController(ProductMediaService productMediaService)
        {
            _productMediaService = productMediaService;
        }

        [HttpPost("SaveProductImage")]
        public async Task<IActionResult> SaveProductImage([FromForm] ProductImage model)
        {
             
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
                    model
                },
                code = HttpStatusCode.OK,
                message = "Success",
                isSuccess = true
           });
        }
        
        [HttpGet("GetProductImageById")]
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

    }
}
