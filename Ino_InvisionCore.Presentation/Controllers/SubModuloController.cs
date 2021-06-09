using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.SubModulo;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [Authorize]
    //[ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubModuloController : ControllerBase
    {
        private readonly IServicioDeSubModulos _servicioDeSubModulos;

        public SubModuloController(IServicioDeSubModulos servicioDeSubModulos)
        {
            _servicioDeSubModulos = servicioDeSubModulos;
        }

        [HttpPost]
        public IActionResult Crear([FromBody]NuevoSubModulo editedItemSubModulo)
        {
            var respuesta = _servicioDeSubModulos.Crear(editedItemSubModulo);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<SubModuloGeneral> Listar([FromQuery]int? Id)
        {
            return _servicioDeSubModulos.Listar(Id);
        }

        [HttpPost]
        public IActionResult Actualizar([FromBody]ActualizarSubModulo editedItemSubModulo)
        {
            var respuesta = _servicioDeSubModulos.Actualizar(editedItemSubModulo);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AsignarRolSubModulo([FromBody]RolSubModuloDto editedItemAcciones)
        {
            var respuesta = _servicioDeSubModulos.AsignarRolSubModulo(editedItemAcciones);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<RolSubModuloDto> ObtenerRolSubModulo([FromQuery]RolSubModuloDto dto)
        {
            return _servicioDeSubModulos.ObtenerRolSubModulo(dto);
        }
    }
}