using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TrabajadoresBiblioteca.Data;
using TrabajadoresBiblioteca.Interfaces;
using TrabajadoresBiblioteca.Models;

namespace TrabajadoresBiblioteca.Repositories
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        private readonly TrabajadoresDbContext _ctx;
        public TrabajadorRepository(TrabajadoresDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<TrabajadorListado>> ListarTodosAsync()
        {
            return await _ctx.TrabajadorListado
                .FromSqlRaw("EXEC usp_ListarTrabajadores")
                .ToListAsync();
        }

        public async Task<Trabajador> ObtenerPorIdAsync(int id) =>
            await _ctx.Trabajadores.FindAsync(id);

        public async Task CrearAsync(Trabajador t)
        {
            _ctx.Trabajadores.Add(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Trabajador t)
        {
            _ctx.Trabajadores.Update(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var t = new Trabajador { Id = id };
            _ctx.Trabajadores.Attach(t);
            _ctx.Trabajadores.Remove(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Departamento>> ListarDepartamentosAsync() =>
            await _ctx.Departamentos.ToListAsync();

        public async Task<List<Provincia>> ListarProvinciasAsync(int idDepartamento) =>
            await _ctx.Provincias
                      .Where(p => p.IdDepartamento == idDepartamento)
                      .ToListAsync();

        public async Task<List<Distrito>> ListarDistritosAsync(int idProvincia) =>
            await _ctx.Distritos
                      .Where(d => d.IdProvincia == idProvincia)
                      .ToListAsync();
    }
}
