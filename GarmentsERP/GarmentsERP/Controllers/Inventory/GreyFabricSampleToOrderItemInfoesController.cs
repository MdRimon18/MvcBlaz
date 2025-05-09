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
    public class GreyFabricSampleToOrderItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricSampleToOrderItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricSampleToOrderItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricSampleToOrderItemInfo>>> GetGreyFabricSampleToOrderItemInfo()
        {
            return await _context.GreyFabricSampleToOrderItemInfoes.ToListAsync();
        }

        // GET: api/GreyFabricSampleToOrderItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricSampleToOrderItemInfo>> GetGreyFabricSampleToOrderItemInfo(int id)
        {
            var greyFabricSampleToOrderItemInfo = await _context.GreyFabricSampleToOrderItemInfoes.FindAsync(id);

            if (greyFabricSampleToOrderItemInfo == null)
            {
                return NotFound();
            }

            return greyFabricSampleToOrderItemInfo;
        }

        // PUT: api/GreyFabricSampleToOrderItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricSampleToOrderItemInfo(int id, GreyFabricSampleToOrderItemInfo greyFabricSampleToOrderItemInfo)
        {
            if (id != greyFabricSampleToOrderItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricSampleToOrderItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricSampleToOrderItemInfoExists(id))
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

        // POST: api/GreyFabricSampleToOrderItemInfoes
        [HttpPost]
        public async Task<ActionResult<GreyFabricSampleToOrderItemInfo>> PostGreyFabricSampleToOrderItemInfo(GreyFabricSampleToOrderItemInfo greyFabricSampleToOrderItemInfo)
        {
            _context.GreyFabricSampleToOrderItemInfoes.Add(greyFabricSampleToOrderItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricSampleToOrderItemInfo", new { id = greyFabricSampleToOrderItemInfo.Id }, greyFabricSampleToOrderItemInfo);
        }

        // DELETE: api/GreyFabricSampleToOrderItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricSampleToOrderItemInfo>> DeleteGreyFabricSampleToOrderItemInfo(int id)
        {
            var greyFabricSampleToOrderItemInfo = await _context.GreyFabricSampleToOrderItemInfoes.FindAsync(id);
            if (greyFabricSampleToOrderItemInfo == null)
            {
                return NotFound();
            }

            _context.GreyFabricSampleToOrderItemInfoes.Remove(greyFabricSampleToOrderItemInfo);
            await _context.SaveChangesAsync();

            return greyFabricSampleToOrderItemInfo;
        }

        private bool GreyFabricSampleToOrderItemInfoExists(int id)
        {
            return _context.GreyFabricSampleToOrderItemInfoes.Any(e => e.Id == id);
        }
    }
}
