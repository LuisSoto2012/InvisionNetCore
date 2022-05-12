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
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    //[ActionWorkFilter]
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
        public IActionResult AgregarTicketConsultaExterna([FromBody]NuevoTicketConsultaExterna parametrosTicketCG)
        {
            var respuesta = _servicioDeTickets.AgregarTicketConsultaExterna(parametrosTicketCG);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult ActualizarTicketIdImpresion([FromBody]ActualizarTicketConsultaExterna actualizarTicketIdImpresion)
        {
            var respuesta = _servicioDeTickets.ActualizarTicketIdImpresion(actualizarTicketIdImpresion);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult ActualizarTicketIdImpresionRevision([FromBody]ActualizarTicketConsultaExterna parametrosTicketCG)
        {
            var respuesta = _servicioDeTickets.ActualizarTicketIdImpresionRevision(parametrosTicketCG);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult ActualizarNroHistoriaClinicaTemporal([FromBody]ActualizarHistoriaClinicaTemporal parametrosHistoriaTemporal)
        {
            var respuesta = _servicioDeTickets.ActualizarNroHistoriaClinicaTemporal(parametrosHistoriaTemporal);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<TicketConsultaExternaGeneral> ListarTicketConsultaExterna([FromQuery]DateTime Fecha)
        {
            return _servicioDeTickets.ListarTicketConsultaExterna(Fecha);
        }
    }
}