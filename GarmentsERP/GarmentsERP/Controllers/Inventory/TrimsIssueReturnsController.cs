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
    public class TrimsIssueReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsIssueReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsIssueReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsIssueReturn>>> GetTrimsIssueReturn()
        {
            return await _context.TrimsIssueReturns.ToListAsync();
        }

        // GET: api/TrimsIssueReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsIssueReturn>> GetTrimsIssueReturn(int id)
        {
            var trimsIssueReturn = await _context.TrimsIssueReturns.FindAsync(id);

            if (trimsIssueReturn == null)
            {
                return NotFound();
            }

            return trimsIssueReturn;
        }

        // PUT: api/TrimsIssueReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsIssueReturn(int id, TrimsIssueReturn trimsIssueReturn)
        {
            if (id != trimsIssueReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsIssueReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsIssueReturnExists(id))
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

        // POST: api/TrimsIssueReturns
        [HttpPost]
        public async Task<ActionResult<TrimsIssueReturn>> PostTrimsIssueReturn(TrimsIssueReturn trimsIssueReturn)
        {
            _context.TrimsIssueReturns.Add(trimsIssueReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsIssueReturn", new { id = trimsIssueReturn.Id }, trimsIssueReturn);
        }

        // DELETE: api/TrimsIssueReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsIssueReturn>> DeleteTrimsIssueReturn(int id)
        {
            var trimsIssueReturn = await _context.TrimsIssueReturns.FindAsync(id);
            if (trimsIssueReturn == null)
            {
                return NotFound();
            }

            _context.TrimsIssueReturns.Remove(trimsIssueReturn);
            await _context.SaveChangesAsync();

            return trimsIssueReturn;
        }

        private bool TrimsIssueReturnExists(int id)
        {
            return _context.TrimsIssueReturns.Any(e => e.Id == id);
        }
    }
}
