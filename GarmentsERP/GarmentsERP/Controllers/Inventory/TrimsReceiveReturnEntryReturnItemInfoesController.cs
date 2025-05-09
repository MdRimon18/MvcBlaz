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
    public class TrimsReceiveReturnEntryReturnItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsReceiveReturnEntryReturnItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsReceiveReturnEntryReturnItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsReceiveReturnEntryReturnItemInfo>>> GetTrimsReceiveReturnEntryReturnItemInfo()
        {
            return await _context.TrimsReceiveReturnEntryReturnItemInfoes.ToListAsync();
        }

        // GET: api/TrimsReceiveReturnEntryReturnItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsReceiveReturnEntryReturnItemInfo>> GetTrimsReceiveReturnEntryReturnItemInfo(int id)
        {
            var trimsReceiveReturnEntryReturnItemInfo = await _context.TrimsReceiveReturnEntryReturnItemInfoes.FindAsync(id);

            if (trimsReceiveReturnEntryReturnItemInfo == null)
            {
                return NotFound();
            }

            return trimsReceiveReturnEntryReturnItemInfo;
        }

        // PUT: api/TrimsReceiveReturnEntryReturnItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsReceiveReturnEntryReturnItemInfo(int id, TrimsReceiveReturnEntryReturnItemInfo trimsReceiveReturnEntryReturnItemInfo)
        {
            if (id != trimsReceiveReturnEntryReturnItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsReceiveReturnEntryReturnItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsReceiveReturnEntryReturnItemInfoExists(id))
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

        // POST: api/TrimsReceiveReturnEntryReturnItemInfoes
        [HttpPost]
        public async Task<ActionResult<TrimsReceiveReturnEntryReturnItemInfo>> PostTrimsReceiveReturnEntryReturnItemInfo(TrimsReceiveReturnEntryReturnItemInfo trimsReceiveReturnEntryReturnItemInfo)
        {
            _context.TrimsReceiveReturnEntryReturnItemInfoes.Add(trimsReceiveReturnEntryReturnItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsReceiveReturnEntryReturnItemInfo", new { id = trimsReceiveReturnEntryReturnItemInfo.Id }, trimsReceiveReturnEntryReturnItemInfo);
        }

        // DELETE: api/TrimsReceiveReturnEntryReturnItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsReceiveReturnEntryReturnItemInfo>> DeleteTrimsReceiveReturnEntryReturnItemInfo(int id)
        {
            var trimsReceiveReturnEntryReturnItemInfo = await _context.TrimsReceiveReturnEntryReturnItemInfoes.FindAsync(id);
            if (trimsReceiveReturnEntryReturnItemInfo == null)
            {
                return NotFound();
            }

            _context.TrimsReceiveReturnEntryReturnItemInfoes.Remove(trimsReceiveReturnEntryReturnItemInfo);
            await _context.SaveChangesAsync();

            return trimsReceiveReturnEntryReturnItemInfo;
        }

        private bool TrimsReceiveReturnEntryReturnItemInfoExists(int id)
        {
            return _context.TrimsReceiveReturnEntryReturnItemInfoes.Any(e => e.Id == id);
        }
    }
}
