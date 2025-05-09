using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Export;

namespace GarmentsERP.Controllers.Commercial.Export
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesContractAmendmentDeailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SalesContractAmendmentDeailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SalesContractAmendmentDeails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesContractAmendmentDeails>>> GetSalesContractAmendmentDeails()
        {
            return await _context.SalesContractAmendmentDeails.ToListAsync();
        }

        // GET: api/SalesContractAmendmentDeails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesContractAmendmentDeails>> GetSalesContractAmendmentDeails(int id)
        {
            var salesContractAmendmentDeails = await _context.SalesContractAmendmentDeails.FindAsync(id);

            if (salesContractAmendmentDeails == null)
            {
                return NotFound();
            }

            return salesContractAmendmentDeails;
        }

        // PUT: api/SalesContractAmendmentDeails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesContractAmendmentDeails(int id, SalesContractAmendmentDeails salesContractAmendmentDeails)
        {
            if (id != salesContractAmendmentDeails.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesContractAmendmentDeails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesContractAmendmentDeailsExists(id))
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

        // POST: api/SalesContractAmendmentDeails
        [HttpPost]
        public async Task<ActionResult<SalesContractAmendmentDeails>> PostSalesContractAmendmentDeails(SalesContractAmendmentDeails salesContractAmendmentDeails)
        {
            _context.SalesContractAmendmentDeails.Add(salesContractAmendmentDeails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesContractAmendmentDeails", new { id = salesContractAmendmentDeails.Id }, salesContractAmendmentDeails);
        }

        // DELETE: api/SalesContractAmendmentDeails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesContractAmendmentDeails>> DeleteSalesContractAmendmentDeails(int id)
        {
            var salesContractAmendmentDeails = await _context.SalesContractAmendmentDeails.FindAsync(id);
            if (salesContractAmendmentDeails == null)
            {
                return NotFound();
            }

            _context.SalesContractAmendmentDeails.Remove(salesContractAmendmentDeails);
            await _context.SaveChangesAsync();

            return salesContractAmendmentDeails;
        }

        private bool SalesContractAmendmentDeailsExists(int id)
        {
            return _context.SalesContractAmendmentDeails.Any(e => e.Id == id);
        }
    }
}
