using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajadoresBiblioteca.Models
{
    public class TrabajadorListado
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public char Sexo { get; set; }
        public string NombreDepartamento { get; set; }
        public string NombreProvincia { get; set; }
        public string NombreDistrito { get; set; }
    }
}
