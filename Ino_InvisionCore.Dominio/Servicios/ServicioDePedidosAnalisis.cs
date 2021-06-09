using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDePedidosAnalisis : IServicioDePedidosAnalisis
    {
        public IRepositorioDePedidosAnalisis RepositorioDePedidosAnalisis { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDePedidosAnalisis(IRepositorioDePedidosAnalisis repositorioDePedidosAnalisis, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDePedidosAnalisis = repositorioDePedidosAnalisis;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD AgregarSolicitudDatosIncompletos(NuevoSolicitudDatosIncompletos nuevoSolicitudDatosIncompletos)
        {
            RespuestaBD respuesta = RepositorioDePedidosAnalisis.AgregarSolicitudDatosIncompletos(nuevoSolicitudDatosIncompletos);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "SolicitudDatosIncompletos",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevoSolicitudDatosIncompletos),
                    IdUsuario = nuevoSolicitudDatosIncompletos.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD AgregarTranscripcionErronea(NuevoTranscripcionErronea nuevoTranscripcionErronea)
        {
            RespuestaBD respuesta = RepositorioDePedidosAnalisis.AgregarTranscripcionErronea(nuevoTranscripcionErronea);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "TranscripcionErronea",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevoTranscripcionErronea),
                    IdUsuario = nuevoTranscripcionErronea.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarSolicitudDatosIncompletos(ActualizarSolicitudDatosIncompletos actualizarSolicitudDatosIncompletos)
        {
            RespuestaBD respuesta = RepositorioDePedidosAnalisis.EditarSolicitudDatosIncompletos(actualizarSolicitudDatosIncompletos);

            if (respuesta.Id != 0)
            {
                SolicitudDatosIncompletos solicitudDatosIncompletos = RepositorioDePedidosAnalisis.EncontrarSolicitudDatosIncompletos(actualizarSolicitudDatosIncompletos.IdSolicitudDatosIncompletos);
                string valoresAntiguos = JsonConvert.SerializeObject(solicitudDatosIncompletos);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "SolicitudDatosIncompletos",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarSolicitudDatosIncompletos),
                    IdUsuario = actualizarSolicitudDatosIncompletos.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarTranscripcionErronea(ActualizarTranscripcionErronea actualizarTranscripcionErronea)
        {
            RespuestaBD respuesta = RepositorioDePedidosAnalisis.EditarTranscripcionErronea(actualizarTranscripcionErronea);

            if (respuesta.Id != 0)
            {
                TranscripcionErronea transcripcionErronea = RepositorioDePedidosAnalisis.EncontrarTranscripcionErronea(actualizarTranscripcionErronea.IdTranscripcionErronea);
                string valoresAntiguos = JsonConvert.SerializeObject(transcripcionErronea);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "TranscripcionErronea",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarTranscripcionErronea),
                    IdUsuario = actualizarTranscripcionErronea.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<SolicitudDatosIncompletosGeneral> ListarSolicitudDatosIncompletos()
        {
            return RepositorioDePedidosAnalisis.ListarSolicitudDatosIncompletos();
        }

        public IEnumerable<TranscripcionErroneaGeneral> ListarTranscripcionErronea()
        {
            return RepositorioDePedidosAnalisis.ListarTranscripcionErronea();
        }
    }
}
