using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Commercial;

namespace GarmentsERP.Controllers.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class YarnPurchaseOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnPurchaseOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnPurchaseOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnPurchaseOrder>>> GetYarnPurchaseOrder()
        {
          
            var result=
             await (
             from yarnPurchaseOrderTbl in _context.YarnPurchaseOrders

             join currencyTbl in _context.DiscountMethods

             on yarnPurchaseOrderTbl.CurrencyId equals currencyTbl.Id

            into currencyTbls

             from currencyTbl in currencyTbls.DefaultIfEmpty()

             join companyTbl in _context.TblCompanyInfoes

                  on yarnPurchaseOrderTbl.PiissueTo equals companyTbl.CompID

                  into companyTbls

             from companyTbl in companyTbls.DefaultIfEmpty()

             join ItemCategoryTbl in _context.ItemCategories

            on yarnPurchaseOrderTbl.ItemCategoryId equals ItemCategoryTbl.Id

            into ItemCategoryTbls

             from ItemCategoryTbl in ItemCategoryTbls.DefaultIfEmpty()

             join SupplierProfileTbl in _context.SupplierProfiles

            on yarnPurchaseOrderTbl.SupplierProfileId equals SupplierProfileTbl.Id

            into SupplierProfileTbls

             from SupplierProfileTbl in SupplierProfileTbls.DefaultIfEmpty()

             orderby yarnPurchaseOrderTbl.Id descending
             select new YarnPurchaseOrder
             {
                 Id = yarnPurchaseOrderTbl.Id,
                 RequisitionId = yarnPurchaseOrderTbl.RequisitionId,
                 OrderAutoId = yarnPurchaseOrderTbl.OrderAutoId,
                 WoNumber = yarnPurchaseOrderTbl.WoNumber,
                 ItemCategoryId = yarnPurchaseOrderTbl.ItemCategoryId,
                 SupplierProfileId = yarnPurchaseOrderTbl.SupplierProfileId,
                 WoDate = yarnPurchaseOrderTbl.WoDate,
                 CurrencyId = yarnPurchaseOrderTbl.CurrencyId,
                 WoBasis = yarnPurchaseOrderTbl.WoBasis,
                 BuyerPO = yarnPurchaseOrderTbl.BuyerPO,
                 PayMode = yarnPurchaseOrderTbl.PayMode,
                 Source = yarnPurchaseOrderTbl.Source,
                 Requisition = yarnPurchaseOrderTbl.Requisition,
                 TargetDeliveryDate = yarnPurchaseOrderTbl.TargetDeliveryDate,
                 Attention = yarnPurchaseOrderTbl.Attention,
                 BuyerName = yarnPurchaseOrderTbl.BuyerName,
                 Style = yarnPurchaseOrderTbl.Style,
                 DoNo = yarnPurchaseOrderTbl.DoNo,
                 PayTerm = yarnPurchaseOrderTbl.PayTerm,
                 Tenor = yarnPurchaseOrderTbl.Tenor,
                 IncoTerm = yarnPurchaseOrderTbl.IncoTerm,
                 PiissueTo = yarnPurchaseOrderTbl.PiissueTo,
                 ReadytoApprove = yarnPurchaseOrderTbl.ReadytoApprove,
                 Remarks = yarnPurchaseOrderTbl.Remarks,
                 StatusId = yarnPurchaseOrderTbl.StatusId,

                 EntryDate = yarnPurchaseOrderTbl.EntryDate,
                 EntryBy = yarnPurchaseOrderTbl.EntryBy,
                 ModifyiedDate = yarnPurchaseOrderTbl.ModifyiedDate,
                 IsModifyied = yarnPurchaseOrderTbl.IsModifyied,
                 ModifyiedBy = yarnPurchaseOrderTbl.ModifyiedBy,
                 ApprovedDate = yarnPurchaseOrderTbl.ApprovedDate,
                 ApprovedBy = yarnPurchaseOrderTbl.ApprovedBy,
                 IsApproved = yarnPurchaseOrderTbl.IsApproved,


                 ItemCategoryName = ItemCategoryTbl.ItemCategoryName,

                 SupplierProfileName = SupplierProfileTbl.SupplierName,

                 CurrencyName = currencyTbl.DiscountMethodName,

                 PiissueToName = companyTbl.Company_Name,


             }).ToListAsync();
                 
            return result;
        }

        // GET: api/YarnPurchaseOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnPurchaseOrder>> GetYarnPurchaseOrder(int id)
        {
            var yarnPurchaseOrder = await _context.YarnPurchaseOrders.FindAsync(id);

            if (yarnPurchaseOrder == null)
            {
                return NotFound();
            }

            return yarnPurchaseOrder;
        }

        // PUT: api/YarnPurchaseOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnPurchaseOrder(int id, YarnPurchaseOrder yarnPurchaseOrder)
        {
            if (id != yarnPurchaseOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnPurchaseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnPurchaseOrderExists(id))
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

        // POST: api/YarnPurchaseOrders
        [HttpPost]
        public async Task<ActionResult<YarnPurchaseOrder>> PostYarnPurchaseOrder(YarnPurchaseOrder yarnPurchaseOrder)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var woNumber = "MKL" + "-YP-" + lastTwoDigit + "-" + _context.YarnPurchaseOrders.Count();
            yarnPurchaseOrder.WoNumber = woNumber;
            _context.YarnPurchaseOrders.Add(yarnPurchaseOrder);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetYarnPurchaseOrder", new { id = yarnPurchaseOrder.Id }, yarnPurchaseOrder);
        }

        // DELETE: api/YarnPurchaseOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnPurchaseOrder>> DeleteYarnPurchaseOrder(int id)
        {
            var yarnPurchaseOrder = await _context.YarnPurchaseOrders.FindAsync(id);
            if (yarnPurchaseOrder == null)
            {
                return NotFound();
            }

            _context.YarnPurchaseOrders.Remove(yarnPurchaseOrder);
            await _context.SaveChangesAsync();

            return yarnPurchaseOrder;
        }

        private bool YarnPurchaseOrderExists(int id)
        {
            return _context.YarnPurchaseOrders.Any(e => e.Id == id);
        }
    }
}
