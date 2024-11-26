using Biblioteca.Contexts;
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


    }
}
