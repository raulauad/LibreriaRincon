using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDesktop.Modelos
{
    internal class Prestamo
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaLimiteDevolucion { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public Libro? Libro { get; set; }
    }
}
