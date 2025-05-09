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
    public class TrimsIssueMultiRefsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsIssueMultiRefsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsIssueMultiRefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsIssueMultiRef>>> GetTrimsIssueMultiRef()
        {
            return await _context.TrimsIssueMultiRefs.ToListAsync();
        }

        // GET: api/TrimsIssueMultiRefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsIssueMultiRef>> GetTrimsIssueMultiRef(int id)
        {
            var trimsIssueMultiRef = await _context.TrimsIssueMultiRefs.FindAsync(id);

            if (trimsIssueMultiRef == null)
            {
                return NotFound();
            }

            return trimsIssueMultiRef;
        }

        // PUT: api/TrimsIssueMultiRefs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsIssueMultiRef(int id, TrimsIssueMultiRef trimsIssueMultiRef)
        {
            if (id != trimsIssueMultiRef.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsIssueMultiRef).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsIssueMultiRefExists(id))
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

        // POST: api/TrimsIssueMultiRefs
        [HttpPost]
        public async Task<ActionResult<TrimsIssueMultiRef>> PostTrimsIssueMultiRef(TrimsIssueMultiRef trimsIssueMultiRef)
        {
            _context.TrimsIssueMultiRefs.Add(trimsIssueMultiRef);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsIssueMultiRef", new { id = trimsIssueMultiRef.Id }, trimsIssueMultiRef);
        }

        // DELETE: api/TrimsIssueMultiRefs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsIssueMultiRef>> DeleteTrimsIssueMultiRef(int id)
        {
            var trimsIssueMultiRef = await _context.TrimsIssueMultiRefs.FindAsync(id);
            if (trimsIssueMultiRef == null)
            {
                return NotFound();
            }

            _context.TrimsIssueMultiRefs.Remove(trimsIssueMultiRef);
            await _context.SaveChangesAsync();

            return trimsIssueMultiRef;
        }

        private bool TrimsIssueMultiRefExists(int id)
        {
            return _context.TrimsIssueMultiRefs.Any(e => e.Id == id);
        }
    }
}
