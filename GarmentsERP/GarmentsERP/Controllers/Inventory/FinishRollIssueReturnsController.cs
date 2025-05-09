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
    public class FinishRollIssueReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishRollIssueReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishRollIssueReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishRollIssueReturn>>> GetFinishRollIssueReturn()
        {
            return await _context.FinishRollIssueReturns.ToListAsync();
        }

        // GET: api/FinishRollIssueReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishRollIssueReturn>> GetFinishRollIssueReturn(int id)
        {
            var finishRollIssueReturn = await _context.FinishRollIssueReturns.FindAsync(id);

            if (finishRollIssueReturn == null)
            {
                return NotFound();
            }

            return finishRollIssueReturn;
        }

        // PUT: api/FinishRollIssueReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishRollIssueReturn(int id, FinishRollIssueReturn finishRollIssueReturn)
        {
            if (id != finishRollIssueReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishRollIssueReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishRollIssueReturnExists(id))
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

        // POST: api/FinishRollIssueReturns
        [HttpPost]
        public async Task<ActionResult<FinishRollIssueReturn>> PostFinishRollIssueReturn(FinishRollIssueReturn finishRollIssueReturn)
        {
            _context.FinishRollIssueReturns.Add(finishRollIssueReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishRollIssueReturn", new { id = finishRollIssueReturn.Id }, finishRollIssueReturn);
        }

        // DELETE: api/FinishRollIssueReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishRollIssueReturn>> DeleteFinishRollIssueReturn(int id)
        {
            var finishRollIssueReturn = await _context.FinishRollIssueReturns.FindAsync(id);
            if (finishRollIssueReturn == null)
            {
                return NotFound();
            }

            _context.FinishRollIssueReturns.Remove(finishRollIssueReturn);
            await _context.SaveChangesAsync();

            return finishRollIssueReturn;
        }

        private bool FinishRollIssueReturnExists(int id)
        {
            return _context.FinishRollIssueReturns.Any(e => e.Id == id);
        }
    }
}
