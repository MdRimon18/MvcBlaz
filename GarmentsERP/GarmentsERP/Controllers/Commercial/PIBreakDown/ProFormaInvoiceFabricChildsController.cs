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
    public class ProFormaInvoiceFabricChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceFabricChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceFabricChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceFabricChild>>> GetProFormaInvoiceFabricChild()
        {
            return await _context.ProFormaInvoiceFabricChilds.ToListAsync();
        }

        // GET: api/ProFormaInvoiceFabricChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceFabricChild>> GetProFormaInvoiceFabricChild(int id)
        {
            var proFormaInvoiceFabricChild = await _context.ProFormaInvoiceFabricChilds.FindAsync(id);

            if (proFormaInvoiceFabricChild == null)
            {
                return NotFound();
            }

            return proFormaInvoiceFabricChild;
        }

        // PUT: api/ProFormaInvoiceFabricChilds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceFabricChild(int id, ProFormaInvoiceFabricChild proFormaInvoiceFabricChild)
        {
            if (id != proFormaInvoiceFabricChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceFabricChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceFabricChildExists(id))
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

        // POST: api/ProFormaInvoiceFabricChilds
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceFabricChild>> PostProFormaInvoiceFabricChild(ProFormaInvoiceFabricChild proFormaInvoiceFabricChild)
        {
            _context.ProFormaInvoiceFabricChilds.Add(proFormaInvoiceFabricChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceFabricChild", new { id = proFormaInvoiceFabricChild.Id }, proFormaInvoiceFabricChild);
        }

        // DELETE: api/ProFormaInvoiceFabricChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceFabricChild>> DeleteProFormaInvoiceFabricChild(int id)
        {
            var proFormaInvoiceFabricChild = await _context.ProFormaInvoiceFabricChilds.FindAsync(id);
            if (proFormaInvoiceFabricChild == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceFabricChilds.Remove(proFormaInvoiceFabricChild);
            await _context.SaveChangesAsync();

            return proFormaInvoiceFabricChild;
        }

        private bool ProFormaInvoiceFabricChildExists(int id)
        {
            return _context.ProFormaInvoiceFabricChilds.Any(e => e.Id == id);
        }
    }
}
