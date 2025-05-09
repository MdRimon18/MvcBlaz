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
    public class ActualProductionResourceEntryMastersController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public ActualProductionResourceEntryMastersController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/ActualProductionResourceEntryMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActualProductionResourceEntryMaster>>> GetActualProductionResourceEntryMaster()
        {
            var result = await (from ape in _context.ActualProductionResourceEntryMasters

                                join locationTbl in _context.TblLocationInfoes on ape.LocationId equals locationTbl.LocationId into locationTbls
                                from locationTbl in locationTbls.DefaultIfEmpty()

                                join floor in _context.Floors on ape.FloorId equals floor.Id into floors
                                from floor in floors.DefaultIfEmpty()

                                join line in _context.SewingLines on ape.LineNo equals line.Id into lines
                                from line in lines.DefaultIfEmpty()


                                orderby ape.Id descending
                                select new ActualProductionResourceEntryMaster
                                {


                                     Id =ape.Id,
                                     SystemId =ape.SystemId,
                                     LocationId =ape.LocationId,
                                     FloorId =ape.FloorId,
                                     LineMerge =ape.LineMerge,
                                     LineNo =ape.LineNo,


                                     Status =ape.Status,

                                     EntryDate =ape.EntryDate,
                                     EntryBy =ape.EntryBy,

                                     ApprovedDate =ape.ApprovedDate,
                                     ApprovedBy =ape.ApprovedBy,
                                    IsApproved =ape.IsApproved,

                                     ModifyiedDate =ape.ModifyiedDate,
                                    IsModifyied =ape.IsModifyied,
                                     ModifyiedBy =ape.ModifyiedBy,

        
                                     LocationName = locationTbl.Location_Name,
        
                                     FloorName = floor.FloorName,
      
                                     Line = line.LineName
    })
              .ToListAsync();

            return result;
        }

        // GET: api/ActualProductionResourceEntryMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActualProductionResourceEntryMaster>> GetActualProductionResourceEntryMaster(int id)
        {
            var actualProductionResourceEntryMaster = await _context.ActualProductionResourceEntryMasters.FindAsync(id);

            if (actualProductionResourceEntryMaster == null)
            {
                return NotFound();
            }

            return actualProductionResourceEntryMaster;
        }

        // PUT: api/ActualProductionResourceEntryMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActualProductionResourceEntryMaster(int id, ActualProductionResourceEntryMaster actualProductionResourceEntryMaster)
        {
            if (id != actualProductionResourceEntryMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(actualProductionResourceEntryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActualProductionResourceEntryMasterExists(id))
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

        // POST: api/ActualProductionResourceEntryMasters
        [HttpPost]
        public async Task<ActionResult<ActualProductionResourceEntryMaster>> PostActualProductionResourceEntryMaster(ActualProductionResourceEntryMaster actualProductionResourceEntryMaster)
        {
            _context.ActualProductionResourceEntryMasters.Add(actualProductionResourceEntryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActualProductionResourceEntryMaster", new { id = actualProductionResourceEntryMaster.Id }, actualProductionResourceEntryMaster);
        }

        // DELETE: api/ActualProductionResourceEntryMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActualProductionResourceEntryMaster>> DeleteActualProductionResourceEntryMaster(int id)
        {
            var actualProductionResourceEntryMaster = await _context.ActualProductionResourceEntryMasters.FindAsync(id);
            if (actualProductionResourceEntryMaster == null)
            {
                return NotFound();
            }

            _context.ActualProductionResourceEntryMasters.Remove(actualProductionResourceEntryMaster);
            await _context.SaveChangesAsync();

            return actualProductionResourceEntryMaster;
        }

        private bool ActualProductionResourceEntryMasterExists(int id)
        {
            return _context.ActualProductionResourceEntryMasters.Any(e => e.Id == id);
        }
    }
}
