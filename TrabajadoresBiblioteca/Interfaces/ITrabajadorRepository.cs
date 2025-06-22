using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresBiblioteca.Models;

namespace TrabajadoresBiblioteca.Interfaces
{
    public interface ITrabajadorRepository
    {
        Task<List<TrabajadorListado>> ListarTodosAsync();
        Task<Trabajador> ObtenerPorIdAsync(int id);
        Task CrearAsync(Trabajador t);
        Task ActualizarAsync(Trabajador t);
        Task EliminarAsync(int id);

        Task<List<Departamento>> ListarDepartamentosAsync();
        Task<List<Provincia>> ListarProvinciasAsync(int idDepartamento);
        Task<List<Distrito>> ListarDistritosAsync(int idProvincia);
    }
}
