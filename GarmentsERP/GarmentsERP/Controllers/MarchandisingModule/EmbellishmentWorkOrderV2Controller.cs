using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentWorkOrderV2Controller : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmbellishmentWorkOrderV2Controller(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmbellishmentWorkOrderV2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmbellishmentWorkOrderV2>>> GetEmbellishmentWorkOrderV2()
        {
            return await _context.EmbellishmentWorkOrderV2.ToListAsync();
        }

        // GET: api/EmbellishmentWorkOrderV2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmbellishmentWorkOrderV2>> GetEmbellishmentWorkOrderV2(int id)
        {
            var embellishmentWorkOrderV2 = await _context.EmbellishmentWorkOrderV2.FindAsync(id);

            if (embellishmentWorkOrderV2 == null)
            {
                return NotFound();
            }

            return embellishmentWorkOrderV2;
        }

        // PUT: api/EmbellishmentWorkOrderV2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbellishmentWorkOrderV2(int id, EmbellishmentWorkOrderV2 embellishmentWorkOrderV2)
        {
            if (id != embellishmentWorkOrderV2.Id)
            {
                return BadRequest();
            }

            _context.Entry(embellishmentWorkOrderV2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmbellishmentWorkOrderV2Exists(id))
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

        // POST: api/EmbellishmentWorkOrderV2
        [HttpPost]
        public async Task<ActionResult<EmbellishmentWorkOrderV2>> PostEmbellishmentWorkOrderV2(EmbellishmentWorkOrderV2 embellishmentWorkOrderV2)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var woNo = "MKL" + "-EB-" +"-"+ lastTwoDigit +"-"+ "0000" + _context.EmbellishmentWorkOrderV2.Count();
            embellishmentWorkOrderV2.WoNo = woNo;


            _context.EmbellishmentWorkOrderV2.Add(embellishmentWorkOrderV2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmbellishmentWorkOrderV2", new { id = embellishmentWorkOrderV2.Id }, embellishmentWorkOrderV2);
        }

        // DELETE: api/EmbellishmentWorkOrderV2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmbellishmentWorkOrderV2>> DeleteEmbellishmentWorkOrderV2(int id)
        {
            var embellishmentWorkOrderV2 = await _context.EmbellishmentWorkOrderV2.FindAsync(id);
            if (embellishmentWorkOrderV2 == null)
            {
                return NotFound();
            }

            _context.EmbellishmentWorkOrderV2.Remove(embellishmentWorkOrderV2);
            await _context.SaveChangesAsync();

            return embellishmentWorkOrderV2;
        }

        private bool EmbellishmentWorkOrderV2Exists(int id)
        {
            return _context.EmbellishmentWorkOrderV2.Any(e => e.Id == id);
        }
    }
}
