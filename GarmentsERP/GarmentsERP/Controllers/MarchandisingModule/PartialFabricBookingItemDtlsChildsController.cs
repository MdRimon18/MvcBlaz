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
    public class PartialFabricBookingItemDtlsChildsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PartialFabricBookingItemDtlsChildsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PartialFabricBookingItemDtlsChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartialFabricBookingItemDtlsChild>>> GetPartialFabricBookingItemDtlsChild()
        {
            var tblInitialOrder = _context.TblInitialOrders;
            var PODetailsInf = _context.TblPodetailsInfroes;
            var result =
                await (from pfbDtls in _context.PartialFabricBookingItemDtlsChilds

                       join preCost in _context.PreCostings on pfbDtls.PreCostingId equals preCost.PrecostingId into preCosts
                       from preCost in preCosts.DefaultIfEmpty()

                       join initOrder in _context.TblInitialOrders on preCost.OrderId equals initOrder.OrderAutoID into initOrders
                       from initOrder in initOrders.DefaultIfEmpty()

                      

                       join bodyPart in _context.BodyPartEntries on pfbDtls.BodyPartId equals bodyPart.Id into bodyParts
                       from bodyPart in bodyParts.DefaultIfEmpty()

                 
                       orderby pfbDtls.PoNoId
                       select new PartialFabricBookingItemDtlsChild
                       {
                            Id =pfbDtls.Id,
                         PreCostingId =pfbDtls.PreCostingId,
                         PoNoId =pfbDtls.PoNoId,
                           RefNo = pfbDtls.RefNo,
                           PartialFabricBookingMasterId =pfbDtls.PartialFabricBookingMasterId,
                         FabricCostId =pfbDtls.FabricCostId,
                         BodyPartId =pfbDtls.BodyPartId,
                         ColorTypeId =pfbDtls.ColorTypeId,
                           WidthDiaType =pfbDtls.WidthDiaType,
                         FabricDesPreCostId =pfbDtls.FabricDesPreCostId,
                         FabricDescription =pfbDtls.FabricDescription,
                         GsmWeight =pfbDtls.GsmWeight,
                         GmtsColor =pfbDtls.GmtsColor,
                         ItemColor =pfbDtls.ItemColor,
                         CnsmtnEntryDia =pfbDtls.CnsmtnEntryDia,
                         CnsmtnEntryProcess =pfbDtls.CnsmtnEntryProcess,
                         BalanceQty =pfbDtls.BalanceQty,
                         WoQnty =pfbDtls.WoQnty,
                         AdjQnty =pfbDtls.AdjQnty,
                         AcWoQnty =pfbDtls.AcWoQnty,
                         Uom =pfbDtls.Uom,
                         Rate =pfbDtls.Rate,
                         Amount =pfbDtls.Amount,
                         Remark =pfbDtls.Remark,

                         Status =pfbDtls.Status,
                    
                           StyleRef = initOrder.Style_Ref,
                           JobNO = initOrder.JobNo,
                           PoNo = PODetailsInf.FirstOrDefault(f => f.PoDetID == pfbDtls.PoNoId).PO_No,

                           BodyPartName = bodyPart.BodyPartFullName

                        
                       }).ToListAsync();

            return result;
        }
        
      
        // GET: api/PartialFabricBookingItemDtlsChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PartialFabricBookingItemDtlsChild>>> GetPartialFabricBookingItemDtlsChild(int id)
        {
             
            var tblInitialOrder = _context.TblInitialOrders;
            var PODetailsInf = _context.TblPodetailsInfroes;
            var result =
                await (from pfbDtls in _context.PartialFabricBookingItemDtlsChilds.Where(w => w.PartialFabricBookingMasterId== id)

                       join preCost in _context.PreCostings on pfbDtls.PreCostingId equals preCost.PrecostingId into preCosts
                       from preCost in preCosts.DefaultIfEmpty()

                       join initOrder in _context.TblInitialOrders on preCost.OrderId equals initOrder.OrderAutoID into initOrders
                       from initOrder in initOrders.DefaultIfEmpty()



                       join bodyPart in _context.BodyPartEntries on pfbDtls.BodyPartId equals bodyPart.Id into bodyParts
                       from bodyPart in bodyParts.DefaultIfEmpty()

                       join cnsmptn in _context.ConsumptionEntryForms on pfbDtls.fabCnsId equals cnsmptn.Id into cnsmptns
                       from cnsmptn in cnsmptns.DefaultIfEmpty()

                       orderby initOrder.JobNo, pfbDtls.RefNo,
                       pfbDtls.BodyPartId, pfbDtls.ColorTypeId,
                       pfbDtls.WidthDiaType,pfbDtls.GmtsColor,
                       pfbDtls.ItemColor

                       select new PartialFabricBookingItemDtlsChild
                       {
                           Id = pfbDtls.Id,
                           PreCostingId = pfbDtls.PreCostingId,
                           PoNoId = pfbDtls.PoNoId,
                           RefNo=pfbDtls.RefNo,
                           PartialFabricBookingMasterId = pfbDtls.PartialFabricBookingMasterId,
                           FabricCostId = pfbDtls.FabricCostId,
                           BodyPartId = pfbDtls.BodyPartId,
                           ColorTypeId = pfbDtls.ColorTypeId,
                           WidthDiaType = pfbDtls.WidthDiaType,
                           FabricDesPreCostId = pfbDtls.FabricDesPreCostId,
                           FabricDescription = pfbDtls.FabricDescription,
                           GsmWeight = pfbDtls.GsmWeight,
                           GmtsColor = pfbDtls.GmtsColor,
                           ItemColor = pfbDtls.ItemColor,
                           CnsmtnEntryDia = pfbDtls.CnsmtnEntryDia,
                           CnsmtnEntryProcess = pfbDtls.CnsmtnEntryProcess,
                           BalanceQty = pfbDtls.BalanceQty,
                           WoQnty = pfbDtls.WoQnty,
                           AdjQnty = pfbDtls.AdjQnty,
                           AcWoQnty = pfbDtls.AcWoQnty,
                           Uom = pfbDtls.Uom,
                           Rate = pfbDtls.Rate,
                           Amount = pfbDtls.Amount,
                           Remark = pfbDtls.Remark,
                          fabCnsPoNoId = pfbDtls.fabCnsPoNoId,
                           fabCnsColor = pfbDtls.fabCnsColor,
                           fabCnsGmtsSizes = pfbDtls.fabCnsGmtsSizes,
                           fabCnsItemSizes = pfbDtls.fabCnsItemSizes,
                           fabCnsDia = pfbDtls.fabCnsDia,
                           fabCnsGreyCons = pfbDtls.fabCnsGreyCons,
                           fabCnsFinishCons = pfbDtls.fabCnsFinishCons,
                           fabCnsTotalQty = pfbDtls.fabCnsTotalQty,
                           fabCnsRate = pfbDtls.fabCnsRate,
                           fabCnsAmount = pfbDtls.fabCnsAmount,
                           fabCnsTotalAmount = pfbDtls.fabCnsTotalAmount,
                           fabCnsId = pfbDtls.fabCnsId,
                           sizeQnty= cnsmptn.SizeQuantity,


                           Status = pfbDtls.Status,

                           StyleRef = initOrder.Style_Ref,
                           JobNO = initOrder.JobNo,
                           PoNo = PODetailsInf.FirstOrDefault(f => f.PoDetID == pfbDtls.fabCnsPoNoId).PO_No,

                           BodyPartName = bodyPart.BodyPartFullName,
                           IsSelected = false


                       }).ToListAsync();
            return   result;
        }

        // PUT: api/PartialFabricBookingItemDtlsChilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartialFabricBookingItemDtlsChild(int id, PartialFabricBookingItemDtlsChild partialFabricBookingItemDtlsChild)
        {
            if (id != partialFabricBookingItemDtlsChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(partialFabricBookingItemDtlsChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartialFabricBookingItemDtlsChildExists(id))
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

        // POST: api/PartialFabricBookingItemDtlsChilds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<int>> PostPartialFabricBookingItemDtlsChild(List<PartialFabricBookingItemDtlsChild> partialFabricBookingItemDtlsChildList)
        {
            var fabricCosts = _context.FabricCosts.ToList();
            int isSuccess = 0;
            
            

            foreach (var fabObj in partialFabricBookingItemDtlsChildList.ToList())
            {


                if (fabObj.Id > 0)
                {
                    _context.Entry(fabObj).State = EntityState.Modified;

                }
                else
                {
                    _context.PartialFabricBookingItemDtlsChilds.Add(fabObj);

                   
                }

            }
            try
            {
               

                //var FabricCostIds = partialFabricBookingItemDtlsChildList.GroupBy(u => u.FabricCostId)
                //                   .Select(grp => new { FabricId = grp.Key })
                //                   .ToList();
                //foreach (var item in FabricCostIds)
                //{
                //    var FabricCostObj = fabricCosts.FirstOrDefault(f => f.Id == item.FabricId);
                //    if (FabricCostObj != null)
                //    {
                //        FabricCostObj.IsBookingComplete = true;
                //        _context.Entry(FabricCostObj).State = EntityState.Modified;
                //    }

                //}

                await _context.SaveChangesAsync();
                isSuccess++;

            }
            catch
            {
                throw new Exception();
            }


            return isSuccess;
        }

        // DELETE: api/PartialFabricBookingItemDtlsChilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PartialFabricBookingItemDtlsChild>> DeletePartialFabricBookingItemDtlsChild(int id)
        {
        
            PartialFabricBookingItemDtlsChild partialFabricBookingItemDtlsChild = _context.PartialFabricBookingItemDtlsChilds.FirstOrDefault(f => f.Id == id);
            if (partialFabricBookingItemDtlsChild == null)
            {
                return NotFound();
            }

            _context.PartialFabricBookingItemDtlsChilds.Remove(partialFabricBookingItemDtlsChild);
            await _context.SaveChangesAsync();

            return partialFabricBookingItemDtlsChild;
        }

        private bool PartialFabricBookingItemDtlsChildExists(int id)
        {
            return _context.PartialFabricBookingItemDtlsChilds.Any(e => e.Id == id);
        }
    }
}
