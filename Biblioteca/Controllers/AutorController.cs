using Biblioteca.Contexts;
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

        [HttpGet("listar-autores")]
        public async Task<IActionResult> ListarAutores() {
            var autorList = await _context.Autores.ToListAsync();
            return Ok(autorList);
        }
    }
}
