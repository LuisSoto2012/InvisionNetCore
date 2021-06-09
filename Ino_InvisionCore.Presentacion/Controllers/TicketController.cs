using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Ticket;
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
    public class TicketController : ControllerBase
    {
        private IServicioDeTickets _servicioDeTickets;

        public TicketController(IServicioDeTickets servicioDeTickets)
        {
            _servicioDeTickets = servicioDeTickets;
        }

        [HttpPost]
        public IActionResult AgregarTicketConsultaExterna([FromBody]NuevoTicketConsultaExterna nuevoTicketConsultaExterna)
        {
            var respuesta = _servicioDeTickets.AgregarTicketConsultaExterna(nuevoTicketConsultaExterna);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult ActualizarTicketIdImpresion([FromBody]ActualizarTicketConsultaExterna actualizarTickeConsultaExterna)
        {
            var respuesta = _servicioDeTickets.ActualizarTicketIdImpresion(actualizarTickeConsultaExterna);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult ActualizarTicketIdImpresionRevision([FromBody]ActualizarTicketConsultaExterna actualizarTickeConsultaExterna)
        {
            var respuesta = _servicioDeTickets.ActualizarTicketIdImpresionRevision(actualizarTickeConsultaExterna);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult ActualizarNroHistoriaClinicaTemporal([FromBody]ActualizarHistoriaClinicaTemporal actualizarHistoriaClinicaTemporal)
        {
            var respuesta = _servicioDeTickets.ActualizarNroHistoriaClinicaTemporal(actualizarHistoriaClinicaTemporal);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<TicketConsultaExternaGeneral> ListarTicketConsultaExterna([FromQuery]int? Id, [FromQuery]DateTime? Fecha)
        {
            return _servicioDeTickets.ListarTicketConsultaExterna(Id, Fecha);
        }
    }
}