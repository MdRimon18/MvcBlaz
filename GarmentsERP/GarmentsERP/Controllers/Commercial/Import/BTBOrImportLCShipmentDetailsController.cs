using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial.Import;

namespace GarmentsERP.Controllers.Commercial.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class BTBOrImportLCShipmentDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BTBOrImportLCShipmentDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BTBOrImportLCShipmentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BTBOrImportLCShipmentDetails>>> GetBTBOrImportLCShipmentDetails()
        {
            return await _context.BTBOrImportLCShipmentDetails.ToListAsync();
        }

        // GET: api/BTBOrImportLCShipmentDetails/5
        [HttpGet("{id}")]// get by btb invoic acceptance id
        public async Task<ActionResult<BTBOrImportLCShipmentDetails>> GetBTBOrImportLCShipmentDetails(int id)
        {
            var bTBOrImportLCShipmentDetails =await _context.BTBOrImportLCShipmentDetails.FirstOrDefaultAsync(f=>f.BTBOrImportLCInvoiceDetailsId==id);

            if (bTBOrImportLCShipmentDetails == null)
            {
                return NotFound();
            }

            return bTBOrImportLCShipmentDetails;
        }

        // PUT: api/BTBOrImportLCShipmentDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBTBOrImportLCShipmentDetails(int id, BTBOrImportLCShipmentDetails bTBOrImportLCShipmentDetails)
        {
            if (id != bTBOrImportLCShipmentDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(bTBOrImportLCShipmentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BTBOrImportLCShipmentDetailsExists(id))
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

        // POST: api/BTBOrImportLCShipmentDetails
        [HttpPost]
        public async Task<ActionResult<BTBOrImportLCShipmentDetails>> PostBTBOrImportLCShipmentDetails(BTBOrImportLCShipmentDetails bTBOrImportLCShipmentDetails)
        {
            _context.BTBOrImportLCShipmentDetails.Add(bTBOrImportLCShipmentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBTBOrImportLCShipmentDetails", new { id = bTBOrImportLCShipmentDetails.Id }, bTBOrImportLCShipmentDetails);
        }

        // DELETE: api/BTBOrImportLCShipmentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BTBOrImportLCShipmentDetails>> DeleteBTBOrImportLCShipmentDetails(int id)
        {
            var bTBOrImportLCShipmentDetails = await _context.BTBOrImportLCShipmentDetails.FindAsync(id);
            if (bTBOrImportLCShipmentDetails == null)
            {
                return NotFound();
            }

            _context.BTBOrImportLCShipmentDetails.Remove(bTBOrImportLCShipmentDetails);
            await _context.SaveChangesAsync();

            return bTBOrImportLCShipmentDetails;
        }

        private bool BTBOrImportLCShipmentDetailsExists(int id)
        {
            return _context.BTBOrImportLCShipmentDetails.Any(e => e.Id == id);
        }
    }
}
