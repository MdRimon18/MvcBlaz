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
    public class PrintIssueEntrypagesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PrintIssueEntrypagesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PrintIssueEntrypages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrintIssueEntrypage>>> GetPrintIssueEntrypage()
        {
            var result = await (from printIss in _context.PrintIssueEntrypages

                                    //join order in _context.TblInitialOrders on printIss.OrderNo equals order.OrderAutoID into orders
                                    //from order in orders.DefaultIfEmpty()

                                join country in _context.TblRegionInfoes on printIss.CountryId equals country.RegionID into countrys
                                from country in countrys.DefaultIfEmpty()

                                join compInf in _context.TblCompanyInfoes on printIss.EmbelCompanyId equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on printIss.LocationId equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()


                                join buyerPrfle in _context.BuyerProfiles on printIss.BuyerId equals buyerPrfle.Id into buyerPrfles
                                from buyerPrfle in buyerPrfles.DefaultIfEmpty()
                                orderby printIss.Id descending
                                select new PrintIssueEntrypage
                                {
                                    Id = printIss.Id,
                                      OrderNo =printIss.OrderNo,
                                     CountryId =printIss.CountryId,
                                     BuyerId =printIss.BuyerId,
                                     Style =printIss.Style,
                                     ItemId =printIss.ItemId,
                                     OrderQnty =printIss.OrderQnty,
                                     EmbelName =printIss.EmbelName,
                                     EmbelTypeId =printIss.EmbelTypeId,
                                     Source =printIss.Source,
                                     EmbelCompanyId =printIss.EmbelCompanyId,
                                     LocationId =printIss.LocationId,
                                     FloorId =printIss.FloorId,
                                     IssueDate =printIss.IssueDate,
                                     IssueQty =printIss.IssueQty,
                                     ChallanNo =printIss.ChallanNo,
                                     IssueId =printIss.IssueId,

                                    Remarks = printIss.Remarks,


                                    Status = printIss.Status,

                                    EntryDate = printIss.EntryDate,
                                    EntryBy = printIss.EntryBy,

                                    ApprovedDate = printIss.ApprovedDate,
                                    ApprovedBy = printIss.ApprovedBy,
                                    IsApproved = printIss.IsApproved,

                                    ModifyiedDate = printIss.ModifyiedDate,
                                    IsModifyied = printIss.IsModifyied,
                                    ModifyiedBy = printIss.ModifyiedBy,


                                    CountryName = country.Region_Name,

                                    EmbelCompanyName = compInf.Company_Name,


                                    BuyerName = buyerPrfle.ContactName,


                                    LocationName = locationTbl.Location_Name,
                                })
                    .ToListAsync();
            return result; ;
        }

        // GET: api/PrintIssueEntrypages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrintIssueEntrypage>> GetPrintIssueEntrypage(int id)
        {
            var printIssueEntrypage = await _context.PrintIssueEntrypages.FindAsync(id);

            if (printIssueEntrypage == null)
            {
                return NotFound();
            }

            return printIssueEntrypage;
        }

        // PUT: api/PrintIssueEntrypages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrintIssueEntrypage(int id, PrintIssueEntrypage printIssueEntrypage)
        {
            if (id != printIssueEntrypage.Id)
            {
                return BadRequest();
            }

            _context.Entry(printIssueEntrypage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrintIssueEntrypageExists(id))
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

        // POST: api/PrintIssueEntrypages
        [HttpPost]
        public async Task<ActionResult<PrintIssueEntrypage>> PostPrintIssueEntrypage(PrintIssueEntrypage printIssueEntrypage)
        {
            _context.PrintIssueEntrypages.Add(printIssueEntrypage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrintIssueEntrypage", new { id = printIssueEntrypage.Id }, printIssueEntrypage);
        }

        // DELETE: api/PrintIssueEntrypages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrintIssueEntrypage>> DeletePrintIssueEntrypage(int id)
        {
            var printIssueEntrypage = await _context.PrintIssueEntrypages.FindAsync(id);
            if (printIssueEntrypage == null)
            {
                return NotFound();
            }

            _context.PrintIssueEntrypages.Remove(printIssueEntrypage);
            await _context.SaveChangesAsync();

            return printIssueEntrypage;
        }

        private bool PrintIssueEntrypageExists(int id)
        {
            return _context.PrintIssueEntrypages.Any(e => e.Id == id);
        }
    }
}
