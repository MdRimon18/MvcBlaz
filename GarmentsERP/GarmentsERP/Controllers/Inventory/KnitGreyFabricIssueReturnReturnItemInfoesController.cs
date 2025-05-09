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
    public class KnitGreyFabricIssueReturnReturnItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnitGreyFabricIssueReturnReturnItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnitGreyFabricIssueReturnReturnItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnitGreyFabricIssueReturnReturnItemInfo>>> GetKnitGreyFabricIssueReturnReturnItemInfo()
        {
            return await _context.KnitGreyFabricIssueReturnReturnItemInfoes.ToListAsync();
        }

        // GET: api/KnitGreyFabricIssueReturnReturnItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnitGreyFabricIssueReturnReturnItemInfo>> GetKnitGreyFabricIssueReturnReturnItemInfo(int id)
        {
            var knitGreyFabricIssueReturnReturnItemInfo = await _context.KnitGreyFabricIssueReturnReturnItemInfoes.FindAsync(id);

            if (knitGreyFabricIssueReturnReturnItemInfo == null)
            {
                return NotFound();
            }

            return knitGreyFabricIssueReturnReturnItemInfo;
        }

        // PUT: api/KnitGreyFabricIssueReturnReturnItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnitGreyFabricIssueReturnReturnItemInfo(int id, KnitGreyFabricIssueReturnReturnItemInfo knitGreyFabricIssueReturnReturnItemInfo)
        {
            if (id != knitGreyFabricIssueReturnReturnItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(knitGreyFabricIssueReturnReturnItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnitGreyFabricIssueReturnReturnItemInfoExists(id))
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

        // POST: api/KnitGreyFabricIssueReturnReturnItemInfoes
        [HttpPost]
        public async Task<ActionResult<KnitGreyFabricIssueReturnReturnItemInfo>> PostKnitGreyFabricIssueReturnReturnItemInfo(KnitGreyFabricIssueReturnReturnItemInfo knitGreyFabricIssueReturnReturnItemInfo)
        {
            _context.KnitGreyFabricIssueReturnReturnItemInfoes.Add(knitGreyFabricIssueReturnReturnItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnitGreyFabricIssueReturnReturnItemInfo", new { id = knitGreyFabricIssueReturnReturnItemInfo.Id }, knitGreyFabricIssueReturnReturnItemInfo);
        }

        // DELETE: api/KnitGreyFabricIssueReturnReturnItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnitGreyFabricIssueReturnReturnItemInfo>> DeleteKnitGreyFabricIssueReturnReturnItemInfo(int id)
        {
            var knitGreyFabricIssueReturnReturnItemInfo = await _context.KnitGreyFabricIssueReturnReturnItemInfoes.FindAsync(id);
            if (knitGreyFabricIssueReturnReturnItemInfo == null)
            {
                return NotFound();
            }

            _context.KnitGreyFabricIssueReturnReturnItemInfoes.Remove(knitGreyFabricIssueReturnReturnItemInfo);
            await _context.SaveChangesAsync();

            return knitGreyFabricIssueReturnReturnItemInfo;
        }

        private bool KnitGreyFabricIssueReturnReturnItemInfoExists(int id)
        {
            return _context.KnitGreyFabricIssueReturnReturnItemInfoes.Any(e => e.Id == id);
        }
    }
}
