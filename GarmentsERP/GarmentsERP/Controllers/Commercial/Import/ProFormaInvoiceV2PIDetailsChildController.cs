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
    public class ProFormaInvoiceV2PIDetailsChildController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceV2PIDetailsChildController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceV2PIDetailsChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceV2PIDetailsChild>>> GetProFormaInvoiceV2PIDetailsChild()
        {
            return await _context.ProFormaInvoiceV2PIDetailsChilds.ToListAsync();
        }

        // GET: api/ProFormaInvoiceV2PIDetailsChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceV2PIDetailsChild>> GetProFormaInvoiceV2PIDetailsChild(int id)
        {
            var proFormaInvoiceV2PIDetailsChild = await _context.ProFormaInvoiceV2PIDetailsChilds.FindAsync(id);

            if (proFormaInvoiceV2PIDetailsChild == null)
            {
                return NotFound();
            }

            return proFormaInvoiceV2PIDetailsChild;
        }

        // PUT: api/ProFormaInvoiceV2PIDetailsChilds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceV2PIDetailsChild(int id, ProFormaInvoiceV2PIDetailsChild proFormaInvoiceV2PIDetailsChild)
        {
            if (id != proFormaInvoiceV2PIDetailsChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceV2PIDetailsChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceV2PIDetailsChildExists(id))
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

        // POST: api/ProFormaInvoiceV2PIDetailsChilds
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceV2PIDetailsChild>> PostProFormaInvoiceV2PIDetailsChild(ProFormaInvoiceV2PIDetailsChild proFormaInvoiceV2PIDetailsChild)
        {
            _context.ProFormaInvoiceV2PIDetailsChilds.Add(proFormaInvoiceV2PIDetailsChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceV2PIDetailsChild", new { id = proFormaInvoiceV2PIDetailsChild.Id }, proFormaInvoiceV2PIDetailsChild);
        }

        // DELETE: api/ProFormaInvoiceV2PIDetailsChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceV2PIDetailsChild>> DeleteProFormaInvoiceV2PIDetailsChild(int id)
        {
            var proFormaInvoiceV2PIDetailsChild = await _context.ProFormaInvoiceV2PIDetailsChilds.FindAsync(id);
            if (proFormaInvoiceV2PIDetailsChild == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceV2PIDetailsChilds.Remove(proFormaInvoiceV2PIDetailsChild);
            await _context.SaveChangesAsync();

            return proFormaInvoiceV2PIDetailsChild;
        }

        private bool ProFormaInvoiceV2PIDetailsChildExists(int id)
        {
            return _context.ProFormaInvoiceV2PIDetailsChilds.Any(e => e.Id == id);
        }
    }
}
