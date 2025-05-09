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
    public class ProFormaInvoiceGeneralsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceGeneralsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceGenerals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceGeneral>>> GetProFormaInvoiceGeneral()
        {

            foreach (var item in _context.ProFormaInvoiceGenerals)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Importer)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.Supplier)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceGenerals.ToListAsync();
        }

        // GET: api/ProFormaInvoiceGenerals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceGeneral>> GetProFormaInvoiceGeneral(int id)
        {
            var proFormaInvoiceGeneral = await _context.ProFormaInvoiceGenerals.FindAsync(id);

            if (proFormaInvoiceGeneral == null)
            {
                return NotFound();
            }

            return proFormaInvoiceGeneral;
        }

        // PUT: api/ProFormaInvoiceGenerals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceGeneral(int id, ProFormaInvoiceGeneral proFormaInvoiceGeneral)
        {
            if (id != proFormaInvoiceGeneral.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceGeneral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceGeneralExists(id))
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

        // POST: api/ProFormaInvoiceGenerals
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceGeneral>> PostProFormaInvoiceGeneral(ProFormaInvoiceGeneral proFormaInvoiceGeneral)
        {
            _context.ProFormaInvoiceGenerals.Add(proFormaInvoiceGeneral);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceGeneral", new { id = proFormaInvoiceGeneral.Id }, proFormaInvoiceGeneral);
        }

        // DELETE: api/ProFormaInvoiceGenerals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceGeneral>> DeleteProFormaInvoiceGeneral(int id)
        {
            var proFormaInvoiceGeneral = await _context.ProFormaInvoiceGenerals.FindAsync(id);
            if (proFormaInvoiceGeneral == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceGenerals.Remove(proFormaInvoiceGeneral);
            await _context.SaveChangesAsync();

            return proFormaInvoiceGeneral;
        }

        private bool ProFormaInvoiceGeneralExists(int id)
        {
            return _context.ProFormaInvoiceGenerals.Any(e => e.Id == id);
        }
    }
}
