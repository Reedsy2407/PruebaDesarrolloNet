using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajadoresBiblioteca.Interfaces;
using TrabajadoresBiblioteca.Models;

namespace TrabajadoresBiblioteca.Services
{
    public class TrabajadorService
    {
        private readonly ITrabajadorRepository TrabRepo;
        public TrabajadorService(ITrabajadorRepository repo)
        {
            TrabRepo = repo;
        }

        public Task<List<TrabajadorListado>> ListarAsync() =>
            TrabRepo.ListarTodosAsync();

        public Task<Trabajador> ObtenerAsync(int id) =>
            TrabRepo.ObtenerPorIdAsync(id);

        public Task CrearAsync(Trabajador t) =>
            TrabRepo.CrearAsync(t);

        public Task ActualizarAsync(Trabajador t) =>
            TrabRepo.ActualizarAsync(t);

        public Task EliminarAsync(int id) =>
            TrabRepo.EliminarAsync(id);

        public Task<List<Departamento>> ObtenerDepartamentosAsync() =>
            TrabRepo.ListarDepartamentosAsync();

        public Task<List<Provincia>> ObtenerProvinciasAsync(int idDep) =>
            TrabRepo.ListarProvinciasAsync(idDep);

        public Task<List<Distrito>> ObtenerDistritosAsync(int idProv) =>
            TrabRepo.ListarDistritosAsync(idProv);
    }
}
