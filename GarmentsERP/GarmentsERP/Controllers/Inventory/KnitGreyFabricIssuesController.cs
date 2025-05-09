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
    public class KnitGreyFabricIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public KnitGreyFabricIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/KnitGreyFabricIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnitGreyFabricIssue>>> GetKnitGreyFabricIssue()
        {
            var result =
               await (from KnitGreyFabricIssueTbl in _context.KnitGreyFabricIssues
                      join compInf in _context.TblCompanyInfoes on KnitGreyFabricIssueTbl.CompanyId equals compInf.CompID into compInfs
                      from compInf in compInfs.DefaultIfEmpty()

                    

                      join BuyerTbl in _context.BuyerProfiles on KnitGreyFabricIssueTbl.BuyerId equals BuyerTbl.Id into Buyertbls
                      from Buyertbl in Buyertbls.DefaultIfEmpty()

                      

                      



                      orderby KnitGreyFabricIssueTbl.Id descending
                      select new KnitGreyFabricIssue
                      {


                           Id=KnitGreyFabricIssueTbl.Id,
         IssueNo=KnitGreyFabricIssueTbl.IssueNo,
         CompanyId=KnitGreyFabricIssueTbl.CompanyId,
         IssueDate=KnitGreyFabricIssueTbl.IssueDate,
         IssueBasis=KnitGreyFabricIssueTbl.IssueBasis,
         IssuePurpose=KnitGreyFabricIssueTbl.IssuePurpose,
         DyeingSource=KnitGreyFabricIssueTbl.DyeingSource,
         DyeingCompany=KnitGreyFabricIssueTbl.DyeingCompany,
         FabricBooking=KnitGreyFabricIssueTbl.FabricBooking,
         BatchNumber=KnitGreyFabricIssueTbl.BatchNumber,
         BuyerId=KnitGreyFabricIssueTbl.BuyerId,
         ChallanNo=KnitGreyFabricIssueTbl.ChallanNo,
         StyleReference=KnitGreyFabricIssueTbl.StyleReference,
         BatchColor=KnitGreyFabricIssueTbl.BatchColor,
         OrderNumbers=KnitGreyFabricIssueTbl.OrderNumbers,


         Status=KnitGreyFabricIssueTbl.Status,

         EntryDate=KnitGreyFabricIssueTbl.EntryDate,
         EntryBy=KnitGreyFabricIssueTbl.EntryBy,

         ApprovedDate=KnitGreyFabricIssueTbl.ApprovedDate,
         ApprovedBy=KnitGreyFabricIssueTbl.ApprovedBy,
         IsApproved=KnitGreyFabricIssueTbl.IsApproved,

         ModifyiedDate=KnitGreyFabricIssueTbl.ModifyiedDate,
         IsModifyied=KnitGreyFabricIssueTbl.IsModifyied,
         ModifyiedBy=KnitGreyFabricIssueTbl.ModifyiedBy,

        

                          CompanyName = compInf.Company_Name,

                        

                          BuyerName = Buyertbl.ContactName,

                          



                      }).ToListAsync();
            return result;
        }

        // GET: api/KnitGreyFabricIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KnitGreyFabricIssue>> GetKnitGreyFabricIssue(int id)
        {
            var knitGreyFabricIssue = await _context.KnitGreyFabricIssues.FindAsync(id);

            if (knitGreyFabricIssue == null)
            {
                return NotFound();
            }

            return knitGreyFabricIssue;
        }

        // PUT: api/KnitGreyFabricIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnitGreyFabricIssue(int id, KnitGreyFabricIssue knitGreyFabricIssue)
        {
            if (id != knitGreyFabricIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(knitGreyFabricIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnitGreyFabricIssueExists(id))
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

        // POST: api/KnitGreyFabricIssues
        [HttpPost]
        public async Task<ActionResult<KnitGreyFabricIssue>> PostKnitGreyFabricIssue(KnitGreyFabricIssue knitGreyFabricIssue)
        {

            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var issueNo = "MKL" + "-KGI-" + lastTwoDigit + "-000" + _context.KnitGreyFabricIssues.Count();
            knitGreyFabricIssue.IssueNo = issueNo;
           

           
            _context.KnitGreyFabricIssues.Add(knitGreyFabricIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnitGreyFabricIssue", new { id = knitGreyFabricIssue.Id }, knitGreyFabricIssue);
        }

        // DELETE: api/KnitGreyFabricIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KnitGreyFabricIssue>> DeleteKnitGreyFabricIssue(int id)
        {
            var knitGreyFabricIssue = await _context.KnitGreyFabricIssues.FindAsync(id);
            if (knitGreyFabricIssue == null)
            {
                return NotFound();
            }

            _context.KnitGreyFabricIssues.Remove(knitGreyFabricIssue);
            await _context.SaveChangesAsync();

            return knitGreyFabricIssue;
        }

        private bool KnitGreyFabricIssueExists(int id)
        {
            return _context.KnitGreyFabricIssues.Any(e => e.Id == id);
        }
    }
}
