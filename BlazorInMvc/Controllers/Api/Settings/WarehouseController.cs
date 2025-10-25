using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api.Settings
{
    //[Route("api/[controller]")]
    [ApiController]

    public class WarehouseController : ControllerBase
    {
            private readonly WarehouseService _warehouseService;

            public WarehouseController(WarehouseService warehouseService)
            {
                  _warehouseService = warehouseService;
            }

            [HttpGet]
            [Route("api/Warehouse/GetAll")]
            public async Task<IActionResult> GetWarehouse(string? search, int page, int pageSize)
            {
                var warehouse = await _warehouseService.Get(null, null, null, null, null, null,null,null,search, 1, 10);
                var totalRecord = warehouse.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

                return Ok(new
                {
                    items = warehouse,
                    currentPage = page,
                    totalPages,
                    totalRecord
                });
            }

            [HttpGet]
            [Route("api/Warehouse/GetById")]
            public async Task<IActionResult> GetWarehouse(long id)
            {
                var warehouse = await _warehouseService.GetById(id);
                if (warehouse == null)
                {
                    return NotFound();
                }

                return Ok(warehouse);
            }

            [HttpPost]
            [Route("api/Warehouse/ManageWarehouse")]
            public async Task<IActionResult>ManageWarehouse([FromBody] Warehouse request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { success = false, errors = ModelState });
                }

                if (request.Status == "Delete")
                {
                    var isDeleted = await _warehouseService.Delete(request.WarehouseId);
                    if (isDeleted)
                    {
                        return Ok(new { success = true });
                    }
                    return BadRequest(new { success = false, message = "Failed to delete warehouse" });
                }

                if (request.WarehouseId > 0)
                {
                    var warehouse = await _warehouseService.GetById(request.WarehouseId);
                    if (warehouse == null)
                    {
                        return NotFound();
                    }
                        
                      warehouse.WarehouseName = request.WarehouseName;

                      //warehouse.LanguageId = 1; // Replace with actual language ID

                    var isUpdated = await _warehouseService.SaveOrUpdate(warehouse);
                    if (isUpdated > 0)
                    {
                        return Ok(new { success = true });
                    }
                    return BadRequest(new { success = false, message = "Failed to update warehouse" });
                }
                else
                {
                    var warehouse = new Warehouse
                    {
                        WarehouseName = request.WarehouseName,
                        EntryDateTime = DateTime.Now,
                            
                    };

                    // Create               
                    var WarehouseId = await _warehouseService.SaveOrUpdate(request);

                    if (WarehouseId > 0)
                    return Ok(new { success = true });

                    return BadRequest(new { success = false, message = "Failed to create warehouse." });



                }
            }
        
    }
}

