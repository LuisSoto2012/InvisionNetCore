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
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    //[ActionWorkFilter]
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
        public IActionResult AgregarSolicitudDatosIncompletos([FromBody]NuevoSolicitudDatosIncompletos itemGeneral)
        {
            var respuesta = _servicioDePedidosAnalisis.AgregarSolicitudDatosIncompletos(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarTranscripcionErronea([FromBody]NuevoTranscripcionErronea itemGeneral)
        {
            var respuesta = _servicioDePedidosAnalisis.AgregarTranscripcionErronea(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarSolicitudDatosIncompletos([FromBody]ActualizarSolicitudDatosIncompletos itemGeneral)
        {
            var respuesta = _servicioDePedidosAnalisis.EditarSolicitudDatosIncompletos(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarTranscripcionErronea([FromBody]ActualizarTranscripcionErronea itemGeneral)
        {
            var respuesta = _servicioDePedidosAnalisis.EditarTranscripcionErronea(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<SolicitudDatosIncompletosGeneral> ListarSolicitudDatosIncompletos()
        {
            return _servicioDePedidosAnalisis.ListarSolicitudDatosIncompletos();
        }

        [HttpGet]
        public IEnumerable<TranscripcionErroneaGeneral> ListarTranscripcionErronea()
        {
            return _servicioDePedidosAnalisis.ListarTranscripcionErronea();
        }
    }
}