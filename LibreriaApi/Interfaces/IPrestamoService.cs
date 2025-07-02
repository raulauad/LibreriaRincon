using LibreriaApi.Modelos;
using LibreriaApi.Interfaces;

namespace LibreriaApi.Interfaces
{
    public interface IPrestamoService
    {
        Task<List<Prestamo>> ObtenerTodosAsync();
        Task<Prestamo?> ObtenerPorIdAsync(int id);
        Task<Prestamo> CrearAsync(Prestamo prestamo);
        Task<bool> DevolverLibroAsync(int prestamoId, DateTime fechaDevolucion);
        decimal CalcularInteres(Prestamo prestamo);
    }
}
