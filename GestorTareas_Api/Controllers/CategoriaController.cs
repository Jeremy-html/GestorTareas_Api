﻿using GestorTareas_Api.Data;
using GestorTareas_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // POST: api/Categorias
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            // Devuelve la categoría creada con su ID asignado
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.ID_Categoria }, categoria);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.ID_Categoria)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.ID_Categoria == id);
        }
    }
}
