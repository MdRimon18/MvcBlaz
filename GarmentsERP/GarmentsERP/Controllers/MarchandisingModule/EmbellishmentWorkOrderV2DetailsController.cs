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
    public class EmbellishmentWorkOrderV2DetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmbellishmentWorkOrderV2DetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmbellishmentWorkOrderV2Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmbellishmentWorkOrderV2Details>>> GetEmbellishmentWorkOrderV2Details()
        {
            return await _context.EmbellishmentWorkOrderV2Details.ToListAsync();
        }

        // GET: api/EmbellishmentWorkOrderV2Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmbellishmentWorkOrderV2Details>> GetEmbellishmentWorkOrderV2Details(int id)
        {
            var embellishmentWorkOrderV2Details = await _context.EmbellishmentWorkOrderV2Details.FindAsync(id);

            if (embellishmentWorkOrderV2Details == null)
            {
                return NotFound();
            }

            return embellishmentWorkOrderV2Details;
        }

        // PUT: api/EmbellishmentWorkOrderV2Details/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbellishmentWorkOrderV2Details(int id, EmbellishmentWorkOrderV2Details embellishmentWorkOrderV2Details)
        {
            if (id != embellishmentWorkOrderV2Details.Id)
            {
                return BadRequest();
            }

            _context.Entry(embellishmentWorkOrderV2Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmbellishmentWorkOrderV2DetailsExists(id))
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

        // POST: api/EmbellishmentWorkOrderV2Details
        [HttpPost]
        public async Task<ActionResult<EmbellishmentWorkOrderV2Details>> PostEmbellishmentWorkOrderV2Details(EmbellishmentWorkOrderV2Details embellishmentWorkOrderV2Details)
        {
            _context.EmbellishmentWorkOrderV2Details.Add(embellishmentWorkOrderV2Details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmbellishmentWorkOrderV2Details", new { id = embellishmentWorkOrderV2Details.Id }, embellishmentWorkOrderV2Details);
        }

        // DELETE: api/EmbellishmentWorkOrderV2Details/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmbellishmentWorkOrderV2Details>> DeleteEmbellishmentWorkOrderV2Details(int id)
        {
            var embellishmentWorkOrderV2Details = await _context.EmbellishmentWorkOrderV2Details.FindAsync(id);
            if (embellishmentWorkOrderV2Details == null)
            {
                return NotFound();
            }

            _context.EmbellishmentWorkOrderV2Details.Remove(embellishmentWorkOrderV2Details);
            await _context.SaveChangesAsync();

            return embellishmentWorkOrderV2Details;
        }

        private bool EmbellishmentWorkOrderV2DetailsExists(int id)
        {
            return _context.EmbellishmentWorkOrderV2Details.Any(e => e.Id == id);
        }
    }
}
