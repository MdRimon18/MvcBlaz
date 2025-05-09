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
    public class CuttingDeliveryToInputChallansController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CuttingDeliveryToInputChallansController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CuttingDeliveryToInputChallans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuttingDeliveryToInputChallan>>> GetCuttingDeliveryToInputChallan()
        {
            var result = await (from CuttingDeliveryTo in _context.CuttingDeliveryToInputChallans


                                join compInf in _context.TblCompanyInfoes on CuttingDeliveryTo.CuttingCompanyId equals compInf.CompID into compInfs
                                from compInf in compInfs.DefaultIfEmpty()


                                join locationTbl in _context.TblLocationInfoes on CuttingDeliveryTo.LocationId equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()

                                join cutCmnylocationTbl in _context.TblLocationInfoes on CuttingDeliveryTo.CutCompanyLocation equals cutCmnylocationTbl.LocationId into cutCmnylocationTblsls
                                from cutCmnylocationTbl in cutCmnylocationTblsls.DefaultIfEmpty()

                                orderby CuttingDeliveryTo.Id descending
                                select new CuttingDeliveryToInputChallan
                                {


                             Id =CuttingDeliveryTo.Id,
                             SysChallanNo =CuttingDeliveryTo.SysChallanNo,
                             LocationId =CuttingDeliveryTo.LocationId,
                             DeliveryDate =CuttingDeliveryTo.DeliveryDate,
                             DeliveryBasis =CuttingDeliveryTo.DeliveryBasis,
                             ChallanNo =CuttingDeliveryTo.ChallanNo,
                             CuttingSource =CuttingDeliveryTo.CuttingSource,
                             CuttingCompanyId =CuttingDeliveryTo.CuttingCompanyId,
                             CutCompanyLocation =CuttingDeliveryTo.CutCompanyLocation,
                             BundleNo =CuttingDeliveryTo.BundleNo,
                            DeliveryQnt =CuttingDeliveryTo.DeliveryQnt,
                             TotalBundleQnty =CuttingDeliveryTo.TotalBundleQnty,
                             Remarks =CuttingDeliveryTo.Remarks,

                             CuttCompanyName = compInf.Company_Name,
        
                             LocationName = locationTbl. Location_Name,
       
                             CuttCompanyLocation = cutCmnylocationTbl.Location_Name,

    })
               .ToListAsync();

            return result;
        }

        // GET: api/CuttingDeliveryToInputChallans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuttingDeliveryToInputChallan>> GetCuttingDeliveryToInputChallan(int id)
        {
            var cuttingDeliveryToInputChallan = await _context.CuttingDeliveryToInputChallans.FindAsync(id);

            if (cuttingDeliveryToInputChallan == null)
            {
                return NotFound();
            }

            return cuttingDeliveryToInputChallan;
        }

        // PUT: api/CuttingDeliveryToInputChallans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuttingDeliveryToInputChallan(int id, CuttingDeliveryToInputChallan cuttingDeliveryToInputChallan)
        {
            if (id != cuttingDeliveryToInputChallan.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuttingDeliveryToInputChallan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuttingDeliveryToInputChallanExists(id))
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

        // POST: api/CuttingDeliveryToInputChallans
        [HttpPost]
        public async Task<ActionResult<CuttingDeliveryToInputChallan>> PostCuttingDeliveryToInputChallan(CuttingDeliveryToInputChallan cuttingDeliveryToInputChallan)
        {
            _context.CuttingDeliveryToInputChallans.Add(cuttingDeliveryToInputChallan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuttingDeliveryToInputChallan", new { id = cuttingDeliveryToInputChallan.Id }, cuttingDeliveryToInputChallan);
        }

        // DELETE: api/CuttingDeliveryToInputChallans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CuttingDeliveryToInputChallan>> DeleteCuttingDeliveryToInputChallan(int id)
        {
            var cuttingDeliveryToInputChallan = await _context.CuttingDeliveryToInputChallans.FindAsync(id);
            if (cuttingDeliveryToInputChallan == null)
            {
                return NotFound();
            }

            _context.CuttingDeliveryToInputChallans.Remove(cuttingDeliveryToInputChallan);
            await _context.SaveChangesAsync();

            return cuttingDeliveryToInputChallan;
        }

        private bool CuttingDeliveryToInputChallanExists(int id)
        {
            return _context.CuttingDeliveryToInputChallans.Any(e => e.Id == id);
        }
    }
}
