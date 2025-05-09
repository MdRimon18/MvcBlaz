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
    public class ProFormaInvoiceFabricsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceFabricsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceFabrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceFabric>>> GetProFormaInvoiceFabric()
        {
            foreach (var item in _context.ProFormaInvoiceFabrics)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Importer)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.Supplier)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceFabrics.ToListAsync();
        }

        // GET: api/ProFormaInvoiceFabrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceFabric>> GetProFormaInvoiceFabric(int id)
        {
            var proFormaInvoiceFabric = await _context.ProFormaInvoiceFabrics.FindAsync(id);

            if (proFormaInvoiceFabric == null)
            {
                return NotFound();
            }

            return proFormaInvoiceFabric;
        }

        // PUT: api/ProFormaInvoiceFabrics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceFabric(int id, ProFormaInvoiceFabric proFormaInvoiceFabric)
        {
            if (id != proFormaInvoiceFabric.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceFabric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceFabricExists(id))
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

        // POST: api/ProFormaInvoiceFabrics
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceFabric>> PostProFormaInvoiceFabric(ProFormaInvoiceFabric proFormaInvoiceFabric)
        {
            _context.ProFormaInvoiceFabrics.Add(proFormaInvoiceFabric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceFabric", new { id = proFormaInvoiceFabric.Id }, proFormaInvoiceFabric);
        }

        // DELETE: api/ProFormaInvoiceFabrics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceFabric>> DeleteProFormaInvoiceFabric(int id)
        {
            var proFormaInvoiceFabric = await _context.ProFormaInvoiceFabrics.FindAsync(id);
            if (proFormaInvoiceFabric == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceFabrics.Remove(proFormaInvoiceFabric);
            await _context.SaveChangesAsync();

            return proFormaInvoiceFabric;
        }

        private bool ProFormaInvoiceFabricExists(int id)
        {
            return _context.ProFormaInvoiceFabrics.Any(e => e.Id == id);
        }
    }
}
