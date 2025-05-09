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
    public class BuyerWiesSeasonsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public BuyerWiesSeasonsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/BuyerWiesSeasons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerWiesSeason>>> GetBuyerWiesSeason()
        {
            try
            {
                _context.BuyerWiesSeasons.ToList();
            }
            catch (Exception e)
            {

                throw;
            }
            return _context.BuyerWiesSeasons.ToList();
            //    var result =
            //        await (from BuyerWiesSeasonTbl in _context.BuyerWiesSeasons


            //               join buyerPrfle in _context.BuyerProfiles on BuyerWiesSeasonTbl.BuyerId equals buyerPrfle.Id into buyerPrfles
            //               from buyerPrfle in buyerPrfles.DefaultIfEmpty()



            //               orderby BuyerWiesSeasonTbl.Id descending
            //               select new BuyerWiesSeason
            //               {

            //                   Id=BuyerWiesSeasonTbl.Id,
            // BuyerId=BuyerWiesSeasonTbl.BuyerId,
            // SeasonName=BuyerWiesSeasonTbl.SeasonName,

            //BuyerName = buyerPrfle.ContactName,


            //               }).ToListAsync();
            //    return result;
        }

        // GET: api/BuyerWiesSeasons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerWiesSeason>> GetBuyerWiesSeason(int id)
        {
            var buyerWiesSeason = await _context.BuyerWiesSeasons.FindAsync(id);

            if (buyerWiesSeason == null)
            {
                return NotFound();
            }

            return buyerWiesSeason;
        }

        // PUT: api/BuyerWiesSeasons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyerWiesSeason(int id, BuyerWiesSeason buyerWiesSeason)
        {
            if (id != buyerWiesSeason.Id)
            {
                return BadRequest();
            }

            _context.Entry(buyerWiesSeason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerWiesSeasonExists(id))
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

        // POST: api/BuyerWiesSeasons
        [HttpPost]
        public async Task<ActionResult<BuyerWiesSeason>> PostBuyerWiesSeason(BuyerWiesSeason buyerWiesSeason)
        {
            try
            {
                _context.BuyerWiesSeasons.Add(buyerWiesSeason);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
           

            return CreatedAtAction("GetBuyerWiesSeason", new { id = buyerWiesSeason.Id }, buyerWiesSeason);
        }

        // DELETE: api/BuyerWiesSeasons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BuyerWiesSeason>> DeleteBuyerWiesSeason(int id)
        {
            var buyerWiesSeason = await _context.BuyerWiesSeasons.FindAsync(id);
            if (buyerWiesSeason == null)
            {
                return NotFound();
            }

            _context.BuyerWiesSeasons.Remove(buyerWiesSeason);
            await _context.SaveChangesAsync();

            return buyerWiesSeason;
        }

        private bool BuyerWiesSeasonExists(int id)
        {
            return _context.BuyerWiesSeasons.Any(e => e.Id == id);
        }
    }
}
