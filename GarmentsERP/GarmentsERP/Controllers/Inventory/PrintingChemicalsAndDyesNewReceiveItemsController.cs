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
    public class PrintingChemicalsAndDyesNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PrintingChemicalsAndDyesNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PrintingChemicalsAndDyesNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrintingChemicalsAndDyesNewReceiveItem>>> GetPrintingChemicalsAndDyesNewReceiveItem()
        {
            return await _context.PrintingChemicalsAndDyesNewReceiveItems.ToListAsync();
        }

        // GET: api/PrintingChemicalsAndDyesNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrintingChemicalsAndDyesNewReceiveItem>> GetPrintingChemicalsAndDyesNewReceiveItem(int id)
        {
            var printingChemicalsAndDyesNewReceiveItem = await _context.PrintingChemicalsAndDyesNewReceiveItems.FindAsync(id);

            if (printingChemicalsAndDyesNewReceiveItem == null)
            {
                return NotFound();
            }

            return printingChemicalsAndDyesNewReceiveItem;
        }

        // PUT: api/PrintingChemicalsAndDyesNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrintingChemicalsAndDyesNewReceiveItem(int id, PrintingChemicalsAndDyesNewReceiveItem printingChemicalsAndDyesNewReceiveItem)
        {
            if (id != printingChemicalsAndDyesNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(printingChemicalsAndDyesNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrintingChemicalsAndDyesNewReceiveItemExists(id))
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

        // POST: api/PrintingChemicalsAndDyesNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<PrintingChemicalsAndDyesNewReceiveItem>> PostPrintingChemicalsAndDyesNewReceiveItem(PrintingChemicalsAndDyesNewReceiveItem printingChemicalsAndDyesNewReceiveItem)
        {
            _context.PrintingChemicalsAndDyesNewReceiveItems.Add(printingChemicalsAndDyesNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrintingChemicalsAndDyesNewReceiveItem", new { id = printingChemicalsAndDyesNewReceiveItem.Id }, printingChemicalsAndDyesNewReceiveItem);
        }

        // DELETE: api/PrintingChemicalsAndDyesNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrintingChemicalsAndDyesNewReceiveItem>> DeletePrintingChemicalsAndDyesNewReceiveItem(int id)
        {
            var printingChemicalsAndDyesNewReceiveItem = await _context.PrintingChemicalsAndDyesNewReceiveItems.FindAsync(id);
            if (printingChemicalsAndDyesNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.PrintingChemicalsAndDyesNewReceiveItems.Remove(printingChemicalsAndDyesNewReceiveItem);
            await _context.SaveChangesAsync();

            return printingChemicalsAndDyesNewReceiveItem;
        }

        private bool PrintingChemicalsAndDyesNewReceiveItemExists(int id)
        {
            return _context.PrintingChemicalsAndDyesNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
