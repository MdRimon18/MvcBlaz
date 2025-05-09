using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.PIBreakDown;

namespace GarmentsERP.Controllers.Commercial.PIBreakDown
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProFormaInvoiceLabTestsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceLabTestsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceLabTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceLabTest>>> GetProFormaInvoiceLabTest()
        {
            foreach (var item in _context.ProFormaInvoiceLabTests)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Importer)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.Supplier)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceLabTests.ToListAsync();
        }

        // GET: api/ProFormaInvoiceLabTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceLabTest>> GetProFormaInvoiceLabTest(int id)
        {
            var proFormaInvoiceLabTest = await _context.ProFormaInvoiceLabTests.FindAsync(id);

            if (proFormaInvoiceLabTest == null)
            {
                return NotFound();
            }

            return proFormaInvoiceLabTest;
        }

        // PUT: api/ProFormaInvoiceLabTests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceLabTest(int id, ProFormaInvoiceLabTest proFormaInvoiceLabTest)
        {
            if (id != proFormaInvoiceLabTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceLabTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceLabTestExists(id))
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

        // POST: api/ProFormaInvoiceLabTests
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceLabTest>> PostProFormaInvoiceLabTest(ProFormaInvoiceLabTest proFormaInvoiceLabTest)
        {
            _context.ProFormaInvoiceLabTests.Add(proFormaInvoiceLabTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceLabTest", new { id = proFormaInvoiceLabTest.Id }, proFormaInvoiceLabTest);
        }

        // DELETE: api/ProFormaInvoiceLabTests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceLabTest>> DeleteProFormaInvoiceLabTest(int id)
        {
            var proFormaInvoiceLabTest = await _context.ProFormaInvoiceLabTests.FindAsync(id);
            if (proFormaInvoiceLabTest == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceLabTests.Remove(proFormaInvoiceLabTest);
            await _context.SaveChangesAsync();

            return proFormaInvoiceLabTest;
        }

        private bool ProFormaInvoiceLabTestExists(int id)
        {
            return _context.ProFormaInvoiceLabTests.Any(e => e.Id == id);
        }
    }
}
