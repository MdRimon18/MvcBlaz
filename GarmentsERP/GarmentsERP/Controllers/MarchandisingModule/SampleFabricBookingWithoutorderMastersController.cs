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
    public class SampleFabricBookingWithoutorderMastersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleFabricBookingWithoutorderMastersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleFabricBookingWithoutorderMasters  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleFabricBookingWithoutOrderMaster>>> GetSampleFabricBookingWithoutorderDetailsMaster()
        {
            return await _context.SampleFabricBookingWithoutOrderMasters.ToListAsync();
        }

        // GET: api/c/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleFabricBookingWithoutOrderMaster>> GetSampleFabricBookingWithoutorderMaster(int id)
        {
            var sampleFabricBookingWithoutorderMaster = await _context.SampleFabricBookingWithoutOrderMasters.FindAsync(id);

            if (sampleFabricBookingWithoutorderMaster == null)
            {
                return NotFound();
            }

            return sampleFabricBookingWithoutorderMaster;
        }

        // PUT: api/SampleFabricBookingWithoutorderMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleFabricBookingWithoutorderMaster(int id, SampleFabricBookingWithoutOrderMaster sampleFabricBookingWithoutorderMaster)
        {
            if (id != sampleFabricBookingWithoutorderMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleFabricBookingWithoutorderMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleFabricBookingWithoutorderMasterExists(id))
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

        // POST: api/SampleFabricBookingWithoutorderMasters
        [HttpPost]
        public async Task<ActionResult<SampleFabricBookingWithoutOrderMaster>> PostSampleFabricBookingWithoutorderMaster(SampleFabricBookingWithoutOrderMaster sampleFabricBookingWithoutOrderMaster)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit=CurrentYear.Substring(2);
            var bokingNo = "MKL" + "-SMN-" + lastTwoDigit +"000"+_context.SampleFabricBookingWithoutOrderMasters.Count();
            sampleFabricBookingWithoutOrderMaster.BookingNo = bokingNo;

            _context.SampleFabricBookingWithoutOrderMasters.Add(sampleFabricBookingWithoutOrderMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleFabricBookingWithoutorderMaster", new { id = sampleFabricBookingWithoutOrderMaster.Id }, sampleFabricBookingWithoutOrderMaster);
        }

        // DELETE: api/SampleFabricBookingWithoutorderMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleFabricBookingWithoutOrderMaster>> DeleteSampleFabricBookingWithoutorderMaster(int id)
        {
            var sampleFabricBookingWithoutorderMaster = await _context.SampleFabricBookingWithoutOrderMasters.FindAsync(id);
            if (sampleFabricBookingWithoutorderMaster == null)
            {
                return NotFound();
            }

            _context.SampleFabricBookingWithoutOrderMasters.Remove(sampleFabricBookingWithoutorderMaster);
            await _context.SaveChangesAsync();

            return sampleFabricBookingWithoutorderMaster;
        }

        private bool SampleFabricBookingWithoutorderMasterExists(int id)
        {
            return _context.SampleFabricBookingWithoutOrderMasters.Any(e => e.Id == id);
        }
    }
}
