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
    public class DocSubmissiontoBankInvoiceListsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DocSubmissiontoBankInvoiceListsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DocSubmissiontoBankInvoiceLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocSubmissiontoBankInvoiceList>>> GetDocSubmissiontoBankInvoiceList()
        {
            return await _context.DocSubmissiontoBankInvoiceLists.ToListAsync();
        }

        // GET: api/DocSubmissiontoBankInvoiceLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocSubmissiontoBankInvoiceList>> GetDocSubmissiontoBankInvoiceList(int id)
        {
            var docSubmissiontoBankInvoiceList = await _context.DocSubmissiontoBankInvoiceLists.FindAsync(id);

            if (docSubmissiontoBankInvoiceList == null)
            {
                return NotFound();
            }

            return docSubmissiontoBankInvoiceList;
        }

        // PUT: api/DocSubmissiontoBankInvoiceLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocSubmissiontoBankInvoiceList(int id, DocSubmissiontoBankInvoiceList docSubmissiontoBankInvoiceList)
        {
            if (id != docSubmissiontoBankInvoiceList.Id)
            {
                return BadRequest();
            }

            _context.Entry(docSubmissiontoBankInvoiceList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocSubmissiontoBankInvoiceListExists(id))
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

        // POST: api/DocSubmissiontoBankInvoiceLists
        [HttpPost]
        public async Task<ActionResult<DocSubmissiontoBankInvoiceList>> PostDocSubmissiontoBankInvoiceList(DocSubmissiontoBankInvoiceList docSubmissiontoBankInvoiceList)
        {
            _context.DocSubmissiontoBankInvoiceLists.Add(docSubmissiontoBankInvoiceList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocSubmissiontoBankInvoiceList", new { id = docSubmissiontoBankInvoiceList.Id }, docSubmissiontoBankInvoiceList);
        }

        // DELETE: api/DocSubmissiontoBankInvoiceLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocSubmissiontoBankInvoiceList>> DeleteDocSubmissiontoBankInvoiceList(int id)
        {
            var docSubmissiontoBankInvoiceList = await _context.DocSubmissiontoBankInvoiceLists.FindAsync(id);
            if (docSubmissiontoBankInvoiceList == null)
            {
                return NotFound();
            }

            _context.DocSubmissiontoBankInvoiceLists.Remove(docSubmissiontoBankInvoiceList);
            await _context.SaveChangesAsync();

            return docSubmissiontoBankInvoiceList;
        }

        private bool DocSubmissiontoBankInvoiceListExists(int id)
        {
            return _context.DocSubmissiontoBankInvoiceLists.Any(e => e.Id == id);
        }
    }
}
