using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Import;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class YarnBagStickersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnBagStickersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnBagStickers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnBagSticker>>> GetYarnBagSticker()
        {
            return await _context.YarnBagStickers.ToListAsync();
        }

        // GET: api/YarnBagStickers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnBagSticker>> GetYarnBagSticker(int id)
        {
            var yarnBagSticker = await _context.YarnBagStickers.FindAsync(id);

            if (yarnBagSticker == null)
            {
                return NotFound();
            }

            return yarnBagSticker;
        }

        // PUT: api/YarnBagStickers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnBagSticker(int id, YarnBagSticker yarnBagSticker)
        {
            if (id != yarnBagSticker.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnBagSticker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnBagStickerExists(id))
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

        // POST: api/YarnBagStickers
        [HttpPost]
        public async Task<ActionResult<YarnBagSticker>> PostYarnBagSticker(YarnBagSticker yarnBagSticker)
        {
            _context.YarnBagStickers.Add(yarnBagSticker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnBagSticker", new { id = yarnBagSticker.Id }, yarnBagSticker);
        }

        // DELETE: api/YarnBagStickers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnBagSticker>> DeleteYarnBagSticker(int id)
        {
            var yarnBagSticker = await _context.YarnBagStickers.FindAsync(id);
            if (yarnBagSticker == null)
            {
                return NotFound();
            }

            _context.YarnBagStickers.Remove(yarnBagSticker);
            await _context.SaveChangesAsync();

            return yarnBagSticker;
        }

        private bool YarnBagStickerExists(int id)
        {
            return _context.YarnBagStickers.Any(e => e.Id == id);
        }
    }
}
