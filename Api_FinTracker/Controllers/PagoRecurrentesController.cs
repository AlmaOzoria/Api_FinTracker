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
    public class PagoRecurrentesController : ControllerBase
    {
        private readonly Contexto _context;

        public PagoRecurrentesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/PagoRecurrentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagoRecurrente>>> GetPagoRecurrente()
        {
            return await _context.PagoRecurrente
                .Include(t => t.categoria)
                .ToListAsync();
        }

        // GET: api/PagoRecurrentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PagoRecurrente>> GetPagoRecurrente(int id)
        {
            var pagoRecurrente = await _context.PagoRecurrente
                .Include(t => t.categoria)
                .FirstOrDefaultAsync(t => t.categoriaId == id);

            if (pagoRecurrente == null)
            {
                return NotFound();
            }

            return pagoRecurrente;
        }

        // PUT: api/PagoRecurrentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagoRecurrente(int id, PagoRecurrente pagoRecurrente)
        {
            if (id != pagoRecurrente.pagoRecurrenteId)
            {
                return BadRequest();
            }

            _context.Entry(pagoRecurrente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoRecurrenteExists(id))
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

        // POST: api/PagoRecurrentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PagoRecurrente>> PostPagoRecurrente(PagoRecurrente pagoRecurrente)
        {
            _context.PagoRecurrente.Add(pagoRecurrente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagoRecurrente", new { id = pagoRecurrente.pagoRecurrenteId }, pagoRecurrente);
        }

        // DELETE: api/PagoRecurrentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagoRecurrente(int id)
        {
            var pagoRecurrente = await _context.PagoRecurrente.FindAsync(id);
            if (pagoRecurrente == null)
            {
                return NotFound();
            }

            _context.PagoRecurrente.Remove(pagoRecurrente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagoRecurrenteExists(int id)
        {
            return _context.PagoRecurrente.Any(e => e.pagoRecurrenteId == id);
        }
    }
}
