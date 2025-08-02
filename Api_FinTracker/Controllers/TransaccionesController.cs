using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_FinTracker.DAL;
using Data.Models;

namespace Api_FinTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly Contexto _context;

        public TransaccionesController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccion>>> GetTransacciones()
        {
            return await _context.Transaccion
                .Include(t => t.categoria)
                .Include(t => t.usuario)
                .ToListAsync();
        }

        // Obtener una transacción específica por su id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Transaccion>> GetTransaccionById(int id)
        {
            var transaccion = await _context.Transaccion
                .Include(t => t.categoria)
                .Include(t => t.usuario)
                .FirstOrDefaultAsync(t => t.transaccionId == id);

            if (transaccion == null)
            {
                return NotFound();
            }

            return Ok(transaccion);
        }

        // Obtener todas las transacciones de un usuario específico
        [HttpGet("PorUsuario/{usuarioId:int}")]
        public async Task<ActionResult<IEnumerable<Transaccion>>> GetTransaccionesPorUsuario(int usuarioId)
        {
            var transacciones = await _context.Transaccion
                .Where(t => t.usuarioId == usuarioId)
                .Include(t => t.categoria)
                .Include(t => t.usuario)
                .ToListAsync();

            //if (transacciones == null || transacciones.Count == 0)
            //{
            //    return NotFound($"No se encontraron transacciones para el usuario con ID {usuarioId}");
            //}

            return Ok(transacciones);
        }

        // Actualizar una transacción
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTransaccion(int id, Transaccion transaccion)
        {
            if (id != transaccion.transaccionId)
            {
                return BadRequest();
            }

            _context.Entry(transaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // Crear una transacción
        [HttpPost]
        public async Task<ActionResult<Transaccion>> PostTransaccion(Transaccion transaccion)
        {
            _context.Transaccion.Add(transaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaccionById), new { id = transaccion.transaccionId }, transaccion);
        }

        // Eliminar una transacción
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTransaccion(int id)
        {
            var transaccion = await _context.Transaccion.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }

            _context.Transaccion.Remove(transaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("totales-mensuales/{usuarioId:int}")]
        public async Task<ActionResult<List<TotalMes>>> ObtenerTotalesPorMes(int usuarioId)
        {
            var totalesPorMes = await _context.Transaccion
                .Where(t => t.usuarioId == usuarioId)
                .GroupBy(t => t.fecha.Month)
                .Select(g => new TotalMes
                {
                    Mes = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key),
                    Total = g.Sum(t => t.monto)
                })
                .ToListAsync();

            return Ok(totalesPorMes);
        }

        [HttpGet("totales-anuales/{usuarioId:int}")]
        public async Task<ActionResult<List<TotalAnual>>> ObtenerTotalesPorAno(int usuarioId)
        {
            var totalesPorAno = await _context.Transaccion
                .Where(t => t.usuarioId == usuarioId)
                .GroupBy(t => t.fecha.Year)
                .Select(g => new TotalAnual
                {
                    Ano = g.Key,
                    Total = g.Sum(t => t.monto)
                })
                .ToListAsync();

            return Ok(totalesPorAno);
        }


        private bool TransaccionExists(int id)
        {
            return _context.Transaccion.Any(e => e.transaccionId == id);
        }
    }
}
