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
    public class ConsumptionEntryFormForTrimsCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ConsumptionEntryFormForTrimsCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ConsumptionEntryFormForTrimsCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumptionEntryFormForTrimsCost>>> GetConsumptionEntryFormForTrimsCost()
        {
            return await _context.ConsumptionEntryFormForTrimsCosts.ToListAsync();
        }

        // GET: api/ConsumptionEntryFormForTrimsCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ConsumptionEntryFormForTrimsCost>>> GetConsumptionEntryFormForTrimsCost(int id)
        {
            var TrimsCostConsumptionByTrimCostId = _context.ConsumptionEntryFormForTrimsCosts.Where(w => w.TrimCostId == id).ToList();
            return TrimsCostConsumptionByTrimCostId;
            
        }

        // PUT: api/ConsumptionEntryFormForTrimsCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumptionEntryFormForTrimsCost(int id, ConsumptionEntryFormForTrimsCost consumptionEntryFormForTrimsCost)
        {
            if (id != consumptionEntryFormForTrimsCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumptionEntryFormForTrimsCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumptionEntryFormForTrimsCostExists(id))
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

        // POST: api/ConsumptionEntryFormForTrimsCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostConsumptionEntryFormForTrimsCost(List<ConsumptionEntryFormForTrimsCost> consumptionEntryFormForTrimsCostList)
        {

            int isSuccess = 0;
            foreach (var consumptionEntryFormForTrimsCostListObj in consumptionEntryFormForTrimsCostList.ToList())
            {
                if (consumptionEntryFormForTrimsCostListObj.Id > 0)
                {
                    _context.Entry(consumptionEntryFormForTrimsCostListObj).State = EntityState.Modified;
                }
                else
                {

                    _context.ConsumptionEntryFormForTrimsCosts.Add(consumptionEntryFormForTrimsCostListObj);

                }

            }
            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {

                throw;
            }
            return isSuccess;

            
        }

        // DELETE: api/ConsumptionEntryFormForTrimsCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsumptionEntryFormForTrimsCost>> DeleteConsumptionEntryFormForTrimsCost(int id)
        {
            var consumptionEntryFormForTrimsCost = await _context.ConsumptionEntryFormForTrimsCosts.FindAsync(id);
            if (consumptionEntryFormForTrimsCost == null)
            {
                return NotFound();
            }

            _context.ConsumptionEntryFormForTrimsCosts.Remove(consumptionEntryFormForTrimsCost);
            await _context.SaveChangesAsync();

            return consumptionEntryFormForTrimsCost;
        }

        private bool ConsumptionEntryFormForTrimsCostExists(int id)
        {
            return _context.ConsumptionEntryFormForTrimsCosts.Any(e => e.Id == id);
        }
    }
}
