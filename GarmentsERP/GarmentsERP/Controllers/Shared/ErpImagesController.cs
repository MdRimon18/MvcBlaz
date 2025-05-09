using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Shared;
using System.IO;

namespace GarmentsERP.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErpImagesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ErpImagesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ErpImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErpImages>>> GetErpImages()
        {
            return await _context.ErpImages.ToListAsync();
        }

        // GET: api/ErpImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErpImages>> GetErpImages(int id)
        {
            var erpImages = await _context.ErpImages.FindAsync(id);

            if (erpImages == null)
            {
                return NotFound();
            }

            return erpImages;
        }

        // PUT: api/ErpImages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErpImages(int id, ErpImages erpImages)
        {
            if (id != erpImages.Id)
            {
                return BadRequest();
            }

            _context.Entry(erpImages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErpImagesExists(id))
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

        [HttpPost]
        [Route("uploadImage")]
        public async Task<IActionResult> UploadViewToImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new Exception("Image file missing !");

            var folderName = Path.Combine("StorageImage/QuotationInqueries/Image");
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            // var uploads = Path.Combine(_host.WebRootPath, "StorageImage");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var erpImagesListCount = _context.ErpImages.ToList().Count();

            var uniquefileName = erpImagesListCount + Path.GetExtension(file.FileName);
            var dbPath = Path.Combine(folderName, uniquefileName);


            var fileObj = new ErpImages();

            if (file.Length > 0)
            {
              //  var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(dbPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);

                    fileObj.ImageName = uniquefileName;
                    fileObj.ImagePath = dbPath;
                }
            }
            return Ok(fileObj);
        }
      

        // POST: api/ErpImages
        [HttpPost]
        public async Task<ActionResult<ErpImages>> PostErpImages(ErpImages erpImages)
        {
            _context.ErpImages.Add(erpImages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErpImages", new { id = erpImages.Id }, erpImages);
        }

        // DELETE: api/ErpImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ErpImages>> DeleteErpImages(int id)
        {
            var erpImages = await _context.ErpImages.FindAsync(id);
            if (erpImages == null)
            {
                return NotFound();
            }
            //delete image
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), erpImages.ImagePath);
            if (!Directory.Exists(uploads))
            {
                System.IO.File.Delete(uploads);
              //  Directory.Delete(uploads);
                
            }

            _context.ErpImages.Remove(erpImages);
            await _context.SaveChangesAsync();

            return erpImages;
        }

        private bool ErpImagesExists(int id)
        {
            return _context.ErpImages.Any(e => e.Id == id);
        }
    }
}
