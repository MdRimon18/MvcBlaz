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
    public class IronentriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public IronentriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/Ironentries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ironentry>>> GetIronentry()
        {
            var result = await (from iron in _context.Ironentries

                                    //join order in _context.TblInitialOrders on iron.OrderNo equals order.OrderAutoID into orders
                                    //from order in orders.DefaultIfEmpty()

                                join country in _context.TblRegionInfoes on iron.CountryId equals country.RegionID into countrys
                                from country in countrys.DefaultIfEmpty()

                                join compInf in _context.TblCompanyInfoes on iron.IronCompanyId equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on iron.LocationId equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()


                                join buyerPrfle in _context.BuyerProfiles on iron.BuyerId equals buyerPrfle.Id into buyerPrfles
                                from buyerPrfle in buyerPrfles.DefaultIfEmpty()
                                orderby iron.Id descending
                                select new Ironentry
                                {
                                    Id = iron.Id,
                                    OrderNo = iron.OrderNo,
                                    CountryId = iron.CountryId,
                                    BuyerId = iron.BuyerId,
                                    Style = iron.Style,
                                    ItemId = iron.ItemId,
                                     OrderQnty = iron.OrderQnty,
                                    WorkOrder = iron.WorkOrder,
                                    Source = iron.Source,
                                    IronCompanyId = iron.IronCompanyId,
                                    LocationId = iron.LocationId,
                                    FloorId = iron.FloorId,
                                    IronOutputDate = iron.IronOutputDate,
                                    ReportingHour = iron.ReportingHour,
                                    IronOutputQty = iron.IronOutputQty,
                                    ReIronQty = iron.ReIronQty,
                                    RejectQty = iron.RejectQty,
                                    ChallanNo = iron.ChallanNo,
                                    Remarks = iron.Remarks,


                                    Status = iron.Status,

                                    EntryDate = iron.EntryDate,
                                    EntryBy = iron.EntryBy,

                                    ApprovedDate = iron.ApprovedDate,
                                    ApprovedBy = iron.ApprovedBy,
                                    IsApproved = iron.IsApproved,

                                    ModifyiedDate = iron.ModifyiedDate,
                                    IsModifyied = iron.IsModifyied,
                                    ModifyiedBy = iron.ModifyiedBy,


                                    CountryName = country.Region_Name,

                                    IronCompanyName = compInf.Company_Name,


                                    BuyerName = buyerPrfle.ContactName,


                                    LocationName = locationTbl.Location_Name,
                                })
                      .ToListAsync();
            return result; ;
        }

        // GET: api/Ironentries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ironentry>> GetIronentry(int id)
        {
            var ironentry = await _context.Ironentries.FindAsync(id);

            if (ironentry == null)
            {
                return NotFound();
            }

            return ironentry;
        }

        // PUT: api/Ironentries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIronentry(int id, Ironentry ironentry)
        {
            if (id != ironentry.Id)
            {
                return BadRequest();
            }

            _context.Entry(ironentry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IronentryExists(id))
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

        // POST: api/Ironentries
        [HttpPost]
        public async Task<ActionResult<Ironentry>> PostIronentry(Ironentry ironentry)
        {
            _context.Ironentries.Add(ironentry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIronentry", new { id = ironentry.Id }, ironentry);
        }

        // DELETE: api/Ironentries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ironentry>> DeleteIronentry(int id)
        {
            var ironentry = await _context.Ironentries.FindAsync(id);
            if (ironentry == null)
            {
                return NotFound();
            }

            _context.Ironentries.Remove(ironentry);
            await _context.SaveChangesAsync();

            return ironentry;
        }

        private bool IronentryExists(int id)
        {
            return _context.Ironentries.Any(e => e.Id == id);
        }
    }
}
