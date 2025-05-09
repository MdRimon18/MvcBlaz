using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Drawing;
using Microsoft.AspNetCore.StaticFiles;
using GarmentsERP.Model.MarchandisingModule.DatabaseViews;
using GarmentsERP.Model.Shared;
 

namespace GarmentsERP.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TblInitialOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;
       // private readonly UserDbContext _db;
      //  private IHostingEnvironment _host;
        private string RootPath;
        private string OutputPath;
        private string filePath="";
        private List<string> FileList;

        public TblInitialOrdersController(GarmentERPContext context)
        {
          //  _db = dbContext;
            _context = context;
         //   _host = host;
         //   RootPath = _host.ContentRootPath;
           // OutputPath = Path.Combine(RootPath, "wwwroot/content");
           // FileList = new List<string>();
        }

       // GET: api/TblInitialOrders
       [HttpGet]
        public async Task<ActionResult<IEnumerable<TblInitialOrder>>> GetTblInitialOrder()
        {
            
            tblInitialOrder_Views tblInitialOrder_Views = new tblInitialOrder_Views(_context);
            var result = await tblInitialOrder_Views.GetTblInitialOrderViews();

            return result;
        }


        // GET: api/TblInitialOrders
        [HttpGet("orderListWhereHavePo")]
        public async Task<ActionResult<IEnumerable<TblInitialOrder>>> OrderListWhereHavePo()
        {
            

            tblInitialOrder_Views tblInitialOrder_Views = new tblInitialOrder_Views(_context);
            var result = await tblInitialOrder_Views.GetTblInitialOrderViews();

            return result;
        }

        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<TblInitialOrder>>> SearchTblInitialOrder(Search search)
        {
            var pageLoad = (search.pageIndex + 1) * search.pageSize;

            var result = await (from ordertbl in _context.TblInitialOrders
                                .Skip((search.pageIndex + 1) * search.pageSize)
                                 .Take(pageLoad + 20)
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
                                })
                .ToListAsync();


            return result;
        }

        // GET: api/TblInitialOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblInitialOrder>> GetTblInitialOrder(int id)
        {
            var tblInitialOrder = await _context.TblInitialOrders.FindAsync(id);

            if (tblInitialOrder == null)
            {
                return NotFound();
            }

            return tblInitialOrder;

   
        }

        // GET: api/TblInitialOrders
        

        // PUT: api/TblInitialOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblInitialOrder(int id, TblInitialOrder tblInitialOrder)
        {

            if (id != tblInitialOrder.OrderAutoID)
            {
                return BadRequest();
            }
         
            _context.Entry(tblInitialOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblInitialOrderExists(id))
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
        
        
        
      

        // POST: api/TblInitialOrders
        [HttpPost]
        public async Task<ActionResult<TblInitialOrder>> PostTblInitialOrder(TblInitialOrder tblInitialOrder)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                  if (tblInitialOrder.JobNo == "")
                {
                    var a = DateTime.Now.Year;
                    double year = Convert.ToDouble(a) % 100;
                    tblInitialOrder.JobNo = "MKL-" + Convert.ToString(year) + "-" + _context.TblInitialOrders.Count();
                }

                _context.TblInitialOrders.Add(tblInitialOrder);
               await _context.SaveChangesAsync();

            }
            catch(Exception e)
            {

            }
            // here we want to make a formation of the order like MKL-18-1

            return CreatedAtAction("GetTblInitialOrder", new { id = tblInitialOrder.OrderAutoID }, tblInitialOrder);


        }

       

        // DELETE: api/TblInitialOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblInitialOrder>> DeleteTblInitialOrder(int id)
        {
            var tblInitialOrder = await _context.TblInitialOrders.FindAsync(id);
            if (tblInitialOrder == null)
            {
                return NotFound();
            }

            _context.TblInitialOrders.Remove(tblInitialOrder);
            await _context.SaveChangesAsync();

            return tblInitialOrder;
        }

        private bool TblInitialOrderExists(int id)
        {
            return _context.TblInitialOrders.Any(e => e.OrderAutoID == id);
        }
    }
}
