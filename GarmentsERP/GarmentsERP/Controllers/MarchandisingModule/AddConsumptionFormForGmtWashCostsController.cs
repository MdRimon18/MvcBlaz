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
    public class AddConsumptionFormForGmtWashCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public AddConsumptionFormForGmtWashCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/AddConsumptionFormForGmtWashCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddConsumptionFormForGmtWashCost>>> GetAddConsumptionFormForGmtWashCost()
        {
             
            return await _context.AddConsumptionFormForGmtWashCosts.OrderBy(o=>o.PoId).ToListAsync();
        }

        // GET: api/AddConsumptionFormForGmtWashCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AddConsumptionFormForGmtWashCost>>> GetAddConsumptionFormForGmtWashCost(int id)
        {
            var GmtWashCostByWashCostId =  _context.AddConsumptionFormForGmtWashCosts.Where(f=>f.WashCostId==id).ToList();
            return GmtWashCostByWashCostId;
        }

        // PUT: api/AddConsumptionFormForGmtWashCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddConsumptionFormForGmtWashCost(int id, AddConsumptionFormForGmtWashCost addConsumptionFormForGmtWashCost)
        {
            if (id != addConsumptionFormForGmtWashCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(addConsumptionFormForGmtWashCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddConsumptionFormForGmtWashCostExists(id))
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

        // POST: api/AddConsumptionFormForGmtWashCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostAddConsumptionFormForGmtWashCost(List<AddConsumptionFormForGmtWashCost> addConsumptionFormForGmtWashCostList)
        {
            int isSuccess = 0;
            foreach (var addConsumptionFormForGmtWashCostobj in addConsumptionFormForGmtWashCostList.ToList())
            {
                if (addConsumptionFormForGmtWashCostobj.Id > 0)
                {
                    _context.Entry(addConsumptionFormForGmtWashCostobj).State = EntityState.Modified;
                }
                else
                {

                    _context.AddConsumptionFormForGmtWashCosts.Add(addConsumptionFormForGmtWashCostobj);

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

        // DELETE: api/AddConsumptionFormForGmtWashCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddConsumptionFormForGmtWashCost>> DeleteAddConsumptionFormForGmtWashCost(int id)
        {
            var addConsumptionFormForGmtWashCost = await _context.AddConsumptionFormForGmtWashCosts.FindAsync(id);
            if (addConsumptionFormForGmtWashCost == null)
            {
                return NotFound();
            }

            _context.AddConsumptionFormForGmtWashCosts.Remove(addConsumptionFormForGmtWashCost);
            await _context.SaveChangesAsync();

            return addConsumptionFormForGmtWashCost;
        }

        private bool AddConsumptionFormForGmtWashCostExists(int id)
        {
            return _context.AddConsumptionFormForGmtWashCosts.Any(e => e.Id == id);
        }
    }
}
