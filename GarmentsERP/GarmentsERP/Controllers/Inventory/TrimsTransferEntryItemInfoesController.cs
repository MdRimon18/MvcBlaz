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
    public class TrimsTransferEntryItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsTransferEntryItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsTransferEntryItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsTransferEntryItemInfo>>> GetTrimsTransferEntryItemInfo()
        {
            return await _context.TrimsTransferEntryItemInfoes.ToListAsync();
        }

        // GET: api/TrimsTransferEntryItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsTransferEntryItemInfo>> GetTrimsTransferEntryItemInfo(int id)
        {
            var trimsTransferEntryItemInfo = await _context.TrimsTransferEntryItemInfoes.FindAsync(id);

            if (trimsTransferEntryItemInfo == null)
            {
                return NotFound();
            }

            return trimsTransferEntryItemInfo;
        }

        // PUT: api/TrimsTransferEntryItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsTransferEntryItemInfo(int id, TrimsTransferEntryItemInfo trimsTransferEntryItemInfo)
        {
            if (id != trimsTransferEntryItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsTransferEntryItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsTransferEntryItemInfoExists(id))
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

        // POST: api/TrimsTransferEntryItemInfoes
        [HttpPost]
        public async Task<ActionResult<TrimsTransferEntryItemInfo>> PostTrimsTransferEntryItemInfo(TrimsTransferEntryItemInfo trimsTransferEntryItemInfo)
        {
            _context.TrimsTransferEntryItemInfoes.Add(trimsTransferEntryItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsTransferEntryItemInfo", new { id = trimsTransferEntryItemInfo.Id }, trimsTransferEntryItemInfo);
        }

        // DELETE: api/TrimsTransferEntryItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsTransferEntryItemInfo>> DeleteTrimsTransferEntryItemInfo(int id)
        {
            var trimsTransferEntryItemInfo = await _context.TrimsTransferEntryItemInfoes.FindAsync(id);
            if (trimsTransferEntryItemInfo == null)
            {
                return NotFound();
            }

            _context.TrimsTransferEntryItemInfoes.Remove(trimsTransferEntryItemInfo);
            await _context.SaveChangesAsync();

            return trimsTransferEntryItemInfo;
        }

        private bool TrimsTransferEntryItemInfoExists(int id)
        {
            return _context.TrimsTransferEntryItemInfoes.Any(e => e.Id == id);
        }
    }
}
