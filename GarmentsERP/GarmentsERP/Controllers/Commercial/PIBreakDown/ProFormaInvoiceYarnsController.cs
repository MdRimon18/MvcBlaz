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
    public class ProFormaInvoiceYarnsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceYarnsController(GarmentERPContext context)
        {
           
                _context = context;
            
      
        }

        // GET: api/ProFormaInvoiceYarns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceYarn>>> GetProFormaInvoiceYarn()
        {
            foreach (var item in _context.ProFormaInvoiceYarns)
            {
                item.ImporterName = _context.TblCompanyInfoes.FirstOrDefault(f => f.CompID == item.ImporterId)?.Company_Name;
                item.SupplierName = _context.SupplierProfiles.FirstOrDefault(f => f.Id == item.SupplierId)?.SupplierName;
                item.CurrencyName = _context.DiscountMethods.FirstOrDefault(f => f.Id == item.CurrencyId)?.DiscountMethodName;
            }
            return await _context.ProFormaInvoiceYarns.ToListAsync();
        }

        // GET: api/ProFormaInvoiceYarns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceYarn>> GetProFormaInvoiceYarn(int id)
        {
            var proFormaInvoiceYarn = await _context.ProFormaInvoiceYarns.FindAsync(id);

            if (proFormaInvoiceYarn == null)
            {
                return NotFound();
            }

            return proFormaInvoiceYarn;
        }

        // PUT: api/ProFormaInvoiceYarns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceYarn(int id, ProFormaInvoiceYarn proFormaInvoiceYarn)
        {
            if (id != proFormaInvoiceYarn.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceYarn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceYarnExists(id))
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

        // POST: api/ProFormaInvoiceYarns
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceYarn>> PostProFormaInvoiceYarn(ProFormaInvoiceYarn proFormaInvoiceYarn)
        {
            try
            {
                _context.ProFormaInvoiceYarns.Add(proFormaInvoiceYarn);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
          

            return CreatedAtAction("GetProFormaInvoiceYarn", new { id = proFormaInvoiceYarn.Id }, proFormaInvoiceYarn);
        }

        // DELETE: api/ProFormaInvoiceYarns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceYarn>> DeleteProFormaInvoiceYarn(int id)
        {
            var proFormaInvoiceYarn = await _context.ProFormaInvoiceYarns.FindAsync(id);
            if (proFormaInvoiceYarn == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceYarns.Remove(proFormaInvoiceYarn);
            await _context.SaveChangesAsync();

            return proFormaInvoiceYarn;
        }

        private bool ProFormaInvoiceYarnExists(int id)
        {
            return _context.ProFormaInvoiceYarns.Any(e => e.Id == id);
        }
    }
}
