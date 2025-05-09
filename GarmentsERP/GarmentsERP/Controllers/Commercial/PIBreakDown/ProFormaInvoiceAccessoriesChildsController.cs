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
    public class ProFormaInvoiceAccessoriesChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceAccessoriesChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceAccessoriesChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceAccessoriesChild>>> GetProFormaInvoiceAccessoriesChild()
        {
            return await _context.ProFormaInvoiceAccessoriesChilds.ToListAsync();
        }

        // GET: api/ProFormaInvoiceAccessoriesChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceAccessoriesChild>> GetProFormaInvoiceAccessoriesChild(int id)
        {
            var proFormaInvoiceAccessoriesChild = await _context.ProFormaInvoiceAccessoriesChilds.FindAsync(id);

            if (proFormaInvoiceAccessoriesChild == null)
            {
                return NotFound();
            }

            return proFormaInvoiceAccessoriesChild;
        }

        // PUT: api/ProFormaInvoiceAccessoriesChilds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceAccessoriesChild(int id, ProFormaInvoiceAccessoriesChild proFormaInvoiceAccessoriesChild)
        {
            if (id != proFormaInvoiceAccessoriesChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceAccessoriesChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceAccessoriesChildExists(id))
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

        // POST: api/ProFormaInvoiceAccessoriesChilds
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceAccessoriesChild>> PostProFormaInvoiceAccessoriesChild(ProFormaInvoiceAccessoriesChild proFormaInvoiceAccessoriesChild)
        {
            _context.ProFormaInvoiceAccessoriesChilds.Add(proFormaInvoiceAccessoriesChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceAccessoriesChild", new { id = proFormaInvoiceAccessoriesChild.Id }, proFormaInvoiceAccessoriesChild);
        }

        // DELETE: api/ProFormaInvoiceAccessoriesChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceAccessoriesChild>> DeleteProFormaInvoiceAccessoriesChild(int id)
        {
            var proFormaInvoiceAccessoriesChild = await _context.ProFormaInvoiceAccessoriesChilds.FindAsync(id);
            if (proFormaInvoiceAccessoriesChild == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceAccessoriesChilds.Remove(proFormaInvoiceAccessoriesChild);
            await _context.SaveChangesAsync();

            return proFormaInvoiceAccessoriesChild;
        }

        private bool ProFormaInvoiceAccessoriesChildExists(int id)
        {
            return _context.ProFormaInvoiceAccessoriesChilds.Any(e => e.Id == id);
        }
    }
}
