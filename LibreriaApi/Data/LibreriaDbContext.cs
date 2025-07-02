using Microsoft.EntityFrameworkCore;
using LibreriaApi.Modelos;

namespace LibreriaApi.Data
{
    public class LibreriaDbContext : DbContext
    {
        public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options) : base(options) { }

        public DbSet<Libro> Libros => Set<Libro>();
        public DbSet<Prestamo> Prestamos => Set<Prestamo>();
    }
}