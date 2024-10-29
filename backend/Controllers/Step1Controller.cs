// Controllers/Step1Controller.cs
using Microsoft.AspNetCore.Mvc;
using catalogo.Models;
using catalogo.Forms;
using System.Threading.Tasks;

namespace catalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Step1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Step1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Step1 - Muestra un ejemplo o un formulario vacío
        [HttpGet]
        public IActionResult GetStep1()
        {
            var step1 = new Step1DTO
            {
                Aplicacion = string.Empty,
                TipoAfiliacion = string.Empty,
                Nombre = string.Empty,
                Rubro = string.Empty
            };
            return Ok(step1);
        }

        // POST: api/Step1 - Crea una nueva entrada en Afiliacion y Empresa
        [HttpPost]
        public async Task<IActionResult> PostStep1([FromBody] Step1DTO step1)
        {
            // Crea la entidad Afiliacion
            var afiliacion = new Afiliacion
            {
                Aplicacion = step1.Aplicacion,
                TipoAfiliacion = step1.TipoAfiliacion
            };
            _context.Afiliaciones.Add(afiliacion);
            await _context.SaveChangesAsync();

            // Crea la entidad Empresa
            var empresa = new Empresa
            {
                Nombre = step1.Nombre,
                Rubro = step1.Rubro
            };
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            // Construir el objeto de respuesta personalizado
            var response = new
            {
                afiliacion = new
                {
                    afiliacion.Id,
                    afiliacion.Aplicacion,
                    afiliacion.TipoAfiliacion,
                    afiliacion.Fecha
                },
                empresa = new
                {
                    empresa.Id,
                    empresa.Nombre,
                    empresa.Rubro
                },
                forward = "step2"
            };

            // Devolver una respuesta 200 con el objeto JSON personalizado
            return Ok(response);
        }

        // PUT: api/Step1 - Actualiza las entradas de Afiliacion y Empresa
        [HttpPut("{idAfiliacion}/{idEmpresa}")]
        public async Task<IActionResult> PutStep1(int idAfiliacion, int idEmpresa, [FromBody] Step1DTO step1)
        {
            var afiliacion = await _context.Afiliaciones.FindAsync(idAfiliacion);
            var empresa = await _context.Empresas.FindAsync(idEmpresa);

            if (afiliacion == null || empresa == null)
            {
                return NotFound();
            }

            // Actualiza los campos
            afiliacion.Aplicacion = step1.Aplicacion;
            afiliacion.TipoAfiliacion = step1.TipoAfiliacion;
            empresa.Nombre = step1.Nombre;
            empresa.Rubro = step1.Rubro;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
