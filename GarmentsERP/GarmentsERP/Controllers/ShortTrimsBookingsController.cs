using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.MarchandisingModule;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortTrimsBookingsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ShortTrimsBookingsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ShortTrimsBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortTrimsBooking>>> GetShortTrimsBooking()
        {
            var result =
                await (from ShortTrimsBookingbl in _context.ShortTrimsBookings
                       join compInf in _context.TblCompanyInfoes on ShortTrimsBookingbl.CompanyNameId equals compInf.CompID into compInfs
                       from compInf in compInfs.DefaultIfEmpty()


                       join BuyerProfiletbl in _context.BuyerProfiles on ShortTrimsBookingbl.BuyerNameId equals BuyerProfiletbl.Id into BuyerProfiletbls
                       from BuyerProfiletbl in BuyerProfiletbls.DefaultIfEmpty()



                       join Supliertbl in _context.SupplierProfiles on ShortTrimsBookingbl.SupplierNameId equals Supliertbl.Id into Supliertbls
                       from Supliertbl in Supliertbls.DefaultIfEmpty()

                      

                       orderby ShortTrimsBookingbl.Id descending
                       select new ShortTrimsBooking
                       {

                            Id=ShortTrimsBookingbl.Id,
         BookingNo=ShortTrimsBookingbl.BookingNo,
         BookingMonth=ShortTrimsBookingbl.BookingMonth,
         BookingYear=ShortTrimsBookingbl.BookingYear,
         JobNo=ShortTrimsBookingbl.JobNo,
         CompanyNameId=ShortTrimsBookingbl.CompanyNameId,
         BuyerNameId=ShortTrimsBookingbl.BuyerNameId,
         BookingDate=ShortTrimsBookingbl.BookingDate,
         PayMode=ShortTrimsBookingbl.PayMode,
         DeliveryDate=ShortTrimsBookingbl.DeliveryDate,
         CurrencyId=ShortTrimsBookingbl.CurrencyId,
         ExchangeRate=ShortTrimsBookingbl.ExchangeRate,
         SupplierNameId=ShortTrimsBookingbl.SupplierNameId,
         Source=ShortTrimsBookingbl.Source,
         SelectItem=ShortTrimsBookingbl.SelectItem,
         Attention=ShortTrimsBookingbl.Attention,
         ReadyToApproved=ShortTrimsBookingbl.ReadyToApproved,
         MaterialSource=ShortTrimsBookingbl.MaterialSource,
         EntryDate=ShortTrimsBookingbl.EntryDate,
         EntryBy=ShortTrimsBookingbl.EntryBy,
         Status=ShortTrimsBookingbl.Status,
         IsApproved = ShortTrimsBookingbl.IsApproved,
         ApprovedDate = ShortTrimsBookingbl.ApprovedDate,
         ApprovedBy = ShortTrimsBookingbl.ApprovedBy,

        CompanyName = compInf.Company_Name,

                           BuyerName = BuyerProfiletbl.ContactName,

                          
                           SupplierName = Supliertbl.SupplierName

                       }).ToListAsync();
            return result; ;
        }

        // GET: api/ShortTrimsBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortTrimsBooking>> GetShortTrimsBooking(int id)
        {
            var shortTrimsBooking = await _context.ShortTrimsBookings.FindAsync(id);

            if (shortTrimsBooking == null)
            {
                return NotFound();
            }

            return shortTrimsBooking;
        }

        // PUT: api/ShortTrimsBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShortTrimsBooking(int id, ShortTrimsBooking shortTrimsBooking)
        {
            if (id != shortTrimsBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(shortTrimsBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortTrimsBookingExists(id))
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

        // POST: api/ShortTrimsBookings
        [HttpPost]
        public async Task<ActionResult<ShortTrimsBooking>> PostShortTrimsBooking(ShortTrimsBooking shortTrimsBooking)
        {
            var a = DateTime.Now.Year;
            double year = Convert.ToDouble(a) % 100;
            shortTrimsBooking.BookingNo = "MKL-" +"TB-"+Convert.ToString(year) + "-0" + _context.ShortTrimsBookings.Count();
            _context.ShortTrimsBookings.Add(shortTrimsBooking);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetShortTrimsBooking", new { id = shortTrimsBooking.Id }, shortTrimsBooking);
        }

        // DELETE: api/ShortTrimsBookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShortTrimsBooking>> DeleteShortTrimsBooking(int id)
        {
            var shortTrimsBooking = await _context.ShortTrimsBookings.FindAsync(id);
            if (shortTrimsBooking == null)
            {
                return NotFound();
            }

            _context.ShortTrimsBookings.Remove(shortTrimsBooking);
            await _context.SaveChangesAsync();

            return shortTrimsBooking;
        }

        private bool ShortTrimsBookingExists(int id)
        {
            return _context.ShortTrimsBookings.Any(e => e.Id == id);
        }
    }
}
