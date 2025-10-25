using Domain.Entity.Settings;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace BlazorInMvc.Controllers.Api.Settings
{
   
       //[Route("api/[controller]")]
        [ApiController]
        public class LanguageController : ControllerBase
        {
            private readonly LanguageService _languageService;

            public LanguageController(LanguageService languageService)
            {
                 _languageService = languageService;
            }

            [HttpGet]
            [Route("api/Language/GetAll")]
            public async Task<IActionResult> c(string? search, int page, int pageSize)
            {
                var language = await _languageService.Get(null, null, search, page, pageSize);
                var totalRecord = language.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecord / pageSize);

                return Ok(new
                {
                    items = language,
                    currentPage = page,
                    totalPages,
                    totalRecord
                });
            }

            [HttpGet]
            [Route("api/Language/GetById")]
            public async Task<IActionResult> Language(long id)
            {
                var language = await _languageService.GetById(id);
                if (language == null)
                {
                    return NotFound();
                }

                return Ok(language);
            }

            [HttpPost]
            [Route("api/Language/ManageLanguage")]
            public async Task<IActionResult> ManageLanguages([FromBody] Language request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { success = false, errors = ModelState });
                }

                if (request.Status == "Delete")
                {
                    var isDeleted = await _languageService.Delete(request.LanguageId);
                    if (isDeleted)
                    {
                        return Ok(new { success = true });
                    }
                    return BadRequest(new { success = false, message = "Failed to delete invoice type" });
                }

                if (request.LanguageId > 0)
                {
                    var language = await _languageService.GetById(request.LanguageId);
                    if (language == null)
                    {
                        return NotFound();
                    }

                      language.LanguageName = request.LanguageName;

                      language.LanguageId = 1; // Replace with actual language ID

                    var isUpdated = await _languageService.Update(language);
                    if (isUpdated)
                    {
                        return Ok(new { success = true });
                    }
                    return BadRequest(new { success = false, message = "Failed to update language" });
                }
                else
                {
                    var language = new Language
                    {
                        LanguageName = request.LanguageName,
                        EntryDateTime = DateTime.Now,

                    };

                    var languageTypeId = await _languageService.Save(language);
                    if (languageTypeId > 0)
                    {
                        return Ok(new { success = true });
                    }
                    return BadRequest(new { success = false, message = "Failed to create language" });
                }
            }
        }
    
}
