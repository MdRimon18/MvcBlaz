using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api.Settings
{
   
        //[Route("api/[controller]")]
        [ApiController]

        public class ShippingByController : ControllerBase
        {
            private readonly ShippingByService _shippingByService;

            public ShippingByController(ShippingByService shippingByService)
            {
                _shippingByService = shippingByService;
            }

            [HttpGet]
            [Route("api/ShippingBy/GetAll")]
            public async Task<IActionResult> GetShippingBy(string? search, int page, int pageSize)
            {
                var shippingBy = await _shippingByService.Get(null, null, null, search, 1, 10);
                var totalRecord = shippingBy.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

                return Ok(new
                {
                    items = shippingBy,
                    currentPage = page,
                    totalPages,
                    totalRecord
                });
            }

            [HttpGet]
            [Route("api/ShippingBy/GetById")]
            public async Task<IActionResult> GetshippingBy(long id)
            {
                var shippingBy = await _shippingByService.GetById(id);
                if (shippingBy == null)
                {
                    return NotFound();
                }

                return Ok(shippingBy);
            }

            [HttpPost]
            [Route("api/ShippingBy/ManageShippingBy")]
            public async Task<IActionResult> ManageShippingBy([FromBody] ShippingBy request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { success = false, errors = ModelState });
                }

                if (request.Status == "Delete")
                {
                    var isDeleted = await _shippingByService.Delete(request.ShippingById); 
                    if (isDeleted)
                    {
                        return Ok(new { success = true });
                    }
                    return BadRequest(new { success = false, message = "Failed to delete shipping By" });
                }

                if (request.ShippingById > 0)
                {
                    var shippingBy = await _shippingByService.GetById(request.ShippingById);
                    if (shippingBy == null)
                    {
                        return NotFound();
                    }

                    shippingBy.ShippingByName = request.ShippingByName;

                    shippingBy.LanguageId = 1; // Replace with actual language ID

                    var isUpdated = await _shippingByService.Update(shippingBy);
                    if (isUpdated)
                    {
                        return Ok(new { success = true });
                    }
                    return BadRequest(new { success = false, message = "Failed to update shipping By" });
                }
                else
                {
                    var shippingBy = new ShippingBy
                    {
                        ShippingByName = request.ShippingByName,
                        EntryDateTime = DateTime.Now,

                    };

                    var ShippingById = await _shippingByService.Save(shippingBy);
                    if (ShippingById > 0)
                    {
                        return Ok(new { success = true });
                    }
                    return BadRequest(new { success = false, message = "Failed to create Shipping By" });
                }
            }
        }
    
}
