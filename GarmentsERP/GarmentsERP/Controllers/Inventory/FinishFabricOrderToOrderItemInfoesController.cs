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
    public class FinishFabricOrderToOrderItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricOrderToOrderItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricOrderToOrderItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricOrderToOrderItemInfo>>> GetFinishFabricOrderToOrderItemInfo()
        {
            return await _context.FinishFabricOrderToOrderItemInfoes.ToListAsync();
        }

        // GET: api/FinishFabricOrderToOrderItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricOrderToOrderItemInfo>> GetFinishFabricOrderToOrderItemInfo(int id)
        {
            var finishFabricOrderToOrderItemInfo = await _context.FinishFabricOrderToOrderItemInfoes.FindAsync(id);

            if (finishFabricOrderToOrderItemInfo == null)
            {
                return NotFound();
            }

            return finishFabricOrderToOrderItemInfo;
        }

        // PUT: api/FinishFabricOrderToOrderItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricOrderToOrderItemInfo(int id, FinishFabricOrderToOrderItemInfo finishFabricOrderToOrderItemInfo)
        {
            if (id != finishFabricOrderToOrderItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricOrderToOrderItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricOrderToOrderItemInfoExists(id))
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

        // POST: api/FinishFabricOrderToOrderItemInfoes
        [HttpPost]
        public async Task<ActionResult<FinishFabricOrderToOrderItemInfo>> PostFinishFabricOrderToOrderItemInfo(FinishFabricOrderToOrderItemInfo finishFabricOrderToOrderItemInfo)
        {
            _context.FinishFabricOrderToOrderItemInfoes.Add(finishFabricOrderToOrderItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricOrderToOrderItemInfo", new { id = finishFabricOrderToOrderItemInfo.Id }, finishFabricOrderToOrderItemInfo);
        }

        // DELETE: api/FinishFabricOrderToOrderItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricOrderToOrderItemInfo>> DeleteFinishFabricOrderToOrderItemInfo(int id)
        {
            var finishFabricOrderToOrderItemInfo = await _context.FinishFabricOrderToOrderItemInfoes.FindAsync(id);
            if (finishFabricOrderToOrderItemInfo == null)
            {
                return NotFound();
            }

            _context.FinishFabricOrderToOrderItemInfoes.Remove(finishFabricOrderToOrderItemInfo);
            await _context.SaveChangesAsync();

            return finishFabricOrderToOrderItemInfo;
        }

        private bool FinishFabricOrderToOrderItemInfoExists(int id)
        {
            return _context.FinishFabricOrderToOrderItemInfoes.Any(e => e.Id == id);
        }
    }
}
