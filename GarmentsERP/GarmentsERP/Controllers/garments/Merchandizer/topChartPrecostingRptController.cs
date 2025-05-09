using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GarmentsERP.Models;
using GarmentsERP.Model;
using GarmentsERP.Repositories;

namespace GarmentsERP.Controllers.Garments.Merchandizer
{
    [Route("api/[controller]")]
    [ApiController]
    public class topChartPrecostingRptController : ControllerBase
    {
        private readonly GarmentERPContext _context;
        private readonly DapperRepository _dapperRepository;
        public topChartPrecostingRptController(GarmentERPContext context, DapperRepository dapperRepository)
        {
            _context = context;
            _dapperRepository = dapperRepository;
        }

        // GET: api/topChartPrecostingRpt
        [HttpGet]
        public ActionResult<IEnumerable<TopChartPreCostingRpt_Result>> Get()
        {
            var result = _dapperRepository.TopChartPreCostingRpt(0);
            return Ok(result);
        }

        // GET: api/topChartPrecostingRpt/5
        [HttpGet("{orderId}")]
        public ActionResult<IEnumerable<TopChartPreCostingRpt_Result>> Get(int orderId)
        {
            var result = _dapperRepository.TopChartPreCostingRpt(0);
            return Ok(result);
        }

        // POST: api/topChartPrecostingRpt
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT: api/topChartPrecostingRpt/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE: api/topChartPrecostingRpt/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}