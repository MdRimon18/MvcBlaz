using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketingTeamInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MarketingTeamInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MarketingTeamInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketingTeamInfo>>> GetMarketingTeamInfo()
        {
            return await _context.MarketingTeamInfoes.ToListAsync();
        }

        // GET: api/MarketingTeamInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketingTeamInfo>> GetMarketingTeamInfo(int id)
        {
            var marketingTeamInfo = await _context.MarketingTeamInfoes.FindAsync(id);

            if (marketingTeamInfo == null)
            {
                return NotFound();
            }

            return marketingTeamInfo;
        }

        // PUT: api/MarketingTeamInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketingTeamInfo(int id, MarketingTeamInfo marketingTeamInfo)
        {
            if (id != marketingTeamInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketingTeamInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketingTeamInfoExists(id))
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

        // POST: api/MarketingTeamInfoes
        [HttpPost]
        public async Task<ActionResult<MarketingTeamInfo>> PostMarketingTeamInfo(MarketingTeamInfo marketingTeamInfo)
        {
            _context.MarketingTeamInfoes.Add(marketingTeamInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketingTeamInfo", new { id = marketingTeamInfo.Id }, marketingTeamInfo);
        }

        // DELETE: api/MarketingTeamInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketingTeamInfo>> DeleteMarketingTeamInfo(int id)
        {
            var marketingTeamInfo = await _context.MarketingTeamInfoes.FindAsync(id);
            if (marketingTeamInfo == null)
            {
                return NotFound();
            }

            _context.MarketingTeamInfoes.Remove(marketingTeamInfo);
            await _context.SaveChangesAsync();

            return marketingTeamInfo;
        }

        private bool MarketingTeamInfoExists(int id)
        {
            return _context.MarketingTeamInfoes.Any(e => e.Id == id);
        }
    }
}
