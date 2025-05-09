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
    public class OfferingCostFabricInformationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public OfferingCostFabricInformationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/OfferingCostFabricInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingCostFabricInformation>>> GetOfferingCostFabricInformation()
        {
            return await _context.OfferingCostFabricInformations.ToListAsync();
        }

        // GET: api/OfferingCostFabricInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferingCostFabricInformation>> GetOfferingCostFabricInformation(int id)
        {
            var offeringCostFabricInformation = await _context.OfferingCostFabricInformations.FindAsync(id);

            if (offeringCostFabricInformation == null)
            {
                return NotFound();
            }

            return offeringCostFabricInformation;
        }

        // PUT: api/OfferingCostFabricInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferingCostFabricInformation(int id, OfferingCostFabricInformation offeringCostFabricInformation)
        {
            if (id != offeringCostFabricInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(offeringCostFabricInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferingCostFabricInformationExists(id))
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

        // POST: api/OfferingCostFabricInformations
        [HttpPost]
        public async Task<ActionResult<OfferingCostFabricInformation>> PostOfferingCostFabricInformation(OfferingCostFabricInformation offeringCostFabricInformation)
        {
            _context.OfferingCostFabricInformations.Add(offeringCostFabricInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferingCostFabricInformation", new { id = offeringCostFabricInformation.Id }, offeringCostFabricInformation);
        }

        // DELETE: api/OfferingCostFabricInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferingCostFabricInformation>> DeleteOfferingCostFabricInformation(int id)
        {
            var offeringCostFabricInformation = await _context.OfferingCostFabricInformations.FindAsync(id);
            if (offeringCostFabricInformation == null)
            {
                return NotFound();
            }

            _context.OfferingCostFabricInformations.Remove(offeringCostFabricInformation);
            await _context.SaveChangesAsync();

            return offeringCostFabricInformation;
        }

        private bool OfferingCostFabricInformationExists(int id)
        {
            return _context.OfferingCostFabricInformations.Any(e => e.Id == id);
        }
    }
}
