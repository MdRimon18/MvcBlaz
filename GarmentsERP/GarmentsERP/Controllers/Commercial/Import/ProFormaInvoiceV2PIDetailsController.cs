using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Import;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProFormaInvoiceV2PIDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceV2PIDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceV2PIDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceV2PIDetails>>> GetProFormaInvoiceV2PIDetails()
        {
            return await _context.ProFormaInvoiceV2PIDetails.ToListAsync();
        }

        // GET: api/ProFormaInvoiceV2PIDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceV2PIDetails>> GetProFormaInvoiceV2PIDetails(int id)
        {
            var proFormaInvoiceV2PIDetails = await _context.ProFormaInvoiceV2PIDetails.FindAsync(id);

            if (proFormaInvoiceV2PIDetails == null)
            {
                return NotFound();
            }

            return proFormaInvoiceV2PIDetails;
        }

        // PUT: api/ProFormaInvoiceV2PIDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceV2PIDetails(int id, ProFormaInvoiceV2PIDetails proFormaInvoiceV2PIDetails)
        {
            if (id != proFormaInvoiceV2PIDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceV2PIDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceV2PIDetailsExists(id))
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

        // POST: api/ProFormaInvoiceV2PIDetails
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceV2PIDetails>> PostProFormaInvoiceV2PIDetails(ProFormaInvoiceV2PIDetails proFormaInvoiceV2PIDetails)
        {


            var a = DateTime.Now.Year;
            double year = Convert.ToDouble(a) % 100;
            proFormaInvoiceV2PIDetails.PiNo = "PI-" + Convert.ToString(year) + "-" + _context.ProFormaInvoiceV2PIDetails.Count();
            _context.ProFormaInvoiceV2PIDetails.Add(proFormaInvoiceV2PIDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceV2PIDetails", new { id = proFormaInvoiceV2PIDetails.Id }, proFormaInvoiceV2PIDetails);
        }

        // DELETE: api/ProFormaInvoiceV2PIDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceV2PIDetails>> DeleteProFormaInvoiceV2PIDetails(int id)
        {
            var proFormaInvoiceV2PIDetails = await _context.ProFormaInvoiceV2PIDetails.FindAsync(id);
            if (proFormaInvoiceV2PIDetails == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceV2PIDetails.Remove(proFormaInvoiceV2PIDetails);
            await _context.SaveChangesAsync();

            return proFormaInvoiceV2PIDetails;
        }

        private bool ProFormaInvoiceV2PIDetailsExists(int id)
        {
            return _context.ProFormaInvoiceV2PIDetails.Any(e => e.Id == id);
        }
    }
}
