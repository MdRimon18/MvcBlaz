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
    public class ProFormaInvoiceDyesChemicalsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceDyesChemicalsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceDyesChemicals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceDyesChemical>>> GetProFormaInvoiceDyesChemical()
        {
            foreach (var item in _context.ProFormaInvoiceDyesChemicals)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.Importer)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.Supplier)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceDyesChemicals.ToListAsync();
        }

        // GET: api/ProFormaInvoiceDyesChemicals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceDyesChemical>> GetProFormaInvoiceDyesChemical(int id)
        {
            var proFormaInvoiceDyesChemical = await _context.ProFormaInvoiceDyesChemicals.FindAsync(id);

            if (proFormaInvoiceDyesChemical == null)
            {
                return NotFound();
            }

            return proFormaInvoiceDyesChemical;
        }

        // PUT: api/ProFormaInvoiceDyesChemicals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceDyesChemical(int id, ProFormaInvoiceDyesChemical proFormaInvoiceDyesChemical)
        {
            if (id != proFormaInvoiceDyesChemical.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceDyesChemical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceDyesChemicalExists(id))
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

        // POST: api/ProFormaInvoiceDyesChemicals
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceDyesChemical>> PostProFormaInvoiceDyesChemical(ProFormaInvoiceDyesChemical proFormaInvoiceDyesChemical)
        {
            _context.ProFormaInvoiceDyesChemicals.Add(proFormaInvoiceDyesChemical);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceDyesChemical", new { id = proFormaInvoiceDyesChemical.Id }, proFormaInvoiceDyesChemical);
        }

        // DELETE: api/ProFormaInvoiceDyesChemicals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceDyesChemical>> DeleteProFormaInvoiceDyesChemical(int id)
        {
            var proFormaInvoiceDyesChemical = await _context.ProFormaInvoiceDyesChemicals.FindAsync(id);
            if (proFormaInvoiceDyesChemical == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceDyesChemicals.Remove(proFormaInvoiceDyesChemical);
            await _context.SaveChangesAsync();

            return proFormaInvoiceDyesChemical;
        }

        private bool ProFormaInvoiceDyesChemicalExists(int id)
        {
            return _context.ProFormaInvoiceDyesChemicals.Any(e => e.Id == id);
        }
    }
}
