using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [Authorize]
    [ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PedidosAnalisisController : ControllerBase
    {
        IServicioDePedidosAnalisis _servicioDePedidosAnalisis;

        public PedidosAnalisisController(IServicioDePedidosAnalisis servicioDePedidosAnalisis)
        {
            _servicioDePedidosAnalisis = servicioDePedidosAnalisis;
        }

        [HttpPost]
        public IActionResult AgregarSolicitudDatosIncompletos([FromBody]NuevoSolicitudDatosIncompletos nuevoSolicitudDatosIncompletos)
        {
            var respuesta = _servicioDePedidosAnalisis.AgregarSolicitudDatosIncompletos(nuevoSolicitudDatosIncompletos);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarTranscripcionErronea([FromBody]NuevoTranscripcionErronea nuevoTranscripcionErronea)
        {
            var respuesta = _servicioDePedidosAnalisis.AgregarTranscripcionErronea(nuevoTranscripcionErronea);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarSolicitudDatosIncompletos([FromBody]ActualizarSolicitudDatosIncompletos actualizarSolicitudDatosIncompletos)
        {
            var respuesta = _servicioDePedidosAnalisis.EditarSolicitudDatosIncompletos(actualizarSolicitudDatosIncompletos);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarTranscripcionErronea([FromBody]ActualizarTranscripcionErronea actualizarTranscripcionErronea)
        {
            var respuesta = _servicioDePedidosAnalisis.EditarTranscripcionErronea(actualizarTranscripcionErronea);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<SolicitudDatosIncompletosGeneral> ListarSolicitudDatosIncompletos([FromQuery]int? Id)
        {
            return _servicioDePedidosAnalisis.ListarSolicitudDatosIncompletos(Id);
        }

        [HttpGet]
        public IEnumerable<TranscripcionErroneaGeneral> ListarTranscripcionErronea([FromQuery]int? Id)
        {
            return _servicioDePedidosAnalisis.ListarTranscripcionErronea(Id);
        }
    }
}