using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinishFabricRollReceiveByStoresController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FinishFabricRollReceiveByStoresController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FinishFabricRollReceiveByStores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinishFabricRollReceiveByStore>>> GetFinishFabricRollReceiveByStore()
        {
            return await _context.FinishFabricRollReceiveByStores.ToListAsync();
        }

        // GET: api/FinishFabricRollReceiveByStores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinishFabricRollReceiveByStore>> GetFinishFabricRollReceiveByStore(int id)
        {
            var finishFabricRollReceiveByStore = await _context.FinishFabricRollReceiveByStores.FindAsync(id);

            if (finishFabricRollReceiveByStore == null)
            {
                return NotFound();
            }

            return finishFabricRollReceiveByStore;
        }

        // PUT: api/FinishFabricRollReceiveByStores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinishFabricRollReceiveByStore(int id, FinishFabricRollReceiveByStore finishFabricRollReceiveByStore)
        {
            if (id != finishFabricRollReceiveByStore.Id)
            {
                return BadRequest();
            }

            _context.Entry(finishFabricRollReceiveByStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishFabricRollReceiveByStoreExists(id))
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

        // POST: api/FinishFabricRollReceiveByStores
        [HttpPost]
        public async Task<ActionResult<FinishFabricRollReceiveByStore>> PostFinishFabricRollReceiveByStore(FinishFabricRollReceiveByStore finishFabricRollReceiveByStore)
        {
            _context.FinishFabricRollReceiveByStores.Add(finishFabricRollReceiveByStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinishFabricRollReceiveByStore", new { id = finishFabricRollReceiveByStore.Id }, finishFabricRollReceiveByStore);
        }

        // DELETE: api/FinishFabricRollReceiveByStores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinishFabricRollReceiveByStore>> DeleteFinishFabricRollReceiveByStore(int id)
        {
            var finishFabricRollReceiveByStore = await _context.FinishFabricRollReceiveByStores.FindAsync(id);
            if (finishFabricRollReceiveByStore == null)
            {
                return NotFound();
            }

            _context.FinishFabricRollReceiveByStores.Remove(finishFabricRollReceiveByStore);
            await _context.SaveChangesAsync();

            return finishFabricRollReceiveByStore;
        }

        private bool FinishFabricRollReceiveByStoreExists(int id)
        {
            return _context.FinishFabricRollReceiveByStores.Any(e => e.Id == id);
        }
    }
}
