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
    public class GarmentsSampleEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public GarmentsSampleEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/GarmentsSampleEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GarmentsSampleEntry>>> GetGarmentsSampleEntry()
        {
            var result =
                await (from GarmentsSampleEntrytbl in _context.GarmentsSampleEntries
                       join SampleTypeTbl in _context.SampleTypes on GarmentsSampleEntrytbl.SampleTypeId equals SampleTypeTbl.Id into SampleTypeTbls
                       from SampleTypeTbl in SampleTypeTbls.DefaultIfEmpty()


                       

                       orderby GarmentsSampleEntrytbl.Id descending
                       select new GarmentsSampleEntry
                       {

                             Id=GarmentsSampleEntrytbl.Id,
                             SampleName=GarmentsSampleEntrytbl.SampleName,
                             SampleTypeId=GarmentsSampleEntrytbl.SampleTypeId,
                             Status=GarmentsSampleEntrytbl.Status,


                           SampleTypeName = SampleTypeTbl.SampleTypeName
                       }).ToListAsync();
            return result;
        }

        // GET: api/GarmentsSampleEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GarmentsSampleEntry>> GetGarmentsSampleEntry(int id)
        {
            var garmentsSampleEntry = await _context.GarmentsSampleEntries.FindAsync(id);

            if (garmentsSampleEntry == null)
            {
                return NotFound();
            }

            return garmentsSampleEntry;
        }

        // PUT: api/GarmentsSampleEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarmentsSampleEntry(int id, GarmentsSampleEntry garmentsSampleEntry)
        {
            if (id != garmentsSampleEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(garmentsSampleEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarmentsSampleEntryExists(id))
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

        // POST: api/GarmentsSampleEntries
        [HttpPost]
        public async Task<ActionResult<GarmentsSampleEntry>> PostGarmentsSampleEntry(GarmentsSampleEntry garmentsSampleEntry)
        {
            _context.GarmentsSampleEntries.Add(garmentsSampleEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGarmentsSampleEntry", new { id = garmentsSampleEntry.Id }, garmentsSampleEntry);
        }

        // DELETE: api/GarmentsSampleEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GarmentsSampleEntry>> DeleteGarmentsSampleEntry(int id)
        {
            var garmentsSampleEntry = await _context.GarmentsSampleEntries.FindAsync(id);
            if (garmentsSampleEntry == null)
            {
                return NotFound();
            }

            _context.GarmentsSampleEntries.Remove(garmentsSampleEntry);
            await _context.SaveChangesAsync();

            return garmentsSampleEntry;
        }

        private bool GarmentsSampleEntryExists(int id)
        {
            return _context.GarmentsSampleEntries.Any(e => e.Id == id);
        }
    }
}
