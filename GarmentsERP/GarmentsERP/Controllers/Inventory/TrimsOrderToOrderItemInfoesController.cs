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
    public class TrimsOrderToOrderItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsOrderToOrderItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsOrderToOrderItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsOrderToOrderItemInfo>>> GetTrimsOrderToOrderItemInfo()
        {
            return await _context.TrimsOrderToOrderItemInfoes.ToListAsync();
        }

        // GET: api/TrimsOrderToOrderItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimsOrderToOrderItemInfo>> GetTrimsOrderToOrderItemInfo(int id)
        {
            var trimsOrderToOrderItemInfo = await _context.TrimsOrderToOrderItemInfoes.FindAsync(id);

            if (trimsOrderToOrderItemInfo == null)
            {
                return NotFound();
            }

            return trimsOrderToOrderItemInfo;
        }

        // PUT: api/TrimsOrderToOrderItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsOrderToOrderItemInfo(int id, TrimsOrderToOrderItemInfo trimsOrderToOrderItemInfo)
        {
            if (id != trimsOrderToOrderItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsOrderToOrderItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsOrderToOrderItemInfoExists(id))
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

        // POST: api/TrimsOrderToOrderItemInfoes
        [HttpPost]
        public async Task<ActionResult<TrimsOrderToOrderItemInfo>> PostTrimsOrderToOrderItemInfo(TrimsOrderToOrderItemInfo trimsOrderToOrderItemInfo)
        {
            _context.TrimsOrderToOrderItemInfoes.Add(trimsOrderToOrderItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrimsOrderToOrderItemInfo", new { id = trimsOrderToOrderItemInfo.Id }, trimsOrderToOrderItemInfo);
        }

        // DELETE: api/TrimsOrderToOrderItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimsOrderToOrderItemInfo>> DeleteTrimsOrderToOrderItemInfo(int id)
        {
            var trimsOrderToOrderItemInfo = await _context.TrimsOrderToOrderItemInfoes.FindAsync(id);
            if (trimsOrderToOrderItemInfo == null)
            {
                return NotFound();
            }

            _context.TrimsOrderToOrderItemInfoes.Remove(trimsOrderToOrderItemInfo);
            await _context.SaveChangesAsync();

            return trimsOrderToOrderItemInfo;
        }

        private bool TrimsOrderToOrderItemInfoExists(int id)
        {
            return _context.TrimsOrderToOrderItemInfoes.Any(e => e.Id == id);
        }
    }
}
