namespace LibreriaApi.Modelos
{
    public class PrestamoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaLimite { get; set; }
    }
}
