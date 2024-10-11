using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiBackendAPI.Data;
using MiBackendAPI.Models;

namespace MiBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminoClaveController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TerminoClaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/terminoclave
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TerminoClave>>> GetTerminoClaves()
        {
            return await _context.TerminoClaves.ToListAsync();
        }

        // GET: api/terminoclave/{termino}
        [HttpGet("{termino}")]
        public async Task<ActionResult<TerminoClave>> GetTerminoClave(string termino)
        {
            var terminoClave = await _context.TerminoClaves.FindAsync(termino);

            if (terminoClave == null)
            {
                return NotFound();
            }

            return terminoClave;
        }

        // POST: api/terminoclave
        [HttpPost]
        public async Task<ActionResult<TerminoClave>> PostTerminoClave(TerminoClave terminoClave)
        {
            _context.TerminoClaves.Add(terminoClave);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTerminoClave), new { termino = terminoClave.termino }, terminoClave);
        }

        // PUT: api/terminoclave/{termino}
        [HttpPut("{termino}")]
        public async Task<IActionResult> PutTerminoClave(string termino, TerminoClave terminoClave)
        {
            if (termino != terminoClave.termino)
            {
                return BadRequest();
            }

            _context.Entry(terminoClave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerminoClaveExists(termino))
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

        // DELETE: api/terminoclave/{termino}
        [HttpDelete("{termino}")]
        public async Task<IActionResult> DeleteTerminoClave(string termino)
        {
            var terminoClave = await _context.TerminoClaves.FindAsync(termino);
            if (terminoClave == null)
            {
                return NotFound();
            }

            _context.TerminoClaves.Remove(terminoClave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TerminoClaveExists(string termino)
        {
            return _context.TerminoClaves.Any(e => e.termino == termino);
        }

    }
}
