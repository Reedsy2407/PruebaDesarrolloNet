using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajadoresBiblioteca.Models
{
    public class Provincia
    {
        public int Id { get; set; }
        public int IdDepartamento { get; set; }
        public string? NombreProvincia { get; set; }
    }
}
