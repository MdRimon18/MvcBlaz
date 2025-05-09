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
    public class PackingAndFinishingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public PackingAndFinishingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/PackingAndFinishings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackingAndFinishing>>> GetPackingAndFinishing()
        {
            var result = await (from pNdf in _context.PackingAndFinishings

                                    //join order in _context.TblInitialOrders on pNdf.OrderNo equals order.OrderAutoID into orders
                                    //from order in orders.DefaultIfEmpty()

                                join country in _context.TblRegionInfoes on pNdf.CountryId equals country.RegionID into countrys
                                from country in countrys.DefaultIfEmpty()

                                join compInf in _context.TblCompanyInfoes on pNdf.FinisCompanyId equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on pNdf.LocationId equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()


                                join buyerPrfle in _context.BuyerProfiles on pNdf.BuyerId equals buyerPrfle.Id into buyerPrfles
                                from buyerPrfle in buyerPrfles.DefaultIfEmpty()
                                orderby pNdf.Id descending
                                select new PackingAndFinishing
                                {
                                      Id =pNdf.Id,
                                     Source =pNdf.Source,
                                     FinisCompanyId =pNdf.FinisCompanyId,
                                     OrderNo =pNdf.OrderNo,
                                     CountryId =pNdf.CountryId,
                                     BuyerId =pNdf.BuyerId,
                                     JobNo =pNdf.JobNo,
                                     Style =pNdf.Style,
                                     ItemId =pNdf.ItemId,
                                     OrderQnty =pNdf.OrderQnty,
                                     LocationId =pNdf.LocationId,
                                     FloorId =pNdf.FloorId,
                                     PackType =pNdf.PackType,
                                     FinishingDate =pNdf.FinishingDate,
                                     ReportingHour =pNdf.ReportingHour,
                                     FinishingQty =pNdf.FinishingQty,
                                     TotalCartonQty =pNdf.TotalCartonQty,
                                     AlterQty =pNdf.AlterQty,
                                     SpotQty =pNdf.SpotQty,
                                     RejectQty =pNdf.RejectQty,
                                     ChallanNo =pNdf.ChallanNo,
                                     ShyChallanNo =pNdf.ShyChallanNo,


                                    Remarks = pNdf.Remarks,


                                    Status = pNdf.Status,

                                    EntryDate = pNdf.EntryDate,
                                    EntryBy = pNdf.EntryBy,

                                    ApprovedDate = pNdf.ApprovedDate,
                                    ApprovedBy = pNdf.ApprovedBy,
                                    IsApproved = pNdf.IsApproved,

                                    ModifyiedDate = pNdf.ModifyiedDate,
                                    IsModifyied = pNdf.IsModifyied,
                                    ModifyiedBy = pNdf.ModifyiedBy,


                                    CountryName = country.Region_Name,

                                    FinisCompanyName = compInf.Company_Name,


                                    BuyerName = buyerPrfle.ContactName,


                                    LocationName = locationTbl.Location_Name,
                                })
                      .ToListAsync();
            return result; ;
        }

        // GET: api/PackingAndFinishings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackingAndFinishing>> GetPackingAndFinishing(int id)
        {
            var packingAndFinishing = await _context.PackingAndFinishings.FindAsync(id);

            if (packingAndFinishing == null)
            {
                return NotFound();
            }

            return packingAndFinishing;
        }

        // PUT: api/PackingAndFinishings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackingAndFinishing(int id, PackingAndFinishing packingAndFinishing)
        {
            if (id != packingAndFinishing.Id)
            {
                return BadRequest();
            }

            _context.Entry(packingAndFinishing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackingAndFinishingExists(id))
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

        // POST: api/PackingAndFinishings
        [HttpPost]
        public async Task<ActionResult<PackingAndFinishing>> PostPackingAndFinishing(PackingAndFinishing packingAndFinishing)
        {
            _context.PackingAndFinishings.Add(packingAndFinishing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackingAndFinishing", new { id = packingAndFinishing.Id }, packingAndFinishing);
        }

        // DELETE: api/PackingAndFinishings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PackingAndFinishing>> DeletePackingAndFinishing(int id)
        {
            var packingAndFinishing = await _context.PackingAndFinishings.FindAsync(id);
            if (packingAndFinishing == null)
            {
                return NotFound();
            }

            _context.PackingAndFinishings.Remove(packingAndFinishing);
            await _context.SaveChangesAsync();

            return packingAndFinishing;
        }

        private bool PackingAndFinishingExists(int id)
        {
            return _context.PackingAndFinishings.Any(e => e.Id == id);
        }
    }
}
