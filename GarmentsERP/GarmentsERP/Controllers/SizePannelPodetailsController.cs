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
    public class SizePannelPodetailsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public SizePannelPodetailsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/SizePannelPodetails/Index

        [HttpGet("Index")]
        public async Task<IEnumerable<SizePannelPodetails>>  GetSizePannelPodetails()
        {
           
            var sizePannelList = _context.SizePannelPodetails.ToList();
            foreach (var v in sizePannelList)
            {
                v.PoName = _context.TblPodetailsInfroes
                    .FirstOrDefault(f => f.PoDetID == v.PoId)?.PO_No;
                v.CountryId = _context.InputPannelPodetails
                    .FirstOrDefault(f => f.Input_Pannel_ID == v.InputPannelId)?.CountryID;
            } 

            return sizePannelList.OrderBy(o=>o.SizePannelId);
        }

        // GET: api/SizePannelPodetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSizePannelPodetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sizePannelPodetails = await _context.SizePannelPodetails.FindAsync(id);

            if (sizePannelPodetails == null)
            {
                return NotFound();
            }

            return Ok(sizePannelPodetails);
        }
        // GET: api/SizePannelPodetails/ByForeignKey/5
        [HttpGet("ByForeignKey/{id}")]
        public IActionResult GetSizePannelPodetailsByForeignKey([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sizePannelPodetails = _context.SizePannelPodetails.Where(x => x.InputPannelId== id).OrderBy(w=>w.SizePannelId);

            if (sizePannelPodetails == null)
            {
                return NotFound();
            }

            return Ok(sizePannelPodetails);
        }

        //[HttpGet("ByCountryId/{id}")]
        //public async Task<ActionResult<IEnumerable<SizePannelPodetails>>> GetFabricCost(int id)
        //{

        //    return await _context.SizePannelPodetails.Where(w => w.InputPannelId == id).ToListAsync();
        //}

            //[HttpPut("{id}")]
            //public async Task<IActionResult> PutSizePannelPodetails([FromRoute] int id, [FromBody] SizePannelPodetails sizePannelPodetails)
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }

            //    if (id != sizePannelPodetails.SizePannelId)
            //    {
            //        return BadRequest();
            //    }

            //    _context.Entry(sizePannelPodetails).State = EntityState.Modified;

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!SizePannelPodetailsExists(id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return NoContent();
            //}

            //  POST: api/SizePannelPodetails
            [HttpPost]
        public async Task<ActionResult<int>> PostSizePannelPodetails([FromBody] List<SizePannelPodetails> sizePannelPodetailsList)
        {
            int isSuccess = 0;
            foreach (var sizeObj in sizePannelPodetailsList.ToList())
            {
        
                 
                sizeObj.ArticleNumber=String.Concat(sizeObj.ArticleNumber.Where(c => !Char.IsWhiteSpace(c)));
                sizeObj.ArticleNumber=sizeObj.ArticleNumber.ToUpper().Trim();
                sizeObj.Color= sizeObj.Color.ToUpper().Trim();
                sizeObj.Size = sizeObj.Size.ToUpper().Trim();
                

                if (sizeObj.SizePannelId > 0)
                {
                    _context.Entry(sizeObj).State = EntityState.Modified;
                }
                else
                {

                    _context.SizePannelPodetails.Add(sizeObj);

                }

            }
            try
            {
                await _context.SaveChangesAsync();
                isSuccess++;
            }
            catch (Exception e)
            {

                throw;
            }
            return isSuccess;
        }
        // PUT: api/SizePannelPodetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizePannelPodetails(int id, SizePannelPodetails sizePannelPodetails)
        {
            if (id != sizePannelPodetails.SizePannelId)
            {
                return BadRequest();
            }

            _context.Entry(sizePannelPodetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizePannelPodetailsExists(id))
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
        // DELETE: api/SizePannelPodetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizePannelPodetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sizePannelPodetails = await _context.SizePannelPodetails.FindAsync(id);
            if (sizePannelPodetails == null)
            {
                return NotFound();
            }

            _context.SizePannelPodetails.Remove(sizePannelPodetails);
            await _context.SaveChangesAsync();

            return Ok(sizePannelPodetails);
        }

        private bool SizePannelPodetailsExists(int id)
        {
            return _context.SizePannelPodetails.Any(e => e.SizePannelId == id);
        }
    }
}