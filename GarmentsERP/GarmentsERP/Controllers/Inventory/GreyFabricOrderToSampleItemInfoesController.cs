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
    public class GreyFabricOrderToSampleItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricOrderToSampleItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricOrderToSampleItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricOrderToSampleItemInfo>>> GetGreyFabricOrderToSampleItemInfo()
        {
            return await _context.GreyFabricOrderToSampleItemInfoes.ToListAsync();
        }

        // GET: api/GreyFabricOrderToSampleItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricOrderToSampleItemInfo>> GetGreyFabricOrderToSampleItemInfo(int id)
        {
            var greyFabricOrderToSampleItemInfo = await _context.GreyFabricOrderToSampleItemInfoes.FindAsync(id);

            if (greyFabricOrderToSampleItemInfo == null)
            {
                return NotFound();
            }

            return greyFabricOrderToSampleItemInfo;
        }

        // PUT: api/GreyFabricOrderToSampleItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricOrderToSampleItemInfo(int id, GreyFabricOrderToSampleItemInfo greyFabricOrderToSampleItemInfo)
        {
            if (id != greyFabricOrderToSampleItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricOrderToSampleItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricOrderToSampleItemInfoExists(id))
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

        // POST: api/GreyFabricOrderToSampleItemInfoes
        [HttpPost]
        public async Task<ActionResult<GreyFabricOrderToSampleItemInfo>> PostGreyFabricOrderToSampleItemInfo(GreyFabricOrderToSampleItemInfo greyFabricOrderToSampleItemInfo)
        {
            _context.GreyFabricOrderToSampleItemInfoes.Add(greyFabricOrderToSampleItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricOrderToSampleItemInfo", new { id = greyFabricOrderToSampleItemInfo.Id }, greyFabricOrderToSampleItemInfo);
        }

        // DELETE: api/GreyFabricOrderToSampleItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricOrderToSampleItemInfo>> DeleteGreyFabricOrderToSampleItemInfo(int id)
        {
            var greyFabricOrderToSampleItemInfo = await _context.GreyFabricOrderToSampleItemInfoes.FindAsync(id);
            if (greyFabricOrderToSampleItemInfo == null)
            {
                return NotFound();
            }

            _context.GreyFabricOrderToSampleItemInfoes.Remove(greyFabricOrderToSampleItemInfo);
            await _context.SaveChangesAsync();

            return greyFabricOrderToSampleItemInfo;
        }

        private bool GreyFabricOrderToSampleItemInfoExists(int id)
        {
            return _context.GreyFabricOrderToSampleItemInfoes.Any(e => e.Id == id);
        }
    }
}
