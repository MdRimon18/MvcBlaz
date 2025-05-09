using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrimCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public TrimCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/TrimCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimCost>>> GetTrimCost()
        {
            var trimCostList = _context.TrimCosts.ToList();
            foreach (var item in trimCostList)
            {
                item.IsTrimBookingComplete = _context.TrimsBookingItemDtlsChilds.Any(a => a.TrimCostId == item.Id);
            }
            return trimCostList;
        }

        // GET: api/TrimCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrimCost>>> GetTrimCost(int id)
        {
           var trimCostList= _context.TrimCosts.Where(w => w.PrecostingId == id).ToList();
            foreach (var item in trimCostList)
            {
                item.IsTrimBookingComplete = _context.TrimsBookingItemDtlsChilds.Any(a => a.TrimCostId == item.Id);
            }
            return trimCostList;
        }

        // PUT: api/TrimCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimCost(int id, TrimCost trimCost)
        {
            if (id != trimCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(trimCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimCostExists(id))
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

        // POST: api/TrimCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostTrimCost(List<TrimCost> trimCostList)
        {
            //_context.TrimCosts.Add(trimCost);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTrimCost", new { id = trimCost.Id }, trimCost);
            int isSuccess = 0;
            foreach (var trimCostObj in trimCostList.ToList())
            {
                if (trimCostObj.Id > 0)
                {
                  _context.Entry(trimCostObj).State = EntityState.Modified;    
                }
                else
                {

                    _context.TrimCosts.Add(trimCostObj);

                    await _context.SaveChangesAsync();
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

        // DELETE: api/TrimCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrimCost>> DeleteTrimCost(int id)
        {
            var trimCost = await _context.TrimCosts.FindAsync(id);
            if (trimCost == null)
            {
                return NotFound();
            }

            _context.TrimCosts.Remove(trimCost);
            await _context.SaveChangesAsync();

            return trimCost;
        }

        private bool TrimCostExists(int id)
        {
            return _context.TrimCosts.Any(e => e.Id == id);
        }
    }
}
