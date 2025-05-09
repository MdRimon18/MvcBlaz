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
    public class RollWiseFinishFabricSampleToSamplDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public RollWiseFinishFabricSampleToSamplDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/RollWiseFinishFabricSampleToSamplDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollWiseFinishFabricSampleToSamplDetails>>> GetRollWiseFinishFabricSampleToSamplDetails()
        {
            return await _context.RollWiseFinishFabricSampleToSamplDetails.ToListAsync();
        }

        // GET: api/RollWiseFinishFabricSampleToSamplDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSamplDetails>> GetRollWiseFinishFabricSampleToSamplDetails(int id)
        {
            var rollWiseFinishFabricSampleToSamplDetails = await _context.RollWiseFinishFabricSampleToSamplDetails.FindAsync(id);

            if (rollWiseFinishFabricSampleToSamplDetails == null)
            {
                return NotFound();
            }

            return rollWiseFinishFabricSampleToSamplDetails;
        }

        // PUT: api/RollWiseFinishFabricSampleToSamplDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollWiseFinishFabricSampleToSamplDetails(int id, RollWiseFinishFabricSampleToSamplDetails rollWiseFinishFabricSampleToSamplDetails)
        {
            if (id != rollWiseFinishFabricSampleToSamplDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollWiseFinishFabricSampleToSamplDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollWiseFinishFabricSampleToSamplDetailsExists(id))
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

        // POST: api/RollWiseFinishFabricSampleToSamplDetails
        [HttpPost]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSamplDetails>> PostRollWiseFinishFabricSampleToSamplDetails(RollWiseFinishFabricSampleToSamplDetails rollWiseFinishFabricSampleToSamplDetails)
        {
            _context.RollWiseFinishFabricSampleToSamplDetails.Add(rollWiseFinishFabricSampleToSamplDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollWiseFinishFabricSampleToSamplDetails", new { id = rollWiseFinishFabricSampleToSamplDetails.Id }, rollWiseFinishFabricSampleToSamplDetails);
        }

        // DELETE: api/RollWiseFinishFabricSampleToSamplDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollWiseFinishFabricSampleToSamplDetails>> DeleteRollWiseFinishFabricSampleToSamplDetails(int id)
        {
            var rollWiseFinishFabricSampleToSamplDetails = await _context.RollWiseFinishFabricSampleToSamplDetails.FindAsync(id);
            if (rollWiseFinishFabricSampleToSamplDetails == null)
            {
                return NotFound();
            }

            _context.RollWiseFinishFabricSampleToSamplDetails.Remove(rollWiseFinishFabricSampleToSamplDetails);
            await _context.SaveChangesAsync();

            return rollWiseFinishFabricSampleToSamplDetails;
        }

        private bool RollWiseFinishFabricSampleToSamplDetailsExists(int id)
        {
            return _context.RollWiseFinishFabricSampleToSamplDetails.Any(e => e.Id == id);
        }
    }
}
