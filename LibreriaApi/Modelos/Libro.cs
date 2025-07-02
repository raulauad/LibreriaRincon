namespace LibreriaApi.Modelos
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; } = string.Empty; // Nuevo campo
        public bool Disponible { get; set; } = true;

    }
}
