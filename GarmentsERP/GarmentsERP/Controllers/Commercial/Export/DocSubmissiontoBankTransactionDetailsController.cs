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
    public class DocSubmissiontoBankTransactionDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DocSubmissiontoBankTransactionDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DocSubmissiontoBankTransactionDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocSubmissiontoBankTransactionDetails>>> GetDocSubmissiontoBankTransactionDetails()
        {
            return await _context.DocSubmissiontoBankTransactionDetails.ToListAsync();
        }

        // GET: api/DocSubmissiontoBankTransactionDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocSubmissiontoBankTransactionDetails>> GetDocSubmissiontoBankTransactionDetails(int id)
        {
            var docSubmissiontoBankTransactionDetails = await _context.DocSubmissiontoBankTransactionDetails.FindAsync(id);

            if (docSubmissiontoBankTransactionDetails == null)
            {
                return NotFound();
            }

            return docSubmissiontoBankTransactionDetails;
        }

        // PUT: api/DocSubmissiontoBankTransactionDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocSubmissiontoBankTransactionDetails(int id, DocSubmissiontoBankTransactionDetails docSubmissiontoBankTransactionDetails)
        {
            if (id != docSubmissiontoBankTransactionDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(docSubmissiontoBankTransactionDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocSubmissiontoBankTransactionDetailsExists(id))
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

        // POST: api/DocSubmissiontoBankTransactionDetails
        [HttpPost]
        public async Task<ActionResult<DocSubmissiontoBankTransactionDetails>> PostDocSubmissiontoBankTransactionDetails(DocSubmissiontoBankTransactionDetails docSubmissiontoBankTransactionDetails)
        {
            _context.DocSubmissiontoBankTransactionDetails.Add(docSubmissiontoBankTransactionDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocSubmissiontoBankTransactionDetails", new { id = docSubmissiontoBankTransactionDetails.Id }, docSubmissiontoBankTransactionDetails);
        }

        // DELETE: api/DocSubmissiontoBankTransactionDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocSubmissiontoBankTransactionDetails>> DeleteDocSubmissiontoBankTransactionDetails(int id)
        {
            var docSubmissiontoBankTransactionDetails = await _context.DocSubmissiontoBankTransactionDetails.FindAsync(id);
            if (docSubmissiontoBankTransactionDetails == null)
            {
                return NotFound();
            }

            _context.DocSubmissiontoBankTransactionDetails.Remove(docSubmissiontoBankTransactionDetails);
            await _context.SaveChangesAsync();

            return docSubmissiontoBankTransactionDetails;
        }

        private bool DocSubmissiontoBankTransactionDetailsExists(int id)
        {
            return _context.DocSubmissiontoBankTransactionDetails.Any(e => e.Id == id);
        }
    }
}
