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
    public class GeneralItemIssueReturnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GeneralItemIssueReturnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GeneralItemIssueReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralItemIssueReturn>>> GetGeneralItemIssueReturn()
        {
            return await _context.GeneralItemIssueReturns.ToListAsync();
        }

        // GET: api/GeneralItemIssueReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralItemIssueReturn>> GetGeneralItemIssueReturn(int id)
        {
            var generalItemIssueReturn = await _context.GeneralItemIssueReturns.FindAsync(id);

            if (generalItemIssueReturn == null)
            {
                return NotFound();
            }

            return generalItemIssueReturn;
        }

        // PUT: api/GeneralItemIssueReturns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralItemIssueReturn(int id, GeneralItemIssueReturn generalItemIssueReturn)
        {
            if (id != generalItemIssueReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalItemIssueReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralItemIssueReturnExists(id))
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

        // POST: api/GeneralItemIssueReturns
        [HttpPost]
        public async Task<ActionResult<GeneralItemIssueReturn>> PostGeneralItemIssueReturn(GeneralItemIssueReturn generalItemIssueReturn)
        {
            _context.GeneralItemIssueReturns.Add(generalItemIssueReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralItemIssueReturn", new { id = generalItemIssueReturn.Id }, generalItemIssueReturn);
        }

        // DELETE: api/GeneralItemIssueReturns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralItemIssueReturn>> DeleteGeneralItemIssueReturn(int id)
        {
            var generalItemIssueReturn = await _context.GeneralItemIssueReturns.FindAsync(id);
            if (generalItemIssueReturn == null)
            {
                return NotFound();
            }

            _context.GeneralItemIssueReturns.Remove(generalItemIssueReturn);
            await _context.SaveChangesAsync();

            return generalItemIssueReturn;
        }

        private bool GeneralItemIssueReturnExists(int id)
        {
            return _context.GeneralItemIssueReturns.Any(e => e.Id == id);
        }
    }
}
