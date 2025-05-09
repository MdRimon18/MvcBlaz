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
    public class SampleFabricBookingWithordersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleFabricBookingWithordersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleFabricBookingWithorders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleFabricBookingWithorder>>> GetSampleFabricBookingWithorder()
        {
            var sbwoLst = _context.SampleFabricBookingWithorders.ToList();
            var PODetailsLst = _context.TblPodetailsInfroes.ToList();
            foreach (var item in sbwoLst)
            {
                item.PoDetId = PODetailsLst
                    .FirstOrDefault(f => f.PO_No.ToLower().Trim() == item.OrderNo.ToLower().Trim()).PoDetID;
            }

            return await _context.SampleFabricBookingWithorders.ToListAsync();
        }

        // GET: api/SampleFabricBookingWithorders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleFabricBookingWithorder>> GetSampleFabricBookingWithorder(int id)
        {
            var sampleFabricBookingWithorder = await _context.SampleFabricBookingWithorders.FindAsync(id);

            if (sampleFabricBookingWithorder == null)
            {
                return NotFound();
            }

            return sampleFabricBookingWithorder;
        }

        // PUT: api/SampleFabricBookingWithorders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleFabricBookingWithorder(int id, SampleFabricBookingWithorder sampleFabricBookingWithorder)
        {
            if (id != sampleFabricBookingWithorder.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleFabricBookingWithorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleFabricBookingWithorderExists(id))
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

        // POST: api/SampleFabricBookingWithorders
        [HttpPost]
        public async Task<ActionResult<SampleFabricBookingWithorder>> PostSampleFabricBookingWithorder(SampleFabricBookingWithorder sampleFabricBookingWithorder)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var bokingNo = "MKL" + "-FB-" + lastTwoDigit + "000" + _context.SampleFabricBookingWithorders.Count();
            sampleFabricBookingWithorder.BookingNo = bokingNo;

            _context.SampleFabricBookingWithorders.Add(sampleFabricBookingWithorder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleFabricBookingWithorder", new { id = sampleFabricBookingWithorder.Id }, sampleFabricBookingWithorder);
        }

        // DELETE: api/SampleFabricBookingWithorders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleFabricBookingWithorder>> DeleteSampleFabricBookingWithorder(int id)
        {
            var sampleFabricBookingWithorder = await _context.SampleFabricBookingWithorders.FindAsync(id);
            if (sampleFabricBookingWithorder == null)
            {
                return NotFound();
            }

            _context.SampleFabricBookingWithorders.Remove(sampleFabricBookingWithorder);
            await _context.SaveChangesAsync();

            return sampleFabricBookingWithorder;
        }

        private bool SampleFabricBookingWithorderExists(int id)
        {
            return _context.SampleFabricBookingWithorders.Any(e => e.Id == id);
        }
    }
}
