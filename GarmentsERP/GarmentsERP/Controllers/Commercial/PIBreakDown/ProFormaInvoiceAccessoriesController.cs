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
    public class ProFormaInvoiceAccessoriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceAccessoriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceAccessories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceAccessories>>> GetProFormaInvoiceAccessories()
        {
            foreach (var item in _context.ProFormaInvoiceAccessories)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Importer)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.Supplier)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceAccessories.ToListAsync();
        }

        // GET: api/ProFormaInvoiceAccessories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceAccessories>> GetProFormaInvoiceAccessories(int id)
        {
            var proFormaInvoiceAccessories = await _context.ProFormaInvoiceAccessories.FindAsync(id);

            if (proFormaInvoiceAccessories == null)
            {
                return NotFound();
            }

            return proFormaInvoiceAccessories;
        }

        // PUT: api/ProFormaInvoiceAccessories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceAccessories(int id, ProFormaInvoiceAccessories proFormaInvoiceAccessories)
        {
            if (id != proFormaInvoiceAccessories.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceAccessories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceAccessoriesExists(id))
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

        // POST: api/ProFormaInvoiceAccessories
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceAccessories>> PostProFormaInvoiceAccessories(ProFormaInvoiceAccessories proFormaInvoiceAccessories)
        {
            _context.ProFormaInvoiceAccessories.Add(proFormaInvoiceAccessories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceAccessories", new { id = proFormaInvoiceAccessories.Id }, proFormaInvoiceAccessories);
        }

        // DELETE: api/ProFormaInvoiceAccessories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceAccessories>> DeleteProFormaInvoiceAccessories(int id)
        {
            var proFormaInvoiceAccessories = await _context.ProFormaInvoiceAccessories.FindAsync(id);
            if (proFormaInvoiceAccessories == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceAccessories.Remove(proFormaInvoiceAccessories);
            await _context.SaveChangesAsync();

            return proFormaInvoiceAccessories;
        }

        private bool ProFormaInvoiceAccessoriesExists(int id)
        {
            return _context.ProFormaInvoiceAccessories.Any(e => e.Id == id);
        }
    }
}
