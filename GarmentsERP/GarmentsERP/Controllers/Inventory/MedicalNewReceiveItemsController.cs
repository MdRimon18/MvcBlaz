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
    public class MedicalNewReceiveItemsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public MedicalNewReceiveItemsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/MedicalNewReceiveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalNewReceiveItem>>> GetMedicalNewReceiveItem()
        {
            return await _context.MedicalNewReceiveItems.ToListAsync();
        }

        // GET: api/MedicalNewReceiveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalNewReceiveItem>> GetMedicalNewReceiveItem(int id)
        {
            var medicalNewReceiveItem = await _context.MedicalNewReceiveItems.FindAsync(id);

            if (medicalNewReceiveItem == null)
            {
                return NotFound();
            }

            return medicalNewReceiveItem;
        }

        // PUT: api/MedicalNewReceiveItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalNewReceiveItem(int id, MedicalNewReceiveItem medicalNewReceiveItem)
        {
            if (id != medicalNewReceiveItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicalNewReceiveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalNewReceiveItemExists(id))
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

        // POST: api/MedicalNewReceiveItems
        [HttpPost]
        public async Task<ActionResult<MedicalNewReceiveItem>> PostMedicalNewReceiveItem(MedicalNewReceiveItem medicalNewReceiveItem)
        {
            _context.MedicalNewReceiveItems.Add(medicalNewReceiveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalNewReceiveItem", new { id = medicalNewReceiveItem.Id }, medicalNewReceiveItem);
        }

        // DELETE: api/MedicalNewReceiveItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalNewReceiveItem>> DeleteMedicalNewReceiveItem(int id)
        {
            var medicalNewReceiveItem = await _context.MedicalNewReceiveItems.FindAsync(id);
            if (medicalNewReceiveItem == null)
            {
                return NotFound();
            }

            _context.MedicalNewReceiveItems.Remove(medicalNewReceiveItem);
            await _context.SaveChangesAsync();

            return medicalNewReceiveItem;
        }

        private bool MedicalNewReceiveItemExists(int id)
        {
            return _context.MedicalNewReceiveItems.Any(e => e.Id == id);
        }
    }
}
