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
    public class AddConsumptionFormForEmblishmentCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public AddConsumptionFormForEmblishmentCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/AddConsumptionFormForEmblishmentCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddConsumptionFormForEmblishmentCost>>> GetAddConsumptionFormForEmblishmentCost()
        {
             
             
            return await _context.AddConsumptionFormForEmblishmentCosts.ToListAsync();
        }

        // GET: api/AddConsumptionFormForEmblishmentCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AddConsumptionFormForEmblishmentCost>>> GetAddConsumptionFormForEmblishmentCost(int id)
        {
            var addConsumptionFormForEmblishmentCost =_context.AddConsumptionFormForEmblishmentCosts.Where(f=>f.EmbelCostId==id).ToList();

            //if (addConsumptionFormForEmblishmentCost == null)
            //{
            //    return NotFound();
            //}

            return addConsumptionFormForEmblishmentCost;
        }

        // PUT: api/AddConsumptionFormForEmblishmentCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddConsumptionFormForEmblishmentCost(int id, AddConsumptionFormForEmblishmentCost addConsumptionFormForEmblishmentCost)
        {
            if (id != addConsumptionFormForEmblishmentCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(addConsumptionFormForEmblishmentCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddConsumptionFormForEmblishmentCostExists(id))
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

        // POST: api/AddConsumptionFormForEmblishmentCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostAddConsumptionFormForEmblishmentCost(List<AddConsumptionFormForEmblishmentCost> addConsumptionFormForEmblishmentCostList)
        {
            int isSuccess = 0;
            foreach (var addConsumptionFormForEmblishmentCostObj in addConsumptionFormForEmblishmentCostList.ToList())
            {
                if (addConsumptionFormForEmblishmentCostObj.Id > 0)
                {
                    _context.Entry(addConsumptionFormForEmblishmentCostObj).State = EntityState.Modified;
                }
                else
                {

                    _context.AddConsumptionFormForEmblishmentCosts.Add(addConsumptionFormForEmblishmentCostObj);

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

            //_context.AddConsumptionFormForEmblishmentCosts.Add(addConsumptionFormForEmblishmentCost);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAddConsumptionFormForEmblishmentCost", new { id = addConsumptionFormForEmblishmentCost.Id }, addConsumptionFormForEmblishmentCost);
        }

        // DELETE: api/AddConsumptionFormForEmblishmentCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddConsumptionFormForEmblishmentCost>> DeleteAddConsumptionFormForEmblishmentCost(int id)
        {
            var addConsumptionFormForEmblishmentCost = await _context.AddConsumptionFormForEmblishmentCosts.FindAsync(id);
            if (addConsumptionFormForEmblishmentCost == null)
            {
                return NotFound();
            }

            _context.AddConsumptionFormForEmblishmentCosts.Remove(addConsumptionFormForEmblishmentCost);
            await _context.SaveChangesAsync();

            return addConsumptionFormForEmblishmentCost;
        }

        private bool AddConsumptionFormForEmblishmentCostExists(int id)
        {
            return _context.AddConsumptionFormForEmblishmentCosts.Any(e => e.Id == id);
        }
    }
}
