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
    public class FinishFabricRollReceiveByStoreDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricRollReceiveByStoreDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricRollReceiveByStoreDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricRollReceiveByStoreDetails>>> GetFinishFabricRollReceiveByStoreDetails()
        {
            return await _context.FinishFabricRollReceiveByStoreDetails.ToListAsync();
        }

        // GET: api/FinishFabricRollReceiveByStoreDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricRollReceiveByStoreDetails>> GetFinishFabricRollReceiveByStoreDetails(int id)
        {
            var finishFabricRollReceiveByStoreDetails = await _context.FinishFabricRollReceiveByStoreDetails.FindAsync(id);

            if (finishFabricRollReceiveByStoreDetails == null)
            {
                return NotFound();
            }

            return finishFabricRollReceiveByStoreDetails;
        }

        // PUT: api/FinishFabricRollReceiveByStoreDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricRollReceiveByStoreDetails(int id, FinishFabricRollReceiveByStoreDetails finishFabricRollReceiveByStoreDetails)
        {
            if (id != finishFabricRollReceiveByStoreDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricRollReceiveByStoreDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricRollReceiveByStoreDetailsExists(id))
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

        // POST: api/FinishFabricRollReceiveByStoreDetails
        [HttpPost]
        public async Task<ActionResult<FinishFabricRollReceiveByStoreDetails>> PostFinishFabricRollReceiveByStoreDetails(FinishFabricRollReceiveByStoreDetails finishFabricRollReceiveByStoreDetails)
        {
            _context.FinishFabricRollReceiveByStoreDetails.Add(finishFabricRollReceiveByStoreDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricRollReceiveByStoreDetails", new { id = finishFabricRollReceiveByStoreDetails.Id }, finishFabricRollReceiveByStoreDetails);
        }

        // DELETE: api/FinishFabricRollReceiveByStoreDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricRollReceiveByStoreDetails>> DeleteFinishFabricRollReceiveByStoreDetails(int id)
        {
            var finishFabricRollReceiveByStoreDetails = await _context.FinishFabricRollReceiveByStoreDetails.FindAsync(id);
            if (finishFabricRollReceiveByStoreDetails == null)
            {
                return NotFound();
            }

            _context.FinishFabricRollReceiveByStoreDetails.Remove(finishFabricRollReceiveByStoreDetails);
            await _context.SaveChangesAsync();

            return finishFabricRollReceiveByStoreDetails;
        }

        private bool FinishFabricRollReceiveByStoreDetailsExists(int id)
        {
            return _context.FinishFabricRollReceiveByStoreDetails.Any(e => e.Id == id);
        }
    }
}
