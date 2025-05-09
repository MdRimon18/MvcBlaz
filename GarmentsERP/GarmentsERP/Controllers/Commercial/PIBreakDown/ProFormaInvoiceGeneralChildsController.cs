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
    public class ProFormaInvoiceGeneralChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceGeneralChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceGeneralChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceGeneralChild>>> GetProFormaInvoiceGeneralChild()
        {
            return await _context.ProFormaInvoiceGeneralChilds.ToListAsync();
        }

        // GET: api/ProFormaInvoiceGeneralChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceGeneralChild>> GetProFormaInvoiceGeneralChild(int id)
        {
            var proFormaInvoiceGeneralChild = await _context.ProFormaInvoiceGeneralChilds.FindAsync(id);

            if (proFormaInvoiceGeneralChild == null)
            {
                return NotFound();
            }

            return proFormaInvoiceGeneralChild;
        }

        // PUT: api/ProFormaInvoiceGeneralChilds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceGeneralChild(int id, ProFormaInvoiceGeneralChild proFormaInvoiceGeneralChild)
        {
            if (id != proFormaInvoiceGeneralChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceGeneralChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceGeneralChildExists(id))
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

        // POST: api/ProFormaInvoiceGeneralChilds
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceGeneralChild>> PostProFormaInvoiceGeneralChild(ProFormaInvoiceGeneralChild proFormaInvoiceGeneralChild)
        {
            _context.ProFormaInvoiceGeneralChilds.Add(proFormaInvoiceGeneralChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceGeneralChild", new { id = proFormaInvoiceGeneralChild.Id }, proFormaInvoiceGeneralChild);
        }

        // DELETE: api/ProFormaInvoiceGeneralChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceGeneralChild>> DeleteProFormaInvoiceGeneralChild(int id)
        {
            var proFormaInvoiceGeneralChild = await _context.ProFormaInvoiceGeneralChilds.FindAsync(id);
            if (proFormaInvoiceGeneralChild == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceGeneralChilds.Remove(proFormaInvoiceGeneralChild);
            await _context.SaveChangesAsync();

            return proFormaInvoiceGeneralChild;
        }

        private bool ProFormaInvoiceGeneralChildExists(int id)
        {
            return _context.ProFormaInvoiceGeneralChilds.Any(e => e.Id == id);
        }
    }
}
