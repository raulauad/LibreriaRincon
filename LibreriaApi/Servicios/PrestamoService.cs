using LibreriaApi.Data;
using LibreriaApi.Interfaces;
using LibreriaApi.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApi.Servicios
{
    public class PrestamoService : IPrestamoService
    {

        private readonly LibreriaDbContext _context;

        public PrestamoService(LibreriaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Prestamo>> ObtenerTodosAsync()
        {
            return await _context.Prestamos.Include(p => p.Libro).ToListAsync();
        }

        public async Task<Prestamo?> ObtenerPorIdAsync(int id)
        {
            return await _context.Prestamos.Include(p => p.Libro)
                                           .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Prestamo> CrearAsync(Prestamo prestamo)
        {
            var libro = await _context.Libros.FindAsync(prestamo.LibroId);
            if (libro == null || !libro.Disponible)
                throw new InvalidOperationException("El libro no está disponible.");

            libro.Disponible = false;
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }

        public async Task<bool> DevolverLibroAsync(int prestamoId, DateTime fechaDevolucion)
        {
            var prestamo = await _context.Prestamos.Include(p => p.Libro)
                                                   .FirstOrDefaultAsync(p => p.Id == prestamoId);
            if (prestamo == null || prestamo.FechaDevolucion != null)
                return false;

            prestamo.FechaDevolucion = fechaDevolucion;
            prestamo.Libro!.Disponible = true;

            await _context.SaveChangesAsync();
            return true;
        }


        public decimal CalcularInteres(Prestamo prestamo)
        {
            if (prestamo.FechaDevolucion.HasValue && prestamo.FechaDevolucion > prestamo.FechaLimiteDevolucion)
            {
                var diasRetraso = (prestamo.FechaDevolucion.Value - prestamo.FechaLimiteDevolucion).Days;
                return diasRetraso * 10m; // Ejemplo: $10 por día de retraso
            }

            return 0m;
        }
    }
}
