using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiJobWSBKnittingDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MultiJobWSBKnittingDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MultiJobWSBKnittingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultiJobWSBKnittingDetails>>> GetMultiJobWSBKnittingDetails()
        {
            return await _context.MultiJobWSBKnittingDetails.ToListAsync();
        }

        // GET: api/MultiJobWSBKnittingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultiJobWSBKnittingDetails>> GetMultiJobWSBKnittingDetails(int id)
        {
            var multiJobWSBKnittingDetails = await _context.MultiJobWSBKnittingDetails.FindAsync(id);

            if (multiJobWSBKnittingDetails == null)
            {
                return NotFound();
            }

            return multiJobWSBKnittingDetails;
        }

        // PUT: api/MultiJobWSBKnittingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultiJobWSBKnittingDetails(int id, MultiJobWSBKnittingDetails multiJobWSBKnittingDetails)
        {
            if (id != multiJobWSBKnittingDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(multiJobWSBKnittingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultiJobWSBKnittingDetailsExists(id))
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

        // POST: api/MultiJobWSBKnittingDetails
        [HttpPost]
        public async Task<ActionResult<MultiJobWSBKnittingDetails>> PostMultiJobWSBKnittingDetails(MultiJobWSBKnittingDetails multiJobWSBKnittingDetails)
        {
            _context.MultiJobWSBKnittingDetails.Add(multiJobWSBKnittingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMultiJobWSBKnittingDetails", new { id = multiJobWSBKnittingDetails.Id }, multiJobWSBKnittingDetails);
        }

        // DELETE: api/MultiJobWSBKnittingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MultiJobWSBKnittingDetails>> DeleteMultiJobWSBKnittingDetails(int id)
        {
            var multiJobWSBKnittingDetails = await _context.MultiJobWSBKnittingDetails.FindAsync(id);
            if (multiJobWSBKnittingDetails == null)
            {
                return NotFound();
            }

            _context.MultiJobWSBKnittingDetails.Remove(multiJobWSBKnittingDetails);
            await _context.SaveChangesAsync();

            return multiJobWSBKnittingDetails;
        }

        private bool MultiJobWSBKnittingDetailsExists(int id)
        {
            return _context.MultiJobWSBKnittingDetails.Any(e => e.Id == id);
        }
    }
}
