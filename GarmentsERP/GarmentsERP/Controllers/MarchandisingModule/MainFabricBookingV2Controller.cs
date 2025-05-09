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
    public class MainFabricBookingV2Controller : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MainFabricBookingV2Controller(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MainFabricBookingV2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainFabricBookingV2>>> GetMainFabricBookingV2()
        {
            return await _context.MainFabricBookingV2.ToListAsync();
        }

        // GET: api/MainFabricBookingV2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainFabricBookingV2>> GetMainFabricBookingV2(int id)
        {
            var mainFabricBookingV2 = await _context.MainFabricBookingV2.FindAsync(id);

            if (mainFabricBookingV2 == null)
            {
                return NotFound();
            }

            return mainFabricBookingV2;
        }

        // PUT: api/MainFabricBookingV2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainFabricBookingV2(int id, MainFabricBookingV2 mainFabricBookingV2)
        {
            if (id != mainFabricBookingV2.Id)
            {
                return BadRequest();
            }

            _context.Entry(mainFabricBookingV2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainFabricBookingV2Exists(id))
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

        // POST: api/MainFabricBookingV2
        [HttpPost]
        public async Task<ActionResult<MainFabricBookingV2>> PostMainFabricBookingV2(MainFabricBookingV2 mainFabricBookingV2)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var bokingNo = "MKL" + "-FB-" + lastTwoDigit + "000" + _context.SampleFabricBookingWithoutOrderMasters.Count();
            mainFabricBookingV2.BookingNo = bokingNo;

            _context.MainFabricBookingV2.Add(mainFabricBookingV2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMainFabricBookingV2", new { id = mainFabricBookingV2.Id }, mainFabricBookingV2);
        }

        // DELETE: api/MainFabricBookingV2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MainFabricBookingV2>> DeleteMainFabricBookingV2(int id)
        {
            var mainFabricBookingV2 = await _context.MainFabricBookingV2.FindAsync(id);
            if (mainFabricBookingV2 == null)
            {
                return NotFound();
            }

            _context.MainFabricBookingV2.Remove(mainFabricBookingV2);
            await _context.SaveChangesAsync();

            return mainFabricBookingV2;
        }

        private bool MainFabricBookingV2Exists(int id)
        {
            return _context.MainFabricBookingV2.Any(e => e.Id == id);
        }
    }
}
