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
    public class SewingInputsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SewingInputsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SewingInputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SewingInput>>> GetSewingInput()
        {
            var result = await (from sewing in _context.SewingInputs

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
                                select new SewingInput
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
                                 InputDate =sewing.InputDate,
                                 SewingLineId =sewing.SewingLineId,
                                 InputQuantity =sewing.InputQuantity,
                                 ChallanNo =sewing.ChallanNo,
                                 IssueID =sewing.IssueID,
                                 ManualCuttingNo =sewing.ManualCuttingNo,
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

        // GET: api/SewingInputs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SewingInput>> GetSewingInput(int id)
        {
            var sewingInput = await _context.SewingInputs.FindAsync(id);

            if (sewingInput == null)
            {
                return NotFound();
            }

            return sewingInput;
        }

        // PUT: api/SewingInputs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSewingInput(int id, SewingInput sewingInput)
        {
            if (id != sewingInput.Id)
            {
                return BadRequest();
            }

            _context.Entry(sewingInput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SewingInputExists(id))
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

        // POST: api/SewingInputs
        [HttpPost]
        public async Task<ActionResult<SewingInput>> PostSewingInput(SewingInput sewingInput)
        {
            _context.SewingInputs.Add(sewingInput);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSewingInput", new { id = sewingInput.Id }, sewingInput);
        }

        // DELETE: api/SewingInputs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SewingInput>> DeleteSewingInput(int id)
        {
            var sewingInput = await _context.SewingInputs.FindAsync(id);
            if (sewingInput == null)
            {
                return NotFound();
            }

            _context.SewingInputs.Remove(sewingInput);
            await _context.SaveChangesAsync();

            return sewingInput;
        }

        private bool SewingInputExists(int id)
        {
            return _context.SewingInputs.Any(e => e.Id == id);
        }
    }
}
