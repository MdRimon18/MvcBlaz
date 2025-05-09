using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Export;

namespace GarmentsERP.Controllers.Commercial.Export
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreExportFinancesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PreExportFinancesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PreExportFinances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreExportFinance>>> GetPreExportFinance()
        {
            return await _context.PreExportFinances.ToListAsync();
        }

        // GET: api/PreExportFinances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreExportFinance>> GetPreExportFinance(int id)
        {
            var preExportFinance = await _context.PreExportFinances.FindAsync(id);

            if (preExportFinance == null)
            {
                return NotFound();
            }

            return preExportFinance;
        }

        // PUT: api/PreExportFinances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreExportFinance(int id, PreExportFinance preExportFinance)
        {
            if (id != preExportFinance.Id)
            {
                return BadRequest();
            }

            _context.Entry(preExportFinance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreExportFinanceExists(id))
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

        // POST: api/PreExportFinances
        [HttpPost]
        public async Task<ActionResult<PreExportFinance>> PostPreExportFinance(PreExportFinance preExportFinance)
        {
            _context.PreExportFinances.Add(preExportFinance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreExportFinance", new { id = preExportFinance.Id }, preExportFinance);
        }

        // DELETE: api/PreExportFinances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreExportFinance>> DeletePreExportFinance(int id)
        {
            var preExportFinance = await _context.PreExportFinances.FindAsync(id);
            if (preExportFinance == null)
            {
                return NotFound();
            }

            _context.PreExportFinances.Remove(preExportFinance);
            await _context.SaveChangesAsync();

            return preExportFinance;
        }

        private bool PreExportFinanceExists(int id)
        {
            return _context.PreExportFinances.Any(e => e.Id == id);
        }
    }
}
