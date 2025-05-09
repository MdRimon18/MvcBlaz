using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;
using GarmentsERP.Model.MarchandisingModule.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarmentsERP.Controllers.MarchandisingModule.TableViews
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchandisingTableViewsController : ControllerBase
    {

        private readonly GarmentERPContext _context;

        public MerchandisingTableViewsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MerchandisingTableViews/JobOrOrderSelectionViews
        [HttpGet("JobOrOrderSelectionViews")]
        public IEnumerable<JobOrOrderNoSelectionForm> JobOrOrderSelectionViews()
        {
            //var itmDtlsOrdList=  _context.ItemDetailsOrderEntries;
            var result = from order in _context.TblInitialOrders

                         join po in _context.TblPodetailsInfroes
                         on order.OrderAutoID equals po.InitialOrderID

                         join locationTbl in _context.TblLocationInfoes on order.LocationID equals locationTbl.LocationId into locationTbls
                         from locationTbl in locationTbls.DefaultIfEmpty()

                         join preCst in _context.PreCostings on order.OrderAutoID equals preCst.OrderId into preCsts
                         from preCst in preCsts.DefaultIfEmpty()

                         select new JobOrOrderNoSelectionForm
                         {

                             OrderAutoId = order.OrderAutoID,
                             PoDetId = po.PoDetID,
                             JobNo = order.JobNo,
                             // Year 
                             // Company 
                             BuyerName = _context.BuyerProfiles.FirstOrDefault(w => w.Id == order.BuyerID).ContactName,
                             StyleRefNo = order.Style_Ref,
                             Style_Description = order.Style_Description,
                             BuyerId = order.BuyerID,
                             CurrencyId = order.CurrencyID,
                             OrderUomId = order.Order_Uom_ID,
                             CompanyId = order.CompanyID,
                             Smv = order.SMV,
                             SeasonId = order.Season_ID,
                             JobQty = _context.TblPodetailsInfroes.Where(w => w.InitialOrderID == order.OrderAutoID).Sum(s => s.PO_Quantity),
                             PoNumber = po.PO_No,
                             PoQuantity = po.PO_Quantity,
                             AvgPrice=po.Avg_Price,
                             ShipmentDate = po.Org_Shipment_Date,
                             // GmtsNature =
                             // itemDtlsId = itemDtls.item,
                             itemDtlsId = "0",
                             FileNo = po.File_No,
                             RegionID = order.RegionID,
                             CostingDate = po.PO_Received_Date,
                             //Leadtime 
                             LocationId = locationTbl.LocationId,
                             //  TeamLeaderName = _context.TblUserInfoes.FirstOrDefault(f => f.UserID == _context.UserMappings.FirstOrDefault(w => w.Id == order.Team_Leader_ID).UserId).UserID,

                             DealingMerchanId = order.Dealing_Merchant_ID,
                             isSelected = false,
                             JobQuantity= order.JobQuantity,
                              AvgUnitPrice= order.AvgUnitPrice,
                              TotalPrice = order.TotalPrice,
                              PrecostingId=preCst.PrecostingId





                         };

            return result.ToList();
        }


        // GET: api/MerchandisingTableViews
        [HttpGet("EmbellishmentWOV2Views")]
        public IEnumerable<EmbellishmentWOV2SelectionFrom> EmbellishmentWOV2Views()
        {

            var result = from ewo in _context.EmbellishmentWorkOrderV2
                         join ewod in _context.EmbellishmentWorkOrderV2Details
                         on ewo.Id equals ewod.EmbellishmentWorkOrderV2Id
                         into EmbellishmentGroup
                         from eg in EmbellishmentGroup.DefaultIfEmpty()
                         select new EmbellishmentWOV2SelectionFrom
                         {
                             Id = ewo.Id,
                             WoNo = ewo.WoNo,
                             JobNo = ewo.JobNo, 
                             BuyerName = _context.BuyerProfiles.FirstOrDefault(w => w.Id == ewo.BuyerProfileId).ContactName,
                             WODate = ewo.WODate,
                             DeliveryDate = ewo.DeliveryDate,
                             SupplierName = ewo.SupplierName,
                             ReadyToApprove = ewo.ReadyToApprove,
                             OrdNo = eg.OrdNo,
                             GarmentsItemName = _context.GarmentsItemEntries.FirstOrDefault(w => w.Id == eg.GarmentsItemId).ItemName,
                             BookingNature = eg.BookingNature,
                       


                         };

            return result.ToList();
        }

        [HttpGet("FabricCosBudgetViews/{id}")]
        public async Task<ActionResult<IEnumerable<FabricCost>>> GetFabricCost(int id)
        {
             var tblInitialOrder = _context.TblInitialOrders;
            var PODetailsInf = _context.TblPodetailsInfroes;
           
            var result =
                await (from fabCost in _context.FabricCosts.Where(w => w.AvgGreyCons > 0)

                       join preCost in _context.PreCostings on fabCost.PreCostingId equals preCost.PrecostingId into preCosts
                       from preCost in preCosts.DefaultIfEmpty()

                       join consumtion in _context.ConsumptionEntryForms.Where(w=>w.TotalQty>0) on fabCost.Id equals consumtion.FabricCostId into consumtions
                       from consumtion in consumtions.DefaultIfEmpty()
                           

                       join initOrder in _context.TblInitialOrders on preCost.OrderId equals initOrder.OrderAutoID into initOrders
                       from initOrder in initOrders.DefaultIfEmpty()

                       join item in _context.GarmentsItemEntries on fabCost.GmtsItemId equals item.Id into items
                       from item in items.DefaultIfEmpty()

                       join bodyPart in _context.BodyPartEntries on fabCost.BodyPartId equals bodyPart.Id into bodyParts
                       from bodyPart in bodyParts.DefaultIfEmpty()

                       join bodyPartType in _context.BodyPartTypes on fabCost.BodyPartTypeId equals bodyPartType.Id into bodyPartTypes
                       from bodyPartType in bodyPartTypes.DefaultIfEmpty()

                          

                       orderby consumtion.PoNoId
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
                           IsBookingComplete = fabCost.IsBookingComplete,

                           BuyerId = initOrder.BuyerID,
                           StyleRef = initOrder.Style_Ref,
                           JobNO = initOrder.JobNo,
                           PoNo =PODetailsInf.FirstOrDefault(f=>f.PoDetID==consumtion.PoNoId).PO_No,
                           PoNoId = consumtion.PoNoId,
                           GmtsItemName = item.ItemName,

                           BodyPartName = bodyPart.BodyPartFullName,

                           BodyPartTypeName = bodyPartType.BodyPartTypeName,
                           CnsmtnEntryTotalQty=consumtion.TotalQty,
                           CnsmtnEntryColor = consumtion.Color,
                           CnsmtnEntryDia = consumtion.Dia,
                           CnsmtnEntryProcess = consumtion.ProcessLoss,
                           //  FabricSourceName =fabCost.FabricSourceName
                       }).ToListAsync();
            
            var partialFabricBookingItemDtls = _context.PartialFabricBookingItemDtlsChilds.ToList();
            var PartialFabricBookinglst = _context.PartialFabricBookings.ToList();

            foreach (var item in result)
            {

                var obj = PartialFabricBookinglst.FirstOrDefault(f => f.Id == id);
               
                    var BookingItemDtlsLst=new  List<PartialFabricBookingItemDtlsChild>();
                    if (obj.TrimsDyingToMatch== "Job Level")
                {
                     BookingItemDtlsLst = partialFabricBookingItemDtls
                                       .Where(w => w.PreCostingId == item.PreCostingId &&
                                       w.FabricCostId == item.Id 
                                      
                                   ).ToList();
                }
                else
                {
                     BookingItemDtlsLst = partialFabricBookingItemDtls
                    .Where(w => w.PreCostingId == item.PreCostingId &&
                    w.FabricCostId == item.Id &&
                     w.PoNoId == item.PoNoId

                ).ToList();
                }

                


                if (BookingItemDtlsLst.Count() <= 0)
                {
                    item.IsBookingComplete = false;
                }
                

            }
            return result;
        }

        
          [HttpGet("EmblCostBudgetViews/{id}")]
        public async Task<ActionResult<IEnumerable<EmbellishmentCost>>> GetEmblCost(int id)
        {
            var tblInitialOrder = _context.TblInitialOrders;
            var PODetailsInf = _context.TblPodetailsInfroes;
            var itemDtls = _context.ItemDetailsOrderEntries;
            var result =
                await (from embellishmentCost in _context.EmbellishmentCosts.Where(w => w.Cons > 0)


                       join cnsmtinEmblCost in _context.AddConsumptionFormForEmblishmentCosts.Where(w => w.Cons > 0) on embellishmentCost.Id equals cnsmtinEmblCost.EmbelCostId into cnsmtinEmblCosts
                       from cnsmtinEmblCost in cnsmtinEmblCosts.DefaultIfEmpty()


                       join preCost in _context.PreCostings on embellishmentCost.PrecostingId equals preCost.PrecostingId into preCosts
                       from preCost in preCosts.DefaultIfEmpty()

                       join embellishmentType in _context.EmbellishmentTypes on embellishmentCost.EmbelTypeId equals embellishmentType.Id into embellishmentTypes
                       from embellishmentType in embellishmentTypes.DefaultIfEmpty()

                       join bodyPartEntry in _context.BodyPartEntries on embellishmentCost.BodyPartId equals bodyPartEntry.Id into bodyPartEntrys
                       from bodyPartEntry in bodyPartEntrys.DefaultIfEmpty()

                       join initOrder in _context.TblInitialOrders on preCost.OrderId equals initOrder.OrderAutoID into initOrders
                       from initOrder in initOrders.DefaultIfEmpty()

                       join buyerProfile in _context.BuyerProfiles on preCost.BuyerId equals buyerProfile.Id into buyerProfiles
                       from buyerProfile in buyerProfiles.DefaultIfEmpty()

                       //join PODetail in _context.TblPodetailsInfroes on initOrder.OrderAutoID equals PODetail.InitialOrderID into PODetails
                       //from PODetail in PODetails.DefaultIfEmpty()

                           //join fabricCost in _context.FabricCosts on embellishmentCost.PrecostingId equals fabricCost.PreCostingId into fabricCosts
                           //from fabricCost in fabricCosts.DefaultIfEmpty()

                       join Uom in _context.UOMs on initOrder.Order_Uom_ID equals Uom.Id into Uoms
                       from Uom in Uoms.DefaultIfEmpty()


                       select new EmbellishmentCost
                       {
                           Id = embellishmentCost.Id,
                           PrecostingId = embellishmentCost.PrecostingId,
                           EmbelName = embellishmentCost.EmbelName,
                           EmbelTypeId = embellishmentCost.EmbelTypeId,
                           BodyPartId = embellishmentCost.BodyPartId,
                           CountryId = embellishmentCost.CountryId,
                           SupplierId = embellishmentCost.SupplierId,
                           Cons = cnsmtinEmblCost.Cons,
                           Amount = embellishmentCost.Amount,
                           Status = embellishmentCost.Status,
                           IsEmbellishmentCostBooking = embellishmentCost.IsEmbellishmentCostBooking,

                           BuyerName = buyerProfile.ContactName,
                           JobName = initOrder.JobNo,
                           FileNo = preCost.Fileno,
                           InternalRef = preCost.internalRef,
                         
                           OrderNo = PODetailsInf.FirstOrDefault(f => f.PoDetID == cnsmtinEmblCost.PoId).PO_No,
                           //TrimsGroupName = itemGroup.ItemGroupName,
                           UomName = Uom.UomName,
                           GmtsItemName = itemDtls.FirstOrDefault(f => f.order_entry_id == initOrder.OrderAutoID).item,
                           EmbellTypeName = embellishmentType.TypeName,
                           BodyPartEntry = bodyPartEntry.BodyPartFullName,
                           OrderAutoId = initOrder.OrderAutoID,
                           embellishmentCostId = embellishmentCost.Id,
                           PoDeptId = cnsmtinEmblCost.PoId

                       }).ToListAsync();


            var WODetailsChild = _context.EmbellishmentWODetailsChilds.ToList();
            var MultipleJobWiseEmbelWorkOrderLst = _context.MultipleJobWiseEmbellishmentWorkOrders.ToList();

            foreach (var item in result)
            {

                var obj = MultipleJobWiseEmbelWorkOrderLst.FirstOrDefault(f => f.Id == id);

                var BookingItemDtlsLst = new List<EmbellishmentWODetailsChild>();
                if (obj.Level == "Job Level")
                {
                    BookingItemDtlsLst = WODetailsChild
                                      .Where(w => w.OrderAutoId == item.OrderAutoId &&
                                      w.EmbelCostId == item.embellishmentCostId

                                  ).ToList();
                }
                else
                {
                    BookingItemDtlsLst = WODetailsChild
                   .Where(w => w.OrderAutoId == item.OrderAutoId &&
                         w.EmbelCostId == item.embellishmentCostId&&
                    w.PoDeptId == item.PoDeptId

               ).ToList();
                }




                if (BookingItemDtlsLst.Count() <= 0)
                {
                    item.IsEmbellishmentCostBooking = false;
                }


            }
            return result;

        }
        [HttpGet("TrimsCostNTrimCostConsumptionBudgetViews/{id}")]
        public async Task<ActionResult<IEnumerable<TrimCost>>> GetTrimsCostNTrimCostConsumption(int id)
        {
            var tblInitialOrder = _context.TblInitialOrders;
            var PODetailsInf = _context.TblPodetailsInfroes;
            var result =
                await (from trimCost in _context.TrimCosts.Where(f => f.ConsUnitGmts > 0)

                       join consumptionEntryFormForTrimsCost in _context.ConsumptionEntryFormForTrimsCosts.Where(f=>f.Cons>0) on trimCost.Id equals consumptionEntryFormForTrimsCost.TrimCostId into consumptionEntryFormForTrimsCosts
                       from consumptionEntryFormForTrimsCost in consumptionEntryFormForTrimsCosts.DefaultIfEmpty()

                       join PODetailsInfro in _context.TblPodetailsInfroes on consumptionEntryFormForTrimsCost.PoNoId equals PODetailsInfro.PoDetID into PODetailsInfros
                       from PODetailsInfro in PODetailsInfros.DefaultIfEmpty()

                       join preCost in _context.PreCostings on trimCost.PrecostingId equals preCost.PrecostingId into preCosts
                       from preCost in preCosts.DefaultIfEmpty()


                        join initOrder in _context.TblInitialOrders on preCost.OrderId equals initOrder.OrderAutoID into initOrders
                        from initOrder in initOrders.DefaultIfEmpty()

                       join buyerProfile in _context.BuyerProfiles on preCost.BuyerId equals buyerProfile.Id into buyerProfiles
                       from buyerProfile in buyerProfiles.DefaultIfEmpty()

                      

                       join itemGroup in _context.ItemGroups on trimCost.GroupId equals itemGroup.Id into itemGroups
                       from itemGroup in itemGroups.DefaultIfEmpty()

                       join Uom in _context.UOMs on trimCost.ConsUOMId equals Uom.Id into Uoms
                       from Uom in Uoms.DefaultIfEmpty()
                       select new TrimCost
                       {
                           Id = trimCost.Id,
                           PrecostingId = trimCost.PrecostingId,
                           GroupId = trimCost.GroupId,
                           CountryId = trimCost.CountryId,
                           Description = trimCost.Description,
                           BrandSupRef = trimCost.BrandSupRef,
                           Remarks = trimCost.Remarks,
                           NominatedSuppId = trimCost.NominatedSuppId,
                           ConsUOMId = trimCost.ConsUOMId,
                           ConsUnitGmts = trimCost.ConsUnitGmts,
                           Rate = trimCost.Rate,
                           Amount = trimCost.Amount,
                           TotalQty = trimCost.TotalQty,
                           TotalAmount = trimCost.TotalAmount,
                           ApvlReq = trimCost.ApvlReq,
                           ImagePath = trimCost.ImagePath,
                           IsTrimBookingComplete = trimCost.IsTrimBookingComplete,
                          
                           ConsFromconsumption=consumptionEntryFormForTrimsCost.Cons,
                           Ex=consumptionEntryFormForTrimsCost.Ex,
                           RateFromconsumption=consumptionEntryFormForTrimsCost.Rate,
                           AmountFromconsumption=consumptionEntryFormForTrimsCost.Amount,
                           BuyerName = buyerProfile.ContactName,
                           JobName = initOrder.JobNo,
                           FileNo = preCost.Fileno,
                           InternalRef = preCost.internalRef,
                           OrderNo = PODetailsInf.FirstOrDefault(f => f.PoDetID == consumptionEntryFormForTrimsCost.PoNoId).PO_No,
                           TrimsGroupName = itemGroup.ItemGroupName,
                           UomName = Uom.UomName,
                           OrderAutoId = initOrder.OrderAutoID,
                           TrimCostId = trimCost.Id,
                           PoDeptId = consumptionEntryFormForTrimsCost.PoNoId



                       }).ToListAsync();

            var TrimsBookingItemDtlsLst = _context.TrimsBookingItemDtlsChilds.ToList();
            var MultipleJobWiseTrimsBookingV2lst = _context.MultipleJobWiseTrimsBookingV2.ToList();

            foreach (var item in result)
            {

                var mjwTrmsBknglstObj = MultipleJobWiseTrimsBookingV2lst.FirstOrDefault(f => f.Id == id);

                var BookingItemDtlsLst = new List<TrimsBookingItemDtlsChild>();
                if (mjwTrmsBknglstObj.Level == "Job Level")
                {
                    BookingItemDtlsLst = TrimsBookingItemDtlsLst
                                      .Where(w => w.OrderAutoId == item.OrderAutoId &&
                                      w.TrimCostId == item.TrimCostId

                                  ).ToList();
                }
                else
                {
                    BookingItemDtlsLst = TrimsBookingItemDtlsLst
                   .Where(w => w.OrderAutoId == item.OrderAutoId &&
                                      w.TrimCostId == item.TrimCostId &&
                    w.PoDeptId == item.PoDeptId

               ).ToList();
                }




                if (BookingItemDtlsLst.Count() <= 0)
                {
                    item.IsTrimBookingComplete = false;
                }


            }
            return result;
        }
        [HttpGet("TrimsCostNShortTrimCostConsumptionBudgetViews/{id}")]
        public async Task<ActionResult<IEnumerable<TrimCost>>> GetShortTrimsCostNTrimCostConsumption(int id)
        {
            var tblInitialOrder = _context.TblInitialOrders;
            var PODetailsInf = _context.TblPodetailsInfroes;
            var result =
                await (from trimCost in _context.TrimCosts.Where(f => f.ConsUnitGmts > 0)

                       join consumptionEntryFormForTrimsCost in _context.ConsumptionEntryFormForTrimsCosts.Where(f => f.Cons > 0) on trimCost.Id equals consumptionEntryFormForTrimsCost.TrimCostId into consumptionEntryFormForTrimsCosts
                       from consumptionEntryFormForTrimsCost in consumptionEntryFormForTrimsCosts.DefaultIfEmpty()

                       join PODetailsInfro in _context.TblPodetailsInfroes on consumptionEntryFormForTrimsCost.PoNoId equals PODetailsInfro.PoDetID into PODetailsInfros
                       from PODetailsInfro in PODetailsInfros.DefaultIfEmpty()

                       join preCost in _context.PreCostings on trimCost.PrecostingId equals preCost.PrecostingId into preCosts
                       from preCost in preCosts.DefaultIfEmpty()


                       join initOrder in _context.TblInitialOrders on preCost.OrderId equals initOrder.OrderAutoID into initOrders
                       from initOrder in initOrders.DefaultIfEmpty()

                       join buyerProfile in _context.BuyerProfiles on preCost.BuyerId equals buyerProfile.Id into buyerProfiles
                       from buyerProfile in buyerProfiles.DefaultIfEmpty()



                       join itemGroup in _context.ItemGroups on trimCost.GroupId equals itemGroup.Id into itemGroups
                       from itemGroup in itemGroups.DefaultIfEmpty()

                       join Uom in _context.UOMs on trimCost.ConsUOMId equals Uom.Id into Uoms
                       from Uom in Uoms.DefaultIfEmpty()
                       select new TrimCost
                       {
                           Id = trimCost.Id,
                           PrecostingId = trimCost.PrecostingId,
                           GroupId = trimCost.GroupId,
                           CountryId = trimCost.CountryId,
                           Description = trimCost.Description,
                           BrandSupRef = trimCost.BrandSupRef,
                           Remarks = trimCost.Remarks,
                           NominatedSuppId = trimCost.NominatedSuppId,
                           ConsUOMId = trimCost.ConsUOMId,
                           ConsUnitGmts = trimCost.ConsUnitGmts,
                           Rate = trimCost.Rate,
                           Amount = trimCost.Amount,
                           TotalQty = trimCost.TotalQty,
                           TotalAmount = trimCost.TotalAmount,
                           ApvlReq = trimCost.ApvlReq,
                           ImagePath = trimCost.ImagePath,
                           IsTrimBookingComplete = trimCost.IsTrimBookingComplete,
                           ConsFromconsumption = consumptionEntryFormForTrimsCost.Cons,
                           Ex = consumptionEntryFormForTrimsCost.Ex,
                           RateFromconsumption = consumptionEntryFormForTrimsCost.Rate,
                           AmountFromconsumption = consumptionEntryFormForTrimsCost.Amount,
                           BuyerName = buyerProfile.ContactName,
                           JobName = initOrder.JobNo,
                           FileNo = preCost.Fileno,
                           InternalRef = preCost.internalRef,
                           OrderNo = PODetailsInf.FirstOrDefault(f => f.PoDetID == consumptionEntryFormForTrimsCost.PoNoId).PO_No,
                           TrimsGroupName = itemGroup.ItemGroupName,
                           UomName = Uom.UomName,
                           OrderAutoId = initOrder.OrderAutoID,
                           TrimCostId = trimCost.Id,
                           PoDeptId = consumptionEntryFormForTrimsCost.PoNoId



                       }).ToListAsync();

            //var TrimsBookingItemDtlsLst = _context.ShortTrimsBookingItemDtlsChilds.ToList();
            //var MultipleJobWiseTrimsBookingV2lst = _context.MultipleJobWiseShortTrimsBookingV2.ToList();

            //foreach (var item in result)
            //{

            //    var mjwTrmsBknglstObj = MultipleJobWiseTrimsBookingV2lst.FirstOrDefault(f => f.Id == id);

            //    var BookingItemDtlsLst = new List<ShortTrimsBookingItemDtlsChilds>();
            //    if (mjwTrmsBknglstObj.Level == "Job Level")
            //    {
            //        BookingItemDtlsLst = TrimsBookingItemDtlsLst
            //                          .Where(w => w.OrderAutoId == item.OrderAutoId &&
            //                          w.TrimCostId == item.TrimCostId

            //                      ).ToList();
            //    }
            //    else
            //    {
            //        BookingItemDtlsLst = TrimsBookingItemDtlsLst
            //       .Where(w => w.OrderAutoId == item.OrderAutoId &&
            //                          w.TrimCostId == item.TrimCostId &&
            //        w.PoDeptId == item.PoDeptId

            //   ).ToList();
            //    }




            //    if (BookingItemDtlsLst.Count() <= 0)
            //    {
            //        item.IsTrimBookingComplete = false;
            //    }


            //}
            return result;
        }

        [HttpGet("PreCostingAndOrdersViews/{id}")]
        public async Task<ActionResult<PreCosting>> GetPreCosting(int id)
        {
            var prcstingObj = _context.PreCostings.FirstOrDefault(w => w.PrecostingId == id);
           var tblPODetailsInfrolst= _context.TblPodetailsInfroes.Where(w => w.InitialOrderID == prcstingObj.OrderId).ToList();
          
            var poNmes = "";
            foreach (var rp in tblPODetailsInfrolst)
            {
                poNmes  = poNmes + rp.PO_No + ",";

            }
            prcstingObj.PoNames = poNmes;

            return prcstingObj;
        }
        
        [HttpGet("GetItemDetailsByPOId/{poId}")]
        public List<GarmentsItemEntry> GetItemDetailsByPOId(int poId)
        {
            var sizeWiseBreadownListByPoId = _context.SizePannelPodetails
                                       .Where(w => w.PoId == poId).ToList();

            var GarmentsItemEntryList = _context.GarmentsItemEntries.ToList();

            List<GarmentsItemEntry> GarmentsItemEntrys = new List<GarmentsItemEntry>();

            var queryList = sizeWiseBreadownListByPoId.GroupBy(p => p.ItemId)
               .Select(g => new { itemId = g.Key });

            foreach (var item in queryList)
            {
              var itemObject= GarmentsItemEntryList.FirstOrDefault(f => f.Id== item.itemId);
                GarmentsItemEntrys.Add(itemObject);
            }
            return GarmentsItemEntrys;
        }
     
        
        [HttpGet("GetItemDetailsByOrderAutoId/{OrderAutoId}")]
        public List<GarmentsItemEntry> GetItemDetailsByOrderAutoId(int OrderAutoId)
        {
           
            var GarmentsItemEntryList = _context.GarmentsItemEntries.ToList();

            List<GarmentsItemEntry> GarmentsItemEntrys = new List<GarmentsItemEntry>();

            var queryList = _context.ItemDetailsOrderEntries
                .Where(w => w.order_entry_id == OrderAutoId).ToList();


            foreach (var item in queryList)
            {
                var itemObject = GarmentsItemEntryList.FirstOrDefault(f => f.Id ==Convert.ToInt32(item.item));
                GarmentsItemEntrys.Add(itemObject);
            }
            return GarmentsItemEntrys;
        }
        [HttpGet("ServiceBookingForAop")]
        public async Task<ActionResult<IEnumerable<FabricCost>>> GetServiceBooking()
        {
            
  
            var FabricSourceList = new List<FabricSource>() {
                new FabricSource { Id = 1, Value = "Buyer Supplied" } ,
                new FabricSource { Id = 2, Value = "Production" } ,
                new FabricSource { Id = 3, Value = "Purchase" } ,
               
            };

            var FabricCostList = _context.FabricCosts.Where(f=>f.ColorTypeId==38).ToList();
            var CompositionList = _context.Compositions.ToList();
            var PrecostingList = _context.PreCostings.ToList();
            var GarmentsItemEntryList = _context.GarmentsItemEntries.ToList();
            var BodyPartTypeList = _context.BodyPartTypes.ToList();
            var FabricNatureList = _context.FabricNatures.ToList();
            var BodyPartEntryList = _context.BodyPartEntries.ToList();
            var ColorTypeList = _context.ColorTypes.ToList();
            var ConsumptionEntryFormList=_context.ConsumptionEntryForms.ToList();
 
            
            foreach (var item in FabricCostList)
            {
                //var YarnCountDeterminationChildlist = _context.YarnCountDeterminationChilds;
                item.ConstructionName =_context.YarnCountDeterminations.FirstOrDefault(f => f.Id == item.FabricDesPreCostId)?.Construction;

                var orderId=  PrecostingList.FirstOrDefault(f => f.PrecostingId == item.PreCostingId).OrderId;

                item.JobNO =_context.TblInitialOrders.FirstOrDefault(f => f.OrderAutoID==orderId)?.JobNo;
               

                item.GmtsItemName = GarmentsItemEntryList.FirstOrDefault(f =>f.Id==item.GmtsItemId)?.ItemName;

                item.BodyPartTypeName = BodyPartTypeList.FirstOrDefault(f => f.Id == item.BodyPartTypeId)?.BodyPartTypeName;
                item.BodyPartName = BodyPartEntryList.FirstOrDefault(f => f.Id == item.BodyPartId)?.BodyPartFullName;

                item.FabricNatureName = FabricNatureList.FirstOrDefault(f => f.Id == item.FabNatureId)?.FabricNatureName;
                

                item.FabricSourceName = FabricSourceList.FirstOrDefault(f => f.Id == item.FabricSourceId)?.Value;

                item.ColorTypeName = ColorTypeList.FirstOrDefault(f => f.Id == item.ColorTypeId)?.ColorTypeName;
                item.Dia = ConsumptionEntryFormList.FirstOrDefault(f => f.FabricCostId == item.Id)?.Dia;

                var CompositionNamelist=_context.YarnCountDeterminationChilds.Where(f => f.YarnCountDeterminationMasterId==item.FabricDesPreCostId);

                var yarnCompositonNames="";

                foreach (var yCitem in CompositionNamelist)
                {
                    yarnCompositonNames= yarnCompositonNames +CompositionList
                        .FirstOrDefault(f => f.Id == yCitem.CompositionId)?.CompositionName + ",";

                }
                
                item.CompositionName = yarnCompositonNames;

            }
            return FabricCostList;
        }
    }
}
class FabricSource
{
    public int Id { get; set; }
    public  string Value { get; set; }
}