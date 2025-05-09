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
    public class YarnDyeingWorkOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnDyeingWorkOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnDyeingWorkOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnDyeingWorkOrder>>> GetYarnDyeingWorkOrder()
        {
            return await _context.YarnDyeingWorkOrders.ToListAsync();
        }

        // GET: api/YarnDyeingWorkOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnDyeingWorkOrder>> GetYarnDyeingWorkOrder(int id)
        {
            var yarnDyeingWorkOrder = await _context.YarnDyeingWorkOrders.FindAsync(id);

            if (yarnDyeingWorkOrder == null)
            {
                return NotFound();
            }

            return yarnDyeingWorkOrder;
        }

        // PUT: api/YarnDyeingWorkOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnDyeingWorkOrder(int id, YarnDyeingWorkOrder yarnDyeingWorkOrder)
        {
            if (id != yarnDyeingWorkOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnDyeingWorkOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnDyeingWorkOrderExists(id))
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

        // POST: api/YarnDyeingWorkOrders
        [HttpPost]
        public async Task<ActionResult<YarnDyeingWorkOrder>> PostYarnDyeingWorkOrder(YarnDyeingWorkOrder yarnDyeingWorkOrder)
        {
            _context.YarnDyeingWorkOrders.Add(yarnDyeingWorkOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnDyeingWorkOrder", new { id = yarnDyeingWorkOrder.Id }, yarnDyeingWorkOrder);
        }

        // DELETE: api/YarnDyeingWorkOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnDyeingWorkOrder>> DeleteYarnDyeingWorkOrder(int id)
        {
            var yarnDyeingWorkOrder = await _context.YarnDyeingWorkOrders.FindAsync(id);
            if (yarnDyeingWorkOrder == null)
            {
                return NotFound();
            }

            _context.YarnDyeingWorkOrders.Remove(yarnDyeingWorkOrder);
            await _context.SaveChangesAsync();

            return yarnDyeingWorkOrder;
        }

        private bool YarnDyeingWorkOrderExists(int id)
        {
            return _context.YarnDyeingWorkOrders.Any(e => e.Id == id);
        }
    }
}
