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
    public class SewingOutputsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SewingOutputsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SewingOutputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SewingOutput>>> GetSewingOutput()
        {
            var result = await (from sewing in _context.SewingOutputs

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
                                select new SewingOutput
                                {
                                     Id =sewing.Id,
                                     Source =sewing.Source,
                                     SewCompanyId =sewing.SewCompanyId,
                                     OrderNo =sewing.OrderNo,
                                     CountryId =sewing.CountryId,
                                     BuyerId =sewing.BuyerId,
                                     JobNo =sewing.JobNo,
                                     Style =sewing.Style,
                                     ItemId =sewing.ItemId,
                                     OrderQnty =sewing.OrderQnty,
                                     LocationId =sewing.LocationId,
                                     FloorId =sewing.FloorId,
                                     WorkOrder =sewing.WorkOrder,
                                     ProducedBy =sewing.ProducedBy,
                                     SewingDate =sewing.SewingDate,
                                     SewingLineId =sewing.SewingLineId,
                                     ColorTypeId =sewing.ColorTypeId,
                                     ReportingHour =sewing.ReportingHour,
                                     Supervisor =sewing.Supervisor,
                                     QcPassQty =sewing.QcPassQty,
                                     AlterQty =sewing.AlterQty,
                                     SpotQty =sewing.SpotQty,
                                     RejectQty =sewing.RejectQty,
                                     ChallanNo =sewing.ChallanNo,
                                     ShyChallanNo =sewing.ShyChallanNo,
                                     Remarks =sewing.Remarks,


                                     Status =sewing.Status,

                                     EntryDate =sewing.EntryDate,
                                     EntryBy =sewing.EntryBy,

                                     ApprovedDate =sewing.ApprovedDate,
                                     ApprovedBy =sewing.ApprovedBy,
                                     IsApproved =sewing.IsApproved,

                                     ModifyiedDate =sewing.ModifyiedDate,
                                     IsModifyied =sewing.IsModifyied,
                                     ModifyiedBy =sewing.ModifyiedBy,

        
                                     CountryName = country.Region_Name,
        
                                     SewingCompanyName = compInf.Company_Name,

        
                                     BuyerName = buyerPrfle.ContactName,

        
                                     LocationName = locationTbl.Location_Name,
    })
                  .ToListAsync();
            return result;
        }

        // GET: api/SewingOutputs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SewingOutput>> GetSewingOutput(int id)
        {
            var sewingOutput = await _context.SewingOutputs.FindAsync(id);

            if (sewingOutput == null)
            {
                return NotFound();
            }

            return sewingOutput;
        }

        // PUT: api/SewingOutputs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSewingOutput(int id, SewingOutput sewingOutput)
        {
            if (id != sewingOutput.Id)
            {
                return BadRequest();
            }

            _context.Entry(sewingOutput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SewingOutputExists(id))
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

        // POST: api/SewingOutputs
        [HttpPost]
        public async Task<ActionResult<SewingOutput>> PostSewingOutput(SewingOutput sewingOutput)
        {
            _context.SewingOutputs.Add(sewingOutput);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSewingOutput", new { id = sewingOutput.Id }, sewingOutput);
        }

        // DELETE: api/SewingOutputs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SewingOutput>> DeleteSewingOutput(int id)
        {
            var sewingOutput = await _context.SewingOutputs.FindAsync(id);
            if (sewingOutput == null)
            {
                return NotFound();
            }

            _context.SewingOutputs.Remove(sewingOutput);
            await _context.SaveChangesAsync();

            return sewingOutput;
        }

        private bool SewingOutputExists(int id)
        {
            return _context.SewingOutputs.Any(e => e.Id == id);
        }
    }
}
