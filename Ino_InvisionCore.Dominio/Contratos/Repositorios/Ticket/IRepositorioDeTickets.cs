using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Ticket
{
    public interface IRepositorioDeTickets
    {
        IEnumerable<TicketConsultaExternaGeneral> ListarTicketConsultaExterna(DateTime Fecha);
        RespuestaBD AgregarTicketConsultaExterna(PacienteCitado pacienteCitado, NuevoTicketConsultaExterna nuevoTicketConsultaExterna);
        RespuestaBD ActualizarTicketIdImpresion(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna);
        RespuestaBD ActualizarTicketIdImpresionRevision(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna);
        RespuestaBD ActualizarNroHistoriaClinicaTemporal(ActualizarHistoriaClinicaTemporal actualizarHistoriaClinicaTemporal);
        IEnumerable<TicketConsultaExternaGeneral> ListarTicketsHub(DateTime Fecha);

        Task<IEnumerable<TicketConsultaExternaGeneral>> ListarTicketConsultaExternaAsync(int? Id, DateTime? Fecha);
        Task<RespuestaBD> AgregarTicketConsultaExternaAsync(PacienteCitado pacienteCitado, NuevoTicketConsultaExterna nuevoTicketConsultaExterna);
        Task<RespuestaBD> ActualizarTicketIdImpresionAsync(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna);
        Task<RespuestaBD> ActualizarTicketIdImpresionRevisionAsync(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna);
        Task<RespuestaBD> ActualizarNroHistoriaClinicaTemporalAsync(ActualizarHistoriaClinicaTemporal actualizarHistoriaClinicaTemporal);
    }
}
