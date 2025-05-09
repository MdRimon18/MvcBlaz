using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule.DatabaseViews
{


    public class tblInitialOrder_Views
    {
        private readonly GarmentERPContext _context;
        public tblInitialOrder_Views(GarmentERPContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<TblInitialOrder>>> GetTblInitialOrderViews()
        {
            var result =
                await (from ordertbl in _context.TblInitialOrders.Take(500)
                       join compInf in _context.TblCompanyInfoes on ordertbl.CompanyID equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()


                       join locationTbl in _context.TblLocationInfoes on ordertbl.LocationID equals locationTbl.LocationId into locationTbls
                       from locationTbl in locationTbls.DefaultIfEmpty()

                       join buyerPrfle in _context.BuyerProfiles on ordertbl.BuyerID equals buyerPrfle.Id into buyerPrfles
                       from buyerPrfle in buyerPrfles.DefaultIfEmpty()

                       join pdeptInfo in _context.TblProductionDeptInfoes on ordertbl.Prod_DeptID equals pdeptInfo.ID into pdeptInfos
                       from pdeptInfo in pdeptInfos.DefaultIfEmpty()

                       join pCtgry in _context.ProductCategories on ordertbl.Product_CatID equals pCtgry.Id into pCtgrys
                       from pCtgry in pCtgrys.DefaultIfEmpty()

                       join uom in _context.UOMs on ordertbl.Order_Uom_ID equals uom.Id into uoms
                       from uom in uoms.DefaultIfEmpty()


                       join packing in _context.TblPackingInfoes on ordertbl.Packing_ID equals packing.PackingID into packings
                       from packing in packings.DefaultIfEmpty()

                       orderby ordertbl.OrderAutoID descending
                       select new TblInitialOrder
                       {

                           OrderAutoID = ordertbl.OrderAutoID,
                           JobNo = ordertbl.JobNo,
                           CompanyID = ordertbl.CompanyID,
                           LocationID = ordertbl.LocationID,
                           BuyerID = ordertbl.BuyerID,
                           Style_Ref = ordertbl.Style_Ref,
                           Style_Description = ordertbl.Style_Description,
                           Prod_DeptID = ordertbl.Prod_DeptID,
                           Sub_DeptID = ordertbl.Sub_DeptID,
                           CurrencyID = ordertbl.CurrencyID,
                           RegionID = ordertbl.RegionID,
                           Product_CatID = ordertbl.Product_CatID,
                           Team_Leader_ID = ordertbl.Team_Leader_ID,
                           Dealing_Merchant_ID = ordertbl.Dealing_Merchant_ID,
                           BH_Merchant = ordertbl.BH_Merchant,
                           Remarks = ordertbl.Remarks,
                           Shipment_Mode_ID = ordertbl.Shipment_Mode_ID,
                           Order_Uom_ID = ordertbl.Order_Uom_ID,
                           SMV = ordertbl.SMV,
                           Packing_ID = ordertbl.Packing_ID,
                           Season_ID = ordertbl.Season_ID,
                           Agent_ID = ordertbl.Agent_ID,
                           UserID = ordertbl.UserID,
                           Repeat_No_Job = ordertbl.Repeat_No_Job,
                           Order_Number = ordertbl.Order_Number,
                           OrderImagePath = ordertbl.OrderImagePath,
                           factory_merchant = ordertbl.factory_merchant,

                           Status = ordertbl.Status,
                           EntryDate = ordertbl.EntryDate,
                           EntryBy = ordertbl.EntryBy,
                            

                           CompanyName = compInf.Company_Name,

                           LocationName = locationTbl.Location_Name,

                           BuyerName = buyerPrfle.ContactName,

                           ProdDeptName = pdeptInfo.ProdDeptName,

                           ProdCatName = pCtgry.ProductCategoryName,

                           TeamLeaderName = _context.TblUserInfoes.FirstOrDefault(f => f.UserID == _context.UserMappings.FirstOrDefault(w => w.Id == ordertbl.Team_Leader_ID).UserId).FullName,

                           DealingMerchandName = _context.TblUserInfoes.FirstOrDefault(f => f.UserID == _context.UserMappings.FirstOrDefault(w => w.Id == ordertbl.Dealing_Merchant_ID).UserId).FullName,

                           OrderUomName = uom.UomName,
                           PackingName = packing.Packing_Name
                       }).ToListAsync();
            return result;
        }

    }
}
