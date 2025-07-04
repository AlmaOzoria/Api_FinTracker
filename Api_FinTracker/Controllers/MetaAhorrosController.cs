using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_FinTracker.DAL;
using Data.Models;

namespace Api_FinTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaAhorrosController : ControllerBase
    {
        private readonly Contexto _context;

        public MetaAhorrosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/MetaAhorroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaAhorro>>> GetMetaAhorro()
        {
            return await _context.MetaAhorro.ToListAsync();
        }

        // GET: api/MetaAhorroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetaAhorro>> GetMetaAhorro(int id)
        {
            var metaAhorro = await _context.MetaAhorro.FindAsync(id);

            if (metaAhorro == null)
            {
                return NotFound();
            }

            return metaAhorro;
        }

        // PUT: api/MetaAhorroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetaAhorro(int id, MetaAhorro metaAhorro)
        {
            if (id != metaAhorro.metaAhorroId)
            {
                return BadRequest();
            }

            _context.Entry(metaAhorro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaAhorroExists(id))
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

        // POST: api/MetaAhorroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetaAhorro>> PostMetaAhorro(MetaAhorro metaAhorro)
        {
            _context.MetaAhorro.Add(metaAhorro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetaAhorro", new { id = metaAhorro.metaAhorroId }, metaAhorro);
        }

        // DELETE: api/MetaAhorroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetaAhorro(int id)
        {
            var metaAhorro = await _context.MetaAhorro.FindAsync(id);
            if (metaAhorro == null)
            {
                return NotFound();
            }

            _context.MetaAhorro.Remove(metaAhorro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetaAhorroExists(int id)
        {
            return _context.MetaAhorro.Any(e => e.metaAhorroId == id);
        }
    }
}
