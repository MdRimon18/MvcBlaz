using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyTypesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PartyTypesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PartyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartyType>>> GetPartyType()
        {
            return await _context.PartyTypes.ToListAsync();
        }

        // GET: api/PartyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartyType>> GetPartyType(int id)
        {
            var partyType = await _context.PartyTypes.FindAsync(id);

            if (partyType == null)
            {
                return NotFound();
            }

            return partyType;
        }

        // PUT: api/PartyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartyType(int id, PartyType partyType)
        {
            if (id != partyType.Id)
            {
                return BadRequest();
            }

            _context.Entry(partyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyTypeExists(id))
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

        // POST: api/PartyTypes
        [HttpPost]
        public async Task<ActionResult<PartyType>> PostPartyType(PartyType partyType)
        {
            _context.PartyTypes.Add(partyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartyType", new { id = partyType.Id }, partyType);
        }

        // DELETE: api/PartyTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PartyType>> DeletePartyType(int id)
        {
            var partyType = await _context.PartyTypes.FindAsync(id);
            if (partyType == null)
            {
                return NotFound();
            }

            _context.PartyTypes.Remove(partyType);
            await _context.SaveChangesAsync();

            return partyType;
        }

        private bool PartyTypeExists(int id)
        {
            return _context.PartyTypes.Any(e => e.Id == id);
        }
    }
}
