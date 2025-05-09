using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule.OfferingCost;

namespace GarmentsERP.Controllers.MarchandisingModule.OfferingCost
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingCostCostingSheetsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public OfferingCostCostingSheetsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/OfferingCostCostingSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingCostCostingSheet>>> GetOfferingCostCostingSheet()
        {

    //        var result =
    //          await (from costingSheet in _context.OfferingCostCostingSheets

    //                 join buyerInfo in _context.OfferingCostBuyerInformations on costingSheet.Id equals buyerInfo.Id into buyerInfos
    //                 from buyerInfo in buyerInfos.DefaultIfEmpty()


                    

    //                 orderby costingSheet.Id descending
    //                 select new OfferingCostCostingSheets
    //                 {

    //                    Id =costingSheet.Id,
    //                    OrderQty =costingSheet.OrderQty,
    //                    OrderQtyPrice =costingSheet.OrderQtyPrice,
    //                    ShipmentQty =costingSheet.ShipmentQty,
    //                    ShipmentQtyPrice =costingSheet.ShipmentQtyPrice,
    //                    ShortORExtra =costingSheet.ShortORExtra,
    //                    ShortORExtraPrice =costingSheet.ShortORExtraPrice,

    //                     EntryDate =costingSheet.EntryDate,
    //                     EntryBy =costingSheet.EntryBy,
    //                     ApprovedDate =costingSheet.ApprovedDate,
    //                     ApprovedBy =costingSheet.ApprovedBy,
    //                     IsApproved =costingSheet.IsApproved,
    //                     Status =costingSheet.Status
    //}).ToListAsync();

            return await _context.OfferingCostCostingSheets.ToListAsync();
        }

        // GET: api/OfferingCostCostingSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferingCostCostingSheet>> GetOfferingCostCostingSheet(int id)
        {
            var offeringCostCostingSheet = await _context.OfferingCostCostingSheets.FindAsync(id);

            if (offeringCostCostingSheet == null)
            {
                return NotFound();
            }

            return offeringCostCostingSheet;
        }

        // PUT: api/OfferingCostCostingSheets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferingCostCostingSheet(int id, OfferingCostCostingSheet offeringCostCostingSheet)
        {
            if (id != offeringCostCostingSheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(offeringCostCostingSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferingCostCostingSheetExists(id))
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

        // POST: api/OfferingCostCostingSheets
        [HttpPost]
        public async Task<ActionResult<OfferingCostCostingSheet>> PostOfferingCostCostingSheet(OfferingCostCostingSheet offeringCostCostingSheet)
        {
            _context.OfferingCostCostingSheets.Add(offeringCostCostingSheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferingCostCostingSheet", new { id = offeringCostCostingSheet.Id }, offeringCostCostingSheet);
        }

        // DELETE: api/OfferingCostCostingSheets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferingCostCostingSheet>> DeleteOfferingCostCostingSheet(int id)
        {
            var offeringCostCostingSheet = await _context.OfferingCostCostingSheets.FindAsync(id);
            if (offeringCostCostingSheet == null)
            {
                return NotFound();
            }

            _context.OfferingCostCostingSheets.Remove(offeringCostCostingSheet);
            await _context.SaveChangesAsync();

            return offeringCostCostingSheet;
        }

        private bool OfferingCostCostingSheetExists(int id)
        {
            return _context.OfferingCostCostingSheets.Any(e => e.Id == id);
        }
    }
}
