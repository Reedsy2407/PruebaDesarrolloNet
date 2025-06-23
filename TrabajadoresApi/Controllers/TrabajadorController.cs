using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajadoresBiblioteca.Models;
using TrabajadoresBiblioteca.Services;

namespace TrabajadoresApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajadorController : ControllerBase
    {
        private readonly TrabajadorService service;
        public TrabajadorController(TrabajadorService svc) => service = svc;

        [HttpGet]
        public Task<List<TrabajadorListado>> Get() => service.ListarAsync();

        [HttpGet("{id}")]
        public Task<Trabajador> Get(int id) => service.ObtenerAsync(id);

        [HttpPost]
        public Task Post([FromBody] Trabajador tra) => service.CrearAsync(tra);

        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] Trabajador tra)
        {
            tra.Id = id;
            return service.ActualizarAsync(tra);
        }

        [HttpDelete("{id}")]
        public Task Delete(int id) => service.EliminarAsync(id);

        // Endpoints para los combobox
        [HttpGet("departamentos")]
        public Task<List<Departamento>> GetDepartamentos() =>
            service.ObtenerDepartamentosAsync();

        [HttpGet("provincias/{idDep}")]
        public Task<List<Provincia>> GetProvincias(int idDep) =>
            service.ObtenerProvinciasAsync(idDep);

        [HttpGet("distritos/{idProv}")]
        public Task<List<Distrito>> GetDistritos(int idProv) =>
            service.ObtenerDistritosAsync(idProv);
    }
}