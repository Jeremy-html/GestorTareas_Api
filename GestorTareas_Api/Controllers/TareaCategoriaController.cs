using GestorTareas_Api.Data;
using GestorTareas_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas_Api.Controllers
{
    [Authorize] // <-- Esto obliga a que el usuario tenga un JWT válido
    [ApiController]
    [Route("api/[controller]")]
    public class TareaCategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TareaCategoriaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TareaCategoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaCategoria>>> GetTareaCategorias()
        {
            // Incluimos las entidades relacionadas si es necesario
            return await _context.TareaCategorias
                .Include(tc => tc.Tarea)
                .Include(tc => tc.Categoria)
                .ToListAsync();
        }

        // GET: api/TareaCategoria/{idTarea}/{idCategoria}
        [HttpGet("{idTarea}/{idCategoria}")]
        public async Task<ActionResult<TareaCategoria>> GetTareaCategoria(int idTarea, int idCategoria)
        {
            var tareaCategoria = await _context.TareaCategorias.FindAsync(idTarea, idCategoria);

            if (tareaCategoria == null)
            {
                return NotFound();
            }

            return tareaCategoria;
        }

        // POST: api/TareaCategoria
        [HttpPost]
        public async Task<ActionResult<TareaCategoria>> PostTareaCategoria(TareaCategoria tareaCategoria)
        {
            _context.TareaCategorias.Add(tareaCategoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTareaCategoria),
                new { idTarea = tareaCategoria.ID_Tarea, idCategoria = tareaCategoria.ID_Categoria },
                tareaCategoria);
        }

        // PUT: api/TareaCategoria/{idTarea}/{idCategoria}
        [HttpPut("{idTarea}/{idCategoria}")]
        public async Task<IActionResult> PutTareaCategoria(int idTarea, int idCategoria, TareaCategoria tareaCategoria)
        {
            if (idTarea != tareaCategoria.ID_Tarea || idCategoria != tareaCategoria.ID_Categoria)
            {
                return BadRequest();
            }

            _context.Entry(tareaCategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaCategoriaExists(idTarea, idCategoria))
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

        // DELETE: api/TareaCategoria/{idTarea}/{idCategoria}
        [HttpDelete("{idTarea}/{idCategoria}")]
        public async Task<IActionResult> DeleteTareaCategoria(int idTarea, int idCategoria)
        {
            var tareaCategoria = await _context.TareaCategorias.FindAsync(idTarea, idCategoria);
            if (tareaCategoria == null)
            {
                return NotFound();
            }

            _context.TareaCategorias.Remove(tareaCategoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TareaCategoriaExists(int idTarea, int idCategoria)
        {
            return _context.TareaCategorias.Any(tc => tc.ID_Tarea == idTarea && tc.ID_Categoria == idCategoria);
        }
    }
}
