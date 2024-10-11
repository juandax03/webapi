using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiBackendAPI.Data;
using MiBackendAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tipoproducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProducto>>> GetTipoProductos()
        {
            return await _context.TipoProductos.ToListAsync();
        }

        // GET: api/tipoproducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProducto>> GetTipoProducto(int id)
        {
            var tipoProducto = await _context.TipoProductos.FindAsync(id);

            if (tipoProducto == null)
            {
                return NotFound();
            }

            return tipoProducto;
        }

        [HttpPost]
        public async Task<ActionResult<TipoProducto>> PostTipoProducto(TipoProducto tipoProducto)
        {
            // Si el id es 0, generar un nuevo id único
            if (tipoProducto.Id == 0)
            {
                // Puedes obtener el último id y generar el siguiente
                tipoProducto.Id = _context.TipoProductos.Max(tp => tp.Id) + 1;
            }

            // Verificar si el id ya existe
            if (_context.TipoProductos.Any(tp => tp.Id == tipoProducto.Id))
            {
                return Conflict($"El tipo de producto con el id {tipoProducto.Id} ya existe.");
            }

            // Si no existe, agregarlo
            _context.TipoProductos.Add(tipoProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoProducto", new { id = tipoProducto.Id }, tipoProducto);
        }



        // PUT: api/tipoproducto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProducto(int id, TipoProducto tipoProducto)
        {
            if (id != tipoProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProductoExists(id))
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

        // DELETE: api/tipoproducto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProducto(int id)
        {
            var tipoProducto = await _context.TipoProductos.FindAsync(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            _context.TipoProductos.Remove(tipoProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoProductoExists(int id)
        {
            return _context.TipoProductos.Any(e => e.Id == id);
        }
    }
}
