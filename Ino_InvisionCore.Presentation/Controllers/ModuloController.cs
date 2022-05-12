using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Modulo;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    //[ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly IServicioDeModulos _servicioDeModulos;

        public ModuloController(IServicioDeModulos servicioDeModulos)
        {
            _servicioDeModulos = servicioDeModulos;
        }

        [HttpPost]
        public IActionResult Crear([FromBody]NuevoModulo editedItemModulo)
        {
            var respuesta = _servicioDeModulos.Crear(editedItemModulo);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<ModuloGeneral> Listar([FromQuery]int? Id)
        {
            return _servicioDeModulos.Listar(Id);
        }

        [HttpPost]
        public IActionResult Actualizar([FromBody]ActualizarModulo editedItemModulo)
        {
            var respuesta = _servicioDeModulos.Actualizar(editedItemModulo);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}