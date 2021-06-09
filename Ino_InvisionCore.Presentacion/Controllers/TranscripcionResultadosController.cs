using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Respuestas;
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
    public class TranscripcionResultadosController : ControllerBase
    {
        private IServicioDeTranscripcionResultados _servicioDeTranscripcionResultados;

        public TranscripcionResultadosController(IServicioDeTranscripcionResultados servicioDeTranscripcionResultados)
        {
            _servicioDeTranscripcionResultados = servicioDeTranscripcionResultados;
        }

        [HttpPost]
        public IActionResult AgregarPacienteSinResultado([FromBody]NuevoPacienteSinResultado nuevoPacienteSinResultado)
        {
            var respuesta = _servicioDeTranscripcionResultados.AgregarPacienteSinResultado(nuevoPacienteSinResultado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarTranscripcionErroneaInoportuna([FromBody]NuevoTranscripcionErroneaInoportuna nuevoTranscripcionErroneaInoportuna)
        {
            var respuesta = _servicioDeTranscripcionResultados.AgregarTranscripcionErroneaInoportuna(nuevoTranscripcionErroneaInoportuna);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarTranscripcionErroneaInoportuna([FromBody]ActualizarTranscripcionErroneaInoportuna actualizarTranscripcionErroneaInoportuna)
        {
            var respuesta = _servicioDeTranscripcionResultados.EditarTranscripcionErroneaInoportuna(actualizarTranscripcionErroneaInoportuna);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarPacienteSinResultado([FromBody]ActualizarPacienteSinResultado actualizarPacienteSinResultado)
        {
            var respuesta = _servicioDeTranscripcionResultados.EditarPacienteSinResultado(actualizarPacienteSinResultado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<PacienteSinResultadoGeneral> ListarPacienteSinResultado([FromQuery]int? Id)
        {
            return _servicioDeTranscripcionResultados.ListarPacienteSinResultado(Id);
        }

        [HttpGet]
        public IEnumerable<TranscripcionErroneaInoportunaGeneral> ListarTranscripcionErroneaInoportuna([FromQuery]int? Id)
        {
            return _servicioDeTranscripcionResultados.ListarTranscripcionErroneaInoportuna(Id);
        }
    }
}