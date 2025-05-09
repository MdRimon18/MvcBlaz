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
    public class WovenGreyFabricReceiveReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenGreyFabricReceiveReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenGreyFabricReceiveReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenGreyFabricReceiveReturn>>> GetWovenGreyFabricReceiveReturn()
        {
            return await _context.WovenGreyFabricReceiveReturns.ToListAsync();
        }

        // GET: api/WovenGreyFabricReceiveReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenGreyFabricReceiveReturn>> GetWovenGreyFabricReceiveReturn(int id)
        {
            var wovenGreyFabricReceiveReturn = await _context.WovenGreyFabricReceiveReturns.FindAsync(id);

            if (wovenGreyFabricReceiveReturn == null)
            {
                return NotFound();
            }

            return wovenGreyFabricReceiveReturn;
        }

        // PUT: api/WovenGreyFabricReceiveReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenGreyFabricReceiveReturn(int id, WovenGreyFabricReceiveReturn wovenGreyFabricReceiveReturn)
        {
            if (id != wovenGreyFabricReceiveReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenGreyFabricReceiveReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenGreyFabricReceiveReturnExists(id))
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

        // POST: api/WovenGreyFabricReceiveReturns
        [HttpPost]
        public async Task<ActionResult<WovenGreyFabricReceiveReturn>> PostWovenGreyFabricReceiveReturn(WovenGreyFabricReceiveReturn wovenGreyFabricReceiveReturn)
        {
            _context.WovenGreyFabricReceiveReturns.Add(wovenGreyFabricReceiveReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenGreyFabricReceiveReturn", new { id = wovenGreyFabricReceiveReturn.Id }, wovenGreyFabricReceiveReturn);
        }

        // DELETE: api/WovenGreyFabricReceiveReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenGreyFabricReceiveReturn>> DeleteWovenGreyFabricReceiveReturn(int id)
        {
            var wovenGreyFabricReceiveReturn = await _context.WovenGreyFabricReceiveReturns.FindAsync(id);
            if (wovenGreyFabricReceiveReturn == null)
            {
                return NotFound();
            }

            _context.WovenGreyFabricReceiveReturns.Remove(wovenGreyFabricReceiveReturn);
            await _context.SaveChangesAsync();

            return wovenGreyFabricReceiveReturn;
        }

        private bool WovenGreyFabricReceiveReturnExists(int id)
        {
            return _context.WovenGreyFabricReceiveReturns.Any(e => e.Id == id);
        }
    }
}
