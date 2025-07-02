using LibreriaApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using LibreriaApi.Data;
using LibreriaApi.Interfaces;
using LibreriaApi.Modelos;

namespace LibreriaApi.Servicios
{
        public class LibroService : ILibroService
        {
            private readonly LibreriaDbContext _context;

            public LibroService(LibreriaDbContext context)
            {
                _context = context;
            }

            public async Task<List<Libro>> ObtenerTodosAsync()
            {
                return await _context.Libros.ToListAsync();
            }

            public async Task<Libro?> ObtenerPorIdAsync(int id)
            {
                return await _context.Libros.FindAsync(id);
            }

            public async Task<Libro> CrearAsync(Libro libro)
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
                return libro;
            }

            public async Task<bool> ActualizarAsync(int id, Libro libro)
            {
                var libroExistente = await _context.Libros.FindAsync(id);
                if (libroExistente == null)
                    return false;

                libroExistente.Titulo = libro.Titulo;
                libroExistente.Autor = libro.Autor;
                libroExistente.Disponible = libro.Disponible;
                libroExistente.Genero = libro.Genero;


            await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> EliminarAsync(int id)
            {
                var libro = await _context.Libros.FindAsync(id);
                if (libro == null)
                    return false;

                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
                return true;
            }
        }
}
