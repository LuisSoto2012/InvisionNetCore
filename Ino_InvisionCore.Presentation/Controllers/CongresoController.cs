using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Congreso;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [Authorize]
    //[ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CongresoController : ControllerBase
    {
        private IServicioDeCongreso _servicioDeCongreso;

        public CongresoController(IServicioDeCongreso servicioDeCongreso)
        {
            _servicioDeCongreso = servicioDeCongreso;
        }

        [HttpGet]
        public IEnumerable<AsistenciaGeneral> EventoAsistenciaListar([FromQuery]int IdHorario, [FromQuery]int IdEvento)
        {
            return _servicioDeCongreso.EventoAsistenciaListar(IdHorario, IdEvento);
        }

        [HttpPost]
        public IActionResult EventoAsistenciaRegistrar([FromBody]NuevaAsistencia parametrosDeRegistro)
        {
            var respuesta = _servicioDeCongreso.EventoAsistenciaRegistrar(parametrosDeRegistro);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<EventoGeneral> EventoListar()
        {
            return _servicioDeCongreso.EventoListar();
        }

        [HttpGet]
        public ParticipanteGeneral EventoParticipanteXDNI([FromQuery]string NumeroDocumento)
        {
            return _servicioDeCongreso.EventoParticipanteXDNI(NumeroDocumento);
        }
    }
}