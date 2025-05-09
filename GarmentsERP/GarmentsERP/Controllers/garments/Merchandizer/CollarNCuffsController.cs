using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;
using Microsoft.AspNetCore.Http;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollarNCuffsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CollarNCuffsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CollarNCuffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollarNCuff>>> GetCollarNCuffs()
        {
            return await _context.CollarNCuffs.ToListAsync();
        }

        // GET: api/CollarNCuffs/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CollarNCuff>>> GetCollarNCuff(int id)
        {
            var collarNCuffs = await _context.CollarNCuffs
                .Where(w => w.BookingId == id)
                .ToListAsync();

            if (collarNCuffs == null || !collarNCuffs.Any())
            {
                return NotFound();
            }

            return collarNCuffs;
        }

        // PUT: api/CollarNCuffs/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCollarNCuff(int id, CollarNCuff collarNCuff)
        {
            if (id != collarNCuff.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(collarNCuff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollarNCuffExists(id))
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

        // POST: api/CollarNCuffs
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> PostCollarNCuff(List<CollarNCuff> collarNCuffs)
        {
            if (collarNCuffs == null || !collarNCuffs.Any())
            {
                return BadRequest("No items provided.");
            }

            int isSuccess = 0;
            foreach (var collarNCuff in collarNCuffs)
            {
                if (collarNCuff.Id > 0)
                {
                    _context.Entry(collarNCuff).State = EntityState.Modified;
                }
                else
                {
                    _context.CollarNCuffs.Add(collarNCuff);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to save changes: {ex.Message}");
            }

            return Ok(isSuccess);
        }

        // DELETE: api/CollarNCuffs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CollarNCuff>> DeleteCollarNCuff(int id)
        {
            var collarNCuff = await _context.CollarNCuffs.FindAsync(id);
            if (collarNCuff == null)
            {
                return NotFound();
            }

            _context.CollarNCuffs.Remove(collarNCuff);
            await _context.SaveChangesAsync();

            return Ok(collarNCuff);
        }

        private bool CollarNCuffExists(int id)
        {
            return _context.CollarNCuffs.Any(e => e.Id == id);
        }
    }
}