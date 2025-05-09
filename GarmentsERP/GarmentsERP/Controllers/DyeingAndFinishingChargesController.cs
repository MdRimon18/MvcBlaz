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
    public class DyeingAndFinishingChargesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DyeingAndFinishingChargesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DyeingAndFinishingCharges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DyeingAndFinishingCharge>>> GetDyeingAndFinishingCharge()
        {
            return await _context.DyeingAndFinishingCharges.ToListAsync();
        }

        // GET: api/DyeingAndFinishingCharges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DyeingAndFinishingCharge>> GetDyeingAndFinishingCharge(int id)
        {
            var dyeingAndFinishingCharge = await _context.DyeingAndFinishingCharges.FindAsync(id);

            if (dyeingAndFinishingCharge == null)
            {
                return NotFound();
            }

            return dyeingAndFinishingCharge;
        }

        // PUT: api/DyeingAndFinishingCharges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDyeingAndFinishingCharge(int id, DyeingAndFinishingCharge dyeingAndFinishingCharge)
        {
            if (id != dyeingAndFinishingCharge.Id)
            {
                return BadRequest();
            }

            _context.Entry(dyeingAndFinishingCharge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DyeingAndFinishingChargeExists(id))
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

        // POST: api/DyeingAndFinishingCharges
        [HttpPost]
        public async Task<ActionResult<DyeingAndFinishingCharge>> PostDyeingAndFinishingCharge(DyeingAndFinishingCharge dyeingAndFinishingCharge)
        {
            _context.DyeingAndFinishingCharges.Add(dyeingAndFinishingCharge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDyeingAndFinishingCharge", new { id = dyeingAndFinishingCharge.Id }, dyeingAndFinishingCharge);
        }

        // DELETE: api/DyeingAndFinishingCharges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DyeingAndFinishingCharge>> DeleteDyeingAndFinishingCharge(int id)
        {
            var dyeingAndFinishingCharge = await _context.DyeingAndFinishingCharges.FindAsync(id);
            if (dyeingAndFinishingCharge == null)
            {
                return NotFound();
            }

            _context.DyeingAndFinishingCharges.Remove(dyeingAndFinishingCharge);
            await _context.SaveChangesAsync();

            return dyeingAndFinishingCharge;
        }

        private bool DyeingAndFinishingChargeExists(int id)
        {
            return _context.DyeingAndFinishingCharges.Any(e => e.Id == id);
        }
    }
}
