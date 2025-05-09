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
    public class GeneralItemIssueReturnReturnItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemIssueReturnReturnItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemIssueReturnReturnItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemIssueReturnReturnItemInfo>>> GetGeneralItemIssueReturnReturnItemInfo()
        {
            return await _context.GeneralItemIssueReturnReturnItemInfoes.ToListAsync();
        }

        // GET: api/GeneralItemIssueReturnReturnItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemIssueReturnReturnItemInfo>> GetGeneralItemIssueReturnReturnItemInfo(int id)
        {
            var generalItemIssueReturnReturnItemInfo = await _context.GeneralItemIssueReturnReturnItemInfoes.FindAsync(id);

            if (generalItemIssueReturnReturnItemInfo == null)
            {
                return NotFound();
            }

            return generalItemIssueReturnReturnItemInfo;
        }

        // PUT: api/GeneralItemIssueReturnReturnItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemIssueReturnReturnItemInfo(int id, GeneralItemIssueReturnReturnItemInfo generalItemIssueReturnReturnItemInfo)
        {
            if (id != generalItemIssueReturnReturnItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemIssueReturnReturnItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemIssueReturnReturnItemInfoExists(id))
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

        // POST: api/GeneralItemIssueReturnReturnItemInfoes
        [HttpPost]
        public async Task<ActionResult<GeneralItemIssueReturnReturnItemInfo>> PostGeneralItemIssueReturnReturnItemInfo(GeneralItemIssueReturnReturnItemInfo generalItemIssueReturnReturnItemInfo)
        {
            _context.GeneralItemIssueReturnReturnItemInfoes.Add(generalItemIssueReturnReturnItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemIssueReturnReturnItemInfo", new { id = generalItemIssueReturnReturnItemInfo.Id }, generalItemIssueReturnReturnItemInfo);
        }

        // DELETE: api/GeneralItemIssueReturnReturnItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemIssueReturnReturnItemInfo>> DeleteGeneralItemIssueReturnReturnItemInfo(int id)
        {
            var generalItemIssueReturnReturnItemInfo = await _context.GeneralItemIssueReturnReturnItemInfoes.FindAsync(id);
            if (generalItemIssueReturnReturnItemInfo == null)
            {
                return NotFound();
            }

            _context.GeneralItemIssueReturnReturnItemInfoes.Remove(generalItemIssueReturnReturnItemInfo);
            await _context.SaveChangesAsync();

            return generalItemIssueReturnReturnItemInfo;
        }

        private bool GeneralItemIssueReturnReturnItemInfoExists(int id)
        {
            return _context.GeneralItemIssueReturnReturnItemInfoes.Any(e => e.Id == id);
        }
    }
}
