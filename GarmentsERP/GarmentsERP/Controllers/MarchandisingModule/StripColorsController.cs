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
    public class StripColorsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public StripColorsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/StripColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StripColors>>> GetStripColors()
        {
            return await _context.StripColors.ToListAsync();
        }

        // GET: api/StripColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StripColors>>> GetStripColors(int id)
        {
            var stripeColors = _context.StripColors.Where(w => w.FabricCostId == id).ToList();
            return stripeColors;
        }

        // PUT: api/StripColors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStripColors(int id, StripColors stripColors)
        {
            if (id != stripColors.Id)
            {
                return BadRequest();
            }

            _context.Entry(stripColors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StripColorsExists(id))
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

        // POST: api/StripColors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<int>> PostStripColors(List<StripColors> stripColors)
        {
            int isSuccess = 0;
            foreach (var sc in stripColors.ToList())
            {
                if (sc.Id > 0)
                {
                    _context.Entry(sc).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {

                    _context.StripColors.Add(sc);
                    await _context.SaveChangesAsync();
                }

            }
            try
            {

                isSuccess++;
            }
            catch (Exception e)
            {

                throw;
            }
            return isSuccess;
        }

        // DELETE: api/StripColors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StripColors>> DeleteStripColors(int id)
        {
            var stripColors = await _context.StripColors.FindAsync(id);
            if (stripColors == null)
            {
                return NotFound();
            }

            _context.StripColors.Remove(stripColors);
            await _context.SaveChangesAsync();

            return stripColors;
        }

        private bool StripColorsExists(int id)
        {
            return _context.StripColors.Any(e => e.Id == id);
        }
    }
}
