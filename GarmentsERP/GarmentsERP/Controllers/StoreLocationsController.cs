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
    public class StoreLocationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public StoreLocationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/StoreLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreLocation>>> GetStoreLocation()
        {
            
            var result = await (from StoreLocationthl in _context.StoreLocations

                                join compInf in _context.TblCompanyInfoes on StoreLocationthl.CompanyName equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on StoreLocationthl.Location equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()

                                orderby StoreLocationthl.Id descending
                                select new StoreLocation
                                {

                                 Id =StoreLocationthl.Id,
                                 StoreName =StoreLocationthl.StoreName,
                                 CompanyName =StoreLocationthl.CompanyName,
                                 Location =StoreLocationthl.Location,
                                 ItemCategoryId =StoreLocationthl.ItemCategoryId,
                                 Status =StoreLocationthl.Status,

                                    Company = compInf.Company_Name,

                                    LocationName = locationTbl.Location_Name,

                                   
                                })
                .ToListAsync();


            return result;
        }

        // GET: api/StoreLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreLocation>> GetStoreLocation(int id)
        {
            var storeLocation = await _context.StoreLocations.FindAsync(id);

            if (storeLocation == null)
            {
                return NotFound();
            }

            return storeLocation;
        }

        // PUT: api/StoreLocations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreLocation(int id, StoreLocation storeLocation)
        {
            if (id != storeLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(storeLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreLocationExists(id))
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

        // POST: api/StoreLocations
        [HttpPost]
        public async Task<ActionResult<StoreLocation>> PostStoreLocation(StoreLocation storeLocation)
        {
            _context.StoreLocations.Add(storeLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoreLocation", new { id = storeLocation.Id }, storeLocation);
        }

        // DELETE: api/StoreLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StoreLocation>> DeleteStoreLocation(int id)
        {
            var storeLocation = await _context.StoreLocations.FindAsync(id);
            if (storeLocation == null)
            {
                return NotFound();
            }

            _context.StoreLocations.Remove(storeLocation);
            await _context.SaveChangesAsync();

            return storeLocation;
        }

        private bool StoreLocationExists(int id)
        {
            return _context.StoreLocations.Any(e => e.Id == id);
        }
    }
}
