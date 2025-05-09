using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarmentsERP.Model;
using GarmentsERP.Model.LibraryModule;

namespace GarmentsERP.Controllers.LibraryModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariableSettingsTablesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public VariableSettingsTablesController(GarmentERPContext context)
        {
            _context =context;
        }

        // GET: api/VariableSettingsTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VariableSettingsTable>>> GetVariableSettingsTable()
        {
            return await _context.VariableSettingsTables.ToListAsync();
        }

        // GET: api/VariableSettingsTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VariableSettingsTable>> GetVariableSettingsTable(int id)
        {
            var variableSettingsTable = await _context.VariableSettingsTables.FindAsync(id);

            if (variableSettingsTable == null)
            {
                return NotFound();
            }

            return variableSettingsTable;
        }

        // PUT: api/VariableSettingsTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariableSettingsTable(int id, VariableSettingsTable variableSettingsTable)
        {
            if (id != variableSettingsTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(variableSettingsTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariableSettingsTableExists(id))
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

        // POST: api/VariableSettingsTables
        [HttpPost]
        public async Task<ActionResult<VariableSettingsTable>> PostVariableSettingsTable(VariableSettingsTable variableSettingsTable)
        {
            _context.VariableSettingsTables.Add(variableSettingsTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariableSettingsTable", new { id = variableSettingsTable.Id }, variableSettingsTable);
        }

        // DELETE: api/VariableSettingsTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VariableSettingsTable>> DeleteVariableSettingsTable(int id)
        {
            var variableSettingsTable = await _context.VariableSettingsTables.FindAsync(id);
            if (variableSettingsTable == null)
            {
                return NotFound();
            }

            _context.VariableSettingsTables.Remove(variableSettingsTable);
            await _context.SaveChangesAsync();

            return variableSettingsTable;
        }

        private bool VariableSettingsTableExists(int id)
        {
            return _context.VariableSettingsTables.Any(e => e.Id == id);
        }
    }
}
