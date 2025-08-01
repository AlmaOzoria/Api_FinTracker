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

        // Obtener todos los pagos recurrentes 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagoRecurrente>>> GetPagoRecurrentes()
        {
            return await _context.PagoRecurrente
                .Include(p => p.categoria)
                .Include(p => p.usuario)
                .ToListAsync();
        }

        // Obtener un pago recurrente específico por su Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PagoRecurrente>> GetPagoRecurrente(int id)
        {
            var pagoRecurrente = await _context.PagoRecurrente
                .Include(p => p.categoria)
                .Include(p => p.usuario)
                .FirstOrDefaultAsync(p => p.pagoRecurrenteId == id);

            if (pagoRecurrente == null)
                return NotFound();

            return Ok(pagoRecurrente);
        }

        // Nuevo endpoint: obtener todos los pagos recurrentes de un usuario específico
        [HttpGet("PorUsuario/{usuarioId:int}")]
        public async Task<ActionResult<IEnumerable<PagoRecurrente>>> GetPagoRecurrentesPorUsuario(int usuarioId)
        {
            var pagos = await _context.PagoRecurrente
                 .Where(p => p.usuarioId == usuarioId)
                .Include(p => p.categoria)
                .Include(p => p.usuario)
                .ToListAsync();

            //if (pagos == null || pagos.Count == 0)
            //    return NotFound($"No se encontraron pagos recurrentes para el usuario con ID {usuarioId}");

            return Ok(pagos);
        }

        // Actualizar un pago recurrente
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPagoRecurrente(int id, PagoRecurrente pagoRecurrente)
        {
            if (id != pagoRecurrente.pagoRecurrenteId)
                return BadRequest();

            _context.Entry(pagoRecurrente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoRecurrenteExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // Crear un nuevo pago recurrente
        [HttpPost]
        public async Task<ActionResult<PagoRecurrente>> PostPagoRecurrente(PagoRecurrente pagoRecurrente)
        {
            _context.PagoRecurrente.Add(pagoRecurrente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPagoRecurrente), new { id = pagoRecurrente.pagoRecurrenteId }, pagoRecurrente);
        }

        // Eliminar un pago recurrente
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePagoRecurrente(int id)
        {
            var pagoRecurrente = await _context.PagoRecurrente.FindAsync(id);
            if (pagoRecurrente == null)
                return NotFound();

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
