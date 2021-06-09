using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.IndicadoresGestion;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeIndicadoresGestion : IServicioDeIndicadoresGestion
    {
        public IRepositorioDeIndicadoresGestion RepositorioDeIndicadoresGestion { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeIndicadoresGestion(IRepositorioDeIndicadoresGestion repositorioDeIndicadoresGestion, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeIndicadoresGestion = repositorioDeIndicadoresGestion;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD AgregarRendimientoHoraTrabajador(NuevoRendimientoHoraTrabajador nuevoRendimientoHoraTrabajador)
        {
            RespuestaBD respuesta = RepositorioDeIndicadoresGestion.AgregarRendimientoHoraTrabajador(nuevoRendimientoHoraTrabajador);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "RendimientoHoraTrabajador",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevoRendimientoHoraTrabajador),
                IdUsuario = nuevoRendimientoHoraTrabajador.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD EditarRendimientoHoraTrabajador(ActualizarRendimientoHoraTrabajador actualizarRendimientoHoraTrabajador)
        {
            RespuestaBD respuesta = RepositorioDeIndicadoresGestion.EditarRendimientoHoraTrabajador(actualizarRendimientoHoraTrabajador);

            if (respuesta.Id != 0)
            {
                RendimientoHoraTrabajador rendimientoHoraTrabajador = RepositorioDeIndicadoresGestion.EncontrarRendimientoHoraTrabajador(actualizarRendimientoHoraTrabajador.IdRendimientoHoraTrabajador);
                string valoresAntiguos = JsonConvert.SerializeObject(rendimientoHoraTrabajador);
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "RendimientoHoraTrabajador",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarRendimientoHoraTrabajador),
                    IdUsuario = actualizarRendimientoHoraTrabajador.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<RendimientoHoraTrabajadorGeneral> ListarRendimientoHoraTrabajador()
        {
            return RepositorioDeIndicadoresGestion.ListarRendimientoHoraTrabajador();
        }

        public RespuestaBD AgregarExamenAtendidoPorServicio(NuevoExamenAtendidoPorServicio request)
        {
            RespuestaBD respuesta = RepositorioDeIndicadoresGestion.AgregarExamenAtendidoPorServicio(request);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "ExamenAtendidoPorServicio",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(request),
                IdUsuario = request.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD EditarExamenAtendidoPorServicio(ActualizarExamenAtendidoPorServicio request)
        {
            RespuestaBD respuesta = RepositorioDeIndicadoresGestion.EditarExamenAtendidoPorServicio(request);

            if (respuesta.Id != 0)
            {
                ExamenAtendidoPorServicio examen = RepositorioDeIndicadoresGestion.EncontrarExamenAtendidoPorServicio(request.IdExamen);
                string valoresAntiguos = JsonConvert.SerializeObject(examen);
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "ExamenAtendidoPorServicio",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(request),
                    IdUsuario = request.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<ExamenAtendidoPorServicioDto> ListarExamenAtendidoPorServicio()
        {
            return RepositorioDeIndicadoresGestion.ListarExamenAtendidoPorServicio().Select(x => Mapper.Map<ExamenAtendidoPorServicioDto>(x)).ToList();
        }

        public RespuestaBD AgregarExamenNoInformadoPorServicio(NuevoExamenNoInformadoPorServicio request)
        {
            RespuestaBD respuesta = RepositorioDeIndicadoresGestion.AgregarExamenNoInformadoPorServicio(request);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "ExamenNoInformadoPorServicio",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(request),
                IdUsuario = request.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD EditarExamenNoInformadoPorServicio(ActualizarExamenNoInformadoPorServicio request)
        {
            RespuestaBD respuesta = RepositorioDeIndicadoresGestion.EditarExamenNoInformadoPorServicio(request);

            if (respuesta.Id != 0)
            {
                ExamenNoInformadoPorServicio examen = RepositorioDeIndicadoresGestion.EncontrarExamenNoInformadoPorServicio(request.IdExamen);
                string valoresAntiguos = JsonConvert.SerializeObject(examen);
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "ExamenNoInformadoPorServicio",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(request),
                    IdUsuario = request.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<ExamenNoInformadoPorServicioDto> ListarExamenNoInformadoPorServicio()
        {
            return RepositorioDeIndicadoresGestion.ListarExamenNoInformadoPorServicio().Select(x => Mapper.Map<ExamenNoInformadoPorServicioDto>(x)).ToList();
        }
    }
}
