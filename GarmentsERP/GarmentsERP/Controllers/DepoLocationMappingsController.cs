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
    public class DepoLocationMappingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public DepoLocationMappingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/DepoLocationMappings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepoLocationMapping>>> GetDepoLocationMapping()
        {
            var result =
                await (from DepoLocationMappingtbl in _context.DepoLocationMappings
                       join countryInfoTbl in _context.TblRegionInfoes on DepoLocationMappingtbl.CountryId equals countryInfoTbl.RegionID into countryInfoTbls
                       from countryInfoTbl in countryInfoTbls.DefaultIfEmpty()


                       join CountryLocationMappingTbl in _context.countryLocationMappings on DepoLocationMappingtbl.UltimateCountryId equals CountryLocationMappingTbl.Id into CountryLocationMappingTbls
                       from CountryLocationMappingTbl in CountryLocationMappingTbls.DefaultIfEmpty()

                       orderby DepoLocationMappingtbl.Id descending
                       select new DepoLocationMapping
                       {

                           Id=DepoLocationMappingtbl.Id,
         CountryId=DepoLocationMappingtbl.CountryId,
         UltimateCountryId=DepoLocationMappingtbl.UltimateCountryId,
       CountryDepoName=DepoLocationMappingtbl.CountryDepoName,
       status=DepoLocationMappingtbl.status,

        CountryName = countryInfoTbl.Region_Name,
                           UltimateCountryName = CountryLocationMappingTbl.UltimateCountryName,

                          
                       }).ToListAsync();
            return result;
        }

        // GET: api/DepoLocationMappings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepoLocationMapping>> GetDepoLocationMapping(int id)
        {
            var depoLocationMapping = await _context.DepoLocationMappings.FindAsync(id);

            if (depoLocationMapping == null)
            {
                return NotFound();
            }

            return depoLocationMapping;
        }

        // PUT: api/DepoLocationMappings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepoLocationMapping(int id, DepoLocationMapping depoLocationMapping)
        {
            if (id != depoLocationMapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(depoLocationMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepoLocationMappingExists(id))
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

        // POST: api/DepoLocationMappings
        [HttpPost]
        public async Task<ActionResult<DepoLocationMapping>> PostDepoLocationMapping(DepoLocationMapping depoLocationMapping)
        {
            _context.DepoLocationMappings.Add(depoLocationMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepoLocationMapping", new { id = depoLocationMapping.Id }, depoLocationMapping);
        }

        // DELETE: api/DepoLocationMappings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DepoLocationMapping>> DeleteDepoLocationMapping(int id)
        {
            var depoLocationMapping = await _context.DepoLocationMappings.FindAsync(id);
            if (depoLocationMapping == null)
            {
                return NotFound();
            }

            _context.DepoLocationMappings.Remove(depoLocationMapping);
            await _context.SaveChangesAsync();

            return depoLocationMapping;
        }

        private bool DepoLocationMappingExists(int id)
        {
            return _context.DepoLocationMappings.Any(e => e.Id == id);
        }
    }
}
