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
    public class OfferingCostTypeInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public OfferingCostTypeInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/OfferingCostTypeInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingCostTypeInfo>>> GetOfferingCostTypeInfo()
        {
            return await _context.OfferingCostTypeInfoes.ToListAsync();
        }

        // GET: api/OfferingCostTypeInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferingCostTypeInfo>> GetOfferingCostTypeInfo(int id)
        {
            var offeringCostTypeInfo = await _context.OfferingCostTypeInfoes.FindAsync(id);

            if (offeringCostTypeInfo == null)
            {
                return NotFound();
            }

            return offeringCostTypeInfo;
        }

        // PUT: api/OfferingCostTypeInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferingCostTypeInfo(int id, OfferingCostTypeInfo offeringCostTypeInfo)
        {
            if (id != offeringCostTypeInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(offeringCostTypeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferingCostTypeInfoExists(id))
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

        // POST: api/OfferingCostTypeInfoes
        [HttpPost]
        public async Task<ActionResult<OfferingCostTypeInfo>> PostOfferingCostTypeInfo(OfferingCostTypeInfo offeringCostTypeInfo)
        {
            _context.OfferingCostTypeInfoes.Add(offeringCostTypeInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferingCostTypeInfo", new { id = offeringCostTypeInfo.Id }, offeringCostTypeInfo);
        }

        // DELETE: api/OfferingCostTypeInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferingCostTypeInfo>> DeleteOfferingCostTypeInfo(int id)
        {
            var offeringCostTypeInfo = await _context.OfferingCostTypeInfoes.FindAsync(id);
            if (offeringCostTypeInfo == null)
            {
                return NotFound();
            }

            _context.OfferingCostTypeInfoes.Remove(offeringCostTypeInfo);
            await _context.SaveChangesAsync();

            return offeringCostTypeInfo;
        }

        private bool OfferingCostTypeInfoExists(int id)
        {
            return _context.OfferingCostTypeInfoes.Any(e => e.Id == id);
        }
    }
}
