using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Ticket
{
    public interface IServicioDeTickets
    {
        IEnumerable<TicketConsultaExternaGeneral> ListarTicketConsultaExterna(DateTime Fecha);
        RespuestaBD AgregarTicketConsultaExterna(NuevoTicketConsultaExterna nuevoTicketConsultaExterna);
        RespuestaBD ActualizarTicketIdImpresion(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna);
        RespuestaBD ActualizarTicketIdImpresionRevision(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna);
        RespuestaBD ActualizarNroHistoriaClinicaTemporal(ActualizarHistoriaClinicaTemporal actualizarHistoriaClinicaTemporal);
    }
}
