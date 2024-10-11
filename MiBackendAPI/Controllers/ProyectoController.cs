using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiBackendAPI.Data;
using MiBackendAPI.Models;

namespace MiBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProyectoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/proyecto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
        {
            return await _context.Proyecto.ToListAsync();
        }

        // GET: api/proyecto/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {
            // Si el id es 0, generar un nuevo id único
            if (proyecto.id == 0)
            {
                // Puedes obtener el último id y generar el siguiente
                proyecto.id = _context.Proyecto.Max(p => p.id) + 1;
            }

            // Verificar si el id ya existe
            if (_context.Proyecto.Any(p => p.id == proyecto.id))
            {
                return Conflict($"El proyecto con el id {proyecto.id} ya existe.");
            }

            // Si no existe, agregarlo
            _context.Proyecto.Add(proyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyecto", new { id = proyecto.id }, proyecto);
        }


        // PUT: api/proyecto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
        {
            if (id != proyecto.id)
            {
                return BadRequest();
            }

            _context.Entry(proyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(id))
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

        // DELETE: api/proyecto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            _context.Proyecto.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyecto.Any(e => e.id == id);
        }
    }
}
