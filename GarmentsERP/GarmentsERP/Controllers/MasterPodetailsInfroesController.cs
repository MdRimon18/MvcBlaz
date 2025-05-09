using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterPodetailsInfroesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MasterPodetailsInfroesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MasterPodetailsInfroes
        [HttpGet]
        public IEnumerable<TblPodetailsInfro> GetTblPodetailsInfro()
        {
            return _context.TblPodetailsInfroes.ToList();

        }

        // GET: api/MasterPodetailsInfroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblPodetailsInfro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblPodetailsInfro = _context.TblPodetailsInfroes.Where(w => w.InitialOrderID == id);

            if (tblPodetailsInfro == null)
            {
                return NotFound();
            }

            return Ok(tblPodetailsInfro);
        }


        [HttpGet("Details/{id}")]
        public IActionResult GetInputPannelDetails([FromRoute] int id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result =
              (from InputPannelPodetails in _context.InputPannelPodetails
               join CountryInfo in _context.TblRegionInfoes on InputPannelPodetails.CountryID equals CountryInfo.RegionID into CountryInfos
               from CountryInfo in CountryInfos.DefaultIfEmpty()


               join PackingInfo in _context.TblPackingInfoes on InputPannelPodetails.Packing_ID equals PackingInfo.PackingID into PackingInfos
               from PackingInfo in PackingInfos.DefaultIfEmpty()

               orderby InputPannelPodetails.Input_Pannel_ID descending
               select new InputPannelPodetails
               {

                   Input_Pannel_ID = InputPannelPodetails.Input_Pannel_ID,
                   Po_details_ID = InputPannelPodetails.Po_details_ID,
                   CountryID = InputPannelPodetails.CountryID,
                   Country_Type = InputPannelPodetails.Country_Type,
                   Cutt_off_Date = InputPannelPodetails.Cutt_off_Date,
                   Cutt_off = InputPannelPodetails.Cutt_off,
                   Country_Shipment_date = InputPannelPodetails.Country_Shipment_date,
                   Remarks = InputPannelPodetails.Remarks,
                   Packing_ID = InputPannelPodetails.Packing_ID,
                   Quantity = InputPannelPodetails.Quantity,


                   //CountryName = CountryInfo.Region_Name,
                 //  PackingName = PackingInfo.Packing_Name,

               }).ToList();


            var inputPanneldetails = result.Where(x => x.Po_details_ID == id);

            if (inputPanneldetails == null)
            {
                return NotFound();
            }
            return Ok(inputPanneldetails);

        }



        // PUT: api/MasterPodetailsInfroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPodetailsInfro([FromRoute] int id, [FromBody] TblPodetailsInfro tblPodetailsInfro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPodetailsInfro.PoDetID)
            {
                return BadRequest();
            }

            _context.Entry(tblPodetailsInfro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPodetailsInfroExists(id))
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

        // POST: api/MasterPodetailsInfroes
        [HttpPost]
        public async Task<ActionResult<int>> PostTblPodetailsInfro(List<TblPodetailsInfro> tblPodetailsList)
        {  
            int isSuccess = 0;
            foreach (var tblPodetailsInfro in tblPodetailsList.ToList())
            {

                if (tblPodetailsInfro.PoDetID > 0)
                {

                    _context.Entry(tblPodetailsInfro).State = EntityState.Modified;
                    try
                    {
                        isSuccess = 2;
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {

                        throw;
                    }
                   
                }
                else
                {
                    tblPodetailsInfro.Amount = tblPodetailsInfro.PO_Quantity * tblPodetailsInfro.Avg_Price;
                    double exxesscut = Convert.ToDouble(tblPodetailsInfro.Excess_Cut);
                    double calculatePlanCut = (Convert.ToDouble(tblPodetailsInfro.PO_Quantity) * exxesscut) / 100;
                    tblPodetailsInfro.Plan_Cut = tblPodetailsInfro.PO_Quantity + calculatePlanCut;

                    //  tblPodetailsInfro.EntryDate = DateTime.Now;
                  
                    _context.TblPodetailsInfroes.Add(tblPodetailsInfro);
                  
                    try
                    {
                        await _context.SaveChangesAsync();
                        isSuccess = 1;
                    }
                    catch (Exception e)
                    {

                        throw;
                    }
                  
                }

            }
             
            return isSuccess;
           
        }

        // DELETE: api/MasterPodetailsInfroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPodetailsInfro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblPodetailsInfro = await _context.TblPodetailsInfroes.FindAsync(id);
            if (tblPodetailsInfro == null)
            {
                return NotFound();
            }

            _context.TblPodetailsInfroes.Remove(tblPodetailsInfro);
            await _context.SaveChangesAsync();

            return Ok(tblPodetailsInfro);
        }

        private bool TblPodetailsInfroExists(int id)
        {
            return _context.TblPodetailsInfroes.Any(e => e.PoDetID == id);
        }


        [HttpGet("GarmentsColor/{id}")]
        public IActionResult GarmentsColor([FromRoute] int id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inputPanneldetails = _context.InputPannelPodetails.Where(x => x.Po_details_ID == id).ToList();

            if (inputPanneldetails == null)
            {
                return NotFound();
            }

            var sizeWiseBreakDownList = new List<SizePannelPodetails>();
            foreach (var item in inputPanneldetails)
            {
                var sizeList = _context.SizePannelPodetails.Where(w => w.InputPannelId == item.Input_Pannel_ID).ToList();
                foreach (var i in sizeList)
                {
                    sizeWiseBreakDownList.Add(i);
                }

            }

            var query = sizeWiseBreakDownList.GroupBy(p => p.Color)
                .Select(g => new { Color = g.Key });

            return Ok(query);

        }
        [HttpGet("GarmentsSize/{id}")]
        public IActionResult GarmentsSize([FromRoute] int id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inputPanneldetails = _context.InputPannelPodetails.Where(x => x.Po_details_ID == id).ToList();

            if (inputPanneldetails == null)
            {
                return NotFound();
            }

            var sizeWiseBreakDownList = new List<SizePannelPodetails>();
            foreach (var item in inputPanneldetails)
            {
                var sizeList = _context.SizePannelPodetails.Where(w => w.InputPannelId == item.Input_Pannel_ID).ToList();
                foreach (var i in sizeList)
                {
                    sizeWiseBreakDownList.Add(i);
                }

            }

            var query = sizeWiseBreakDownList.GroupBy(p => p.Size)
                .Select(g => new { Size = g.Key });

            return Ok(query);

        }


    }
}