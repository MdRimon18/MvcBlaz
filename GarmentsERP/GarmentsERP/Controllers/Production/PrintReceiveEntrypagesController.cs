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
    public class PrintReceiveEntrypagesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PrintReceiveEntrypagesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PrintReceiveEntrypages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrintReceiveEntrypage>>> GetPrintReceiveEntrypage()
        {
            var result = await (from printRcv in _context.PrintReceiveEntrypages

                                    //join order in _context.TblInitialOrders on printRcv.OrderNo equals order.OrderAutoID into orders
                                    //from order in orders.DefaultIfEmpty()

                                join country in _context.TblRegionInfoes on printRcv.CountryId equals country.RegionID into countrys
                                from country in countrys.DefaultIfEmpty()

                                join compInf in _context.TblCompanyInfoes on printRcv.EmbelCompanyId equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on printRcv.LocationId equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()


                                join buyerPrfle in _context.BuyerProfiles on printRcv.BuyerId equals buyerPrfle.Id into buyerPrfles
                                from buyerPrfle in buyerPrfles.DefaultIfEmpty()
                                orderby printRcv.Id descending
                                select new PrintReceiveEntrypage
                                {
                                    Id = printRcv.Id,
                                    OrderNo = printRcv.OrderNo,
                                    CountryId = printRcv.CountryId,
                                    BuyerId = printRcv.BuyerId,
                                    Style = printRcv.Style,
                                    ItemId = printRcv.ItemId,
                                     OrderQnty = printRcv.OrderQnty,
                                    EmbelName = printRcv.EmbelName,
                                    EmbelTypeId = printRcv.EmbelTypeId,
                                    Source = printRcv.Source,
                                    EmbelCompanyId = printRcv.EmbelCompanyId,
                                    LocationId = printRcv.LocationId,
                                    FloorId = printRcv.FloorId,
                                    ReceiveDate = printRcv.ReceiveDate,
                                    ReceiveQnty = printRcv.ReceiveQnty,
                                    RejectQnty = printRcv.RejectQnty,
                                    ChallanNo = printRcv.ChallanNo,
                                    Remarks = printRcv.Remarks,


                                    Status = printRcv.Status,

                                    EntryDate = printRcv.EntryDate,
                                    EntryBy = printRcv.EntryBy,

                                    ApprovedDate = printRcv.ApprovedDate,
                                    ApprovedBy = printRcv.ApprovedBy,
                                    IsApproved = printRcv.IsApproved,

                                    ModifyiedDate = printRcv.ModifyiedDate,
                                    IsModifyied = printRcv.IsModifyied,
                                    ModifyiedBy = printRcv.ModifyiedBy,


                                    CountryName = country.Region_Name,

                                    EmbelCompanyName = compInf.Company_Name,


                                    BuyerName = buyerPrfle.ContactName,


                                    LocationName = locationTbl.Location_Name,
                                })
                    .ToListAsync();
            return result; ;
        }

        // GET: api/PrintReceiveEntrypages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrintReceiveEntrypage>> GetPrintReceiveEntrypage(int id)
        {
            var printReceiveEntrypage = await _context.PrintReceiveEntrypages.FindAsync(id);

            if (printReceiveEntrypage == null)
            {
                return NotFound();
            }

            return printReceiveEntrypage;
        }

        // PUT: api/PrintReceiveEntrypages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrintReceiveEntrypage(int id, PrintReceiveEntrypage printReceiveEntrypage)
        {
            if (id != printReceiveEntrypage.Id)
            {
                return BadRequest();
            }

            _context.Entry(printReceiveEntrypage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrintReceiveEntrypageExists(id))
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

        // POST: api/PrintReceiveEntrypages
        [HttpPost]
        public async Task<ActionResult<PrintReceiveEntrypage>> PostPrintReceiveEntrypage(PrintReceiveEntrypage printReceiveEntrypage)
        {
            _context.PrintReceiveEntrypages.Add(printReceiveEntrypage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrintReceiveEntrypage", new { id = printReceiveEntrypage.Id }, printReceiveEntrypage);
        }

        // DELETE: api/PrintReceiveEntrypages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrintReceiveEntrypage>> DeletePrintReceiveEntrypage(int id)
        {
            var printReceiveEntrypage = await _context.PrintReceiveEntrypages.FindAsync(id);
            if (printReceiveEntrypage == null)
            {
                return NotFound();
            }

            _context.PrintReceiveEntrypages.Remove(printReceiveEntrypage);
            await _context.SaveChangesAsync();

            return printReceiveEntrypage;
        }

        private bool PrintReceiveEntrypageExists(int id)
        {
            return _context.PrintReceiveEntrypages.Any(e => e.Id == id);
        }
    }
}
