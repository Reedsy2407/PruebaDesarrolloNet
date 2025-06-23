using Microsoft.AspNetCore.Mvc;
using TrabajadoresBiblioteca.Models;
using TrabajadoresBiblioteca.Services;

namespace TrabajadoresWeb.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly TrabajadorService _svc;
        public TrabajadoresController(TrabajadorService svc) => _svc = svc;

        // Listado
        public async Task<IActionResult> Index()
        {
            var lista = await _svc.ListarAsync();
            return View(lista);
        }

        //combobox json

        [HttpGet]
        public async Task<JsonResult> Provincias(int idDep)
        {
            var list = await _svc.ObtenerProvinciasAsync(idDep);
            return Json(list);
        }
        [HttpGet]
        public async Task<JsonResult> Distritos(int idProv)
        {
            var list = await _svc.ObtenerDistritosAsync(idProv);
            return Json(list);
        }

        // Crear
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            ViewBag.Departamentos = await _svc.ObtenerDepartamentosAsync();
            ViewBag.Provincias = new List<Provincia>();
            ViewBag.Distritos = new List<Distrito>();
            return PartialView("_CrearEditar", new Trabajador());
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Trabajador t)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _svc.CrearAsync(t);
            return Ok();
        }

        // Editar
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var t = await _svc.ObtenerAsync(id);
            ViewBag.Departamentos = await _svc.ObtenerDepartamentosAsync();
            ViewBag.Provincias = await _svc.ObtenerProvinciasAsync(t.IdDepartamento);
            ViewBag.Distritos = await _svc.ObtenerDistritosAsync(t.IdProvincia);
            return PartialView("_CrearEditar", t);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Trabajador t)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _svc.ActualizarAsync(t);
            return Ok();
        }

        // Eliminar
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _svc.EliminarAsync(id);
            return Ok();
        }
    }
}
