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
    public class FabricCostsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public FabricCostsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/FabricCosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FabricCost>>> GetFabricCost()
        {
            var tblInitialOrder = _context.TblInitialOrders;
            var PODetailsInf = _context.TblPodetailsInfroes;
            var result =
                await (from fabCost in _context.FabricCosts

                      join preCost in _context.PreCostings on fabCost.PreCostingId equals preCost.PrecostingId into preCosts
                      from preCost in preCosts.DefaultIfEmpty()

                     
                     

                       join initOrder in _context.TblInitialOrders on preCost.OrderId equals initOrder.OrderAutoID into initOrders
                       from initOrder in initOrders.DefaultIfEmpty()


                     //join podetails in _context.TblPodetailsInfroes on initOrder.OrderAutoID equals podetails.InitialOrderID into podetailses
                     //from podetails in podetailses.DefaultIfEmpty()

                       join item in _context.GarmentsItemEntries on fabCost.GmtsItemId equals item.Id into items
                       from item in items.DefaultIfEmpty()

                       join bodyPart in _context.BodyPartEntries on fabCost.BodyPartId equals bodyPart.Id into bodyParts
                       from bodyPart in bodyParts.DefaultIfEmpty()

                       join bodyPartType in _context.BodyPartTypes on fabCost.BodyPartTypeId equals bodyPartType.Id into bodyPartTypes
                       from bodyPartType in bodyPartTypes.DefaultIfEmpty()

                           //join fabSrc in _con on fabCost.BodyPartTypeId equals bodyPartType.Id into bodyPartTypes
                           //from fabSrc in bodyPartTypes.DefaultIfEmpty()

                       orderby fabCost.Id
                       select new FabricCost
                       {
                           Id = fabCost.Id,

                           GmtsItemId = fabCost.GmtsItemId,
                           BodyPartId = fabCost.BodyPartId,
                           BodyPartTypeId = fabCost.BodyPartTypeId,
                           FabNatureId = fabCost.FabNatureId,
                           ColorTypeId = fabCost.ColorTypeId,
                           FabricDesPreCostId = fabCost.FabricDesPreCostId,
                           FabricSourceId = fabCost.FabricSourceId,
                           NominatedSuppId = fabCost.NominatedSuppId,
                           WidthDiaType = fabCost.WidthDiaType,
                           GsmWeight = fabCost.GsmWeight,

                           ColorSizeSensitive = fabCost.ColorSizeSensitive,
                           Color = fabCost.Color,
                           ConsumptionBasis = fabCost.ConsumptionBasis,
                           Uom = fabCost.Uom,
                           AvgGreyCons = fabCost.AvgGreyCons,
                           Rate = fabCost.Rate,
                           Amount = fabCost.Amount,
                           TotalQty = fabCost.TotalQty,
                           TotalAmount = fabCost.TotalAmount,

                           PreCostingId = fabCost.PreCostingId,
                           SuplierId = fabCost.SuplierId,
                           FabricDescription = fabCost.FabricDescription,
                           // IsBookingComplete = fabCost.IsBookingComplete,
                           IsBookingComplete =_context.PartialFabricBookingItemDtlsChilds.Any(a=>a.FabricCostId== fabCost.Id),
                           BuyerId = initOrder.BuyerID,
                           StyleRef = initOrder.Style_Ref,
                            JobNO = initOrder.JobNo,
                            //PoNo = podetails.PO_No,
                          // PoNoId = podetails.PoDetID,
                           GmtsItemName = item.ItemName,
                           BodyPartName = bodyPart.BodyPartFullName,
                           BodyPartTypeName = bodyPartType.BodyPartTypeName,
                          
                           //  FabricSourceName =fabCost.FabricSourceName
                       }).ToListAsync();
            return result;
        }

        // GET: api/FabricCosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FabricCost>>> GetFabricCost(int id)
        {
            var fabricCostsByPrecostingId= _context.FabricCosts.Where(w => w.PreCostingId == id).ToList();
            foreach (var item in fabricCostsByPrecostingId)
            {
                item.IsBookingComplete = _context.PartialFabricBookingItemDtlsChilds.Any(a => a.FabricCostId == item.Id);
            }
            return   fabricCostsByPrecostingId;
            //var fabricCost = await _context.FabricCosts.FindAsync(id);

            //if (fabricCost == null)
            //{
            //    return NotFound();
            //}

            //return fabricCost;
        }

        // PUT: api/FabricCosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricCost(int id, FabricCost fabricCost)
        {
            if (id != fabricCost.Id)
            {
                return BadRequest();
            }

            _context.Entry(fabricCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricCostExists(id))
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

        // POST: api/FabricCosts
        [HttpPost]
        public async Task<ActionResult<int>> PostFabricCost(List<FabricCost> fabricCostList)
        {

            int isSuccess = 0;
            foreach (var fabricCostObj in fabricCostList.ToList())
            {
                if (fabricCostObj.Id > 0)
                {
                    _context.Entry(fabricCostObj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {

                    _context.FabricCosts.Add(fabricCostObj);
                    await _context.SaveChangesAsync();
                }

            }
            try
            {
               // await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {

                throw;
            }
            return isSuccess;


            //try {
            //    _context.FabricCosts.Add(fabricCost);
            //    await _context.SaveChangesAsync();
            //}
            //catch(Exception e)
            //{

            //}


            //return CreatedAtAction("GetFabricCost", new { id = fabricCost.Id }, fabricCost);
        }

        // DELETE: api/FabricCosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FabricCost>> DeleteFabricCost(int id)
        {
            var fabricCost = await _context.FabricCosts.FindAsync(id);
            if (fabricCost == null)
            {
                return NotFound();
            }

            _context.FabricCosts.Remove(fabricCost);
            await _context.SaveChangesAsync();

            return fabricCost;
        }

        private bool FabricCostExists(int id)
        {
            return _context.FabricCosts.Any(e => e.Id == id);
        }
    }
}
