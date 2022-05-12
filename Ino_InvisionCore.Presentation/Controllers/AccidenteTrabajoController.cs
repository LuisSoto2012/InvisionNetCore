using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.AccidenteTrabajo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccidenteTrabajoController : ControllerBase
    {
        private IServicioDeAccidentesTrabajo _servicio;

        public AccidenteTrabajoController(IServicioDeAccidentesTrabajo servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public IActionResult Crear([FromBody]RegistroAccidenteDeTrabajo solicitud)
        {
            var respuesta = _servicio.Crear(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult Actualizar([FromBody]ActualizarAccidenteDeTrabajo solicitud)
        {
            var respuesta = _servicio.Actualizar(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<AccidenteDeTrabajoDto> Listar()
        {
            return _servicio.Listar();
        }
    }
}