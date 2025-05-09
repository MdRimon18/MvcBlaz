using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class YarnReceivesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnReceivesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnReceives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnReceive>>> GetYarnReceive()
        {
            var result =
                await (from YarnReceiveTbl in _context.YarnReceives
                       join compInf in _context.TblCompanyInfoes on YarnReceiveTbl.CompanyId equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()

                       join Supliertbl in _context.SupplierProfiles on YarnReceiveTbl.SupplierId equals Supliertbl.Id into Supliertbls
                       from Supliertbl in Supliertbls.DefaultIfEmpty()

                       join Currencytbl in _context.DiscountMethods on YarnReceiveTbl.CurrencyId equals Currencytbl.Id into Currencytbls
                       from Currencytbl in Currencytbls.DefaultIfEmpty()




                       orderby YarnReceiveTbl.Id descending
                       select new YarnReceive
                       {
                         Id=YarnReceiveTbl.Id,
                         MrNumber=YarnReceiveTbl.MrNumber,
                         CompanyId=YarnReceiveTbl.CompanyId,
                         ReceiveBasis=YarnReceiveTbl.ReceiveBasis,
                         ReceivePurpose=YarnReceiveTbl.ReceivePurpose,
                         ReceiveDate=YarnReceiveTbl.ReceiveDate,
                         ChallanNo=YarnReceiveTbl.ChallanNo,
                         StoreName=YarnReceiveTbl.StoreName,
                         WoOrPI=YarnReceiveTbl.WoOrPI,
                         SupplierId=YarnReceiveTbl.SupplierId,
                         LoanParty=YarnReceiveTbl.LoanParty,

                         CurrencyId=YarnReceiveTbl.CurrencyId,
                         ExchangeRate=YarnReceiveTbl.ExchangeRate,
                         Source=YarnReceiveTbl.Source,
                         LcNo=YarnReceiveTbl.LcNo,
                         IssueChallanNo=YarnReceiveTbl.IssueChallanNo,
                         Remarks=YarnReceiveTbl.Remarks,


                         Status=YarnReceiveTbl.Status,

                         EntryDate=YarnReceiveTbl.EntryDate,
                         EntryBy=YarnReceiveTbl.EntryBy,

                         ApprovedDate=YarnReceiveTbl.ApprovedDate,
                         ApprovedBy=YarnReceiveTbl.ApprovedBy,
                         IsApproved=YarnReceiveTbl.IsApproved,

                         ModifyiedDate=YarnReceiveTbl.ModifyiedDate,
                         IsModifyied=YarnReceiveTbl.IsModifyied,
                         ModifyiedBy=YarnReceiveTbl.ModifyiedBy,

                          CompanyName = compInf.Company_Name,

                           SupplierName = Supliertbl.SupplierName,

                           CurrencyName = Currencytbl.DiscountMethodName,


                       }).ToListAsync();
            return result;
        }

        // GET: api/YarnReceives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnReceive>> GetYarnReceive(int id)
        {
            var yarnReceive = await _context.YarnReceives.FindAsync(id);

            if (yarnReceive == null)
            {
                return NotFound();
            }

            return yarnReceive;
        }

        // PUT: api/YarnReceives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnReceive(int id, YarnReceive yarnReceive)
        {
            if (id != yarnReceive.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnReceive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnReceiveExists(id))
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

        // POST: api/YarnReceives
        [HttpPost]
        public async Task<ActionResult<YarnReceive>> PostYarnReceive(YarnReceive yarnReceive)
        {


            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var MrNumber = "MKL" + "-YRV-" + lastTwoDigit + "000" + _context.YarnReceives.Count();
            yarnReceive.MrNumber = MrNumber;
            _context.YarnReceives.Add(yarnReceive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnReceive", new { id = yarnReceive.Id }, yarnReceive);
        }

        // DELETE: api/YarnReceives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnReceive>> DeleteYarnReceive(int id)
        {
            var yarnReceive = await _context.YarnReceives.FindAsync(id);
            if (yarnReceive == null)
            {
                return NotFound();
            }

            _context.YarnReceives.Remove(yarnReceive);
            await _context.SaveChangesAsync();

            return yarnReceive;
        }

        private bool YarnReceiveExists(int id)
        {
            return _context.YarnReceives.Any(e => e.Id == id);
        }
    }
}
