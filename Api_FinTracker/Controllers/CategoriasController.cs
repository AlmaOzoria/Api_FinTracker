using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_FinTracker.DAL;
using Data.Models;

namespace Api_FinTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly Contexto _context;

        public CategoriasController(Contexto context)
        {
            _context = context;
        }

        // Obtener todas las categorías (si es necesario para debug o administración)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categoria
                .Include(c => c.usuario)
                .ToListAsync();
        }

        // Obtener categoría específica por su id primario
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categoria
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(c => c.categoriaId == id);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        // Obtener todas las categorías de un usuario específico
        [HttpGet("PorUsuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasPorUsuario(int usuarioId)
        {
            var categorias = await _context.Categoria
                //.Include(c => c.usuario)
                .Where(c => c.usuarioId == usuarioId)
                .ToListAsync();

        
            if (categorias == null || categorias.Count == 0)
                return NotFound($"No se encontraron categorías para el usuario con ID {usuarioId}");

            return Ok(categorias);
        }

        // Crear una nueva categoría
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.categoriaId }, categoria);
        }


        // Actualizar una categoría
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.categoriaId)
                return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // Eliminar una categoría
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
                return NotFound();

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.categoriaId == id);
        }
    }
}
