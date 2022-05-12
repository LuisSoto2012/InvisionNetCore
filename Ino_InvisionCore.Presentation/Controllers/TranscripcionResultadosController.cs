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
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    //[ActionWorkFilter]
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
        public IActionResult AgregarPacienteSinResultado([FromBody]NuevoPacienteSinResultado itemGeneral)
        {
            var respuesta = _servicioDeTranscripcionResultados.AgregarPacienteSinResultado(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarTranscripcionErroneaInoportuna([FromBody]NuevoTranscripcionErroneaInoportuna itemGeneral)
        {
            var respuesta = _servicioDeTranscripcionResultados.AgregarTranscripcionErroneaInoportuna(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarTranscripcionErroneaInoportuna([FromBody]ActualizarTranscripcionErroneaInoportuna itemGeneral)
        {
            var respuesta = _servicioDeTranscripcionResultados.EditarTranscripcionErroneaInoportuna(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarPacienteSinResultado([FromBody]ActualizarPacienteSinResultado itemGeneral)
        {
            var respuesta = _servicioDeTranscripcionResultados.EditarPacienteSinResultado(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<PacienteSinResultadoGeneral> ListarPacienteSinResultado()
        {
            return _servicioDeTranscripcionResultados.ListarPacienteSinResultado();
        }

        [HttpGet]
        public IEnumerable<TranscripcionErroneaInoportunaGeneral> ListarTranscripcionErroneaInoportuna()
        {
            return _servicioDeTranscripcionResultados.ListarTranscripcionErroneaInoportuna();
        }
    }
}