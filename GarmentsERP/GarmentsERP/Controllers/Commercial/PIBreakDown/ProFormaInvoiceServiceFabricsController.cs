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
    public class ProFormaInvoiceServiceFabricsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceServiceFabricsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceServiceFabrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceServiceFabric>>> GetProFormaInvoiceServiceFabric()
        {

            foreach (var item in _context.ProFormaInvoiceServiceFabrics)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Importer)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.Supplier)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceServiceFabrics.ToListAsync();
        }

        // GET: api/ProFormaInvoiceServiceFabrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceServiceFabric>> GetProFormaInvoiceServiceFabric(int id)
        {
            var proFormaInvoiceServiceFabric = await _context.ProFormaInvoiceServiceFabrics.FindAsync(id);

            if (proFormaInvoiceServiceFabric == null)
            {
                return NotFound();
            }

            return proFormaInvoiceServiceFabric;
        }

        // PUT: api/ProFormaInvoiceServiceFabrics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceServiceFabric(int id, ProFormaInvoiceServiceFabric proFormaInvoiceServiceFabric)
        {
            if (id != proFormaInvoiceServiceFabric.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceServiceFabric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceServiceFabricExists(id))
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

        // POST: api/ProFormaInvoiceServiceFabrics
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceServiceFabric>> PostProFormaInvoiceServiceFabric(ProFormaInvoiceServiceFabric proFormaInvoiceServiceFabric)
        {
            _context.ProFormaInvoiceServiceFabrics.Add(proFormaInvoiceServiceFabric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceServiceFabric", new { id = proFormaInvoiceServiceFabric.Id }, proFormaInvoiceServiceFabric);
        }

        // DELETE: api/ProFormaInvoiceServiceFabrics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceServiceFabric>> DeleteProFormaInvoiceServiceFabric(int id)
        {
            var proFormaInvoiceServiceFabric = await _context.ProFormaInvoiceServiceFabrics.FindAsync(id);
            if (proFormaInvoiceServiceFabric == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceServiceFabrics.Remove(proFormaInvoiceServiceFabric);
            await _context.SaveChangesAsync();

            return proFormaInvoiceServiceFabric;
        }

        private bool ProFormaInvoiceServiceFabricExists(int id)
        {
            return _context.ProFormaInvoiceServiceFabrics.Any(e => e.Id == id);
        }
    }
}
