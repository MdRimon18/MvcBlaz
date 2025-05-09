using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial;

namespace GarmentsERP.Controllers.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class YarnPurchaseRequisitionDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnPurchaseRequisitionDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnPurchaseRequisitionDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnPurchaseRequisitionDetails>>> GetYarnPurchaseRequisitionDetails()
        {
            

            return await _context.YarnPurchaseRequisitionDetails.ToListAsync();
        }

        // GET: api/YarnPurchaseRequisitionDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnPurchaseRequisitionDetails>> GetYarnPurchaseRequisitionDetails(int id)
        {
            var yarnPurchaseRequisitionDetails = await _context.YarnPurchaseRequisitionDetails.FindAsync(id);

            if (yarnPurchaseRequisitionDetails == null)
            {
                return NotFound();
            }

            return yarnPurchaseRequisitionDetails;
        }

        // PUT: api/YarnPurchaseRequisitionDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnPurchaseRequisitionDetails(int id, YarnPurchaseRequisitionDetails yarnPurchaseRequisitionDetails)
        {
            if (id != yarnPurchaseRequisitionDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnPurchaseRequisitionDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnPurchaseRequisitionDetailsExists(id))
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

        // POST: api/YarnPurchaseRequisitionDetails
        [HttpPost]
        public async Task<ActionResult<YarnPurchaseRequisitionDetails>> PostYarnPurchaseRequisitionDetails(YarnPurchaseRequisitionDetails yarnPurchaseRequisitionDetails)
        {
            _context.YarnPurchaseRequisitionDetails.Add(yarnPurchaseRequisitionDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnPurchaseRequisitionDetails", new { id = yarnPurchaseRequisitionDetails.Id }, yarnPurchaseRequisitionDetails);
        }

        // DELETE: api/YarnPurchaseRequisitionDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnPurchaseRequisitionDetails>> DeleteYarnPurchaseRequisitionDetails(int id)
        {
            var yarnPurchaseRequisitionDetails = await _context.YarnPurchaseRequisitionDetails.FindAsync(id);
            if (yarnPurchaseRequisitionDetails == null)
            {
                return NotFound();
            }

            _context.YarnPurchaseRequisitionDetails.Remove(yarnPurchaseRequisitionDetails);
            await _context.SaveChangesAsync();

            return yarnPurchaseRequisitionDetails;
        }

        private bool YarnPurchaseRequisitionDetailsExists(int id)
        {
            return _context.YarnPurchaseRequisitionDetails.Any(e => e.Id == id);
        }
    }
}
