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

        // Obtener todas las metas (por si necesitas debug o administración)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaAhorro>>> GetMetaAhorros()
        {
            return await _context.MetaAhorro
                .Include(m => m.usuario)
                .ToListAsync();
        }

        // Obtener una meta de ahorro específica por su Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MetaAhorro>> GetMetaAhorro(int id)
        {
            var metaAhorro = await _context.MetaAhorro
                .Include(m => m.usuario)
                .FirstOrDefaultAsync(m => m.metaAhorroId == id);

            if (metaAhorro == null)
                return NotFound();

            return Ok(metaAhorro);
        }

        // Obtener todas las metas de un usuario específico
        [HttpGet("PorUsuario/{usuarioId:int}")]
        public async Task<ActionResult<IEnumerable<MetaAhorro>>> GetMetaAhorrosPorUsuario(int usuarioId)
        {
            var metas = await _context.MetaAhorro
                 .Where(m => m.usuarioId == usuarioId)
                .Include(m => m.usuario)
                .ToListAsync();

            //if (metas == null || metas.Count == 0)
            //    return NotFound($"No se encontraron metas de ahorro para el usuario con ID {usuarioId}");

            return Ok(metas);
        }

        // Crear una nueva meta de ahorro
        [HttpPost]
        public async Task<ActionResult<MetaAhorro>> PostMetaAhorro(MetaAhorro metaAhorro)
        {
            _context.MetaAhorro.Add(metaAhorro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMetaAhorro), new { id = metaAhorro.metaAhorroId }, metaAhorro);
        }

        // Actualizar una meta de ahorro
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutMetaAhorro(int id, MetaAhorro metaAhorro)
        {
            if (id != metaAhorro.metaAhorroId)
                return BadRequest();

            _context.Entry(metaAhorro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaAhorroExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // Eliminar una meta de ahorro
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMetaAhorro(int id)
        {
            var metaAhorro = await _context.MetaAhorro.FindAsync(id);
            if (metaAhorro == null)
                return NotFound();

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
