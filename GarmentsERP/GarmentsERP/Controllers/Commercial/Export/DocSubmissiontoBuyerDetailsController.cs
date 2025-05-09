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
    public class DocSubmissiontoBuyerDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DocSubmissiontoBuyerDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DocSubmissiontoBuyerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocSubmissiontoBuyerDetails>>> GetDocSubmissiontoBuyerDetails()
        {
            return await _context.DocSubmissiontoBuyerDetails.ToListAsync();
        }

        // GET: api/DocSubmissiontoBuyerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocSubmissiontoBuyerDetails>> GetDocSubmissiontoBuyerDetails(int id)
        {
            var docSubmissiontoBuyerDetails = await _context.DocSubmissiontoBuyerDetails.FindAsync(id);

            if (docSubmissiontoBuyerDetails == null)
            {
                return NotFound();
            }

            return docSubmissiontoBuyerDetails;
        }

        // PUT: api/DocSubmissiontoBuyerDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocSubmissiontoBuyerDetails(int id, DocSubmissiontoBuyerDetails docSubmissiontoBuyerDetails)
        {
            if (id != docSubmissiontoBuyerDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(docSubmissiontoBuyerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocSubmissiontoBuyerDetailsExists(id))
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

        // POST: api/DocSubmissiontoBuyerDetails
        [HttpPost]
        public async Task<ActionResult<DocSubmissiontoBuyerDetails>> PostDocSubmissiontoBuyerDetails(DocSubmissiontoBuyerDetails docSubmissiontoBuyerDetails)
        {
            _context.DocSubmissiontoBuyerDetails.Add(docSubmissiontoBuyerDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocSubmissiontoBuyerDetails", new { id = docSubmissiontoBuyerDetails.Id }, docSubmissiontoBuyerDetails);
        }

        // DELETE: api/DocSubmissiontoBuyerDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocSubmissiontoBuyerDetails>> DeleteDocSubmissiontoBuyerDetails(int id)
        {
            var docSubmissiontoBuyerDetails = await _context.DocSubmissiontoBuyerDetails.FindAsync(id);
            if (docSubmissiontoBuyerDetails == null)
            {
                return NotFound();
            }

            _context.DocSubmissiontoBuyerDetails.Remove(docSubmissiontoBuyerDetails);
            await _context.SaveChangesAsync();

            return docSubmissiontoBuyerDetails;
        }

        private bool DocSubmissiontoBuyerDetailsExists(int id)
        {
            return _context.DocSubmissiontoBuyerDetails.Any(e => e.Id == id);
        }
    }
}
