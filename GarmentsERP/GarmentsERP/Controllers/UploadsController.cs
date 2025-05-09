using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using System.IO;
using System.Net.Http.Headers;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public UploadsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Uploads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Upload>>> GetUpload()
        {
            return await _context.Uploads.ToListAsync();
        }

        // GET: api/Uploads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Upload>> GetUpload(int id)
        {
            var upload = await _context.Uploads.FindAsync(id);

            if (upload == null)
            {
                return NotFound();
            }

            return upload;
        }

        // PUT: api/Uploads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpload(int id, Upload upload)
        {
            if (id != upload.Id)
            {
                return BadRequest();
            }

            _context.Entry(upload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Uploads
        [HttpPost,DisableRequestSizeLimit]
        public ActionResult<Upload> PostUpload(Upload upload)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StorageImage", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }


    
    //_context.Uploads.Add(upload);
    //await _context.SaveChangesAsync();

    //return CreatedAtAction("GetUpload", new { id = upload.Id }, upload);


        // DELETE: api/Uploads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Upload>> DeleteUpload(int id)
        {
            var upload = await _context.Uploads.FindAsync(id);
            if (upload == null)
            {
                return NotFound();
            }

            _context.Uploads.Remove(upload);
            await _context.SaveChangesAsync();

            return upload;
        }

        private bool UploadExists(int id)
        {
            return _context.Uploads.Any(e => e.Id == id);
        }
    }
}
