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
    public class WovenFinishRollIssueReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenFinishRollIssueReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenFinishRollIssueReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenFinishRollIssueReturn>>> GetWovenFinishRollIssueReturn()
        {
            return await _context.WovenFinishRollIssueReturns.ToListAsync();
        }

        // GET: api/WovenFinishRollIssueReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenFinishRollIssueReturn>> GetWovenFinishRollIssueReturn(int id)
        {
            var wovenFinishRollIssueReturn = await _context.WovenFinishRollIssueReturns.FindAsync(id);

            if (wovenFinishRollIssueReturn == null)
            {
                return NotFound();
            }

            return wovenFinishRollIssueReturn;
        }

        // PUT: api/WovenFinishRollIssueReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenFinishRollIssueReturn(int id, WovenFinishRollIssueReturn wovenFinishRollIssueReturn)
        {
            if (id != wovenFinishRollIssueReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenFinishRollIssueReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenFinishRollIssueReturnExists(id))
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

        // POST: api/WovenFinishRollIssueReturns
        [HttpPost]
        public async Task<ActionResult<WovenFinishRollIssueReturn>> PostWovenFinishRollIssueReturn(WovenFinishRollIssueReturn wovenFinishRollIssueReturn)
        {
            _context.WovenFinishRollIssueReturns.Add(wovenFinishRollIssueReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenFinishRollIssueReturn", new { id = wovenFinishRollIssueReturn.Id }, wovenFinishRollIssueReturn);
        }

        // DELETE: api/WovenFinishRollIssueReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenFinishRollIssueReturn>> DeleteWovenFinishRollIssueReturn(int id)
        {
            var wovenFinishRollIssueReturn = await _context.WovenFinishRollIssueReturns.FindAsync(id);
            if (wovenFinishRollIssueReturn == null)
            {
                return NotFound();
            }

            _context.WovenFinishRollIssueReturns.Remove(wovenFinishRollIssueReturn);
            await _context.SaveChangesAsync();

            return wovenFinishRollIssueReturn;
        }

        private bool WovenFinishRollIssueReturnExists(int id)
        {
            return _context.WovenFinishRollIssueReturns.Any(e => e.Id == id);
        }
    }
}
