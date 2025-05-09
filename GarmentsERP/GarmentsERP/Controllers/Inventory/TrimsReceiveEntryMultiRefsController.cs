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
    public class TrimsReceiveEntryMultiRefsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsReceiveEntryMultiRefsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsReceiveEntryMultiRefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsReceiveEntryMultiRef>>> GetTrimsReceiveEntryMultiRef()
        {
            return await _context.TrimsReceiveEntryMultiRefs.ToListAsync();
        }

        // GET: api/TrimsReceiveEntryMultiRefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsReceiveEntryMultiRef>> GetTrimsReceiveEntryMultiRef(int id)
        {
            var trimsReceiveEntryMultiRef = await _context.TrimsReceiveEntryMultiRefs.FindAsync(id);

            if (trimsReceiveEntryMultiRef == null)
            {
                return NotFound();
            }

            return trimsReceiveEntryMultiRef;
        }

        // PUT: api/TrimsReceiveEntryMultiRefs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsReceiveEntryMultiRef(int id, TrimsReceiveEntryMultiRef trimsReceiveEntryMultiRef)
        {
            if (id != trimsReceiveEntryMultiRef.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsReceiveEntryMultiRef).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsReceiveEntryMultiRefExists(id))
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

        // POST: api/TrimsReceiveEntryMultiRefs
        [HttpPost]
        public async Task<ActionResult<TrimsReceiveEntryMultiRef>> PostTrimsReceiveEntryMultiRef(TrimsReceiveEntryMultiRef trimsReceiveEntryMultiRef)
        {
            _context.TrimsReceiveEntryMultiRefs.Add(trimsReceiveEntryMultiRef);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsReceiveEntryMultiRef", new { id = trimsReceiveEntryMultiRef.Id }, trimsReceiveEntryMultiRef);
        }

        // DELETE: api/TrimsReceiveEntryMultiRefs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsReceiveEntryMultiRef>> DeleteTrimsReceiveEntryMultiRef(int id)
        {
            var trimsReceiveEntryMultiRef = await _context.TrimsReceiveEntryMultiRefs.FindAsync(id);
            if (trimsReceiveEntryMultiRef == null)
            {
                return NotFound();
            }

            _context.TrimsReceiveEntryMultiRefs.Remove(trimsReceiveEntryMultiRef);
            await _context.SaveChangesAsync();

            return trimsReceiveEntryMultiRef;
        }

        private bool TrimsReceiveEntryMultiRefExists(int id)
        {
            return _context.TrimsReceiveEntryMultiRefs.Any(e => e.Id == id);
        }
    }
}
