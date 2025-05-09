using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Production;

namespace GarmentsERP.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentIssueEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmbellishmentIssueEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmbellishmentIssueEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmbellishmentIssueEntry>>> GetEmbellishmentIssueEntry()
        {
            var result = await (from emblEntry in _context.EmbellishmentIssueEntries

                                    //join order in _context.TblInitialOrders on emblEntry.OrderNo equals order.OrderAutoID into orders
                                    //from order in orders.DefaultIfEmpty()

                                join country in _context.TblRegionInfoes on emblEntry.CountryId equals country.RegionID into countrys
                                from country in countrys.DefaultIfEmpty()

                                join compInf in _context.TblCompanyInfoes on emblEntry.EmbelCompany equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on emblEntry.LocationId equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()

                                join sendingLocationTbl in _context.TblLocationInfoes on emblEntry.SendingLocationId equals sendingLocationTbl.LocationId into sendingLocationTbls
                                from sendingLocationTbl in sendingLocationTbls.DefaultIfEmpty()

                                join buyerPrfle in _context.BuyerProfiles on emblEntry.BuyerId equals buyerPrfle.Id into buyerPrfles
                                from buyerPrfle in buyerPrfles.DefaultIfEmpty()


                                join emblType in _context.EmbellishmentTypes on emblEntry.EmbelType equals emblType.Id into emblTypes
                                from emblType in emblTypes.DefaultIfEmpty()


                                orderby emblEntry.Id descending
                                select new EmbellishmentIssueEntry
                                {
                                     Id =emblEntry.Id,
                                 OrderNo =emblEntry.OrderNo,
                             CountryId =emblEntry.CountryId,
                             BuyerId =emblEntry.BuyerId,
                             Style =emblEntry.Style,
                             Item =emblEntry.Item,
                             OrderQnty =emblEntry.OrderQnty,
                             EmbelName =emblEntry.EmbelName,
                             EmbelType =emblEntry.EmbelType,
                             Source =emblEntry.Source,
                             EmbelCompany =emblEntry.EmbelCompany,
                             LocationId =emblEntry.LocationId,
                             FloorId =emblEntry.FloorId,
                             SendingLocationId =emblEntry.SendingLocationId,
                             IssueDate =emblEntry.IssueDate,
                             ColorTypeId =emblEntry.ColorTypeId,
                             IssueQty =emblEntry.IssueQty,
                             ChallanNo =emblEntry.ChallanNo,
                             IssueId =emblEntry.IssueId,
                             ManualCutNo =emblEntry.ManualCutNo,
                             Remarks =emblEntry.Remarks,


                             Status =emblEntry.Status,

                             EntryDate =emblEntry.EntryDate,
                             EntryBy =emblEntry.EntryBy,

                             ApprovedDate =emblEntry.ApprovedDate,
                             ApprovedBy =emblEntry.ApprovedBy,
                             IsApproved =emblEntry.IsApproved,

                             ModifyiedDate =emblEntry.ModifyiedDate,
                             IsModifyied =emblEntry.IsModifyied,
                             ModifyiedBy =emblEntry.ModifyiedBy,

                             CountryName = country.Region_Name,
       
                             BuyerName = buyerPrfle.ContactName,
       
                             EmbelTypeName = emblType.TypeName,
       
                             EmbelCompanyName =compInf.Company_Name,
       
                             LocationName =locationTbl.Location_Name,
       
                             SendingLocationName = sendingLocationTbl.Location_Name
    })
               .ToListAsync();
            return result;
        }

        // GET: api/EmbellishmentIssueEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmbellishmentIssueEntry>> GetEmbellishmentIssueEntry(int id)
        {
            var embellishmentIssueEntry = await _context.EmbellishmentIssueEntries.FindAsync(id);

            if (embellishmentIssueEntry == null)
            {
                return NotFound();
            }

            return embellishmentIssueEntry;
        }

        // PUT: api/EmbellishmentIssueEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbellishmentIssueEntry(int id, EmbellishmentIssueEntry embellishmentIssueEntry)
        {
            if (id != embellishmentIssueEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(embellishmentIssueEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmbellishmentIssueEntryExists(id))
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

        // POST: api/EmbellishmentIssueEntries
        [HttpPost]
        public async Task<ActionResult<EmbellishmentIssueEntry>> PostEmbellishmentIssueEntry(EmbellishmentIssueEntry embellishmentIssueEntry)
        {
            _context.EmbellishmentIssueEntries.Add(embellishmentIssueEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmbellishmentIssueEntry", new { id = embellishmentIssueEntry.Id }, embellishmentIssueEntry);
        }

        // DELETE: api/EmbellishmentIssueEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmbellishmentIssueEntry>> DeleteEmbellishmentIssueEntry(int id)
        {
            var embellishmentIssueEntry = await _context.EmbellishmentIssueEntries.FindAsync(id);
            if (embellishmentIssueEntry == null)
            {
                return NotFound();
            }

            _context.EmbellishmentIssueEntries.Remove(embellishmentIssueEntry);
            await _context.SaveChangesAsync();

            return embellishmentIssueEntry;
        }

        private bool EmbellishmentIssueEntryExists(int id)
        {
            return _context.EmbellishmentIssueEntries.Any(e => e.Id == id);
        }
    }
}
