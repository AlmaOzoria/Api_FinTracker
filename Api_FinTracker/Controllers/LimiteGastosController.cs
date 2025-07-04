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
    public class LimiteGastosController : ControllerBase
    {
        private readonly Contexto _context;

        public LimiteGastosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/LimiteGastoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LimiteGasto>>> GetLimiteGasto()
        {
            return await _context.LimiteGasto.ToListAsync();
        }

        // GET: api/LimiteGastoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LimiteGasto>> GetLimiteGasto(int id)
        {
            var limiteGasto = await _context.LimiteGasto.FindAsync(id);

            if (limiteGasto == null)
            {
                return NotFound();
            }

            return limiteGasto;
        }

        // PUT: api/LimiteGastoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLimiteGasto(int id, LimiteGasto limiteGasto)
        {
            if (id != limiteGasto.limiteGastoId)
            {
                return BadRequest();
            }

            _context.Entry(limiteGasto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LimiteGastoExists(id))
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

        // POST: api/LimiteGastoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LimiteGasto>> PostLimiteGasto(LimiteGasto limiteGasto)
        {
            _context.LimiteGasto.Add(limiteGasto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLimiteGasto", new { id = limiteGasto.limiteGastoId }, limiteGasto);
        }

        // DELETE: api/LimiteGastoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLimiteGasto(int id)
        {
            var limiteGasto = await _context.LimiteGasto.FindAsync(id);
            if (limiteGasto == null)
            {
                return NotFound();
            }

            _context.LimiteGasto.Remove(limiteGasto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LimiteGastoExists(int id)
        {
            return _context.LimiteGasto.Any(e => e.limiteGastoId == id);
        }
    }
}
