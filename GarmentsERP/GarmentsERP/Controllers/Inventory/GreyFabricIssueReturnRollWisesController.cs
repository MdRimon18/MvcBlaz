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
    public class GreyFabricIssueReturnRollWisesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GreyFabricIssueReturnRollWisesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GreyFabricIssueReturnRollWises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreyFabricIssueReturnRollWise>>> GetGreyFabricIssueReturnRollWise()
        {
            return await _context.GreyFabricIssueReturnRollWises.ToListAsync();
        }

        // GET: api/GreyFabricIssueReturnRollWises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreyFabricIssueReturnRollWise>> GetGreyFabricIssueReturnRollWise(int id)
        {
            var greyFabricIssueReturnRollWise = await _context.GreyFabricIssueReturnRollWises.FindAsync(id);

            if (greyFabricIssueReturnRollWise == null)
            {
                return NotFound();
            }

            return greyFabricIssueReturnRollWise;
        }

        // PUT: api/GreyFabricIssueReturnRollWises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreyFabricIssueReturnRollWise(int id, GreyFabricIssueReturnRollWise greyFabricIssueReturnRollWise)
        {
            if (id != greyFabricIssueReturnRollWise.Id)
            {
                return BadRequest();
            }

            _context.Entry(greyFabricIssueReturnRollWise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreyFabricIssueReturnRollWiseExists(id))
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

        // POST: api/GreyFabricIssueReturnRollWises
        [HttpPost]
        public async Task<ActionResult<GreyFabricIssueReturnRollWise>> PostGreyFabricIssueReturnRollWise(GreyFabricIssueReturnRollWise greyFabricIssueReturnRollWise)
        {
            _context.GreyFabricIssueReturnRollWises.Add(greyFabricIssueReturnRollWise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreyFabricIssueReturnRollWise", new { id = greyFabricIssueReturnRollWise.Id }, greyFabricIssueReturnRollWise);
        }

        // DELETE: api/GreyFabricIssueReturnRollWises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GreyFabricIssueReturnRollWise>> DeleteGreyFabricIssueReturnRollWise(int id)
        {
            var greyFabricIssueReturnRollWise = await _context.GreyFabricIssueReturnRollWises.FindAsync(id);
            if (greyFabricIssueReturnRollWise == null)
            {
                return NotFound();
            }

            _context.GreyFabricIssueReturnRollWises.Remove(greyFabricIssueReturnRollWise);
            await _context.SaveChangesAsync();

            return greyFabricIssueReturnRollWise;
        }

        private bool GreyFabricIssueReturnRollWiseExists(int id)
        {
            return _context.GreyFabricIssueReturnRollWises.Any(e => e.Id == id);
        }
    }
}
