using Biblioteca.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar-paises")]
        public async Task<IActionResult> ListarTodosLosPaises()
        {
            var paises = await _context.Paises.ToListAsync();
            return Ok(paises);
        }
    }
}
