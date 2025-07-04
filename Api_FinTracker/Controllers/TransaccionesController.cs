﻿using System;
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
    public class TransaccionesController : ControllerBase
    {
        private readonly Contexto _context;

        public TransaccionesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Transaccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccion>>> GetTransaccion()
        {
            return await _context.Transaccion.ToListAsync();
        }

        // GET: api/Transaccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaccion>> GetTransaccion(int id)
        {
            var transaccion = await _context.Transaccion.FindAsync(id);

            if (transaccion == null)
            {
                return NotFound();
            }

            return transaccion;
        }

        // PUT: api/Transaccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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

        // POST: api/Transaccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaccion>> PostTransaccion(Transaccion transaccion)
        {
            _context.Transaccion.Add(transaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaccion", new { id = transaccion.transaccionId }, transaccion);
        }

        // DELETE: api/Transaccions/5
        [HttpDelete("{id}")]
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

        private bool TransaccionExists(int id)
        {
            return _context.Transaccion.Any(e => e.transaccionId == id);
        }
    }
}
