using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers.MarchandisingModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleRequisitionWithBookingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SampleRequisitionWithBookingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SampleRequisitionWithBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleRequisitionWithBooking>>> GetSampleRequisitionWithBooking()
        {
            var result =
                  await (from SampleReqWithBooking in _context.SampleRequisitionWithBookings
                         join companyInfo in _context.TblCompanyInfoes on SampleReqWithBooking.CompanyNameId equals companyInfo.CompID into companyInfos
                         from companyInfo in companyInfos.DefaultIfEmpty()


                         join EmpCategoryInfo in _context.EmpCategories on SampleReqWithBooking.DealingMerchantId equals EmpCategoryInfo.EmpCatagoryId into EmpCategoryInfos
                         from EmpCategoryInfo in EmpCategoryInfos.DefaultIfEmpty()

                         join SeasonInfo in _context.TblSeasonInfoes on SampleReqWithBooking.SeasonId equals SeasonInfo.SeasonID into SeasonInfos
                         from SeasonInfo in SeasonInfos.DefaultIfEmpty()

                         join locationInfo in _context.TblLocationInfoes on SampleReqWithBooking.LocationId equals locationInfo.LocationId into locationInfos
                         from locationInfo in locationInfos.DefaultIfEmpty()

                         join buyerInfo in _context.BuyerProfiles on SampleReqWithBooking.BuyerNameId equals buyerInfo.Id into buyerInfos
                         from buyerInfo in buyerInfos.DefaultIfEmpty()

                         join AgentInfo in _context.TblAgentInfoes on SampleReqWithBooking.AgentNameId equals AgentInfo.AgentID into AgentInfos
                         from AgentInfo in AgentInfos.DefaultIfEmpty()



                         orderby SampleReqWithBooking.Id descending
                         select new SampleRequisitionWithBooking
                         {

                             Id = SampleReqWithBooking.Id,
                             RequisitionId = SampleReqWithBooking.RequisitionId,
                             SampleStage = SampleReqWithBooking.SampleStage,
                             RequisitionDate = SampleReqWithBooking.RequisitionDate,
                             StyleRefId = SampleReqWithBooking.StyleRefId,
                             CompanyNameId = SampleReqWithBooking.CompanyNameId,
                             LocationId = SampleReqWithBooking.LocationId,
                             BuyerNameId = SampleReqWithBooking.BuyerNameId,
                             SeasonId = SampleReqWithBooking.SeasonId,
                             ProductDept = SampleReqWithBooking.ProductDept,
                             DealingMerchantId = SampleReqWithBooking.DealingMerchantId,
                             AgentNameId = SampleReqWithBooking.AgentNameId,
                             BuyerRef = SampleReqWithBooking.BuyerRef,
                             BHMerchant = SampleReqWithBooking.BHMerchant,
                             EstShipDate = SampleReqWithBooking.EstShipDate,
                             RemarksDesc = SampleReqWithBooking.RemarksDesc,
                             File = SampleReqWithBooking.File,
                             ReadyToApproved = SampleReqWithBooking.ReadyToApproved,
                             MaterialDeliveryDate = SampleReqWithBooking.MaterialDeliveryDate,

                             EntryDate = SampleReqWithBooking.EntryDate,

                             EntryBy = SampleReqWithBooking.EntryBy,
                             ApprovedDate = SampleReqWithBooking.ApprovedDate,
                             ApprovedBy = SampleReqWithBooking.ApprovedBy,
                             IsApproved = SampleReqWithBooking.IsApproved,
                             Status = SampleReqWithBooking.Status,

                             CompanyName = companyInfo.Company_Name,
                             LocationName = locationInfo.Location_Name,
                             BuyerName = buyerInfo.ContactName,
                             SeasonName = SeasonInfo.Season_Name,
                             AgentName = AgentInfo.Agent_Name,


                         }).ToListAsync();

            return result;
        }

        // GET: api/SampleRequisitionWithBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleRequisitionWithBooking>> GetSampleRequisitionWithBooking(int id)
        {
            var sampleRequisitionWithBooking = await _context.SampleRequisitionWithBookings.FindAsync(id);

            if (sampleRequisitionWithBooking == null)
            {
                return NotFound();
            }

            return sampleRequisitionWithBooking;
        }

        // PUT: api/SampleRequisitionWithBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleRequisitionWithBooking(int id, SampleRequisitionWithBooking sampleRequisitionWithBooking)
        {
            if (id != sampleRequisitionWithBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleRequisitionWithBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleRequisitionWithBookingExists(id))
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

        // POST: api/SampleRequisitionWithBookings
        [HttpPost]
        public async Task<ActionResult<SampleRequisitionWithBooking>> PostSampleRequisitionWithBooking(SampleRequisitionWithBooking sampleRequisitionWithBooking)
        {
            string CurrentYear = DateTime.Now.Year.ToString();
            var lastTwoDigit = CurrentYear.Substring(2);
            var requisitionId = "MKL-" +lastTwoDigit + "000" + _context.SampleRequisitionWithBookings.Count();
            sampleRequisitionWithBooking.RequisitionId = requisitionId;
            _context.SampleRequisitionWithBookings.Add(sampleRequisitionWithBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleRequisitionWithBooking", new { id = sampleRequisitionWithBooking.Id }, sampleRequisitionWithBooking);
        }

        // DELETE: api/SampleRequisitionWithBookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleRequisitionWithBooking>> DeleteSampleRequisitionWithBooking(int id)
        {
            var sampleRequisitionWithBooking = await _context.SampleRequisitionWithBookings.FindAsync(id);
            if (sampleRequisitionWithBooking == null)
            {
                return NotFound();
            }

            _context.SampleRequisitionWithBookings.Remove(sampleRequisitionWithBooking);
            await _context.SaveChangesAsync();

            return sampleRequisitionWithBooking;
        }

        private bool SampleRequisitionWithBookingExists(int id)
        {
            return _context.SampleRequisitionWithBookings.Any(e => e.Id == id);
        }
    }
}
