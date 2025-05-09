using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.TNA;

namespace GarmentsERP.Controllers.TNA
{
    [Route("api/[controller]")]
    [ApiController]
    public class TNATemplateEntryDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TNATemplateEntryDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TNATemplateEntryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TNATemplateEntryDetails>>> GetTNATemplateEntryDetails()
        {
            return await _context.TNATemplateEntryDetails.ToListAsync();
        }

        // GET: api/TNATemplateEntryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TNATemplateEntryDetails>> GetTNATemplateEntryDetails(int id)
        {
            var tNATemplateEntryDetails = await _context.TNATemplateEntryDetails.FindAsync(id);

            if (tNATemplateEntryDetails == null)
            {
                return NotFound();
            }

            return tNATemplateEntryDetails;
        }

        // PUT: api/TNATemplateEntryDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTNATemplateEntryDetails(int id, TNATemplateEntryDetails tNATemplateEntryDetails)
        {
            if (id != tNATemplateEntryDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(tNATemplateEntryDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TNATemplateEntryDetailsExists(id))
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

        // POST: api/TNATemplateEntryDetails
        [HttpPost]
        public async Task<ActionResult<TNATemplateEntryDetails>> PostTNATemplateEntryDetails(TNATemplateEntryDetails tNATemplateEntryDetails)
        {
            _context.TNATemplateEntryDetails.Add(tNATemplateEntryDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTNATemplateEntryDetails", new { id = tNATemplateEntryDetails.Id }, tNATemplateEntryDetails);
        }

        // DELETE: api/TNATemplateEntryDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TNATemplateEntryDetails>> DeleteTNATemplateEntryDetails(int id)
        {
            var tNATemplateEntryDetails = await _context.TNATemplateEntryDetails.FindAsync(id);
            if (tNATemplateEntryDetails == null)
            {
                return NotFound();
            }

            _context.TNATemplateEntryDetails.Remove(tNATemplateEntryDetails);
            await _context.SaveChangesAsync();

            return tNATemplateEntryDetails;
        }

        private bool TNATemplateEntryDetailsExists(int id)
        {
            return _context.TNATemplateEntryDetails.Any(e => e.Id == id);
        }
    }
}
