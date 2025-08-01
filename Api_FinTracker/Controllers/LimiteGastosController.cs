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

        // Obtener todos los límites de gasto (si lo necesitas)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LimiteGasto>>> GetLimiteGasto()
        {
            return await _context.LimiteGasto
                .Include(t => t.categoria)
                .Include(t => t.usuario)
                .ToListAsync();
        }

        // Obtener límite de gasto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<LimiteGasto>> GetLimiteGasto(int id)
        {
            var limiteGasto = await _context.LimiteGasto
                .Include(t => t.categoria)
                .Include(t => t.usuario)
                .FirstOrDefaultAsync(t => t.limiteGastoId == id);

            if (limiteGasto == null)
                return NotFound();

            return Ok(limiteGasto);
        }

        // Obtener todos los límites de gasto de un usuario específico
        [HttpGet("PorUsuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<LimiteGasto>>> GetPorUsuario(int usuarioId)
        {
            var limiteGasto = await _context.LimiteGasto
                 .Where(l => l.usuarioId == usuarioId)
                .Include(l => l.categoria) 
                .Include(l => l.usuario)   
                .ToListAsync();

            return Ok(limiteGasto);
        }


        // Crear nuevo límite de gasto
        [HttpPost]
        public async Task<ActionResult<LimiteGasto>> PostLimiteGasto(LimiteGasto limiteGasto)
        {
            _context.LimiteGasto.Add(limiteGasto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLimiteGasto),
                new { id = limiteGasto.limiteGastoId }, limiteGasto);
        }

        // Actualizar un límite de gasto
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLimiteGasto(int id, LimiteGasto limiteGasto)
        {
            if (id != limiteGasto.limiteGastoId)
                return BadRequest();

            _context.Entry(limiteGasto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LimiteGastoExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // Eliminar un límite de gasto
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLimiteGasto(int id)
        {
            var limiteGasto = await _context.LimiteGasto.FindAsync(id);
            if (limiteGasto == null)
                return NotFound();

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
