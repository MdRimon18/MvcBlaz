using Domain.Entity.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api
{
   // [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("api/Auth/Register")]
        public IActionResult Register([FromBody] AuthRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input. Please check your data." });
            }

            // Simulate user registration logic
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest(new { message = "Passwords do not match." });
            }

            return Ok(new { message = "Registration successful!" });
        }
    }
}
