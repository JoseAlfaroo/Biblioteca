using Biblioteca.Contexts;
using Biblioteca.DTO;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO model)
        {
            if (model.Nombres == null)
            {
                return BadRequest(new { Message = "Los nombres son obligatorios" });
            }

            if (model.Apellidos == null)
            {
                return BadRequest(new { Message = "Los apellidos son obligatorios" });
            }

            if (model.Email == null)
            {
                return BadRequest(new { Message = "El correo es obligatorio" });
            }

            if (model.Username == null)
            {
                return BadRequest(new { Message = "El nombre de usuario es obligatorio" });
            }

            if (model.Password == null)
            {
                return BadRequest(new { Message = "La contraseña es obligatoria" });
            }

            var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(model.Email, emailRegex))
            {
                return BadRequest(new { Message = "El formato del correo no es válido" });
            }

            var username = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == model.Username);

            if (username != null)
            {
                return Conflict(new { Message = "El nombre de usuario ya está registrado" });
            }

            var email = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == model.Email);


            if (email != null)
            {
                return Conflict(new { Message = "El correo ya está registrado" });
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var nuevoUsuario = new Usuario
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IntentosFallidos = 0,
                UltimoIntento = DateTime.Now,
                RolId = 2
            };

            try
            {
                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Usuario creado correctamente" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.ToString() });
            }
        }
    }
}
