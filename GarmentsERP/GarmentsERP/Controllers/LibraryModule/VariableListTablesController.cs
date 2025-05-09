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
    public class VariableListTablesController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public VariableListTablesController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/VariableListTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VariableListTable>>> GetVariableListTable()
        {
            return await _context.VariableListTables.ToListAsync();
        }

        // GET: api/VariableListTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VariableListTable>> GetVariableListTable(int id)
        {
            var variableListTable = await _context.VariableListTables.FindAsync(id);

            if (variableListTable == null)
            {
                return NotFound();
            }

            return variableListTable;
        }

        // PUT: api/VariableListTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariableListTable(int id, VariableListTable variableListTable)
        {
            if (id != variableListTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(variableListTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariableListTableExists(id))
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

        // POST: api/VariableListTables
        [HttpPost]
        public async Task<ActionResult<VariableListTable>> PostVariableListTable(VariableListTable variableListTable)
        {
            _context.VariableListTables.Add(variableListTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariableListTable", new { id = variableListTable.Id }, variableListTable);
        }

        // DELETE: api/VariableListTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VariableListTable>> DeleteVariableListTable(int id)
        {
            var variableListTable = await _context.VariableListTables.FindAsync(id);
            if (variableListTable == null)
            {
                return NotFound();
            }

            _context.VariableListTables.Remove(variableListTable);
            await _context.SaveChangesAsync();

            return variableListTable;
        }

        private bool VariableListTableExists(int id)
        {
            return _context.VariableListTables.Any(e => e.Id == id);
        }
    }
}
