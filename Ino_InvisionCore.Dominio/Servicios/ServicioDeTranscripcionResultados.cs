using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Respuestas;
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
    public class ServicioDeTranscripcionResultados : IServicioDeTranscripcionResultados
    {
        public IRepositorioDeTranscripcionResultados RepositorioDeTranscripcionResultados { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeTranscripcionResultados(IRepositorioDeTranscripcionResultados repositorioDeTranscripcionResultados, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeTranscripcionResultados = repositorioDeTranscripcionResultados;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD AgregarPacienteSinResultado(NuevoPacienteSinResultado nuevoPacienteSinResultado)
        {
            RespuestaBD respuesta = RepositorioDeTranscripcionResultados.AgregarPacienteSinResultado(nuevoPacienteSinResultado);

            return respuesta;
        }

        public RespuestaBD AgregarTranscripcionErroneaInoportuna(NuevoTranscripcionErroneaInoportuna nuevoTranscripcionErroneaInoportuna)
        {
            RespuestaBD respuesta = RepositorioDeTranscripcionResultados.AgregarTranscripcionErroneaInoportuna(nuevoTranscripcionErroneaInoportuna);

            return respuesta;
        }

        public RespuestaBD EditarPacienteSinResultado(ActualizarPacienteSinResultado actualizarPacienteSinResultado)
        {
            RespuestaBD respuesta = RepositorioDeTranscripcionResultados.EditarPacienteSinResultado(actualizarPacienteSinResultado);

            if (respuesta.Id != 0)
            {
                PacienteSinResultado pacienteSinResultado = RepositorioDeTranscripcionResultados.EncontrarPacienteSinResultado(actualizarPacienteSinResultado.IdPacienteSinResultado);
                string valoresAntiguos = JsonConvert.SerializeObject(pacienteSinResultado);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "PacienteSinResultado",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarPacienteSinResultado),
                    IdUsuario = actualizarPacienteSinResultado.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarTranscripcionErroneaInoportuna(ActualizarTranscripcionErroneaInoportuna actualizarTranscripcionErroneaInoportuna)
        {
            RespuestaBD respuesta = RepositorioDeTranscripcionResultados.EditarTranscripcionErroneaInoportuna(actualizarTranscripcionErroneaInoportuna);

            if (respuesta.Id != 0)
            {
                TranscripcionErroneaInoportuna transcripcionErroneaInoportuna = RepositorioDeTranscripcionResultados.EncontrarTranscripcionErroneaInoportuna(actualizarTranscripcionErroneaInoportuna.IdTranscripcionErroneaInoportuna);
                string valoresAntiguos = JsonConvert.SerializeObject(transcripcionErroneaInoportuna);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "TranscripcionErroneaInoportuna",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarTranscripcionErroneaInoportuna),
                    IdUsuario = actualizarTranscripcionErroneaInoportuna.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<PacienteSinResultadoGeneral> ListarPacienteSinResultado()
        {
            return RepositorioDeTranscripcionResultados.ListarPacienteSinResultado();
        }

        public IEnumerable<TranscripcionErroneaInoportunaGeneral> ListarTranscripcionErroneaInoportuna()
        {
            return RepositorioDeTranscripcionResultados.ListarTranscripcionErroneaInoportuna();
        }
    }
}
