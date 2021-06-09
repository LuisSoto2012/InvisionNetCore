using System.Collections.Generic;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Aplicacion;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [Authorize]
    [ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AplicacionController : ControllerBase
    {
        private IServicioDeAplicaciones _servicioDeAplicaciones;

        public AplicacionController(IServicioDeAplicaciones servicioDeAplicaciones)
        {
            _servicioDeAplicaciones = servicioDeAplicaciones;
        }

        [HttpPost]
        public IActionResult Crear([FromBody]NuevaAplicacion aplicacion)
        {
            var respuesta = _servicioDeAplicaciones.Crear(aplicacion);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<AplicacionGeneral> Listar([FromQuery] int? Id)
        {
            return _servicioDeAplicaciones.Listar(Id);
        }

        [HttpPost]
        public IActionResult Actualizar([FromBody]ActualizarAplicacion aplicacion)
        {
            var respuesta = _servicioDeAplicaciones.Actualizar(aplicacion);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}