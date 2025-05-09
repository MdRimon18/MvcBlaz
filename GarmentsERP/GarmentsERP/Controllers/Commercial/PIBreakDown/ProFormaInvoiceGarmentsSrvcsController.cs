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
    public class ProFormaInvoiceGarmentsSrvcsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceGarmentsSrvcsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceGarmentsSrvcs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceGarmentsSrvc>>> GetProFormaInvoiceGarmentsSrvc()
        {
            foreach (var item in _context.ProFormaInvoiceGarmentsSrvcs)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Importer)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.Supplier)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceGarmentsSrvcs.ToListAsync();
        }

        // GET: api/ProFormaInvoiceGarmentsSrvcs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceGarmentsSrvc>> GetProFormaInvoiceGarmentsSrvc(int id)
        {
            var proFormaInvoiceGarmentsSrvc = await _context.ProFormaInvoiceGarmentsSrvcs.FindAsync(id);

            if (proFormaInvoiceGarmentsSrvc == null)
            {
                return NotFound();
            }

            return proFormaInvoiceGarmentsSrvc;
        }

        // PUT: api/ProFormaInvoiceGarmentsSrvcs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceGarmentsSrvc(int id, ProFormaInvoiceGarmentsSrvc proFormaInvoiceGarmentsSrvc)
        {
            if (id != proFormaInvoiceGarmentsSrvc.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceGarmentsSrvc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceGarmentsSrvcExists(id))
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

        // POST: api/ProFormaInvoiceGarmentsSrvcs
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceGarmentsSrvc>> PostProFormaInvoiceGarmentsSrvc(ProFormaInvoiceGarmentsSrvc proFormaInvoiceGarmentsSrvc)
        {
            _context.ProFormaInvoiceGarmentsSrvcs.Add(proFormaInvoiceGarmentsSrvc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceGarmentsSrvc", new { id = proFormaInvoiceGarmentsSrvc.Id }, proFormaInvoiceGarmentsSrvc);
        }

        // DELETE: api/ProFormaInvoiceGarmentsSrvcs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceGarmentsSrvc>> DeleteProFormaInvoiceGarmentsSrvc(int id)
        {
            var proFormaInvoiceGarmentsSrvc = await _context.ProFormaInvoiceGarmentsSrvcs.FindAsync(id);
            if (proFormaInvoiceGarmentsSrvc == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceGarmentsSrvcs.Remove(proFormaInvoiceGarmentsSrvc);
            await _context.SaveChangesAsync();

            return proFormaInvoiceGarmentsSrvc;
        }

        private bool ProFormaInvoiceGarmentsSrvcExists(int id)
        {
            return _context.ProFormaInvoiceGarmentsSrvcs.Any(e => e.Id == id);
        }
    }
}
