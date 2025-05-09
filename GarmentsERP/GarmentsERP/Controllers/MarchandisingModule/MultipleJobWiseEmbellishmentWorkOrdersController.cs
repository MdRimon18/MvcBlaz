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
    public class MultipleJobWiseEmbellishmentWorkOrdersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MultipleJobWiseEmbellishmentWorkOrdersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MultipleJobWiseEmbellishmentWorkOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultipleJobWiseEmbellishmentWorkOrder>>> GetMultipleJobWiseEmbellishmentWorkOrder()
        {
            var result =
                await (from MultipleJobWiseEmbelsTbl in _context.MultipleJobWiseEmbellishmentWorkOrders
                       join compInf in _context.TblCompanyInfoes on MultipleJobWiseEmbelsTbl.CompanyNameId equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()



                       join buyerPrfle in _context.BuyerProfiles on MultipleJobWiseEmbelsTbl.BuyerNameId equals buyerPrfle.Id into buyerPrfles
                       from buyerPrfle in buyerPrfles.DefaultIfEmpty()

                       join Supliertbl in _context.SupplierProfiles on MultipleJobWiseEmbelsTbl.SupplierNameId equals Supliertbl.Id into Supliertbls
                       from Supliertbl in Supliertbls.DefaultIfEmpty()

                       join Currencytbl in _context.DiscountMethods on MultipleJobWiseEmbelsTbl.CurrencyId equals Currencytbl.Id into Currencytbls
                       from Currencytbl in Currencytbls.DefaultIfEmpty()




                       orderby MultipleJobWiseEmbelsTbl.Id descending
                       select new MultipleJobWiseEmbellishmentWorkOrder
                       {
         Id=MultipleJobWiseEmbelsTbl.Id,
         WoNo=MultipleJobWiseEmbelsTbl.WoNo,
         CompanyNameId=MultipleJobWiseEmbelsTbl.CompanyNameId,
         BuyerNameId=MultipleJobWiseEmbelsTbl.BuyerNameId,
         WODate=MultipleJobWiseEmbelsTbl.WODate,
         DeliveryDate=MultipleJobWiseEmbelsTbl.DeliveryDate,
         CurrencyId=MultipleJobWiseEmbelsTbl.CurrencyId,
         Source=MultipleJobWiseEmbelsTbl.Source,
         PayMode=MultipleJobWiseEmbelsTbl.PayMode,
         SupplierNameId=MultipleJobWiseEmbelsTbl.SupplierNameId,
         ReadyToApprove=MultipleJobWiseEmbelsTbl.ReadyToApprove,
         Level=MultipleJobWiseEmbelsTbl.Level,
         Attention=MultipleJobWiseEmbelsTbl.Attention,
         Remarks=MultipleJobWiseEmbelsTbl.Remarks,

         EntryDate=MultipleJobWiseEmbelsTbl.EntryDate,
         EntryBy=MultipleJobWiseEmbelsTbl.EntryBy,
         ApprovedDate=MultipleJobWiseEmbelsTbl.ApprovedDate,
         ApprovedBy=MultipleJobWiseEmbelsTbl.ApprovedBy,
         Status=MultipleJobWiseEmbelsTbl.Status,

         CompanyName = compInf.Company_Name,

         BuyerName = buyerPrfle.ContactName,

         SupplierName = Supliertbl.SupplierName,

         CurrencyName = Currencytbl.DiscountMethodName,

                          
                       }).ToListAsync();
            return result;
        }

        // GET: api/MultipleJobWiseEmbellishmentWorkOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultipleJobWiseEmbellishmentWorkOrder>> GetMultipleJobWiseEmbellishmentWorkOrder(int id)
        {
            var multipleJobWiseEmbellishmentWorkOrder = await _context.MultipleJobWiseEmbellishmentWorkOrders.FindAsync(id);

            if (multipleJobWiseEmbellishmentWorkOrder == null)
            {
                return NotFound();
            }

            return multipleJobWiseEmbellishmentWorkOrder;
        }

        // PUT: api/MultipleJobWiseEmbellishmentWorkOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultipleJobWiseEmbellishmentWorkOrder(int id, MultipleJobWiseEmbellishmentWorkOrder multipleJobWiseEmbellishmentWorkOrder)
        {
            if (id != multipleJobWiseEmbellishmentWorkOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(multipleJobWiseEmbellishmentWorkOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultipleJobWiseEmbellishmentWorkOrderExists(id))
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

        // POST: api/MultipleJobWiseEmbellishmentWorkOrders
        [HttpPost]
        public async Task<ActionResult<MultipleJobWiseEmbellishmentWorkOrder>> PostMultipleJobWiseEmbellishmentWorkOrder(MultipleJobWiseEmbellishmentWorkOrder multipleJobWiseEmbellishmentWorkOrder)
        {


            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var WoNo = "MKL" + "-EB-" + lastTwoDigit + "-" + _context.MultipleJobWiseEmbellishmentWorkOrders.Count();
            multipleJobWiseEmbellishmentWorkOrder.WoNo = WoNo;

            _context.MultipleJobWiseEmbellishmentWorkOrders.Add(multipleJobWiseEmbellishmentWorkOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMultipleJobWiseEmbellishmentWorkOrder", new { id = multipleJobWiseEmbellishmentWorkOrder.Id }, multipleJobWiseEmbellishmentWorkOrder);
        }

        // DELETE: api/MultipleJobWiseEmbellishmentWorkOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MultipleJobWiseEmbellishmentWorkOrder>> DeleteMultipleJobWiseEmbellishmentWorkOrder(int id)
        {
            var multipleJobWiseEmbellishmentWorkOrder = await _context.MultipleJobWiseEmbellishmentWorkOrders.FindAsync(id);
            if (multipleJobWiseEmbellishmentWorkOrder == null)
            {
                return NotFound();
            }

            _context.MultipleJobWiseEmbellishmentWorkOrders.Remove(multipleJobWiseEmbellishmentWorkOrder);
            await _context.SaveChangesAsync();

            return multipleJobWiseEmbellishmentWorkOrder;
        }

        private bool MultipleJobWiseEmbellishmentWorkOrderExists(int id)
        {
            return _context.MultipleJobWiseEmbellishmentWorkOrders.Any(e => e.Id == id);
        }
    }
}
