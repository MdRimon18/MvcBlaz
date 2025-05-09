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
    public class CuttingEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CuttingEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CuttingEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuttingEntry>>> GetCuttingEntry()
        {
            var result = await (from cuttingEntry in _context.CuttingEntries

                                join order in _context.TblPodetailsInfroes on cuttingEntry.OrderNo equals order.PoDetID into orders
                                from order in orders.DefaultIfEmpty()


                                join item in _context.ItemDetailsOrderEntries on cuttingEntry.ItemId equals item.id into items
                                from item in items.DefaultIfEmpty()

                                join compInf in _context.TblCompanyInfoes on cuttingEntry.CuttCompany equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on cuttingEntry.Location equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()

                                join buyerPrfle in _context.BuyerProfiles on cuttingEntry.BuyerId equals buyerPrfle.Id into buyerPrfles
                                from buyerPrfle in buyerPrfles.DefaultIfEmpty()

                                join country in _context.TblRegionInfoes on cuttingEntry.CountryId equals country.RegionID into countrys
                                from country in countrys.DefaultIfEmpty()


                                orderby cuttingEntry.Id descending
                                
                                select new CuttingEntry
                                {
                                    Id = cuttingEntry.Id,
                                    OrderNo = cuttingEntry.OrderNo,

                                    Style = cuttingEntry.Style,
                                    ItemId = cuttingEntry.ItemId,
                                    OrderQnty = cuttingEntry.OrderQnty,
                                    PlanCutQnty = cuttingEntry.PlanCutQnty,
                                    Source = cuttingEntry.Source,
                                    CuttCompany = cuttingEntry.CuttCompany,
                                    Location = cuttingEntry.Location,
                                    Floor = cuttingEntry.Floor,
                                    WorkOrder = cuttingEntry.WorkOrder,
                                    ProducedBy = cuttingEntry.ProducedBy,
                                    ColorType = cuttingEntry.ColorType,
                                    CuttingQuantity = cuttingEntry.CuttingQuantity,
                                    RejectQnty = cuttingEntry.RejectQnty,
                                    ReportingHour = cuttingEntry.ReportingHour,
                                    ChallanNo = cuttingEntry.ChallanNo,
                                    Remarks = cuttingEntry.Remarks,
                                    CountryId = cuttingEntry.CountryId,
                                    BuyerId = cuttingEntry.BuyerId,

                                    Status = cuttingEntry.Status,

                                    EntryDate = cuttingEntry.EntryDate,


                                    OrderName = order.PO_No,
                                    ItemName = item.item,
                                    CuttCompanyName = compInf.Company_Name,
                                    LocationName = locationTbl.Location_Name,
                                    BuyerName = buyerPrfle.ContactName,
                                    CountryName = country.Region_Name,

                                })
               .ToListAsync();

            return result;
        }

        // GET: api/CuttingEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuttingEntry>> GetCuttingEntry(int id)
        {
            var cuttingEntry = await _context.CuttingEntries.FindAsync(id);

            if (cuttingEntry == null)
            {
                return NotFound();
            }

            return cuttingEntry;
        }
        //public  int? ToNullableInt(string s)
        //{
        //    int i;
        //    if (int.TryParse(s, out i)) return i;
        //    return 0;
        //}
        // PUT: api/CuttingEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuttingEntry(int id, CuttingEntry cuttingEntry)
        {
            if (id != cuttingEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuttingEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuttingEntryExists(id))
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

        // POST: api/CuttingEntries
        [HttpPost]
        public async Task<ActionResult<CuttingEntry>> PostCuttingEntry(CuttingEntry cuttingEntry)
        {
            _context.CuttingEntries.Add(cuttingEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuttingEntry", new { id = cuttingEntry.Id }, cuttingEntry);
        }

        // DELETE: api/CuttingEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CuttingEntry>> DeleteCuttingEntry(int id)
        {
            var cuttingEntry = await _context.CuttingEntries.FindAsync(id);
            if (cuttingEntry == null)
            {
                return NotFound();
            }

            _context.CuttingEntries.Remove(cuttingEntry);
            await _context.SaveChangesAsync();

            return cuttingEntry;
        }

        private bool CuttingEntryExists(int id)
        {
            return _context.CuttingEntries.Any(e => e.Id == id);
        }
    }
}
