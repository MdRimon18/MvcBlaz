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
    public class MultipleJobWiseTrimsBookingV2Controller : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MultipleJobWiseTrimsBookingV2Controller(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MultipleJobWiseTrimsBookingV2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultipleJobWiseTrimsBookingV2>>> GetMultipleJobWiseTrimsBookingV2()
        {
            var result =
                 await (from MultipleBookingtbl in _context.MultipleJobWiseTrimsBookingV2
                        join compInf in _context.TblCompanyInfoes on MultipleBookingtbl.CompanyNameId equals compInf.CompID into compInfs
                        from compInf in compInfs.DefaultIfEmpty()


                        join BuyerProfiletbl in _context.BuyerProfiles on MultipleBookingtbl.BuyerNameId equals BuyerProfiletbl.Id into BuyerProfiletbls
                        from BuyerProfiletbl in BuyerProfiletbls.DefaultIfEmpty()

                        join DiscountMethodtbl in _context.DiscountMethods on MultipleBookingtbl.CurrencyId equals DiscountMethodtbl.Id into DiscountMethodtbls
                        from DiscountMethodtbl in DiscountMethodtbls.DefaultIfEmpty()

                        join Supliertbl in _context.SupplierProfiles on MultipleBookingtbl.SupplierNameId equals Supliertbl.Id into Supliertbls
                        from Supliertbl in Supliertbls.DefaultIfEmpty()



                        orderby MultipleBookingtbl.Id descending
                        select new MultipleJobWiseTrimsBookingV2
                        {

                                 Id=MultipleBookingtbl.Id,
                                 BookingNo=MultipleBookingtbl.BookingNo,
                                 ShipmentMonth=MultipleBookingtbl.ShipmentMonth,
                                 ShipmentYear=MultipleBookingtbl.ShipmentYear,
                                 CompanyNameId=MultipleBookingtbl.CompanyNameId,
                                 BuyerNameId=MultipleBookingtbl.BuyerNameId,
                                 BookingDate=MultipleBookingtbl.BookingDate,
                                 DeliveryDate=MultipleBookingtbl.DeliveryDate,
                                 PayMode=MultipleBookingtbl.PayMode,
                                 CurrencyId=MultipleBookingtbl.CurrencyId,
                                 SupplierNameId=MultipleBookingtbl.SupplierNameId,
                                 MaterialSource=MultipleBookingtbl.MaterialSource,
                                 Attention=MultipleBookingtbl.Attention,
                                 ReadyToApproved=MultipleBookingtbl.ReadyToApproved,
                                 Source=MultipleBookingtbl.Source,
                                 Remarks=MultipleBookingtbl.Remarks,
                                 Level=MultipleBookingtbl.Level,
                                 DeliveryTo=MultipleBookingtbl.DeliveryTo,
                                 Unapproverequest=MultipleBookingtbl.Unapproverequest,

                                 EntryDate=MultipleBookingtbl.EntryDate,
                                 EntryBy=MultipleBookingtbl.EntryBy,
                                 Status=MultipleBookingtbl.Status,

                                CompanyName = compInf.Company_Name,

                            BuyerName = BuyerProfiletbl.ContactName,

                            CurrencyName = DiscountMethodtbl.DiscountMethodName,
                            SupplierName = Supliertbl.SupplierName

                        }).ToListAsync();
            return result;
        }

        // GET: api/MultipleJobWiseTrimsBookingV2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultipleJobWiseTrimsBookingV2>> GetMultipleJobWiseTrimsBookingV2(int id)
        {
            var multipleJobWiseTrimsBookingV2 = await _context.MultipleJobWiseTrimsBookingV2.FindAsync(id);

            if (multipleJobWiseTrimsBookingV2 == null)
            {
                return NotFound();
            }

            return multipleJobWiseTrimsBookingV2;
        }

        // PUT: api/MultipleJobWiseTrimsBookingV2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultipleJobWiseTrimsBookingV2(int id, MultipleJobWiseTrimsBookingV2 multipleJobWiseTrimsBookingV2)
        {
            if (id != multipleJobWiseTrimsBookingV2.Id)
            {
                return BadRequest();
            }

            _context.Entry(multipleJobWiseTrimsBookingV2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultipleJobWiseTrimsBookingV2Exists(id))
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

        // POST: api/MultipleJobWiseTrimsBookingV2
        [HttpPost]
        public async Task<ActionResult<MultipleJobWiseTrimsBookingV2>> PostMultipleJobWiseTrimsBookingV2(MultipleJobWiseTrimsBookingV2 multipleJobWiseTrimsBookingV2)
        {
           var y=DateTime.Now.Year;
            var year = Convert.ToDouble(y) % 100;
           multipleJobWiseTrimsBookingV2.BookingNo="MKL-" + "TB-" + Convert.ToString(year) + "-0" + _context.MultipleJobWiseTrimsBookingV2.Count();
            _context.MultipleJobWiseTrimsBookingV2.Add(multipleJobWiseTrimsBookingV2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMultipleJobWiseTrimsBookingV2", new { id = multipleJobWiseTrimsBookingV2.Id }, multipleJobWiseTrimsBookingV2);
        }

        // DELETE: api/MultipleJobWiseTrimsBookingV2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MultipleJobWiseTrimsBookingV2>> DeleteMultipleJobWiseTrimsBookingV2(int id)
        {
            var multipleJobWiseTrimsBookingV2 = await _context.MultipleJobWiseTrimsBookingV2.FindAsync(id);
            if (multipleJobWiseTrimsBookingV2 == null)
            {
                return NotFound();
            }

            _context.MultipleJobWiseTrimsBookingV2.Remove(multipleJobWiseTrimsBookingV2);
            await _context.SaveChangesAsync();

            return multipleJobWiseTrimsBookingV2;
        }

        private bool MultipleJobWiseTrimsBookingV2Exists(int id)
        {
            return _context.MultipleJobWiseTrimsBookingV2.Any(e => e.Id == id);
        }
    }
}
