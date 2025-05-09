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
    public class YarnOrderToOrderItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnOrderToOrderItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnOrderToOrderItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnOrderToOrderItemInfo>>> GetYarnOrderToOrderItemInfo()
        {
            return await _context.YarnOrderToOrderItemInfoes.ToListAsync();
        }

        // GET: api/YarnOrderToOrderItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnOrderToOrderItemInfo>> GetYarnOrderToOrderItemInfo(int id)
        {
            var yarnOrderToOrderItemInfo = await _context.YarnOrderToOrderItemInfoes.FindAsync(id);

            if (yarnOrderToOrderItemInfo == null)
            {
                return NotFound();
            }

            return yarnOrderToOrderItemInfo;
        }

        // PUT: api/YarnOrderToOrderItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnOrderToOrderItemInfo(int id, YarnOrderToOrderItemInfo yarnOrderToOrderItemInfo)
        {
            if (id != yarnOrderToOrderItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnOrderToOrderItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnOrderToOrderItemInfoExists(id))
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

        // POST: api/YarnOrderToOrderItemInfoes
        [HttpPost]
        public async Task<ActionResult<YarnOrderToOrderItemInfo>> PostYarnOrderToOrderItemInfo(YarnOrderToOrderItemInfo yarnOrderToOrderItemInfo)
        {
            _context.YarnOrderToOrderItemInfoes.Add(yarnOrderToOrderItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnOrderToOrderItemInfo", new { id = yarnOrderToOrderItemInfo.Id }, yarnOrderToOrderItemInfo);
        }

        // DELETE: api/YarnOrderToOrderItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnOrderToOrderItemInfo>> DeleteYarnOrderToOrderItemInfo(int id)
        {
            var yarnOrderToOrderItemInfo = await _context.YarnOrderToOrderItemInfoes.FindAsync(id);
            if (yarnOrderToOrderItemInfo == null)
            {
                return NotFound();
            }

            _context.YarnOrderToOrderItemInfoes.Remove(yarnOrderToOrderItemInfo);
            await _context.SaveChangesAsync();

            return yarnOrderToOrderItemInfo;
        }

        private bool YarnOrderToOrderItemInfoExists(int id)
        {
            return _context.YarnOrderToOrderItemInfoes.Any(e => e.Id == id);
        }
    }
}
