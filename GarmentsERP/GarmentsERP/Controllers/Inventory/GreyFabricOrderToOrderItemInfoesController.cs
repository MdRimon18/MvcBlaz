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
    public class GreyFabricOrderToOrderItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricOrderToOrderItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricOrderToOrderItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricOrderToOrderItemInfo>>> GetGreyFabricOrderToOrderItemInfo()
        {
            return await _context.GreyFabricOrderToOrderItemInfoes.ToListAsync();
        }

        // GET: api/GreyFabricOrderToOrderItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricOrderToOrderItemInfo>> GetGreyFabricOrderToOrderItemInfo(int id)
        {
            var greyFabricOrderToOrderItemInfo = await _context.GreyFabricOrderToOrderItemInfoes.FindAsync(id);

            if (greyFabricOrderToOrderItemInfo == null)
            {
                return NotFound();
            }

            return greyFabricOrderToOrderItemInfo;
        }

        // PUT: api/GreyFabricOrderToOrderItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricOrderToOrderItemInfo(int id, GreyFabricOrderToOrderItemInfo greyFabricOrderToOrderItemInfo)
        {
            if (id != greyFabricOrderToOrderItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricOrderToOrderItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricOrderToOrderItemInfoExists(id))
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

        // POST: api/GreyFabricOrderToOrderItemInfoes
        [HttpPost]
        public async Task<ActionResult<GreyFabricOrderToOrderItemInfo>> PostGreyFabricOrderToOrderItemInfo(GreyFabricOrderToOrderItemInfo greyFabricOrderToOrderItemInfo)
        {
            _context.GreyFabricOrderToOrderItemInfoes.Add(greyFabricOrderToOrderItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricOrderToOrderItemInfo", new { id = greyFabricOrderToOrderItemInfo.Id }, greyFabricOrderToOrderItemInfo);
        }

        // DELETE: api/GreyFabricOrderToOrderItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricOrderToOrderItemInfo>> DeleteGreyFabricOrderToOrderItemInfo(int id)
        {
            var greyFabricOrderToOrderItemInfo = await _context.GreyFabricOrderToOrderItemInfoes.FindAsync(id);
            if (greyFabricOrderToOrderItemInfo == null)
            {
                return NotFound();
            }

            _context.GreyFabricOrderToOrderItemInfoes.Remove(greyFabricOrderToOrderItemInfo);
            await _context.SaveChangesAsync();

            return greyFabricOrderToOrderItemInfo;
        }

        private bool GreyFabricOrderToOrderItemInfoExists(int id)
        {
            return _context.GreyFabricOrderToOrderItemInfoes.Any(e => e.Id == id);
        }
    }
}
