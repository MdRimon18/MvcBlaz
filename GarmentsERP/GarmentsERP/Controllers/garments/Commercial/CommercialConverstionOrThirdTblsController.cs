using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Models;
using GarmentsERP.Model; // Assuming your models are in this namespace

namespace GarmentsERP.Controllers.Garments.Commercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercialConverstionOrThirdTblsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CommercialConverstionOrThirdTblsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/CommercialConverstionOrThirdTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommercialConverstionOrThirdTbl>>> GetCommercialConverstionOrThirdTbls()
        {
            return await _context.CommercialConverstionOrThirdTbls.ToListAsync();
        }

        // GET: api/CommercialConverstionOrThirdTbls/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<CommercialConverstionOrThirdTbl>> GetCommercialConverstionOrThirdTbl(int id)
        {
            List<CommercialConverstionOrThirdTbl> converstionOrThirdTbls = _context.CommercialConverstionOrThirdTbls
                .Where(w => w.MasterTblid == id)
                .ToList();

            return converstionOrThirdTbls;
        }

        // PUT: api/CommercialConverstionOrThirdTbls/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommercialConverstionOrThirdTbl(int id, CommercialConverstionOrThirdTbl commercialConverstionOrThirdTbl)
        {
            if (id != commercialConverstionOrThirdTbl.Id)
            {
                return BadRequest();
            }

            _context.Entry(commercialConverstionOrThirdTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercialConverstionOrThirdTblExists(id))
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

        // POST: api/CommercialConverstionOrThirdTbls
        [HttpPost]
        public async Task<ActionResult<int>> PostCommercialConverstionOrThirdTbl(List<CommercialConverstionOrThirdTbl> converstionOrThirdTbls)
        {
            int isSuccess = 0;
            foreach (var conv in converstionOrThirdTbls.ToList())
            {
                if (conv.Id > 0)
                {
                    _context.Entry(conv).State = EntityState.Modified;
                    isSuccess = 2;
                }
                else
                {
                    _context.CommercialConverstionOrThirdTbls.Add(conv);
                    isSuccess = 1;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Consider logging the exception for debugging purposes
                return StatusCode(500, e.Message); // Return a more specific error
            }

            return isSuccess;
        }

        // DELETE: api/CommercialConverstionOrThirdTbls/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommercialConverstionOrThirdTbl>> DeleteCommercialConverstionOrThirdTbl(int id)
        {
            var commercialConverstionOrThirdTbl = await _context.CommercialConverstionOrThirdTbls.FindAsync(id);
            if (commercialConverstionOrThirdTbl == null)
            {
                return NotFound();
            }

            _context.CommercialConverstionOrThirdTbls.Remove(commercialConverstionOrThirdTbl);
            await _context.SaveChangesAsync();

            return commercialConverstionOrThirdTbl;
        }

        private bool CommercialConverstionOrThirdTblExists(int id)
        {
            return _context.CommercialConverstionOrThirdTbls.Any(e => e.Id == id);
        }
    }
}