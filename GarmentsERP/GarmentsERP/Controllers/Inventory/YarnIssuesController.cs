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
    public class YarnIssuesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnIssuesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnIssue>>> GetYarnIssue()
        {
            var result =
                await (from YarnIssueTbl in _context.YarnIssues
                       join compInf in _context.TblCompanyInfoes on YarnIssueTbl.CompanyId equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()

                       join Supliertbl in _context.SupplierProfiles on YarnIssueTbl.SupplierId equals Supliertbl.Id into Supliertbls
                       from Supliertbl in Supliertbls.DefaultIfEmpty()

                       join BuyerTbl in _context.BuyerProfiles on YarnIssueTbl.BuyerId equals BuyerTbl.Id into Buyertbls
                       from Buyertbl in Buyertbls.DefaultIfEmpty()

                       join locationTbl in _context.TblLocationInfoes on YarnIssueTbl.LocationId equals locationTbl.LocationId into locationTbls
                       from locationTbl in locationTbls.DefaultIfEmpty()

                       join SampleTbl in _context.SampleTypes on YarnIssueTbl.SampleId equals SampleTbl.Id into SampleTbls
                       from SampleTbl in SampleTbls.DefaultIfEmpty()

                       

                       orderby YarnIssueTbl.Id descending
                       select new YarnIssue
                       {
                             Id=YarnIssueTbl.Id,
         SystemID=YarnIssueTbl.SystemID,
         CompanyId=YarnIssueTbl.CompanyId,
         Basis=YarnIssueTbl.Basis,
         IssuePurpose=YarnIssueTbl.IssuePurpose,
         IssueDate=YarnIssueTbl.IssueDate,
         FabBookingNo=YarnIssueTbl.FabBookingNo,
         KnittingSource=YarnIssueTbl.KnittingSource,
         IssueTo=YarnIssueTbl.IssueTo,
         LocationId=YarnIssueTbl.LocationId,
         SupplierId=YarnIssueTbl.SupplierId,
         ChallanOrProgramNo=YarnIssueTbl.ChallanOrProgramNo,
         LoanParty=YarnIssueTbl.LoanParty,
         SampleId=YarnIssueTbl.SampleId,
         BuyerId=YarnIssueTbl.BuyerId,
         StyleReference=YarnIssueTbl.StyleReference,
         BuyerJobNo=YarnIssueTbl.BuyerJobNo,
         Remarks=YarnIssueTbl.Remarks,
         ReadytoApprove=YarnIssueTbl.ReadytoApprove,


         Status=YarnIssueTbl.Status,

         EntryDate=YarnIssueTbl.EntryDate,
         EntryBy=YarnIssueTbl.EntryBy,

         ApprovedDate=YarnIssueTbl.ApprovedDate,
         ApprovedBy=YarnIssueTbl.ApprovedBy,
         IsApproved=YarnIssueTbl.IsApproved,

         ModifyiedDate=YarnIssueTbl.ModifyiedDate,
         IsModifyied=YarnIssueTbl.IsModifyied,
         ModifyiedBy=YarnIssueTbl.ModifyiedBy,

                           CompanyName = compInf.Company_Name,

                           SupplierName = Supliertbl.SupplierName,

                           BuyerName = Buyertbl.ContactName,

                           LocationName = locationTbl.Location_Name,

                           SampleName = SampleTbl.SampleTypeName,



                       }).ToListAsync();
            return result;
        }

        // GET: api/YarnIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnIssue>> GetYarnIssue(int id)
        {
            var yarnIssue = await _context.YarnIssues.FindAsync(id);

            if (yarnIssue == null)
            {
                return NotFound();
            }

            return yarnIssue;
        }

        // PUT: api/YarnIssues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnIssue(int id, YarnIssue yarnIssue)
        {
            if (id != yarnIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(yarnIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnIssueExists(id))
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

        // POST: api/YarnIssues
        [HttpPost]
        public async Task<ActionResult<YarnIssue>> PostYarnIssue(YarnIssue yarnIssue)
        {


            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var systemID = "MKL" + "-YIS-" + lastTwoDigit + "000" + _context.YarnIssues.Count();
            yarnIssue.SystemID = systemID;
            _context.YarnIssues.Add(yarnIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYarnIssue", new { id = yarnIssue.Id }, yarnIssue);
        }

        // DELETE: api/YarnIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnIssue>> DeleteYarnIssue(int id)
        {
            var yarnIssue = await _context.YarnIssues.FindAsync(id);
            if (yarnIssue == null)
            {
                return NotFound();
            }

            _context.YarnIssues.Remove(yarnIssue);
            await _context.SaveChangesAsync();

            return yarnIssue;
        }

        private bool YarnIssueExists(int id)
        {
            return _context.YarnIssues.Any(e => e.Id == id);
        }
    }
}
