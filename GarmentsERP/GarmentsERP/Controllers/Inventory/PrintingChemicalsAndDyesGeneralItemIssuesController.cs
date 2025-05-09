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
    public class PrintingChemicalsAndDyesGeneralItemIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PrintingChemicalsAndDyesGeneralItemIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PrintingChemicalsAndDyesGeneralItemIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrintingChemicalsAndDyesGeneralItemIssue>>> GetPrintingChemicalsAndDyesGeneralItemIssue()
        {
            return await _context.PrintingChemicalsAndDyesGeneralItemIssues.ToListAsync();
        }

        // GET: api/PrintingChemicalsAndDyesGeneralItemIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrintingChemicalsAndDyesGeneralItemIssue>> GetPrintingChemicalsAndDyesGeneralItemIssue(int id)
        {
            var printingChemicalsAndDyesGeneralItemIssue = await _context.PrintingChemicalsAndDyesGeneralItemIssues.FindAsync(id);

            if (printingChemicalsAndDyesGeneralItemIssue == null)
            {
                return NotFound();
            }

            return printingChemicalsAndDyesGeneralItemIssue;
        }

        // PUT: api/PrintingChemicalsAndDyesGeneralItemIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrintingChemicalsAndDyesGeneralItemIssue(int id, PrintingChemicalsAndDyesGeneralItemIssue printingChemicalsAndDyesGeneralItemIssue)
        {
            if (id != printingChemicalsAndDyesGeneralItemIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(printingChemicalsAndDyesGeneralItemIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrintingChemicalsAndDyesGeneralItemIssueExists(id))
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

        // POST: api/PrintingChemicalsAndDyesGeneralItemIssues
        [HttpPost]
        public async Task<ActionResult<PrintingChemicalsAndDyesGeneralItemIssue>> PostPrintingChemicalsAndDyesGeneralItemIssue(PrintingChemicalsAndDyesGeneralItemIssue printingChemicalsAndDyesGeneralItemIssue)
        {
            _context.PrintingChemicalsAndDyesGeneralItemIssues.Add(printingChemicalsAndDyesGeneralItemIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrintingChemicalsAndDyesGeneralItemIssue", new { id = printingChemicalsAndDyesGeneralItemIssue.Id }, printingChemicalsAndDyesGeneralItemIssue);
        }

        // DELETE: api/PrintingChemicalsAndDyesGeneralItemIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrintingChemicalsAndDyesGeneralItemIssue>> DeletePrintingChemicalsAndDyesGeneralItemIssue(int id)
        {
            var printingChemicalsAndDyesGeneralItemIssue = await _context.PrintingChemicalsAndDyesGeneralItemIssues.FindAsync(id);
            if (printingChemicalsAndDyesGeneralItemIssue == null)
            {
                return NotFound();
            }

            _context.PrintingChemicalsAndDyesGeneralItemIssues.Remove(printingChemicalsAndDyesGeneralItemIssue);
            await _context.SaveChangesAsync();

            return printingChemicalsAndDyesGeneralItemIssue;
        }

        private bool PrintingChemicalsAndDyesGeneralItemIssueExists(int id)
        {
            return _context.PrintingChemicalsAndDyesGeneralItemIssues.Any(e => e.Id == id);
        }
    }
}
