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
    public class ProFormaInvoiceServiceYarnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceServiceYarnsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceServiceYarns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceServiceYarn>>> GetProFormaInvoiceServiceYarn()
        {
            foreach (var item in _context.ProFormaInvoiceServiceYarns)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Importer)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.Supplier)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceServiceYarns.ToListAsync();
        }

        // GET: api/ProFormaInvoiceServiceYarns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceServiceYarn>> GetProFormaInvoiceServiceYarn(int id)
        {
            var proFormaInvoiceServiceYarn = await _context.ProFormaInvoiceServiceYarns.FindAsync(id);

            if (proFormaInvoiceServiceYarn == null)
            {
                return NotFound();
            }

            return proFormaInvoiceServiceYarn;
        }

        // PUT: api/ProFormaInvoiceServiceYarns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceServiceYarn(int id, ProFormaInvoiceServiceYarn proFormaInvoiceServiceYarn)
        {
            if (id != proFormaInvoiceServiceYarn.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceServiceYarn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceServiceYarnExists(id))
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

        // POST: api/ProFormaInvoiceServiceYarns
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceServiceYarn>> PostProFormaInvoiceServiceYarn(ProFormaInvoiceServiceYarn proFormaInvoiceServiceYarn)
        {
            _context.ProFormaInvoiceServiceYarns.Add(proFormaInvoiceServiceYarn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceServiceYarn", new { id = proFormaInvoiceServiceYarn.Id }, proFormaInvoiceServiceYarn);
        }

        // DELETE: api/ProFormaInvoiceServiceYarns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceServiceYarn>> DeleteProFormaInvoiceServiceYarn(int id)
        {
            var proFormaInvoiceServiceYarn = await _context.ProFormaInvoiceServiceYarns.FindAsync(id);
            if (proFormaInvoiceServiceYarn == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceServiceYarns.Remove(proFormaInvoiceServiceYarn);
            await _context.SaveChangesAsync();

            return proFormaInvoiceServiceYarn;
        }

        private bool ProFormaInvoiceServiceYarnExists(int id)
        {
            return _context.ProFormaInvoiceServiceYarns.Any(e => e.Id == id);
        }
    }
}
