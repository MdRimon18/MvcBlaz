using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsNConditionSubTablesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TermsNConditionSubTablesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TermsNConditionSubTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TermsNConditionSubTable>>> GetTermsNConditionSubTable()
        {
            return await _context.TermsNConditionSubTables.ToListAsync();
        }

        // GET: api/TermsNConditionSubTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TermsNConditionSubTable>> GetTermsNConditionSubTable(int id)
        {
            var termsNConditionSubTable = await _context.TermsNConditionSubTables.FindAsync(id);

            if (termsNConditionSubTable == null)
            {
                return NotFound();
            }

            return termsNConditionSubTable;
        }

        // PUT: api/TermsNConditionSubTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTermsNConditionSubTable(int id, TermsNConditionSubTable termsNConditionSubTable)
        {

            if (id != termsNConditionSubTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(termsNConditionSubTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermsNConditionSubTableExists(id))
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

        // POST: api/TermsNConditionSubTables
        [HttpPost]
        public async Task<ActionResult<TermsNConditionSubTable>> PostTermsNConditionSubTable(TermsNConditionSubTable termsNConditionSubTable)
        {
            _context.TermsNConditionSubTables.Add(termsNConditionSubTable);
            await _context.SaveChangesAsync();

            return Ok(1);
        }

        // DELETE: api/TermsNConditionSubTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TermsNConditionSubTable>> DeleteTermsNConditionSubTable(int id)
        {
         var TermsNConditionSubTables =   _context.TermsNConditionSubTables.Where(w => w.TermsNConditionId == id).ToList();
            foreach(var v in TermsNConditionSubTables)
            {
                var termsNConditionSubTable = await _context.TermsNConditionSubTables.FindAsync(v.Id);
                if (termsNConditionSubTable == null)
                {
                    return NotFound();
                }

                _context.TermsNConditionSubTables.Remove(termsNConditionSubTable);
                await _context.SaveChangesAsync();
            }
           

            return Ok(1);
        }

        private bool TermsNConditionSubTableExists(int id)
        {
            return _context.TermsNConditionSubTables.Any(e => e.Id == id);
        }
    }
}
