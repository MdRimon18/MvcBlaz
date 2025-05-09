using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarmentsERP.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarmentsERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostComponentsMasterController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public CostComponentsMasterController(GarmentERPContext context)
        {
    

            _context = context;
        }
        // GET: api/CostComponentsMasters
        [HttpGet]
        public IEnumerable<CostComponentsMaster> Get()

        {
            

            return _context.CostComponentsMasters;
        }

        // GET: api/CostComponentsMasters/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CostComponentsMasters
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // List<CostComponentsMasters> costComponentsMasters = new List<CostComponentsMasters>();
            //costComponentsMasters.Add(new CostComponentsMasters {Id=1, Cost_ComponetName = "Fabric Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 2, Cost_ComponetName = "Trims Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 3, Cost_ComponetName = "Embel. Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 4, Cost_ComponetName = "Gmts. Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 5, Cost_ComponetName = "Comml. Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 6, Cost_ComponetName = "Lab Test" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 7, Cost_ComponetName = "Inspection" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 8, Cost_ComponetName = "Freight" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 9, Cost_ComponetName = "Currier Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 10, Cost_ComponetName = "Certificate Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 11, Cost_ComponetName = "Deffd .Lc Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 12, Cost_ComponetName = "Design Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 13, Cost_ComponetName = "Studio Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 14, Cost_ComponetName = "Opert. Exp." });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 15, Cost_ComponetName = "CM Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 16, Cost_ComponetName = "Interest" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 17, Cost_ComponetName = "Income Tax" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 18, Cost_ComponetName = "Depc. & Amort." });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 19, Cost_ComponetName = "Commission" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 20, Cost_ComponetName = "Total Cost" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 21, Cost_ComponetName = "Price/Dzn	" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 22, Cost_ComponetName = "Margin/Dzn" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 23, Cost_ComponetName = "Price/Pcs" });
            //costComponentsMasters.Add(new CostComponentsMasters { Id = 24, Cost_ComponetName = "Final Cost/Pcs" });
            // costComponentsMasters.Add(new CostComponentsMasters { Id = 25, Cost_ComponetName = "Margin/pcs" });
            //foreach(var cost in costComponentsMasters)
            //{
            //    _context.Add(cost);
            //    _context.SaveChanges();
            //}


        }

        // PUT: api/CostComponentsMasters/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
