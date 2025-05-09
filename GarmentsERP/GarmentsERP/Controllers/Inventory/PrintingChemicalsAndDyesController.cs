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
    public class PrintingChemicalsAndDyesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PrintingChemicalsAndDyesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PrintingChemicalsAndDyes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrintingChemicalsAndDyes>>> GetPrintingChemicalsAndDyes()
        {
            return await _context.PrintingChemicalsAndDyes.ToListAsync();
        }

        // GET: api/PrintingChemicalsAndDyes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrintingChemicalsAndDyes>> GetPrintingChemicalsAndDyes(int id)
        {
            var printingChemicalsAndDyes = await _context.PrintingChemicalsAndDyes.FindAsync(id);

            if (printingChemicalsAndDyes == null)
            {
                return NotFound();
            }

            return printingChemicalsAndDyes;
        }

        // PUT: api/PrintingChemicalsAndDyes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrintingChemicalsAndDyes(int id, PrintingChemicalsAndDyes printingChemicalsAndDyes)
        {
            if (id != printingChemicalsAndDyes.Id)
            {
                return BadRequest();
            }

            _context.Entry(printingChemicalsAndDyes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrintingChemicalsAndDyesExists(id))
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

        // POST: api/PrintingChemicalsAndDyes
        [HttpPost]
        public async Task<ActionResult<PrintingChemicalsAndDyes>> PostPrintingChemicalsAndDyes(PrintingChemicalsAndDyes printingChemicalsAndDyes)
        {
            _context.PrintingChemicalsAndDyes.Add(printingChemicalsAndDyes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrintingChemicalsAndDyes", new { id = printingChemicalsAndDyes.Id }, printingChemicalsAndDyes);
        }

        // DELETE: api/PrintingChemicalsAndDyes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrintingChemicalsAndDyes>> DeletePrintingChemicalsAndDyes(int id)
        {
            var printingChemicalsAndDyes = await _context.PrintingChemicalsAndDyes.FindAsync(id);
            if (printingChemicalsAndDyes == null)
            {
                return NotFound();
            }

            _context.PrintingChemicalsAndDyes.Remove(printingChemicalsAndDyes);
            await _context.SaveChangesAsync();

            return printingChemicalsAndDyes;
        }

        private bool PrintingChemicalsAndDyesExists(int id)
        {
            return _context.PrintingChemicalsAndDyes.Any(e => e.Id == id);
        }
    }
}
