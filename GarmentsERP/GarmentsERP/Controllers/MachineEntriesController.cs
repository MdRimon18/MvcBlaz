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
    public class MachineEntriesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MachineEntriesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MachineEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineEntry>>> GetMachineEntry()
        {
            var result =
              await (from MachineEntryTbl in _context.MachineEntries
                     join compInf in _context.TblCompanyInfoes on MachineEntryTbl.Company equals compInf.CompID into compInfs
                     from compInf in compInfs.DefaultIfEmpty()


                     join locationTbl in _context.TblLocationInfoes on MachineEntryTbl.Location equals locationTbl.LocationId into locationTbls
                     from locationTbl in locationTbls.DefaultIfEmpty()

                     join FloorTbl in _context.Floors on MachineEntryTbl.FloorNo equals FloorTbl.Id into FloorTbls
                     from FloorTbl in FloorTbls.DefaultIfEmpty()

                     join UOMtbl in _context.UOMs on MachineEntryTbl.CapacityUOMId equals UOMtbl.Id into UOMtbls
                     from UOMtbl in UOMtbls.DefaultIfEmpty()

                     

                    

                     orderby MachineEntryTbl.Id descending
                     select new MachineEntry
                     {

                         Id=MachineEntryTbl.Id,
         Company=MachineEntryTbl.Company,
         Attachment=MachineEntryTbl.Attachment,
         Location=MachineEntryTbl.Location,
         ProdCapacity=MachineEntryTbl.ProdCapacity==0?null: MachineEntryTbl.ProdCapacity,
         FloorNo=MachineEntryTbl.FloorNo,
         CapacityUOMId=MachineEntryTbl.CapacityUOMId,
         MachineNo=MachineEntryTbl.MachineNo,
         Brand=MachineEntryTbl.Brand,
         Category=MachineEntryTbl.Category,
         Origin=MachineEntryTbl.Origin,
         Group=MachineEntryTbl.Group,
         PurchaseDate=MachineEntryTbl.PurchaseDate,
         DiaWidth=MachineEntryTbl.DiaWidth==0?null: MachineEntryTbl.DiaWidth,
         PurchaseCost=MachineEntryTbl.PurchaseCost==0?null: MachineEntryTbl.PurchaseCost,
         Gauge=MachineEntryTbl.Gauge,
         AccumulatedDep=MachineEntryTbl.AccumulatedDep==0?null: MachineEntryTbl.AccumulatedDep,
         ExtraCylinder=MachineEntryTbl.ExtraCylinder,
         DepreciationRate=MachineEntryTbl.DepreciationRate==0?null: MachineEntryTbl.DepreciationRate,
         Nooffeeder=MachineEntryTbl.Nooffeeder,
         DepreciationMethod=MachineEntryTbl.DepreciationMethod,
         Remarks=MachineEntryTbl.Remarks,
         SequenceNo=MachineEntryTbl.SequenceNo==0?null: MachineEntryTbl.SequenceNo,
         Status=MachineEntryTbl.Status,

                         CompanyName = compInf.Company_Name,

                         LocationName = locationTbl.Location_Name,

                         OrderUomName = UOMtbl.UomName,
                         FloorName = FloorTbl.FloorName
                     }).ToListAsync();
            return result;
        }

        // GET: api/MachineEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineEntry>> GetMachineEntry(int id)
        {
            var machineEntry = await _context.MachineEntries.FindAsync(id);

            if (machineEntry == null)
            {
                return NotFound();
            }

            return machineEntry;
        }

        // PUT: api/MachineEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachineEntry(int id, MachineEntry machineEntry)
        {
            if (id != machineEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(machineEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineEntryExists(id))
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

        // POST: api/MachineEntries
        [HttpPost]
        public async Task<ActionResult<MachineEntry>> PostMachineEntry(MachineEntry machineEntry)
        {
            _context.MachineEntries.Add(machineEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMachineEntry", new { id = machineEntry.Id }, machineEntry);
        }

        // DELETE: api/MachineEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MachineEntry>> DeleteMachineEntry(int id)
        {
            var machineEntry = await _context.MachineEntries.FindAsync(id);
            if (machineEntry == null)
            {
                return NotFound();
            }

            _context.MachineEntries.Remove(machineEntry);
            await _context.SaveChangesAsync();

            return machineEntry;
        }

        private bool MachineEntryExists(int id)
        {
            return _context.MachineEntries.Any(e => e.Id == id);
        }
    }
}
