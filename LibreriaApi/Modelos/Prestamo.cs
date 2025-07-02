namespace LibreriaApi.Modelos
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public string ClienteNombre { get; set; } = string.Empty;
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
        public DateTime FechaLimiteDevolucion { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public Libro? Libro { get; set; }

    }
}
