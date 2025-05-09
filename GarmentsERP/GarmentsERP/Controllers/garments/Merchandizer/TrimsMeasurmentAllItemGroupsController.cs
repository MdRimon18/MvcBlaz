using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrimsMeasurmentAllItemGroupsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimsMeasurmentAllItemGroupsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimsMeasurmentAllItemGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimsMeasurmentAllItemGroup>>> GetTrimsMeasurmentAllItemGroups()
        {
            return await _context.TrimsMeasurmentAllItemGroups.ToListAsync();
        }

        // GET: api/TrimsMeasurmentAllItemGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrimsMeasurmentAllItemGroup>>> GetTrimsMeasurmentAllItemGroup(int id)
        {
            var groups = await _context.TrimsMeasurmentAllItemGroups
                .Where(w => w.PrecostingId == id)
                .ToListAsync();

            if (groups == null || !groups.Any())
            {
                return NotFound();
            }

            return groups;
        }

        // PUT: api/TrimsMeasurmentAllItemGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimsMeasurmentAllItemGroup(int id, TrimsMeasurmentAllItemGroup trimsMeasurmentAllItemGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trimsMeasurmentAllItemGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimsMeasurmentAllItemGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimsMeasurmentAllItemGroupExists(id))
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

        // POST: api/TrimsMeasurmentAllItemGroups
        [HttpPost]
        public async Task<ActionResult<int>> PostTrimsMeasurmentAllItemGroup(List<TrimsMeasurmentAllItemGroup> itemGroups)
        {
            int isSuccess = 0;
            foreach (var trims in itemGroups)
            {
                if (trims.Id > 0)
                {
                    _context.Entry(trims).State = EntityState.Modified;
                }
                else
                {
                    _context.TrimsMeasurmentAllItemGroups.Add(trims);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return isSuccess;
        }

        // DELETE: api/TrimsMeasurmentAllItemGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrimsMeasurmentAllItemGroup(int id)
        {
            var trimsMeasurmentAllItemGroup = await _context.TrimsMeasurmentAllItemGroups.FindAsync(id);
            if (trimsMeasurmentAllItemGroup == null)
            {
                return NotFound();
            }

            _context.TrimsMeasurmentAllItemGroups.Remove(trimsMeasurmentAllItemGroup);
            await _context.SaveChangesAsync();

            return Ok(trimsMeasurmentAllItemGroup);
        }

        private bool TrimsMeasurmentAllItemGroupExists(int id)
        {
            return _context.TrimsMeasurmentAllItemGroups.Any(e => e.Id == id);
        }
    }
}