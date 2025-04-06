using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpPost("save-items")]
        public IActionResult SaveItems([FromBody] List<InvoicePostViewModel> items)
        {
            if (items == null || !items.Any())
            {
                return BadRequest("No items provided.");
            }

            // Save logic here (DB insert or update)

            return Ok(new { message = "Items saved successfully!" });
        }
    }
}
