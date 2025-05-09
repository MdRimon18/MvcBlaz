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
    public class YarnRatesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnRatesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnRate>>> GetYarnRate()
        {
            var result =
                 await (from YarnRatetbl in _context.YarnRates
                        


                        join SupplierProfileTbl in _context.SupplierProfiles on YarnRatetbl.SupplierId equals SupplierProfileTbl.Id into SupplierProfileTbls
                        from SupplierProfileTbl in SupplierProfileTbls.DefaultIfEmpty()

                        join YarnCountTbl in _context.YarnCounts on YarnRatetbl.YarnCountId equals YarnCountTbl.Id into YarnCountTbls
                        from YarnCountTbl in YarnCountTbls.DefaultIfEmpty()

                        join CompositionTbl in _context.Compositions on YarnRatetbl.CompositionId equals CompositionTbl.Id into CompositionTbls
                        from CompositionTbl in CompositionTbls.DefaultIfEmpty()

                        join TypeTbl in _context.Typpes on YarnRatetbl.Type equals TypeTbl.Id into TypeTbls
                        from TypeTbl in TypeTbls.DefaultIfEmpty()

                        


                      

                        orderby YarnRatetbl.Id descending
                        select new YarnRate
                        {

                            Id=YarnRatetbl.Id,
         SupplierId=YarnRatetbl.SupplierId,
         YarnCountId=YarnRatetbl.YarnCountId,
         CompositionId=YarnRatetbl.CompositionId,
       Percentage=YarnRatetbl.Percentage,
         Type=YarnRatetbl.Type,
       RateOrKg=YarnRatetbl.RateOrKg,
       EffectiveDate=YarnRatetbl.EffectiveDate,

                            SupplierName = SupplierProfileTbl.SupplierName,

                            TypeName = TypeTbl.TypeName,

                            CompositionName = CompositionTbl.CompositionName,

                            YarnCountName = YarnCountTbl.Name,

                            
                        }).ToListAsync();
            return result;
        }

        // GET: api/YarnRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnRate>> GetYarnRate(int id)
        {
            var yarnRate = await _context.YarnRates.FindAsync(id);

            if (yarnRate == null)
            {
                return NotFound();
            }

            return yarnRate;
        }

        // PUT: api/YarnRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnRate(int id, YarnRate yarnRate)
        {
            if (id != yarnRate.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnRateExists(id))
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

        // POST: api/YarnRates
        [HttpPost]
        public async Task<ActionResult<YarnRate>> PostYarnRate(YarnRate yarnRate)
        {
            _context.YarnRates.Add(yarnRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnRate", new { id = yarnRate.Id }, yarnRate);
        }

        // DELETE: api/YarnRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnRate>> DeleteYarnRate(int id)
        {
            var yarnRate = await _context.YarnRates.FindAsync(id);
            if (yarnRate == null)
            {
                return NotFound();
            }

            _context.YarnRates.Remove(yarnRate);
            await _context.SaveChangesAsync();

            return yarnRate;
        }

        private bool YarnRateExists(int id)
        {
            return _context.YarnRates.Any(e => e.Id == id);
        }
    }
}
