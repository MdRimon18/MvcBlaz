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
    public class ProFormaInvoiceServiceEmbellishmentsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceServiceEmbellishmentsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceServiceEmbellishments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceServiceEmbellishment>>> GetProFormaInvoiceServiceEmbellishment()
        {
            foreach (var item in _context.ProFormaInvoiceServiceEmbellishments)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Importer)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.Supplier)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceServiceEmbellishments.ToListAsync();
        }

        // GET: api/ProFormaInvoiceServiceEmbellishments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceServiceEmbellishment>> GetProFormaInvoiceServiceEmbellishment(int id)
        {
            var proFormaInvoiceServiceEmbellishment = await _context.ProFormaInvoiceServiceEmbellishments.FindAsync(id);

            if (proFormaInvoiceServiceEmbellishment == null)
            {
                return NotFound();
            }

            return proFormaInvoiceServiceEmbellishment;
        }

        // PUT: api/ProFormaInvoiceServiceEmbellishments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceServiceEmbellishment(int id, ProFormaInvoiceServiceEmbellishment proFormaInvoiceServiceEmbellishment)
        {
            if (id != proFormaInvoiceServiceEmbellishment.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceServiceEmbellishment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceServiceEmbellishmentExists(id))
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

        // POST: api/ProFormaInvoiceServiceEmbellishments
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceServiceEmbellishment>> PostProFormaInvoiceServiceEmbellishment(ProFormaInvoiceServiceEmbellishment proFormaInvoiceServiceEmbellishment)
        {
            _context.ProFormaInvoiceServiceEmbellishments.Add(proFormaInvoiceServiceEmbellishment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceServiceEmbellishment", new { id = proFormaInvoiceServiceEmbellishment.Id }, proFormaInvoiceServiceEmbellishment);
        }

        // DELETE: api/ProFormaInvoiceServiceEmbellishments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceServiceEmbellishment>> DeleteProFormaInvoiceServiceEmbellishment(int id)
        {
            var proFormaInvoiceServiceEmbellishment = await _context.ProFormaInvoiceServiceEmbellishments.FindAsync(id);
            if (proFormaInvoiceServiceEmbellishment == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceServiceEmbellishments.Remove(proFormaInvoiceServiceEmbellishment);
            await _context.SaveChangesAsync();

            return proFormaInvoiceServiceEmbellishment;
        }

        private bool ProFormaInvoiceServiceEmbellishmentExists(int id)
        {
            return _context.ProFormaInvoiceServiceEmbellishments.Any(e => e.Id == id);
        }
    }
}
