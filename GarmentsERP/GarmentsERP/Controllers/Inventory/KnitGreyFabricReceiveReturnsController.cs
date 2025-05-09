using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnitGreyFabricReceiveReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnitGreyFabricReceiveReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnitGreyFabricReceiveReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnitGreyFabricReceiveReturn>>> GetKnitGreyFabricReceiveReturn()
        {
            return await _context.KnitGreyFabricReceiveReturns.ToListAsync();
        }

        // GET: api/KnitGreyFabricReceiveReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnitGreyFabricReceiveReturn>> GetKnitGreyFabricReceiveReturn(int id)
        {
            var knitGreyFabricReceiveReturn = await _context.KnitGreyFabricReceiveReturns.FindAsync(id);

            if (knitGreyFabricReceiveReturn == null)
            {
                return NotFound();
            }

            return knitGreyFabricReceiveReturn;
        }

        // PUT: api/KnitGreyFabricReceiveReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnitGreyFabricReceiveReturn(int id, KnitGreyFabricReceiveReturn knitGreyFabricReceiveReturn)
        {
            if (id != knitGreyFabricReceiveReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(knitGreyFabricReceiveReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnitGreyFabricReceiveReturnExists(id))
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

        // POST: api/KnitGreyFabricReceiveReturns
        [HttpPost]
        public async Task<ActionResult<KnitGreyFabricReceiveReturn>> PostKnitGreyFabricReceiveReturn(KnitGreyFabricReceiveReturn knitGreyFabricReceiveReturn)
        {
            _context.KnitGreyFabricReceiveReturns.Add(knitGreyFabricReceiveReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnitGreyFabricReceiveReturn", new { id = knitGreyFabricReceiveReturn.Id }, knitGreyFabricReceiveReturn);
        }

        // DELETE: api/KnitGreyFabricReceiveReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnitGreyFabricReceiveReturn>> DeleteKnitGreyFabricReceiveReturn(int id)
        {
            var knitGreyFabricReceiveReturn = await _context.KnitGreyFabricReceiveReturns.FindAsync(id);
            if (knitGreyFabricReceiveReturn == null)
            {
                return NotFound();
            }

            _context.KnitGreyFabricReceiveReturns.Remove(knitGreyFabricReceiveReturn);
            await _context.SaveChangesAsync();

            return knitGreyFabricReceiveReturn;
        }

        private bool KnitGreyFabricReceiveReturnExists(int id)
        {
            return _context.KnitGreyFabricReceiveReturns.Any(e => e.Id == id);
        }
    }
}
