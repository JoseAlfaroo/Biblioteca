using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // De acuerdo a nombres de las tablas
        public DbSet<Pais> Paises { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Genero> Generos { get; set; }
    }
}
