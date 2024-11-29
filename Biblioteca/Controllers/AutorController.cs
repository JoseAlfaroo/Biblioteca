using Biblioteca.Contexts;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;


        // Buscar autor por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarAutor(int id)
        {
            var autor = await _context.Autores
                .Include(a => a.Pais)
                .FirstOrDefaultAsync(a => a.AutorID == id);

            if (autor == null)
            {
                return BadRequest( new { Message = "No se encontró autor por ID"} );
            }

            return Ok(new
            {
                autor.AutorID,
                autor.NombresAutor,
                autor.ApellidosAutor,
                paisAutor = autor?.Pais?.NombrePais == null ? "No se asignó pais" : autor.Pais.NombrePais
            });
        }

        // Lista autores
        [HttpGet("listar-autores")]
        public async Task<IActionResult> ListarAutores() {

            // Vamos a listar autores con relacion a paises

            var autores = await _context.Autores
                .Include(a => a.Pais) // Incluye relaciones a otras entidades
                // Personaliza la consulta
                .Select(a => new
                {
                    autorID = a.AutorID,
                    nombresAutor = a.NombresAutor,
                    apellidosAutor = a.ApellidosAutor,
                    paisAutor = a.Pais!.NombrePais == null ? "No se asignó pais" : a.Pais.NombrePais
                })
                .ToListAsync();
            return Ok(autores);
        }

        // Registrar autores, validando que exista pais
        [HttpPost]
        public async Task<IActionResult> RegistrarAutor([FromBody] Autor model)
        {
            if (model.NombresAutor == null)
            {
                return BadRequest(new { Message = "Ingrese nombres del autor" });
            }

            if (model.ApellidosAutor == null)
            {
                return BadRequest(new { Message = "Ingrese apellidos del autor" });
            }

            // PERMITIR PAIS NULO
            if (model.PaisID != null)
            {
                var paisExiste = await _context.Paises.FindAsync(model.PaisID);

                if (paisExiste == null)
                {
                    return BadRequest(new { Message = "No se encontró pais" });
                }
            }

            var nuevoAutor = new Autor
            {
                AutorID = null,
                NombresAutor = model.NombresAutor,
                ApellidosAutor = model.ApellidosAutor,
                PaisID = model.PaisID
            };

            try
            {
                _context.Autores.Add(nuevoAutor);
                await _context.SaveChangesAsync();

                // Muestra respuesta como JSON
                return Ok(new { Message = "Autor registrado correctamente", nuevoAutor });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
            
        }

        // Actualizar autores, buscarse por id
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarAutor(int id, [FromBody] Autor model)
        {
            var autorExistente = await _context.Autores.FindAsync(id);

            if (autorExistente == null)
            {
                return BadRequest(new { Message = "No se encontró autor. Ingrese ID Valida" });
            }

            if (model.NombresAutor == null)
            {
                return BadRequest(new { Message = "Ingrese nombres del autor" });
            }

            if (model.ApellidosAutor == null)
            {
                return BadRequest(new { Message = "Ingrese apellidos del autor" });
            }

            // PERMITIR PAIS NULO
            if (model.PaisID != null)
            {
                var paisExiste = await _context.Paises.FindAsync(model.PaisID);

                if (paisExiste == null)
                {
                    return BadRequest(new { Message = "No se encontró pais" });
                }
            }

            try
            {
                autorExistente.NombresAutor = model.NombresAutor;
                autorExistente.ApellidosAutor = model.ApellidosAutor;
                autorExistente.PaisID = model.PaisID;

                _context.Autores.Update(autorExistente);
                await _context.SaveChangesAsync();

                return Ok(autorExistente);
            }

            catch(Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }

        }

        // Eliminar autores, por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
            {
                return BadRequest(new { Message = "Autor no existe en base de datos"} );
            }

            try
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Autor eliminado correctamente" });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }

        }

    }
}
