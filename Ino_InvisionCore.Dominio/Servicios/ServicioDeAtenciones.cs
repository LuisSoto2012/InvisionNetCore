﻿using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Atencion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Atencion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeAtenciones : IServicioDeAtenciones
    {
        public IRepositorioDeAtenciones RepositorioDeAtenciones { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeAtenciones(IRepositorioDeAtenciones repositorioDeAtenciones, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeAtenciones = repositorioDeAtenciones;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD ActualizarAtencion(RegistroAtencion nuevaAtencion)
        {
            RespuestaBD respuesta = RepositorioDeAtenciones.ActualizarAtencion(nuevaAtencion);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Actulizar",
                NombreTabla = "Atención",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevaAtencion),
                IdUsuario = nuevaAtencion.IdUsuario
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD RegistrarAtencion(RegistroAtencion nuevaAtencion)
        {
            RespuestaBD respuesta = RepositorioDeAtenciones.RegistrarAtencion(nuevaAtencion);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "Atención",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevaAtencion),
                IdUsuario = nuevaAtencion.IdUsuario
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public IEnumerable<AtencionFiltro> ListarAtenciones(AtencionesPor atencionesPor)
        {
            return RepositorioDeAtenciones.ListarAtenciones(atencionesPor);
        }

        public IEnumerable<CitadosPorFecha> ListarCitadosPorFecha(CitasPor citasPor)
        {
            return RepositorioDeAtenciones.ListarCitadosPorFecha(citasPor);
        }

        public IEnumerable<CitadosPorFechaMedicoEspecialidad> ListarCitadosPorFechaMedicoEspecialidad(PacientesPor PacientesPor)
        {
            return RepositorioDeAtenciones.ListarCitadosPorFechaMedicoEspecialidad(PacientesPor);
        }

        public IEnumerable<Diagnostico> ListarDiagnosticos(Diagnostico diagnostico)
        {
            return RepositorioDeAtenciones.ListarDiagnosticos(diagnostico);
        }

        public IEnumerable<ProcedimientoDto> ListarProcedimientos(ProcedimientoDto procedimiento)
        {
            return RepositorioDeAtenciones.ListarProcedimientos(procedimiento);
        }

        public async Task<RespuestaBD> AgregarRecetaRefraccion(RegistroRecetaRefraccion parametrosRegistro)
        {
            RespuestaBD respuestaBD = await RepositorioDeAtenciones.AgregarRecetaRefraccion(parametrosRegistro);

            return respuestaBD;
        }

        public async Task<IEnumerable<RecetaRefraccionDto>> ListarRecetaRefraccion(DateTime fecha)
        {
            return await RepositorioDeAtenciones.ListarRecetaRefraccion(fecha);
        }

        public async Task<RespuestaBD> ImprimirRecetaRefraccion(ImprimirRecetaRefraccion parametros)
        {
            RespuestaBD respuestaBD = await RepositorioDeAtenciones.ImprimirRecetaRefraccion(parametros);

            return respuestaBD;
        }

        public async Task<RespuestaBD> RegistrarEvaluacionExamen(RegistrarEvaluacionExamenDto solicitud)
        {
            RespuestaBD respuestaBD = await RepositorioDeAtenciones.RegistrarEvaluacionExamen(solicitud);
            return respuestaBD;
        }

        public async Task<IEnumerable<EvaluacionExamenDto>> ListarEvaluacionExamenPorAtencion(int idAtencion)
        {
            return await RepositorioDeAtenciones.ListarEvaluacionExamenPorAtencion(idAtencion);
        }

        public async Task<RespuestaBD> EliminarEvaluacionExamen(EliminarEvaluacionExamenDto solicitud)
        {
            return await RepositorioDeAtenciones.EliminarEvaluacionExamen(solicitud);
        }
    }
}
