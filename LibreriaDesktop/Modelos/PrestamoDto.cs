using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDesktop.Modelos
{
    internal class PrestamoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string FechaPrestamo { get; set; }
        public string FechaLimite { get; set; }

    }
}
