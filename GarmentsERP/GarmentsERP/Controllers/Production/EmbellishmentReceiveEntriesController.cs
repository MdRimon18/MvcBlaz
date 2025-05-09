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
    public class EmbellishmentReceiveEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public EmbellishmentReceiveEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/EmbellishmentReceiveEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmbellishmentReceiveEntry>>> GetEmbellishmentReceiveEntry()
        {
            var result = await (from emblEntry in _context.EmbellishmentReceiveEntries

                                    //join order in _context.TblInitialOrders on emblEntry.OrderNo equals order.OrderAutoID into orders
                                    //from order in orders.DefaultIfEmpty()

                                join country in _context.TblRegionInfoes on emblEntry.CountryId equals country.RegionID into countrys
                                from country in countrys.DefaultIfEmpty()

                                join compInf in _context.TblCompanyInfoes on emblEntry.EmbelCompanyId equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on emblEntry.LocationId equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()

                                join RecievingLocationTbl in _context.TblLocationInfoes on emblEntry.ReceivingLocationId equals RecievingLocationTbl.LocationId into RecievingLocationTbls
                                from RecievingLocationTbl in RecievingLocationTbls.DefaultIfEmpty()

                                join buyerPrfle in _context.BuyerProfiles on emblEntry.BuyerId equals buyerPrfle.Id into buyerPrfles
                                from buyerPrfle in buyerPrfles.DefaultIfEmpty()


                                join emblType in _context.EmbellishmentTypes on emblEntry.EmbelTypeId equals emblType.Id into emblTypes
                                from emblType in emblTypes.DefaultIfEmpty()


                                orderby emblEntry.Id descending
                                select new EmbellishmentReceiveEntry
                                {
                                    Id = emblEntry.Id,
                                    OrderNo = emblEntry.OrderNo,
                                 CountryId = emblEntry.CountryId,
                                 BuyerId = emblEntry.BuyerId,
                                Style = emblEntry.Style,
                                 ItemId = emblEntry.ItemId,
                                 OrderQnty = emblEntry.OrderQnty,
                                EmbelName = emblEntry.EmbelName,
                                 EmbelTypeId = emblEntry.EmbelTypeId,
                                Source = emblEntry.Source,
                                 EmbelCompanyId = emblEntry.EmbelCompanyId,
                                 LocationId = emblEntry.LocationId,
                                 FloorId = emblEntry.FloorId,
                                WorkOrder = emblEntry.WorkOrder,
                                 ReceivingLocationId = emblEntry.ReceivingLocationId,
                                ReceiveDate = emblEntry.ReceiveDate,
                                 ColorTypeId = emblEntry.ColorTypeId,
                                 ReceiveQnty = emblEntry.ReceiveQnty,
                                RejectQnty = emblEntry.RejectQnty,
                                ChallanNo = emblEntry.ChallanNo,
                                SysChln = emblEntry.SysChln,
                                Remarks = emblEntry.Remarks,


                                Status = emblEntry.Status,

                                    EntryDate = emblEntry.EntryDate,
                                    EntryBy = emblEntry.EntryBy,

                                    ApprovedDate = emblEntry.ApprovedDate,
                                    ApprovedBy = emblEntry.ApprovedBy,
                                    IsApproved = emblEntry.IsApproved,

                                    ModifyiedDate = emblEntry.ModifyiedDate,
                                    IsModifyied = emblEntry.IsModifyied,
                                    ModifyiedBy = emblEntry.ModifyiedBy,

                                    CountryName = country.Region_Name,

                                    BuyerName = buyerPrfle.ContactName,

                                    EmbelTypeName = emblType.TypeName,

                                    EmbelCompanyName = compInf.Company_Name,

                                    LocationName = locationTbl.Location_Name,

                                    RecievingLocationName = RecievingLocationTbl.Location_Name
                                })
                  .ToListAsync();
            return result;
        }

        // GET: api/EmbellishmentReceiveEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmbellishmentReceiveEntry>> GetEmbellishmentReceiveEntry(int id)
        {
            var embellishmentReceiveEntry = await _context.EmbellishmentReceiveEntries.FindAsync(id);

            if (embellishmentReceiveEntry == null)
            {
                return NotFound();
            }

            return embellishmentReceiveEntry;
        }

        // PUT: api/EmbellishmentReceiveEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbellishmentReceiveEntry(int id, EmbellishmentReceiveEntry embellishmentReceiveEntry)
        {
            if (id != embellishmentReceiveEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(embellishmentReceiveEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmbellishmentReceiveEntryExists(id))
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

        // POST: api/EmbellishmentReceiveEntries
        [HttpPost]
        public async Task<ActionResult<EmbellishmentReceiveEntry>> PostEmbellishmentReceiveEntry(EmbellishmentReceiveEntry embellishmentReceiveEntry)
        {
            _context.EmbellishmentReceiveEntries.Add(embellishmentReceiveEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmbellishmentReceiveEntry", new { id = embellishmentReceiveEntry.Id }, embellishmentReceiveEntry);
        }

        // DELETE: api/EmbellishmentReceiveEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmbellishmentReceiveEntry>> DeleteEmbellishmentReceiveEntry(int id)
        {
            var embellishmentReceiveEntry = await _context.EmbellishmentReceiveEntries.FindAsync(id);
            if (embellishmentReceiveEntry == null)
            {
                return NotFound();
            }

            _context.EmbellishmentReceiveEntries.Remove(embellishmentReceiveEntry);
            await _context.SaveChangesAsync();

            return embellishmentReceiveEntry;
        }

        private bool EmbellishmentReceiveEntryExists(int id)
        {
            return _context.EmbellishmentReceiveEntries.Any(e => e.Id == id);
        }
    }
}
