using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // De acuerdo a nombres de las tablas
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
