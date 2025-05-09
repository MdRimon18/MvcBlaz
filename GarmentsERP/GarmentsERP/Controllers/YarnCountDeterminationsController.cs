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
    public class YarnCountDeterminationsController : ControllerBase
    {
        private readonly GarmentERPContext _context;

        public YarnCountDeterminationsController(GarmentERPContext context)
        {
            _context = context;
        }

        // GET: api/YarnCountDeterminations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YarnCountDetermination>>> GetYarnCountDetermination()
        {
           
            var yarnCountDeterminationList = _context.YarnCountDeterminations.OrderBy(o=>o.Id).ToList();
            var yarnCountList = _context.YarnCounts.ToList();
            foreach (var y in yarnCountDeterminationList)
            {
                var yarnChildList = _context.YarnCountDeterminationChilds.Where(w => w.YarnCountDeterminationMasterId == y.Id).ToList();
                //y.YarnCountDeterminationChildList = yarnChildList;

                var compName = "";
                foreach (var item in yarnChildList)
                {
                    
                    var yarnObj = yarnCountList.FirstOrDefault(f => f.Id == item.YarnCountId)?.Name;
                    item.CompositionName = _context.Compositions.FirstOrDefault(f => f.Id == item.CompositionId)?.CompositionName;
                    compName = compName + item.CompositionName + ' ' + item.Percentage + ' ' + yarnObj + ' ' + item.Type + ",";
                }

                y.Status = compName;


            }
            return  yarnCountDeterminationList;
        }

        // GET: api/YarnCountDeterminations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YarnCountDetermination>> GetYarnCountDetermination(int id)
        {
            var yarnCountDetermination = await _context.YarnCountDeterminations.FindAsync(id);

            if (yarnCountDetermination == null)
            {
                return NotFound();
            }

            return yarnCountDetermination;
        }

        // PUT: api/YarnCountDeterminations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYarnCountDetermination(int id, YarnCountDetermination yarnCountDetermination)
        {
            if (id != yarnCountDetermination.Id)
            {
                return BadRequest();
            }
            if (yarnCountDetermination.YarnCountDeterminationChildList != null)
            {
                foreach (var v in yarnCountDetermination.YarnCountDeterminationChildList)
                {
                    v.YarnCountDeterminationMasterId = yarnCountDetermination.Id;
                    if (v.Id != 0)
                    {
                       
                        _context.Entry(v).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.YarnCountDeterminationChilds.Add(v);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            
            _context.Entry(yarnCountDetermination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnCountDeterminationExists(id))
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

        // POST: api/YarnCountDeterminations
        [HttpPost]
        public async Task<ActionResult<YarnCountDetermination>> PostYarnCountDetermination(YarnCountDetermination yarnCountDetermination)
        {
            try
            {
                _context.YarnCountDeterminations.Add(yarnCountDetermination);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {

            }
            

            foreach(var child in yarnCountDetermination.YarnCountDeterminationChildList)
            {
                child.YarnCountDeterminationMasterId = yarnCountDetermination.Id;
                _context.YarnCountDeterminationChilds.Add(child);
                
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetYarnCountDetermination", new { id = yarnCountDetermination.Id }, yarnCountDetermination);
        }

        // DELETE: api/YarnCountDeterminations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YarnCountDetermination>> DeleteYarnCountDetermination(int id)
        {
            var yarnCountDetermination = await _context.YarnCountDeterminations.FindAsync(id);
            if (yarnCountDetermination == null)
            {
                return NotFound();
            }

            _context.YarnCountDeterminations.Remove(yarnCountDetermination);
            var yarnChildListByMasterId= _context.YarnCountDeterminationChilds.Where(w => w.YarnCountDeterminationMasterId == id).ToList();
            if (yarnChildListByMasterId != null)
            {
                foreach (var i in yarnChildListByMasterId)
                {
                    var yarnCountDeterminationChild = await _context.YarnCountDeterminationChilds.FindAsync(i.Id);
                    if (yarnCountDeterminationChild == null)
                    {
                        return NotFound();
                    }
                    _context.YarnCountDeterminationChilds.Remove(yarnCountDeterminationChild);
                }
            }
           
            await _context.SaveChangesAsync();

            return yarnCountDetermination;
        }

        private bool YarnCountDeterminationExists(int id)
        {
            return _context.YarnCountDeterminations.Any(e => e.Id == id);
        }
    }
}
