using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Import;
using GarmentsERP.ViewModel;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class BTBOrImportLCInvoiceDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BTBOrImportLCInvoiceDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BTBOrImportLCInvoiceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BTBOrImportLCInvoiceDetails>>> GetBTBOrImportLCInvoiceDetails()
        {
       //     var result =(
       //from btbMstr in _context.BTBOrImportLCInvoiceDetails
       //join btbChild in _context.BTBOrImportLCShipmentDetails on btbMstr.Id equals btbChild.BTBOrImportLCInvoiceDetailsId into btbMasteAndChild
       //from btbChild in btbMasteAndChild.DefaultIfEmpty()
       //select new BBTOrImportInvoiceDtlsNShipmentDtls {
       //    Id= btbMstr.Id,
       //    LCNumber = btbMstr.LCNumber,
       //    InvoiceNumber = btbMstr.InvoiceNumber,


       //    BLOrCargoNo = btbChild.BLOrCargoNo == null ? "" : btbChild.BLOrCargoNo,
       //    BLOrCargoDate = btbChild.BLOrCargoDate == null ? "" : btbChild.BLOrCargoDate,
       //}
       //).ToList();

            return await _context.BTBOrImportLCInvoiceDetails.ToListAsync();
        }

        // GET: api/BTBOrImportLCInvoiceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BTBOrImportLCInvoiceDetails>> GetBTBOrImportLCInvoiceDetails(int id)
        {
            var bTBOrImportLCInvoiceDetails = await _context.BTBOrImportLCInvoiceDetails.FindAsync(id);

            if (bTBOrImportLCInvoiceDetails == null)
            {
                return NotFound();
            }

            return bTBOrImportLCInvoiceDetails;
        }

        // PUT: api/BTBOrImportLCInvoiceDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBTBOrImportLCInvoiceDetails(int id, BTBOrImportLCInvoiceDetails bTBOrImportLCInvoiceDetails)
        {
            if (id != bTBOrImportLCInvoiceDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(bTBOrImportLCInvoiceDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BTBOrImportLCInvoiceDetailsExists(id))
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

        // POST: api/BTBOrImportLCInvoiceDetails
        [HttpPost]
        public async Task<ActionResult<BTBOrImportLCInvoiceDetails>> PostBTBOrImportLCInvoiceDetails(BTBOrImportLCInvoiceDetails bTBOrImportLCInvoiceDetails)
        {
            _context.BTBOrImportLCInvoiceDetails.Add(bTBOrImportLCInvoiceDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBTBOrImportLCInvoiceDetails", new { id = bTBOrImportLCInvoiceDetails.Id }, bTBOrImportLCInvoiceDetails);
        }

        // DELETE: api/BTBOrImportLCInvoiceDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BTBOrImportLCInvoiceDetails>> DeleteBTBOrImportLCInvoiceDetails(int id)
        {
            var bTBOrImportLCInvoiceDetails = await _context.BTBOrImportLCInvoiceDetails.FindAsync(id);
            if (bTBOrImportLCInvoiceDetails == null)
            {
                return NotFound();
            }

            _context.BTBOrImportLCInvoiceDetails.Remove(bTBOrImportLCInvoiceDetails);
            await _context.SaveChangesAsync();

            return bTBOrImportLCInvoiceDetails;
        }

        private bool BTBOrImportLCInvoiceDetailsExists(int id)
        {
            return _context.BTBOrImportLCInvoiceDetails.Any(e => e.Id == id);
        }
    }
}
