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
    public class SewingOutputGrossQtiesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SewingOutputGrossQtiesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SewingOutputGrossQties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SewingOutputGrossQty>>> GetSewingOutputGrossQty()
        {
            var result = await (from sewing in _context.SewingOutputGrossQties

                                    //join order in _context.TblInitialOrders on sewing.OrderNo equals order.OrderAutoID into orders
                                    //from order in orders.DefaultIfEmpty()

                                join country in _context.TblRegionInfoes on sewing.CountryId equals country.RegionID into countrys
                                from country in countrys.DefaultIfEmpty()

                                join compInf in _context.TblCompanyInfoes on sewing.SewCompanyId equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on sewing.LocationId equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()


                                join buyerPrfle in _context.BuyerProfiles on sewing.BuyerId equals buyerPrfle.Id into buyerPrfles
                                from buyerPrfle in buyerPrfles.DefaultIfEmpty()
                                orderby sewing.Id descending
                                select new SewingOutputGrossQty
                                {
                                    Id = sewing.Id,
                                    Source = sewing.Source,
                                    SewCompanyId = sewing.SewCompanyId,
                                    OrderNo = sewing.OrderNo,
                                    CountryId = sewing.CountryId,
                                    BuyerId = sewing.BuyerId,
                                    JobNo = sewing.JobNo,
                                    Style = sewing.Style,
                                    ItemId = sewing.ItemId,
                                    OrderQnty = sewing.OrderQnty,
                                    LocationId = sewing.LocationId,
                                    FloorId = sewing.FloorId,
                                    WorkOrder = sewing.WorkOrder,
                                    ProducedBy = sewing.ProducedBy,
                                    SewingDate = sewing.SewingDate,
                                    SewingLineId = sewing.SewingLineId,
                                   
                                    ReportingHour = sewing.ReportingHour,
                                    Supervisor = sewing.Supervisor,
                                    QcPassQty = sewing.QcPassQty,
                                    AlterQty = sewing.AlterQty,
                                    SpotQty = sewing.SpotQty,
                                    RejectQty = sewing.RejectQty,
                                    ChallanNo = sewing.ChallanNo,
                                 
                                    Remarks = sewing.Remarks,


                                    Status = sewing.Status,

                                    EntryDate = sewing.EntryDate,
                                    EntryBy = sewing.EntryBy,

                                    ApprovedDate = sewing.ApprovedDate,
                                    ApprovedBy = sewing.ApprovedBy,
                                    IsApproved = sewing.IsApproved,

                                    ModifyiedDate = sewing.ModifyiedDate,
                                    IsModifyied = sewing.IsModifyied,
                                    ModifyiedBy = sewing.ModifyiedBy,


                                    CountryName = country.Region_Name,

                                    SewingCompanyName = compInf.Company_Name,


                                    BuyerName = buyerPrfle.ContactName,


                                    LocationName = locationTbl.Location_Name,
                                })
                    .ToListAsync();
            return result; ;
        }

        // GET: api/SewingOutputGrossQties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SewingOutputGrossQty>> GetSewingOutputGrossQty(int id)
        {
            var sewingOutputGrossQty = await _context.SewingOutputGrossQties.FindAsync(id);

            if (sewingOutputGrossQty == null)
            {
                return NotFound();
            }

            return sewingOutputGrossQty;
        }

        // PUT: api/SewingOutputGrossQties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSewingOutputGrossQty(int id, SewingOutputGrossQty sewingOutputGrossQty)
        {
            if (id != sewingOutputGrossQty.Id)
            {
                return BadRequest();
            }

            _context.Entry(sewingOutputGrossQty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SewingOutputGrossQtyExists(id))
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

        // POST: api/SewingOutputGrossQties
        [HttpPost]
        public async Task<ActionResult<SewingOutputGrossQty>> PostSewingOutputGrossQty(SewingOutputGrossQty sewingOutputGrossQty)
        {
            _context.SewingOutputGrossQties.Add(sewingOutputGrossQty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSewingOutputGrossQty", new { id = sewingOutputGrossQty.Id }, sewingOutputGrossQty);
        }

        // DELETE: api/SewingOutputGrossQties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SewingOutputGrossQty>> DeleteSewingOutputGrossQty(int id)
        {
            var sewingOutputGrossQty = await _context.SewingOutputGrossQties.FindAsync(id);
            if (sewingOutputGrossQty == null)
            {
                return NotFound();
            }

            _context.SewingOutputGrossQties.Remove(sewingOutputGrossQty);
            await _context.SaveChangesAsync();

            return sewingOutputGrossQty;
        }

        private bool SewingOutputGrossQtyExists(int id)
        {
            return _context.SewingOutputGrossQties.Any(e => e.Id == id);
        }
    }
}
