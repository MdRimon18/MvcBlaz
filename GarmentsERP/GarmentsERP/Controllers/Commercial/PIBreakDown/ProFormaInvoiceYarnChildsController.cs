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
    public class ProFormaInvoiceYarnChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ProFormaInvoiceYarnChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ProFormaInvoiceYarnChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProFormaInvoiceYarnChild>>> GetProFormaInvoiceYarnChild()
        {
            return await _context.ProFormaInvoiceYarnChilds.ToListAsync();
        }

        // GET: api/ProFormaInvoiceYarnChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProFormaInvoiceYarnChild>> GetProFormaInvoiceYarnChild(int id)
        {
            var proFormaInvoiceYarnChild = await _context.ProFormaInvoiceYarnChilds.FindAsync(id);

            if (proFormaInvoiceYarnChild == null)
            {
                return NotFound();
            }

            return proFormaInvoiceYarnChild;
        }

        // PUT: api/ProFormaInvoiceYarnChilds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProFormaInvoiceYarnChild(int id, ProFormaInvoiceYarnChild proFormaInvoiceYarnChild)
        {
            if (id != proFormaInvoiceYarnChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFormaInvoiceYarnChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFormaInvoiceYarnChildExists(id))
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

        // POST: api/ProFormaInvoiceYarnChilds
        [HttpPost]
        public async Task<ActionResult<ProFormaInvoiceYarnChild>> PostProFormaInvoiceYarnChild(ProFormaInvoiceYarnChild proFormaInvoiceYarnChild)
        {
            _context.ProFormaInvoiceYarnChilds.Add(proFormaInvoiceYarnChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProFormaInvoiceYarnChild", new { id = proFormaInvoiceYarnChild.Id }, proFormaInvoiceYarnChild);
        }

        // DELETE: api/ProFormaInvoiceYarnChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProFormaInvoiceYarnChild>> DeleteProFormaInvoiceYarnChild(int id)
        {
            var proFormaInvoiceYarnChild = await _context.ProFormaInvoiceYarnChilds.FindAsync(id);
            if (proFormaInvoiceYarnChild == null)
            {
                return NotFound();
            }

            _context.ProFormaInvoiceYarnChilds.Remove(proFormaInvoiceYarnChild);
            await _context.SaveChangesAsync();

            return proFormaInvoiceYarnChild;
        }

        private bool ProFormaInvoiceYarnChildExists(int id)
        {
            return _context.ProFormaInvoiceYarnChilds.Any(e => e.Id == id);
        }
    }
}
