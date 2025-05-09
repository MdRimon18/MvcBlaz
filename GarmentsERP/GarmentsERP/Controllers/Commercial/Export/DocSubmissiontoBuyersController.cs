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
    public class DocSubmissiontoBuyersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DocSubmissiontoBuyersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DocSubmissiontoBuyers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocSubmissiontoBuyer>>> GetDocSubmissiontoBuyer()
        {
            return await _context.DocSubmissiontoBuyers.ToListAsync();
        }

        // GET: api/DocSubmissiontoBuyers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocSubmissiontoBuyer>> GetDocSubmissiontoBuyer(int id)
        {
            var docSubmissiontoBuyer = await _context.DocSubmissiontoBuyers.FindAsync(id);

            if (docSubmissiontoBuyer == null)
            {
                return NotFound();
            }

            return docSubmissiontoBuyer;
        }

        // PUT: api/DocSubmissiontoBuyers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocSubmissiontoBuyer(int id, DocSubmissiontoBuyer docSubmissiontoBuyer)
        {
            if (id != docSubmissiontoBuyer.Id)
            {
                return BadRequest();
            }

            _context.Entry(docSubmissiontoBuyer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocSubmissiontoBuyerExists(id))
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

        // POST: api/DocSubmissiontoBuyers
        [HttpPost]
        public async Task<ActionResult<DocSubmissiontoBuyer>> PostDocSubmissiontoBuyer(DocSubmissiontoBuyer docSubmissiontoBuyer)
        {
            _context.DocSubmissiontoBuyers.Add(docSubmissiontoBuyer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocSubmissiontoBuyer", new { id = docSubmissiontoBuyer.Id }, docSubmissiontoBuyer);
        }

        // DELETE: api/DocSubmissiontoBuyers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocSubmissiontoBuyer>> DeleteDocSubmissiontoBuyer(int id)
        {
            var docSubmissiontoBuyer = await _context.DocSubmissiontoBuyers.FindAsync(id);
            if (docSubmissiontoBuyer == null)
            {
                return NotFound();
            }

            _context.DocSubmissiontoBuyers.Remove(docSubmissiontoBuyer);
            await _context.SaveChangesAsync();

            return docSubmissiontoBuyer;
        }

        private bool DocSubmissiontoBuyerExists(int id)
        {
            return _context.DocSubmissiontoBuyers.Any(e => e.Id == id);
        }
    }
}
