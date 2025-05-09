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
    public class EmbellishmentCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmbellishmentCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmbellishmentCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmbellishmentCost>>> GetEmbellishmentCost()
        {
            var embelListByPrecostingId = _context.EmbellishmentCosts.ToList();
            foreach (var item in embelListByPrecostingId)
            {
                item.IsEmbellishmentCostBooking = _context.EmbellishmentWODetailsChilds.Any(a => a.EmbelCostId == item.Id);
            }

            return embelListByPrecostingId;
        }

        // GET: api/EmbellishmentCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EmbellishmentCost>>> GetEmbellishmentCost(int id)
        {
            var embelListByPrecostingId= _context.EmbellishmentCosts.Where(w => w.PrecostingId == id).ToList();
            foreach (var item in embelListByPrecostingId)
            {
                item.IsEmbellishmentCostBooking = _context.EmbellishmentWODetailsChilds.Any(a => a.EmbelCostId == item.Id);
            }

            return embelListByPrecostingId;
            //var embellishmentCost = await _context.EmbellishmentCosts.FindAsync(id);

            //if (embellishmentCost == null)
            //{
            //    return NotFound();
            //}

            //return embellishmentCost;
        }

        // PUT: api/EmbellishmentCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbellishmentCost(int id, EmbellishmentCost embellishmentCost)
        {
            if (id != embellishmentCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(embellishmentCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmbellishmentCostExists(id))
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

        // POST: api/EmbellishmentCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostEmbellishmentCost(List<EmbellishmentCost> embellishmentCostList)
        {
            int isSuccess = 0;
            foreach (var embellishmentCostObj in embellishmentCostList.ToList())
            {
                if (embellishmentCostObj.Id > 0)
                {
                    _context.Entry(embellishmentCostObj).State = EntityState.Modified;
                }
                else
                {

                    _context.EmbellishmentCosts.Add(embellishmentCostObj);
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
            //_context.EmbellishmentCosts.Add(embellishmentCost);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetEmbellishmentCost", new { id = embellishmentCost.Id }, embellishmentCost);
        }

        // DELETE: api/EmbellishmentCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmbellishmentCost>> DeleteEmbellishmentCost(int id)
        {
            var embellishmentCost = await _context.EmbellishmentCosts.FindAsync(id);
            if (embellishmentCost == null)
            {
                return NotFound();
            }

            _context.EmbellishmentCosts.Remove(embellishmentCost);
            await _context.SaveChangesAsync();

            return embellishmentCost;
        }

        private bool EmbellishmentCostExists(int id)
        {
            return _context.EmbellishmentCosts.Any(e => e.Id == id);
        }
    }
}
