﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajadoresBiblioteca.Models
{
    public class Trabajador
    {
        public int Id { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombres { get; set; }
        public char Sexo { get; set; }

        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }

        public Departamento? Departamento { get; set; }
        public Provincia? Provincia { get; set; }
        public Distrito? Distrito { get; set; }
    }
}
