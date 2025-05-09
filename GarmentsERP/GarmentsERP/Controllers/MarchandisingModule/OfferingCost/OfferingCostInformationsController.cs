using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule.OfferingCost;

namespace GarmentsERP.Controllers.MarchandisingModule.OfferingCost
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingCostInformationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public OfferingCostInformationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/OfferingCostInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingCostInformation>>> GetOfferingCostInformation()
        {
            return await _context.OfferingCostInformations.OrderBy(f=>f.OfferingCostTypeId).ToListAsync();
        }

        // GET: api/OfferingCostInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferingCostInformation>> GetOfferingCostInformation(int id)
        {
            var offeringCostInformation = await _context.OfferingCostInformations.FindAsync(id);

            if (offeringCostInformation == null)
            {
                return NotFound();
            }

            return offeringCostInformation;
        }

        // PUT: api/OfferingCostInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferingCostInformation(int id, OfferingCostInformation offeringCostInformation)
        {
            if (id != offeringCostInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(offeringCostInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferingCostInformationExists(id))
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

        // POST: api/OfferingCostInformations
        [HttpPost]
        public async Task<ActionResult<OfferingCostInformation>> PostOfferingCostInformation(OfferingCostInformation offeringCostInformation)
        {
            _context.OfferingCostInformations.Add(offeringCostInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferingCostInformation", new { id = offeringCostInformation.Id }, offeringCostInformation);
        }

        // DELETE: api/OfferingCostInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferingCostInformation>> DeleteOfferingCostInformation(int id)
        {
            var offeringCostInformation = await _context.OfferingCostInformations.FindAsync(id);
            if (offeringCostInformation == null)
            {
                return NotFound();
            }

            _context.OfferingCostInformations.Remove(offeringCostInformation);
            await _context.SaveChangesAsync();

            return offeringCostInformation;
        }

        private bool OfferingCostInformationExists(int id)
        {
            return _context.OfferingCostInformations.Any(e => e.Id == id);
        }
    }
}
