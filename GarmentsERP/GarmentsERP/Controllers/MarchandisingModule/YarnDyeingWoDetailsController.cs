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
    public class YarnDyeingWoDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnDyeingWoDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnDyeingWoDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnDyeingWoDetail>>> GetYarnDyeingWoDetail()
        {
            return await _context.YarnDyeingWoDetails.ToListAsync();
        }

        // GET: api/YarnDyeingWoDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnDyeingWoDetail>> GetYarnDyeingWoDetail(int id)
        {
            var yarnDyeingWoDetail = await _context.YarnDyeingWoDetails.FindAsync(id);

            if (yarnDyeingWoDetail == null)
            {
                return NotFound();
            }

            return yarnDyeingWoDetail;
        }

        // PUT: api/YarnDyeingWoDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnDyeingWoDetail(int id, YarnDyeingWoDetail yarnDyeingWoDetail)
        {
            if (id != yarnDyeingWoDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnDyeingWoDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnDyeingWoDetailExists(id))
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

        // POST: api/YarnDyeingWoDetails
        [HttpPost]
        public async Task<ActionResult<YarnDyeingWoDetail>> PostYarnDyeingWoDetail(YarnDyeingWoDetail yarnDyeingWoDetail)
        {
            _context.YarnDyeingWoDetails.Add(yarnDyeingWoDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnDyeingWoDetail", new { id = yarnDyeingWoDetail.Id }, yarnDyeingWoDetail);
        }

        // DELETE: api/YarnDyeingWoDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnDyeingWoDetail>> DeleteYarnDyeingWoDetail(int id)
        {
            var yarnDyeingWoDetail = await _context.YarnDyeingWoDetails.FindAsync(id);
            if (yarnDyeingWoDetail == null)
            {
                return NotFound();
            }

            _context.YarnDyeingWoDetails.Remove(yarnDyeingWoDetail);
            await _context.SaveChangesAsync();

            return yarnDyeingWoDetail;
        }

        private bool YarnDyeingWoDetailExists(int id)
        {
            return _context.YarnDyeingWoDetails.Any(e => e.Id == id);
        }
    }
}
