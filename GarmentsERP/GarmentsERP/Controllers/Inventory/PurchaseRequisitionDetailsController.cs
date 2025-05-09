using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseRequisitionDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PurchaseRequisitionDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseRequisitionDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseRequisitionDetails>>> GetPurchaseRequisitionDetails()
        {
            return await _context.PurchaseRequisitionDetails.ToListAsync();
        }

        // GET: api/PurchaseRequisitionDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseRequisitionDetails>> GetPurchaseRequisitionDetails(int id)
        {
            var purchaseRequisitionDetails = await _context.PurchaseRequisitionDetails.FindAsync(id);

            if (purchaseRequisitionDetails == null)
            {
                return NotFound();
            }

            return purchaseRequisitionDetails;
        }

        // PUT: api/PurchaseRequisitionDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseRequisitionDetails(int id, PurchaseRequisitionDetails purchaseRequisitionDetails)
        {
            if (id != purchaseRequisitionDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseRequisitionDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseRequisitionDetailsExists(id))
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

        // POST: api/PurchaseRequisitionDetails
        [HttpPost]
        public async Task<ActionResult<PurchaseRequisitionDetails>> PostPurchaseRequisitionDetails(PurchaseRequisitionDetails purchaseRequisitionDetails)
        {
            _context.PurchaseRequisitionDetails.Add(purchaseRequisitionDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseRequisitionDetails", new { id = purchaseRequisitionDetails.Id }, purchaseRequisitionDetails);
        }

        // DELETE: api/PurchaseRequisitionDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseRequisitionDetails>> DeletePurchaseRequisitionDetails(int id)
        {
            var purchaseRequisitionDetails = await _context.PurchaseRequisitionDetails.FindAsync(id);
            if (purchaseRequisitionDetails == null)
            {
                return NotFound();
            }

            _context.PurchaseRequisitionDetails.Remove(purchaseRequisitionDetails);
            await _context.SaveChangesAsync();

            return purchaseRequisitionDetails;
        }

        private bool PurchaseRequisitionDetailsExists(int id)
        {
            return _context.PurchaseRequisitionDetails.Any(e => e.Id == id);
        }
    }
}
