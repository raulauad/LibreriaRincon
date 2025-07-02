using LibreriaApi.Interfaces;
using LibreriaApi.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaApi.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamosController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var prestamos = await _prestamoService.ObtenerTodosAsync();

            var prestamosDto = prestamos
                .Where(p => p.FechaDevolucion == null) // solo activos
               .Select(p => new PrestamoDto
               {
                   Id = p.Id,
                   Titulo = p.Libro?.Titulo ?? "Sin título",
                   Autor = p.Libro?.Autor ?? "Sin autor",
                   Genero = p.Libro?.Genero ?? "Sin género",
                   FechaPrestamo = p.FechaPrestamo,
                   FechaLimite = p.FechaLimiteDevolucion
               });

            return Ok(prestamosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var prestamo = await _prestamoService.ObtenerPorIdAsync(id);
            if (prestamo == null) return NotFound();
            return Ok(prestamo);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Prestamo prestamo)
        {
            try
            {
                var nuevoPrestamo = await _prestamoService.CrearAsync(prestamo);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoPrestamo.Id }, nuevoPrestamo);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("devolver/{id}")]
        public async Task<IActionResult> Devolver(int id, [FromBody] DateTime fechaDevolucion)
        {
            var exito = await _prestamoService.DevolverLibroAsync(id, fechaDevolucion);
            if (!exito) return BadRequest("No se pudo devolver el libro.");
            return Ok("Libro devuelto correctamente.");
        }

        [HttpGet("{id}/interes")]
        public async Task<IActionResult> CalcularInteres(int id)
        {
            var prestamo = await _prestamoService.ObtenerPorIdAsync(id);
            if (prestamo == null) return NotFound();

            var interes = _prestamoService.CalcularInteres(prestamo);
            return Ok(new { Interes = interes });
        }
    }
}
