using Domain.CommonServices;
using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetCurrentUserId")]
        public IActionResult GetCurrentUserId()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
 
            return Ok(new { CurrentUserId = userId });
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllUsers(string? search,long roleId, int page, int pageSize)
        {
            // Sending null for all filters
            var users = (await _userService.Get(
                userId: null,
                email: null,
                name: search,
                phoneNo: null,
                password: null,
                roleId: roleId,
                pageNumber: page,
                pageSize: pageSize
            )).ToList();

            if (users.Count == 0)
            {
                return Ok(new
                {
                    items = users,
                    currentPage = page,
                    totalPages = 0,
                    totalRecord = 0
                });
            }

            var totalRecord = users[0].total_row;
            var totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

            return Ok(new
            {
                items = users,
                currentPage = page,
                totalPages,
                totalRecord
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(long id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [Route("SaveUser")]
        public async Task<ActionResult<User>> SaveUser([FromForm] User user, [FromForm] IFormFile? imageFile)
        {
            if (imageFile != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine("wwwroot/Users/Images", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                user.ImgLink = "/Users/images/" + fileName;
            }

            if (user.UserId > 0)
            {
                user.LastModifyDate = DateTime.UtcNow;
                user.LastModifyBy = UserInfo.UserId; // Replace this with your logic
            }
            else
            {
                user.EntryDateTime = DateTime.UtcNow;
                user.EntryBy = UserInfo.UserId; // Replace this with your logic
            }

            var successId = await _userService.SaveOrUpdate(user);
            if (successId > 0)
            {
                if (user.UserId == 0)
                {
                    user.UserId = successId;
                    return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
                }
                else
                {
                    return NoContent();
                }
            }

            return BadRequest("Failed to save user");
        }
    }
}
