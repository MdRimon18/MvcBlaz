using GarmentsERP.Model;
using GarmentsERP.Models; // Assuming your models are in this namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Controllers.Garments.Inventory.ViewsNspController
{
    [Route("api/inventoryViewNsp")]
    [ApiController]
    public class InventoryViewNspController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public InventoryViewNspController(GarmentERPContext context)
        {
            _context = context;
        }

        // api/inventoryViewNsp/view_gate_pass_entry_list
        //[HttpGet("view_gate_pass_entry_list")]
        //public ActionResult<IEnumerable<view_gate_pass_entry_list>> GetViewGatePassEntryList()
        //{
        //    try
        //    {
        //        return _context.view_gate_pass_entry_list.ToList();
        //    }
        //    catch (Exception)
        //    {
        //        // Consider logging the exception for debugging purposes
        //        return StatusCode(500); // Return a generic server error
        //    }
        //}

        // GET: api/inventoryViewNsp/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST: api/inventoryViewNsp
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            // Implementation for POST request
            return NoContent(); // Or a CreatedAtAction if you create a resource
        }

        // PUT: api/inventoryViewNsp/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            // Implementation for PUT request
            return NoContent();
        }

        // DELETE: api/inventoryViewNsp/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Implementation for DELETE request
            return NoContent();
        }
    }
}