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
    public class countryLocationMappingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public countryLocationMappingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/countryLocationMappings
        [HttpGet]
        public async Task< IEnumerable<countryLocationMapping>> GetCountryLocationMapping()
        {
            var result =
                 await(from CountryLocationMappingTbl in _context.countryLocationMappings
                       join countryTbl in _context.TblRegionInfoes on CountryLocationMappingTbl.CountryId equals countryTbl.RegionID into countryTbls
                       from countryTbl in countryTbls.DefaultIfEmpty()


                       

                       orderby CountryLocationMappingTbl.Id descending
                       select new countryLocationMapping
                       {
                             Id=CountryLocationMappingTbl.Id,
                             CountryId=CountryLocationMappingTbl.CountryId,
                             UltimateCountryName=CountryLocationMappingTbl.UltimateCountryName,

                           CountryName = countryTbl.Region_Name
                       }).ToListAsync();
            return result;
        }

        // GET: api/countryLocationMappings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<countryLocationMapping>> GetcountryLocationMapping(int id)
        {
            var countryLocationMapping = await _context.countryLocationMappings.FindAsync(id);

            if (countryLocationMapping == null)
            {
                return NotFound();
            }

            return countryLocationMapping;
        }

        // PUT: api/countryLocationMappings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutcountryLocationMapping(int id, countryLocationMapping countryLocationMapping)
        {
            if (id != countryLocationMapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(countryLocationMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!countryLocationMappingExists(id))
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

        // POST: api/countryLocationMappings
        [HttpPost]
        public async Task<ActionResult<countryLocationMapping>> PostcountryLocationMapping(countryLocationMapping countryLocationMapping)
        {
            _context.countryLocationMappings.Add(countryLocationMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetcountryLocationMapping", new { id = countryLocationMapping.Id }, countryLocationMapping);
        }

        // DELETE: api/countryLocationMappings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<countryLocationMapping>> DeletecountryLocationMapping(int id)
        {
            var countryLocationMapping = await _context.countryLocationMappings.FindAsync(id);
            if (countryLocationMapping == null)
            {
                return NotFound();
            }

            _context.countryLocationMappings.Remove(countryLocationMapping);
            await _context.SaveChangesAsync();

            return countryLocationMapping;
        }

        private bool countryLocationMappingExists(int id)
        {
            return _context.countryLocationMappings.Any(e => e.Id == id);
        }
    }
}
