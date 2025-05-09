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
    public class KnitGreyFabricIssueReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnitGreyFabricIssueReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnitGreyFabricIssueReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnitGreyFabricIssueReturn>>> GetKnitGreyFabricIssueReturn()
        {
            return await _context.KnitGreyFabricIssueReturns.ToListAsync();
        }

        // GET: api/KnitGreyFabricIssueReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnitGreyFabricIssueReturn>> GetKnitGreyFabricIssueReturn(int id)
        {
            var knitGreyFabricIssueReturn = await _context.KnitGreyFabricIssueReturns.FindAsync(id);

            if (knitGreyFabricIssueReturn == null)
            {
                return NotFound();
            }

            return knitGreyFabricIssueReturn;
        }

        // PUT: api/KnitGreyFabricIssueReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnitGreyFabricIssueReturn(int id, KnitGreyFabricIssueReturn knitGreyFabricIssueReturn)
        {
            if (id != knitGreyFabricIssueReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(knitGreyFabricIssueReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnitGreyFabricIssueReturnExists(id))
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

        // POST: api/KnitGreyFabricIssueReturns
        [HttpPost]
        public async Task<ActionResult<KnitGreyFabricIssueReturn>> PostKnitGreyFabricIssueReturn(KnitGreyFabricIssueReturn knitGreyFabricIssueReturn)
        {
            _context.KnitGreyFabricIssueReturns.Add(knitGreyFabricIssueReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnitGreyFabricIssueReturn", new { id = knitGreyFabricIssueReturn.Id }, knitGreyFabricIssueReturn);
        }

        // DELETE: api/KnitGreyFabricIssueReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnitGreyFabricIssueReturn>> DeleteKnitGreyFabricIssueReturn(int id)
        {
            var knitGreyFabricIssueReturn = await _context.KnitGreyFabricIssueReturns.FindAsync(id);
            if (knitGreyFabricIssueReturn == null)
            {
                return NotFound();
            }

            _context.KnitGreyFabricIssueReturns.Remove(knitGreyFabricIssueReturn);
            await _context.SaveChangesAsync();

            return knitGreyFabricIssueReturn;
        }

        private bool KnitGreyFabricIssueReturnExists(int id)
        {
            return _context.KnitGreyFabricIssueReturns.Any(e => e.Id == id);
        }
    }
}
