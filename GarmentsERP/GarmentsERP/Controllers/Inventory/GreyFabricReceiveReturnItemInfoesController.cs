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
    public class GreyFabricReceiveReturnItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricReceiveReturnItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricReceiveReturnItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricReceiveReturnItemInfo>>> GetGreyFabricReceiveReturnItemInfo()
        {
            return await _context.GreyFabricReceiveReturnItemInfoes.ToListAsync();
        }

        // GET: api/GreyFabricReceiveReturnItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricReceiveReturnItemInfo>> GetGreyFabricReceiveReturnItemInfo(int id)
        {
            var greyFabricReceiveReturnItemInfo = await _context.GreyFabricReceiveReturnItemInfoes.FindAsync(id);

            if (greyFabricReceiveReturnItemInfo == null)
            {
                return NotFound();
            }

            return greyFabricReceiveReturnItemInfo;
        }

        // PUT: api/GreyFabricReceiveReturnItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricReceiveReturnItemInfo(int id, GreyFabricReceiveReturnItemInfo greyFabricReceiveReturnItemInfo)
        {
            if (id != greyFabricReceiveReturnItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricReceiveReturnItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricReceiveReturnItemInfoExists(id))
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

        // POST: api/GreyFabricReceiveReturnItemInfoes
        [HttpPost]
        public async Task<ActionResult<GreyFabricReceiveReturnItemInfo>> PostGreyFabricReceiveReturnItemInfo(GreyFabricReceiveReturnItemInfo greyFabricReceiveReturnItemInfo)
        {
            _context.GreyFabricReceiveReturnItemInfoes.Add(greyFabricReceiveReturnItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricReceiveReturnItemInfo", new { id = greyFabricReceiveReturnItemInfo.Id }, greyFabricReceiveReturnItemInfo);
        }

        // DELETE: api/GreyFabricReceiveReturnItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricReceiveReturnItemInfo>> DeleteGreyFabricReceiveReturnItemInfo(int id)
        {
            var greyFabricReceiveReturnItemInfo = await _context.GreyFabricReceiveReturnItemInfoes.FindAsync(id);
            if (greyFabricReceiveReturnItemInfo == null)
            {
                return NotFound();
            }

            _context.GreyFabricReceiveReturnItemInfoes.Remove(greyFabricReceiveReturnItemInfo);
            await _context.SaveChangesAsync();

            return greyFabricReceiveReturnItemInfo;
        }

        private bool GreyFabricReceiveReturnItemInfoExists(int id)
        {
            return _context.GreyFabricReceiveReturnItemInfoes.Any(e => e.Id == id);
        }
    }
}
