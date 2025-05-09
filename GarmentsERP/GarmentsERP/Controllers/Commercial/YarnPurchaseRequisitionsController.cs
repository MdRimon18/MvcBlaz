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
    public class YarnPurchaseRequisitionsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnPurchaseRequisitionsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnPurchaseRequisitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnPurchaseRequisition>>> GetYarnPurchaseRequisition()
        {
            var result =
                 await (from YarnPurchaseRequisitiontbl in _context.YarnPurchaseRequisitions

                        join ItemCategorytbl in _context.ItemCategories on YarnPurchaseRequisitiontbl.ItemCategoryId equals ItemCategorytbl.Id into ItemCategorytbls
                        from ItemCategorytbl in ItemCategorytbls.DefaultIfEmpty()

                        join DiscountMethodTbl in _context.DiscountMethods on YarnPurchaseRequisitiontbl.CurrencyId equals DiscountMethodTbl.Id into DiscountMethodTbls
                        from DiscountMethodTbl in DiscountMethodTbls.DefaultIfEmpty()


                        


                       

                        orderby YarnPurchaseRequisitiontbl.Id descending
                        select new YarnPurchaseRequisition
                        {

                             Id=YarnPurchaseRequisitiontbl.Id,
        RequisitionNo=YarnPurchaseRequisitiontbl.RequisitionNo,
        ItemCategoryId=YarnPurchaseRequisitiontbl.ItemCategoryId,
        RequiredDate=YarnPurchaseRequisitiontbl.RequiredDate,
        PayMode=YarnPurchaseRequisitiontbl.PayMode,
        RequisitionDate=YarnPurchaseRequisitiontbl.RequisitionDate,
        CurrencyId=YarnPurchaseRequisitiontbl.CurrencyId,
        Source=YarnPurchaseRequisitiontbl.Source,
        DoNo=YarnPurchaseRequisitiontbl.DoNo,
        Attention=YarnPurchaseRequisitiontbl.Attention,
        DealingMerchant=YarnPurchaseRequisitiontbl.DealingMerchant,
        PiBasis=YarnPurchaseRequisitiontbl.PiBasis,
        ReadytoApprove=YarnPurchaseRequisitiontbl.ReadytoApprove,
        Remarks=YarnPurchaseRequisitiontbl.Remarks,

        EntryDate=YarnPurchaseRequisitiontbl.EntryDate,
        EntryBy=YarnPurchaseRequisitiontbl.EntryBy,
        ApprovedDate=YarnPurchaseRequisitiontbl.ApprovedDate,
        ApprovedBy=YarnPurchaseRequisitiontbl.ApprovedBy,
         IsApproved=YarnPurchaseRequisitiontbl.IsApproved,
        Status=YarnPurchaseRequisitiontbl.Status,


        ItemCategoryName=ItemCategorytbl.ItemCategoryName,

 
        CurrencyName=DiscountMethodTbl.DiscountMethodName,
    }).ToListAsync();
            return result;
           
        }

        // GET: api/YarnPurchaseRequisitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnPurchaseRequisition>> GetYarnPurchaseRequisition(int id)
        {
            var yarnPurchaseRequisition = await _context.YarnPurchaseRequisitions.FindAsync(id);

            if (yarnPurchaseRequisition == null)
            {
                return NotFound();
            }

            return yarnPurchaseRequisition;
        }

        // PUT: api/YarnPurchaseRequisitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnPurchaseRequisition(int id, YarnPurchaseRequisition yarnPurchaseRequisition)
        {
            if (id != yarnPurchaseRequisition.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnPurchaseRequisition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnPurchaseRequisitionExists(id))
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

        // POST: api/YarnPurchaseRequisitions
        [HttpPost]
        public async Task<ActionResult<YarnPurchaseRequisition>> PostYarnPurchaseRequisition(YarnPurchaseRequisition yarnPurchaseRequisition)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var requisitionNo = "MKL-" + "RQSN-"+ lastTwoDigit + "-000" + _context.YarnPurchaseRequisitions.Count();
            yarnPurchaseRequisition.RequisitionNo = requisitionNo;
            _context.YarnPurchaseRequisitions.Add(yarnPurchaseRequisition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnPurchaseRequisition", new { id = yarnPurchaseRequisition.Id }, yarnPurchaseRequisition);
        }

        // DELETE: api/YarnPurchaseRequisitions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnPurchaseRequisition>> DeleteYarnPurchaseRequisition(int id)
        {
            var yarnPurchaseRequisition = await _context.YarnPurchaseRequisitions.FindAsync(id);
            if (yarnPurchaseRequisition == null)
            {
                return NotFound();
            }

            _context.YarnPurchaseRequisitions.Remove(yarnPurchaseRequisition);
            await _context.SaveChangesAsync();

            return yarnPurchaseRequisition;
        }

        private bool YarnPurchaseRequisitionExists(int id)
        {
            return _context.YarnPurchaseRequisitions.Any(e => e.Id == id);
        }
    }
}
