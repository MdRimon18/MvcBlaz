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
    public class YarnBagStickerChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnBagStickerChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnBagStickerChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnBagStickerChild>>> GetYarnBagStickerChild()
        {
            return await _context.YarnBagStickerChilds.ToListAsync();
        }

        // GET: api/YarnBagStickerChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnBagStickerChild>> GetYarnBagStickerChild(int id)
        {
            var yarnBagStickerChild = await _context.YarnBagStickerChilds.FindAsync(id);

            if (yarnBagStickerChild == null)
            {
                return NotFound();
            }

            return yarnBagStickerChild;
        }

        // PUT: api/YarnBagStickerChilds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnBagStickerChild(int id, YarnBagStickerChild yarnBagStickerChild)
        {
            if (id != yarnBagStickerChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnBagStickerChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnBagStickerChildExists(id))
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

        // POST: api/YarnBagStickerChilds
        [HttpPost]
        public async Task<ActionResult<YarnBagStickerChild>> PostYarnBagStickerChild(YarnBagStickerChild yarnBagStickerChild)
        {
            _context.YarnBagStickerChilds.Add(yarnBagStickerChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnBagStickerChild", new { id = yarnBagStickerChild.Id }, yarnBagStickerChild);
        }

        // DELETE: api/YarnBagStickerChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnBagStickerChild>> DeleteYarnBagStickerChild(int id)
        {
            var yarnBagStickerChild = await _context.YarnBagStickerChilds.FindAsync(id);
            if (yarnBagStickerChild == null)
            {
                return NotFound();
            }

            _context.YarnBagStickerChilds.Remove(yarnBagStickerChild);
            await _context.SaveChangesAsync();

            return yarnBagStickerChild;
        }

        private bool YarnBagStickerChildExists(int id)
        {
            return _context.YarnBagStickerChilds.Any(e => e.Id == id);
        }
    }
}
