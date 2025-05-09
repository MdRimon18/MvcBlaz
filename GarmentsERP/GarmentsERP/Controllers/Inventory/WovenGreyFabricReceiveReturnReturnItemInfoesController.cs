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
    public class WovenGreyFabricReceiveReturnReturnItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public WovenGreyFabricReceiveReturnReturnItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/WovenGreyFabricReceiveReturnReturnItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WovenGreyFabricReceiveReturnReturnItemInfo>>> GetWovenGreyFabricReceiveReturnReturnItemInfo()
        {
            return await _context.WovenGreyFabricReceiveReturnReturnItemInfoes.ToListAsync();
        }

        // GET: api/WovenGreyFabricReceiveReturnReturnItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WovenGreyFabricReceiveReturnReturnItemInfo>> GetWovenGreyFabricReceiveReturnReturnItemInfo(int id)
        {
            var wovenGreyFabricReceiveReturnReturnItemInfo = await _context.WovenGreyFabricReceiveReturnReturnItemInfoes.FindAsync(id);

            if (wovenGreyFabricReceiveReturnReturnItemInfo == null)
            {
                return NotFound();
            }

            return wovenGreyFabricReceiveReturnReturnItemInfo;
        }

        // PUT: api/WovenGreyFabricReceiveReturnReturnItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWovenGreyFabricReceiveReturnReturnItemInfo(int id, WovenGreyFabricReceiveReturnReturnItemInfo wovenGreyFabricReceiveReturnReturnItemInfo)
        {
            if (id != wovenGreyFabricReceiveReturnReturnItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(wovenGreyFabricReceiveReturnReturnItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WovenGreyFabricReceiveReturnReturnItemInfoExists(id))
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

        // POST: api/WovenGreyFabricReceiveReturnReturnItemInfoes
        [HttpPost]
        public async Task<ActionResult<WovenGreyFabricReceiveReturnReturnItemInfo>> PostWovenGreyFabricReceiveReturnReturnItemInfo(WovenGreyFabricReceiveReturnReturnItemInfo wovenGreyFabricReceiveReturnReturnItemInfo)
        {
            _context.WovenGreyFabricReceiveReturnReturnItemInfoes.Add(wovenGreyFabricReceiveReturnReturnItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWovenGreyFabricReceiveReturnReturnItemInfo", new { id = wovenGreyFabricReceiveReturnReturnItemInfo.Id }, wovenGreyFabricReceiveReturnReturnItemInfo);
        }

        // DELETE: api/WovenGreyFabricReceiveReturnReturnItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WovenGreyFabricReceiveReturnReturnItemInfo>> DeleteWovenGreyFabricReceiveReturnReturnItemInfo(int id)
        {
            var wovenGreyFabricReceiveReturnReturnItemInfo = await _context.WovenGreyFabricReceiveReturnReturnItemInfoes.FindAsync(id);
            if (wovenGreyFabricReceiveReturnReturnItemInfo == null)
            {
                return NotFound();
            }

            _context.WovenGreyFabricReceiveReturnReturnItemInfoes.Remove(wovenGreyFabricReceiveReturnReturnItemInfo);
            await _context.SaveChangesAsync();

            return wovenGreyFabricReceiveReturnReturnItemInfo;
        }

        private bool WovenGreyFabricReceiveReturnReturnItemInfoExists(int id)
        {
            return _context.WovenGreyFabricReceiveReturnReturnItemInfoes.Any(e => e.Id == id);
        }
    }
}
