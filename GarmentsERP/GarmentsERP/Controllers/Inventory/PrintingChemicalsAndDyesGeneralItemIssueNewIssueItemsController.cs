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
    public class PrintingChemicalsAndDyesGeneralItemIssueNewIssueItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PrintingChemicalsAndDyesGeneralItemIssueNewIssueItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrintingChemicalsAndDyesGeneralItemIssueNewIssueItem>>> GetPrintingChemicalsAndDyesGeneralItemIssueNewIssueItem()
        {
            return await _context.PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems.ToListAsync();
        }

        // GET: api/PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrintingChemicalsAndDyesGeneralItemIssueNewIssueItem>> GetPrintingChemicalsAndDyesGeneralItemIssueNewIssueItem(int id)
        {
            var printingChemicalsAndDyesGeneralItemIssueNewIssueItem = await _context.PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems.FindAsync(id);

            if (printingChemicalsAndDyesGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            return printingChemicalsAndDyesGeneralItemIssueNewIssueItem;
        }

        // PUT: api/PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrintingChemicalsAndDyesGeneralItemIssueNewIssueItem(int id, PrintingChemicalsAndDyesGeneralItemIssueNewIssueItem printingChemicalsAndDyesGeneralItemIssueNewIssueItem)
        {
            if (id != printingChemicalsAndDyesGeneralItemIssueNewIssueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(printingChemicalsAndDyesGeneralItemIssueNewIssueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrintingChemicalsAndDyesGeneralItemIssueNewIssueItemExists(id))
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

        // POST: api/PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems
        [HttpPost]
        public async Task<ActionResult<PrintingChemicalsAndDyesGeneralItemIssueNewIssueItem>> PostPrintingChemicalsAndDyesGeneralItemIssueNewIssueItem(PrintingChemicalsAndDyesGeneralItemIssueNewIssueItem printingChemicalsAndDyesGeneralItemIssueNewIssueItem)
        {
            _context.PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems.Add(printingChemicalsAndDyesGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrintingChemicalsAndDyesGeneralItemIssueNewIssueItem", new { id = printingChemicalsAndDyesGeneralItemIssueNewIssueItem.Id }, printingChemicalsAndDyesGeneralItemIssueNewIssueItem);
        }

        // DELETE: api/PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrintingChemicalsAndDyesGeneralItemIssueNewIssueItem>> DeletePrintingChemicalsAndDyesGeneralItemIssueNewIssueItem(int id)
        {
            var printingChemicalsAndDyesGeneralItemIssueNewIssueItem = await _context.PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems.FindAsync(id);
            if (printingChemicalsAndDyesGeneralItemIssueNewIssueItem == null)
            {
                return NotFound();
            }

            _context.PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems.Remove(printingChemicalsAndDyesGeneralItemIssueNewIssueItem);
            await _context.SaveChangesAsync();

            return printingChemicalsAndDyesGeneralItemIssueNewIssueItem;
        }

        private bool PrintingChemicalsAndDyesGeneralItemIssueNewIssueItemExists(int id)
        {
            return _context.PrintingChemicalsAndDyesGeneralItemIssueNewIssueItems.Any(e => e.Id == id);
        }
    }
}
