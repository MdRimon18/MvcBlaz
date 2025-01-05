using Domain.Entity.Inventory;
using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSerialController : ControllerBase
    {
        private readonly ProductSerialNumbersService _productSerialNumbersService;
        public ProductSerialController(ProductSerialNumbersService productSerialNumbersService)
        {
            _productSerialNumbersService = productSerialNumbersService;
        }
        [HttpPost("SaveSerialNumber")]
        public async Task<IActionResult> SaveSerialNumber([FromBody] ProductSerialNumbers productSerialNumber)
        {
            long responseId = 0;
            if (ModelState.IsValid)
            {
                 
                responseId=await _productSerialNumbersService.SaveOrUpdate(productSerialNumber);
                if (responseId == -1)
                {
                    return Ok(new
                    {
                        success = false,
                        message = "Serial number already exists!",
                        responseId
                    });
                }
                return Ok(new
                {
                    Data = new
                    {
                        productSerialNumber
                    },
                    code = HttpStatusCode.OK,
                    message = "Serial Number saved successfully!",
                    isSuccess = true,
                    responseId= responseId
                });
                 
            }

            return BadRequest(new { success = false, message = "Validation failed!", errors = ModelState.Values });
        }
        [HttpGet("GetSerialNumber/{id}")]
        public async Task<IActionResult> GetSerialNumber(long id)
        {
            var serialNumber = await _productSerialNumbersService.GetById(id);
            if (serialNumber == null)
            {
                return NotFound(new { success = false, message = "Serial number not found!" });
            }

            return Ok(new
            {
                success = true,
                data = serialNumber
            });
        }
        [HttpDelete("DeleteSerialNumber/{id}")]
        public async Task<IActionResult> DeleteSerialNumber(long id)
        {
            var isDeleted = await _productSerialNumbersService.Delete(id);
            if (!isDeleted)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Failed to delete serial number. Please try again!"
                });
            }

            return Ok(new
            {
                success = true,
                message = "Serial number deleted successfully!"
            });
        }

    }
}
