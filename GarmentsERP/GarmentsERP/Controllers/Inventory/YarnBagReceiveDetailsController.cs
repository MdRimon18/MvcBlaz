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
    public class YarnBagReceiveDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnBagReceiveDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnBagReceiveDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnBagReceiveDetails>>> GetYarnBagReceiveDetails()
        {
            return await _context.YarnBagReceiveDetails.ToListAsync();
        }

        // GET: api/YarnBagReceiveDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnBagReceiveDetails>> GetYarnBagReceiveDetails(int id)
        {
            var yarnBagReceiveDetails = await _context.YarnBagReceiveDetails.FindAsync(id);

            if (yarnBagReceiveDetails == null)
            {
                return NotFound();
            }

            return yarnBagReceiveDetails;
        }

        // PUT: api/YarnBagReceiveDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnBagReceiveDetails(int id, YarnBagReceiveDetails yarnBagReceiveDetails)
        {
            if (id != yarnBagReceiveDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnBagReceiveDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnBagReceiveDetailsExists(id))
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

        // POST: api/YarnBagReceiveDetails
        [HttpPost]
        public async Task<ActionResult<YarnBagReceiveDetails>> PostYarnBagReceiveDetails(YarnBagReceiveDetails yarnBagReceiveDetails)
        {
            _context.YarnBagReceiveDetails.Add(yarnBagReceiveDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnBagReceiveDetails", new { id = yarnBagReceiveDetails.Id }, yarnBagReceiveDetails);
        }

        // DELETE: api/YarnBagReceiveDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnBagReceiveDetails>> DeleteYarnBagReceiveDetails(int id)
        {
            var yarnBagReceiveDetails = await _context.YarnBagReceiveDetails.FindAsync(id);
            if (yarnBagReceiveDetails == null)
            {
                return NotFound();
            }

            _context.YarnBagReceiveDetails.Remove(yarnBagReceiveDetails);
            await _context.SaveChangesAsync();

            return yarnBagReceiveDetails;
        }

        private bool YarnBagReceiveDetailsExists(int id)
        {
            return _context.YarnBagReceiveDetails.Any(e => e.Id == id);
        }
    }
}
