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
    public class YarnDyeingWOWithoutOrderMastersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnDyeingWOWithoutOrderMastersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnDyeingWOWithoutOrderMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnDyeingWOWithoutOrderMaster>>> GetYarnDyeingWOWithoutOrderMaster()
        {
            return await _context.YarnDyeingWOWithoutOrderMasters.ToListAsync();
        }

        // GET: api/YarnDyeingWOWithoutOrderMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnDyeingWOWithoutOrderMaster>> GetYarnDyeingWOWithoutOrderMaster(int id)
        {
            var yarnDyeingWOWithoutOrderMaster = await _context.YarnDyeingWOWithoutOrderMasters.FindAsync(id);

            if (yarnDyeingWOWithoutOrderMaster == null)
            {
                return NotFound();
            }

            return yarnDyeingWOWithoutOrderMaster;
        }

        // PUT: api/YarnDyeingWOWithoutOrderMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnDyeingWOWithoutOrderMaster(int id, YarnDyeingWOWithoutOrderMaster yarnDyeingWOWithoutOrderMaster)
        {
            if (id != yarnDyeingWOWithoutOrderMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnDyeingWOWithoutOrderMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnDyeingWOWithoutOrderMasterExists(id))
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

        // POST: api/YarnDyeingWOWithoutOrderMasters
        [HttpPost]
        public async Task<ActionResult<YarnDyeingWOWithoutOrderMaster>> PostYarnDyeingWOWithoutOrderMaster(YarnDyeingWOWithoutOrderMaster yarnDyeingWOWithoutOrderMaster)
        {
            _context.YarnDyeingWOWithoutOrderMasters.Add(yarnDyeingWOWithoutOrderMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnDyeingWOWithoutOrderMaster", new { id = yarnDyeingWOWithoutOrderMaster.Id }, yarnDyeingWOWithoutOrderMaster);
        }

        // DELETE: api/YarnDyeingWOWithoutOrderMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnDyeingWOWithoutOrderMaster>> DeleteYarnDyeingWOWithoutOrderMaster(int id)
        {
            var yarnDyeingWOWithoutOrderMaster = await _context.YarnDyeingWOWithoutOrderMasters.FindAsync(id);
            if (yarnDyeingWOWithoutOrderMaster == null)
            {
                return NotFound();
            }

            _context.YarnDyeingWOWithoutOrderMasters.Remove(yarnDyeingWOWithoutOrderMaster);
            await _context.SaveChangesAsync();

            return yarnDyeingWOWithoutOrderMaster;
        }

        private bool YarnDyeingWOWithoutOrderMasterExists(int id)
        {
            return _context.YarnDyeingWOWithoutOrderMasters.Any(e => e.Id == id);
        }
    }
}
