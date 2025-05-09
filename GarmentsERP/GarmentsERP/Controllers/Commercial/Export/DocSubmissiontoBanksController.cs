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
    public class DocSubmissiontoBanksController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DocSubmissiontoBanksController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DocSubmissiontoBanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocSubmissiontoBank>>> GetDocSubmissiontoBank()
        {
            return await _context.DocSubmissiontoBanks.ToListAsync();
        }

        // GET: api/DocSubmissiontoBanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocSubmissiontoBank>> GetDocSubmissiontoBank(int id)
        {
            var docSubmissiontoBank = await _context.DocSubmissiontoBanks.FindAsync(id);

            if (docSubmissiontoBank == null)
            {
                return NotFound();
            }

            return docSubmissiontoBank;
        }

        // PUT: api/DocSubmissiontoBanks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocSubmissiontoBank(int id, DocSubmissiontoBank docSubmissiontoBank)
        {
            if (id != docSubmissiontoBank.Id)
            {
                return BadRequest();
            }

            _context.Entry(docSubmissiontoBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocSubmissiontoBankExists(id))
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

        // POST: api/DocSubmissiontoBanks
        [HttpPost]
        public async Task<ActionResult<DocSubmissiontoBank>> PostDocSubmissiontoBank(DocSubmissiontoBank docSubmissiontoBank)
        {
            _context.DocSubmissiontoBanks.Add(docSubmissiontoBank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocSubmissiontoBank", new { id = docSubmissiontoBank.Id }, docSubmissiontoBank);
        }

        // DELETE: api/DocSubmissiontoBanks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocSubmissiontoBank>> DeleteDocSubmissiontoBank(int id)
        {
            var docSubmissiontoBank = await _context.DocSubmissiontoBanks.FindAsync(id);
            if (docSubmissiontoBank == null)
            {
                return NotFound();
            }

            _context.DocSubmissiontoBanks.Remove(docSubmissiontoBank);
            await _context.SaveChangesAsync();

            return docSubmissiontoBank;
        }

        private bool DocSubmissiontoBankExists(int id)
        {
            return _context.DocSubmissiontoBanks.Any(e => e.Id == id);
        }
    }
}
