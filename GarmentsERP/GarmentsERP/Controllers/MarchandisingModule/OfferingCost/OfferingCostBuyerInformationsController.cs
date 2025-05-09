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
    public class OfferingCostBuyerInformationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public OfferingCostBuyerInformationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/OfferingCostBuyerInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingCostBuyerInformation>>> GetOfferingCostBuyerInformation()
        {
            return await _context.OfferingCostBuyerInformations.ToListAsync();
        }

        // GET: api/OfferingCostBuyerInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferingCostBuyerInformation>> GetOfferingCostBuyerInformation(int id)
        {
            var offeringCostBuyerInformation = await _context.OfferingCostBuyerInformations.FindAsync(id);

            if (offeringCostBuyerInformation == null)
            {
                return NotFound();
            }

            return offeringCostBuyerInformation;
        }

        // PUT: api/OfferingCostBuyerInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferingCostBuyerInformation(int id, OfferingCostBuyerInformation offeringCostBuyerInformation)
        {
            if (id != offeringCostBuyerInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(offeringCostBuyerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferingCostBuyerInformationExists(id))
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

        // POST: api/OfferingCostBuyerInformations
        [HttpPost]
        public async Task<ActionResult<OfferingCostBuyerInformation>> PostOfferingCostBuyerInformation(OfferingCostBuyerInformation offeringCostBuyerInformation)
        {
            _context.OfferingCostBuyerInformations.Add(offeringCostBuyerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferingCostBuyerInformation", new { id = offeringCostBuyerInformation.Id }, offeringCostBuyerInformation);
        }

        // DELETE: api/OfferingCostBuyerInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferingCostBuyerInformation>> DeleteOfferingCostBuyerInformation(int id)
        {
            var offeringCostBuyerInformation = await _context.OfferingCostBuyerInformations.FindAsync(id);
            if (offeringCostBuyerInformation == null)
            {
                return NotFound();
            }

            _context.OfferingCostBuyerInformations.Remove(offeringCostBuyerInformation);
            await _context.SaveChangesAsync();

            return offeringCostBuyerInformation;
        }

        private bool OfferingCostBuyerInformationExists(int id)
        {
            return _context.OfferingCostBuyerInformations.Any(e => e.Id == id);
        }
    }
}
