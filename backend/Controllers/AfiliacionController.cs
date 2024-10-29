using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using catalogo.Models;

namespace catalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfiliacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AfiliacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Afiliacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Afiliacion>>> GetAfiliaciones()
        {
            return await _context.Afiliaciones.ToListAsync();
        }

        // GET: api/Afiliacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Afiliacion>> GetAfiliacion(int id)
        {
            var afiliacion = await _context.Afiliaciones.FindAsync(id);

            if (afiliacion == null)
            {
                return NotFound();
            }

            return afiliacion;
        }

        // POST: api/Afiliacion
        [HttpPost]
        public async Task<ActionResult<Afiliacion>> PostAfiliacion(Afiliacion afiliacion)
        {
            _context.Afiliaciones.Add(afiliacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAfiliacion), new { id = afiliacion.Id }, afiliacion);
        }

        // PUT: api/Afiliacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAfiliacion(int id, Afiliacion afiliacion)
        {
            if (id != afiliacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(afiliacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Afiliaciones.Any(e => e.Id == id))
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

        // DELETE: api/Afiliacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAfiliacion(int id)
        {
            var afiliacion = await _context.Afiliaciones.FindAsync(id);
            if (afiliacion == null)
            {
                return NotFound();
            }

            _context.Afiliaciones.Remove(afiliacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
