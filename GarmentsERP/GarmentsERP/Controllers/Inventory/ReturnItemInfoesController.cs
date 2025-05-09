using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.Inventory;

namespace GarmentsERP.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnItemInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ReturnItemInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ReturnItemInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnItemInfo>>> GetReturnItemInfo()
        {
            return await _context.ReturnItemInfoes.ToListAsync();
        }

        // GET: api/ReturnItemInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnItemInfo>> GetReturnItemInfo(int id)
        {
            var returnItemInfo = await _context.ReturnItemInfoes.FindAsync(id);

            if (returnItemInfo == null)
            {
                return NotFound();
            }

            return returnItemInfo;
        }

        // PUT: api/ReturnItemInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReturnItemInfo(int id, ReturnItemInfo returnItemInfo)
        {
            if (id != returnItemInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(returnItemInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReturnItemInfoExists(id))
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

        // POST: api/ReturnItemInfoes
        [HttpPost]
        public async Task<ActionResult<ReturnItemInfo>> PostReturnItemInfo(ReturnItemInfo returnItemInfo)
        {
            _context.ReturnItemInfoes.Add(returnItemInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReturnItemInfo", new { id = returnItemInfo.Id }, returnItemInfo);
        }

        // DELETE: api/ReturnItemInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReturnItemInfo>> DeleteReturnItemInfo(int id)
        {
            var returnItemInfo = await _context.ReturnItemInfoes.FindAsync(id);
            if (returnItemInfo == null)
            {
                return NotFound();
            }

            _context.ReturnItemInfoes.Remove(returnItemInfo);
            await _context.SaveChangesAsync();

            return returnItemInfo;
        }

        private bool ReturnItemInfoExists(int id)
        {
            return _context.ReturnItemInfoes.Any(e => e.Id == id);
        }
    }
}
