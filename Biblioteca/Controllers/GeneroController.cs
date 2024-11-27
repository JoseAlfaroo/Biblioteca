using Biblioteca.Contexts;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GeneroController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("listar-Generos")]
        public async Task<IActionResult> ListarGeneros()
        {
            var generos=await _context.Generos.ToListAsync();
            return Ok(generos);
        }

        [HttpPost("crear-Genero")]
        public async Task<IActionResult> CrearGenero([FromBody] Genero nuevoGenero)
        {
            if (nuevoGenero == null)
            {
                return BadRequest("El género no puede ser nulo.");
            }

            nuevoGenero.GeneroID = null;

            // Agregar el nuevo género al contexto de la base de datos
            await _context.Generos.AddAsync(nuevoGenero);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Retornar una respuesta con el objeto creado, y el código de estado 201 (Creado)
            return CreatedAtAction(nameof(CrearGenero), new { id = nuevoGenero.GeneroID }, nuevoGenero);
        }


    }
}
