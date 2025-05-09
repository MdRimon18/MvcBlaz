using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model;
using GarmentsERP.Repositories;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class YarnConsOptimaizationStripeColorsController : ControllerBase
    {
        private readonly GarmentERPContext _context;
        private readonly DapperRepository _dapperRepository;
        public YarnConsOptimaizationStripeColorsController(GarmentERPContext context, 
            DapperRepository dapperRepository)
        {
            _context = context;
            _dapperRepository = dapperRepository;
        }

        // GET: api/YarnConsOptimaizationStripeColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnConsOptimaizationStripeColor>>> GetYarnConsOptimaizationStripeColors()
        {
            return await _context.YarnConsOptimaizationStripeColors.ToListAsync();
        }

        // GET: api/YarnConsOptimaizationStripeColors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GetYarnConsOptimaizationStripeColor_Result>>> GetYarnConsOptimaizationStripeColor(int id)
        {
            var yarnConsOptimaizationStripeColor = (await _dapperRepository.GetYarnConsOptimaizationStripeColor(id)).ToList();

            if (yarnConsOptimaizationStripeColor == null || !yarnConsOptimaizationStripeColor.Any())
            {
                return NotFound();
            }

            return yarnConsOptimaizationStripeColor;
        }

        // PUT: api/YarnConsOptimaizationStripeColors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnConsOptimaizationStripeColor(int id, YarnConsOptimaizationStripeColor yarnConsOptimaizationStripeColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yarnConsOptimaizationStripeColor.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnConsOptimaizationStripeColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnConsOptimaizationStripeColorExists(id))
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

        // POST: api/YarnConsOptimaizationStripeColors
        [HttpPost]
        public async Task<ActionResult<int>> PostYarnConsOptimaizationStripeColor(List<YarnConsOptimaizationStripeColor> yarnConsOptimaizationStripeColors)
        {
            int isSuccess = 0;
            foreach (var y in yarnConsOptimaizationStripeColors)
            {
                if (y.Id > 0)
                {
                    _context.Entry(y).State = EntityState.Modified;
                }
                else
                {
                    _context.YarnConsOptimaizationStripeColors.Add(y);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception)
            {
                throw;
            }

            return isSuccess;
        }

        // DELETE: api/YarnConsOptimaizationStripeColors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYarnConsOptimaizationStripeColor(int id)
        {
            var yarnConsOptimaizationStripeColor = await _context.YarnConsOptimaizationStripeColors.FindAsync(id);
            if (yarnConsOptimaizationStripeColor == null)
            {
                return NotFound();
            }

            _context.YarnConsOptimaizationStripeColors.Remove(yarnConsOptimaizationStripeColor);
            await _context.SaveChangesAsync();

            return Ok(yarnConsOptimaizationStripeColor);
        }

        private bool YarnConsOptimaizationStripeColorExists(int id)
        {
            return _context.YarnConsOptimaizationStripeColors.Any(e => e.Id == id);
        }
    }
}