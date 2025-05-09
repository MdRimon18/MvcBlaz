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
    public class YarnDyeingWOWithoutOrderDetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnDyeingWOWithoutOrderDetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnDyeingWOWithoutOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnDyeingWOWithoutOrderDetail>>> GetYarnDyeingWOWithoutOrderDetail()
        {
            return await _context.YarnDyeingWOWithoutOrderDetails.ToListAsync();
        }

        // GET: api/YarnDyeingWOWithoutOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnDyeingWOWithoutOrderDetail>> GetYarnDyeingWOWithoutOrderDetail(int id)
        {
            var yarnDyeingWOWithoutOrderDetail = await _context.YarnDyeingWOWithoutOrderDetails.FindAsync(id);

            if (yarnDyeingWOWithoutOrderDetail == null)
            {
                return NotFound();
            }

            return yarnDyeingWOWithoutOrderDetail;
        }

        // PUT: api/YarnDyeingWOWithoutOrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnDyeingWOWithoutOrderDetail(int id, YarnDyeingWOWithoutOrderDetail yarnDyeingWOWithoutOrderDetail)
        {
            if (id != yarnDyeingWOWithoutOrderDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnDyeingWOWithoutOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnDyeingWOWithoutOrderDetailExists(id))
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

        // POST: api/YarnDyeingWOWithoutOrderDetails
        [HttpPost]
        public async Task<ActionResult<YarnDyeingWOWithoutOrderDetail>> PostYarnDyeingWOWithoutOrderDetail(YarnDyeingWOWithoutOrderDetail yarnDyeingWOWithoutOrderDetail)
        {
            _context.YarnDyeingWOWithoutOrderDetails.Add(yarnDyeingWOWithoutOrderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnDyeingWOWithoutOrderDetail", new { id = yarnDyeingWOWithoutOrderDetail.Id }, yarnDyeingWOWithoutOrderDetail);
        }

        // DELETE: api/YarnDyeingWOWithoutOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnDyeingWOWithoutOrderDetail>> DeleteYarnDyeingWOWithoutOrderDetail(int id)
        {
            var yarnDyeingWOWithoutOrderDetail = await _context.YarnDyeingWOWithoutOrderDetails.FindAsync(id);
            if (yarnDyeingWOWithoutOrderDetail == null)
            {
                return NotFound();
            }

            _context.YarnDyeingWOWithoutOrderDetails.Remove(yarnDyeingWOWithoutOrderDetail);
            await _context.SaveChangesAsync();

            return yarnDyeingWOWithoutOrderDetail;
        }

        private bool YarnDyeingWOWithoutOrderDetailExists(int id)
        {
            return _context.YarnDyeingWOWithoutOrderDetails.Any(e => e.Id == id);
        }
    }
}
