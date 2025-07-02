using LibreriaApi.Interfaces;
using LibreriaApi.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaApi.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var libros = await _libroService.ObtenerTodosAsync();
            return Ok(libros);
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var libro = await _libroService.ObtenerPorIdAsync(id);
            if (libro == null)
                return NotFound();

            return Ok(libro);
        }

        // POST: api/Libros
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Libro libro)
        {
            var nuevoLibro = await _libroService.CrearAsync(libro);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoLibro.Id }, nuevoLibro);
        }

        // PUT: api/Libros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Libro libro)
        {
            var resultado = await _libroService.ActualizarAsync(id, libro);
            if (!resultado)
                return NotFound();

            return Ok("Libro actualizado correctamente.");
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _libroService.EliminarAsync(id);
            if (!eliminado)
                return NotFound();

            return Ok("Libro eliminado correctamente.");
        }


        [HttpDelete("eliminar-todos")]
        public async Task<IActionResult> EliminarTodos()
        {
            var libros = await _libroService.ObtenerTodosAsync();

            foreach (var libro in libros)
            {
                await _libroService.EliminarAsync(libro.Id);
            }

            return Ok("Todos los libros fueron eliminados.");
        }

    }
}
