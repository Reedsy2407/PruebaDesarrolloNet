using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace TrabajadoresBiblioteca.Models
{
    public class TrabajadorListado
    {
        public int Id { get; set; }

        [DisplayName("Tipo Documento")]
        public string? TipoDocumento { get; set; }

        [DisplayName("Nro Documento")]
        public string? NumeroDocumento { get; set; }

        [DisplayName("Nombres")]
        public string? Nombres { get; set; }

        [DisplayName("Sexo")]
        public char Sexo { get; set; }

        [DisplayName("Departamento")]
        public string? NombreDepartamento { get; set; }

        [DisplayName("Provincia")]
        public string? NombreProvincia { get; set; }

        [DisplayName("Distrito")]
        public string? NombreDistrito { get; set; }
    }
}
