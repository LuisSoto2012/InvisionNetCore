using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Ticket;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Paciente;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Ticket;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeTickets : IServicioDeTickets
    {
        public IRepositorioDeTickets RepositorioDeTickets { get; set; }
        public IServicioDePacientes ServicioDePacientes { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeTickets(IRepositorioDeTickets repositorioDeTickets, IServicioDePacientes servicioDePaciens,IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeTickets = repositorioDeTickets;
            ServicioDePacientes = servicioDePaciens;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD ActualizarNroHistoriaClinicaTemporal(ActualizarHistoriaClinicaTemporal actualizarHistoriaClinicaTemporal)
        {
            RespuestaBD respuesta = RepositorioDeTickets.ActualizarNroHistoriaClinicaTemporal(actualizarHistoriaClinicaTemporal);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Actualizar",
                NombreTabla = "PacientesTemporal",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(actualizarHistoriaClinicaTemporal),
                IdUsuario = actualizarHistoriaClinicaTemporal.IdUsuario
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD AgregarTicketConsultaExterna(NuevoTicketConsultaExterna nuevoTicketConsultaExterna)
        {
            PacienteCitado pacienteCitado = ServicioDePacientes.ListarPacienteCitadoDelDia(new PacientePorHcDni
            {
                NroHistoriaClinica = nuevoTicketConsultaExterna.HistoriaClinica,
                NroDocumento = nuevoTicketConsultaExterna.NumeroDocumento,
                IdEspecialidad = nuevoTicketConsultaExterna.IdEspecialidad
            });

            RespuestaBD respuesta = RepositorioDeTickets.AgregarTicketConsultaExterna(pacienteCitado, nuevoTicketConsultaExterna);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "TicketConsultaExterna",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevoTicketConsultaExterna),
                    IdUsuario = nuevoTicketConsultaExterna.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<TicketConsultaExternaGeneral> ListarTicketConsultaExterna(DateTime Fecha)
        {
            return RepositorioDeTickets.ListarTicketConsultaExterna(Fecha);
        }

        public RespuestaBD ActualizarTicketIdImpresion(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna)
        {
            RespuestaBD respuesta = RepositorioDeTickets.ActualizarTicketIdImpresion(actualizarTicketConsultaExterna);

            return respuesta;
        }

        public RespuestaBD ActualizarTicketIdImpresionRevision(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna)
        {
            RespuestaBD respuesta = RepositorioDeTickets.ActualizarTicketIdImpresionRevision(actualizarTicketConsultaExterna);

            return respuesta;
        }
    }
}
