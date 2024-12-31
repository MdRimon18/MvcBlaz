using Domain.Entity.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public ProductController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("SaveProductImage")]
        public IActionResult SaveProductImage([FromForm] ProductImage model)
        {
            //if (ModelState.IsValid)
            //{
            //    // Handle file upload
            //    if (model.file != null)
            //    {
            //        string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            //        if (!Directory.Exists(uploadsFolder))
            //        {
            //            Directory.CreateDirectory(uploadsFolder);
            //        }

            //        string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.file.FileName;
            //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //        {
            //            model.file.CopyTo(fileStream);
            //        }

            //        model.ImageUrl = $"/uploads/{uniqueFileName}";
            //    }

                // Save the model to the database (example)
                // _dbContext.ProductImages.Add(model);
                // _dbContext.SaveChanges();

                return Ok(new { message = "Product image saved successfully!", model });
           // }

            return BadRequest(ModelState);
        }
    }
}
