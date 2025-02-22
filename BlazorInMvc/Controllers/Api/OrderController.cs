using Domain.Services.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("Place")]
        public async Task<IActionResult> Place(int AddressId,long UserId)
        { 

            return Ok(new
            {   
                Order=new {OrderId=1},
                code = HttpStatusCode.OK,
                message = "Success",
                isSuccess = true
            });
        }
    }
}
