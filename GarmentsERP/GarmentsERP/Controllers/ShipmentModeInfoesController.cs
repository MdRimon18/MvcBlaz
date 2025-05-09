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
    public class ShipmentModeInfoesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ShipmentModeInfoesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ShipmentModeInfoes/Index
        [HttpGet("Index")]
        public IEnumerable<TblShipmentModeInfo> GetTblShipmentModeInfo()
        {
            return _context.TblShipmentModeInfoes;
        }

        // GET: api/ShipmentModeInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblShipmentModeInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblShipmentModeInfo = await _context.TblShipmentModeInfoes.FindAsync(id);

            if (tblShipmentModeInfo == null)
            {
                return NotFound();
            }

            return Ok(tblShipmentModeInfo);
        }

        // PUT: api/ShipmentModeInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblShipmentModeInfo([FromRoute] int id, [FromBody] TblShipmentModeInfo tblShipmentModeInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblShipmentModeInfo.ID)
            {
                return BadRequest();
            }

            _context.Entry(tblShipmentModeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblShipmentModeInfoExists(id))
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

        // POST: api/ShipmentModeInfoes
        [HttpPost]
        public async Task<IActionResult> PostTblShipmentModeInfo([FromBody] TblShipmentModeInfo tblShipmentModeInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblShipmentModeInfoes.Add(tblShipmentModeInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblShipmentModeInfo", new { id = tblShipmentModeInfo.ID }, tblShipmentModeInfo);
        }

        // DELETE: api/ShipmentModeInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblShipmentModeInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblShipmentModeInfo = await _context.TblShipmentModeInfoes.FindAsync(id);
            if (tblShipmentModeInfo == null)
            {
                return NotFound();
            }

            _context.TblShipmentModeInfoes.Remove(tblShipmentModeInfo);
            await _context.SaveChangesAsync();

            return Ok(tblShipmentModeInfo);
        }

        private bool TblShipmentModeInfoExists(int id)
        {
            return _context.TblShipmentModeInfoes.Any(e => e.ID == id);
        }
    }
}