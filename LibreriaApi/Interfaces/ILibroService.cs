using LibreriaApi.Modelos;

namespace LibreriaApi.Interfaces
{
    public interface ILibroService
    {
        Task<List<Libro>> ObtenerTodosAsync();
        Task<Libro?> ObtenerPorIdAsync(int id);
        Task<Libro> CrearAsync(Libro libro);
        Task<bool> ActualizarAsync(int id, Libro libro);
        Task<bool> EliminarAsync(int id);
    }
}
