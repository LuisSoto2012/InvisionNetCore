using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Respuestas;
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
    public class ServicioDeTomaMuestra : IServicioDeTomaMuestra
    {
        public IRepositorioDeTomaMuestra RepositorioDeTomaMuestra { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeTomaMuestra(IRepositorioDeTomaMuestra repositorioDeTomaMuestra, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeTomaMuestra = repositorioDeTomaMuestra;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD AgregarIncidentesPacientes(NuevoIncidentesPacientes nuevoIncidentesPacientes)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.AgregarIncidentesPacientes(nuevoIncidentesPacientes);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "IncidentesPacientes",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevoIncidentesPacientes),
                    IdUsuario = nuevoIncidentesPacientes.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD AgregarIncumplimientoAnalisis(NuevoIncumplimientoAnalisis nuevoIncumplimientoAnalisis)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.AgregarIncumplimientoAnalisis(nuevoIncumplimientoAnalisis);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "IncumplimientoAnalisis",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevoIncumplimientoAnalisis),
                    IdUsuario = nuevoIncumplimientoAnalisis.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD AgregarPruebasNoRealizadas(NuevoPruebasNoRealizadas nuevoPruebasNoRealizadas)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.AgregarPruebasNoRealizadas(nuevoPruebasNoRealizadas);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "PruebasNoRealizadas",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevoPruebasNoRealizadas),
                    IdUsuario = nuevoPruebasNoRealizadas.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD AgregarRecoleccionMuestra(NuevoRecoleccionMuestra nuevoRecoleccionMuestra)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.AgregarRecoleccionMuestra(nuevoRecoleccionMuestra);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "RecoleccionMuestra",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevoRecoleccionMuestra),
                    IdUsuario = nuevoRecoleccionMuestra.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD AgregarVenopunturasFallidas(NuevoVenopunturasFallidas nuevoVenopunturasFallidas)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.AgregarVenopunturasFallidas(nuevoVenopunturasFallidas);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "VenopunturasFallidas",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevoVenopunturasFallidas),
                    IdUsuario = nuevoVenopunturasFallidas.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarIncidentesPacientes(ActualizarIncidentesPacientes actualizarIncidentesPacientes)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.EditarIncidentesPacientes(actualizarIncidentesPacientes);

            if (respuesta.Id != 0)
            {
                IncidentesPacientes incidentesPacientes = RepositorioDeTomaMuestra.EncontrarIncidentesPacientes(actualizarIncidentesPacientes.IdIncidentesPacientes);
                string valoresAntiguos = JsonConvert.SerializeObject(incidentesPacientes);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "IncidentesPacientes",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarIncidentesPacientes),
                    IdUsuario = actualizarIncidentesPacientes.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarIncumplimientoAnalisis(ActualizarIncumplimientoAnalisis actualizarIncumplimientoAnalisis)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.EditarIncumplimientoAnalisis(actualizarIncumplimientoAnalisis);

            if (respuesta.Id != 0)
            {
                IncumplimientoAnalisis incumplimientoAnalisis = RepositorioDeTomaMuestra.EncontrarIncumplimientoAnalisis(actualizarIncumplimientoAnalisis.IdIncumplimientoAnalisis);
                string valoresAntiguos = JsonConvert.SerializeObject(incumplimientoAnalisis);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "IncumplimientoAnalisis",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarIncumplimientoAnalisis),
                    IdUsuario = actualizarIncumplimientoAnalisis.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarPruebasNoRealizadas(ActualizarPruebasNoRealizadas actualizarPruebasNoRealizadas)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.EditarPruebasNoRealizadas(actualizarPruebasNoRealizadas);

            if (respuesta.Id != 0)
            {
                PruebasNoRealizadas pruebasNoRealizadas = RepositorioDeTomaMuestra.EncontrarPruebasNoRealizadas(actualizarPruebasNoRealizadas.IdPruebasNoRealizadas);
                string valoresAntiguos = JsonConvert.SerializeObject(pruebasNoRealizadas);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "PruebasNoRealizadas",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarPruebasNoRealizadas),
                    IdUsuario = actualizarPruebasNoRealizadas.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarRecoleccionMuestra(ActualizarRecoleccionMuestra actualizarRecoleccionMuestra)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.EditarRecoleccionMuestra(actualizarRecoleccionMuestra);

            if (respuesta.Id != 0)
            {
                RecoleccionMuestra recoleccionMuestra = RepositorioDeTomaMuestra.EncontrarRecoleccionMuestra(actualizarRecoleccionMuestra.IdRecoleccionMuestra);
                string valoresAntiguos = JsonConvert.SerializeObject(recoleccionMuestra);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "RecoleccionMuestra",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarRecoleccionMuestra),
                    IdUsuario = actualizarRecoleccionMuestra.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarVenopunturasFallidas(ActualizarVenopunturasFallidas actualizarVenopunturasFallidas)
        {
            RespuestaBD respuesta = RepositorioDeTomaMuestra.EditarVenopunturasFallidas(actualizarVenopunturasFallidas);

            if (respuesta.Id != 0)
            {
                VenopunturasFallidas venopunturasFallidas = RepositorioDeTomaMuestra.EncontrarVenopunturasFallidas(actualizarVenopunturasFallidas.IdVenopunturasFallidas);
                string valoresAntiguos = JsonConvert.SerializeObject(venopunturasFallidas);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "VenopunturasFallidas",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarVenopunturasFallidas),
                    IdUsuario = actualizarVenopunturasFallidas.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);

            }

            return respuesta;
        }

        public IEnumerable<IncidentesPacientesGeneral> ListarIncidentesPacientes()
        {
            return RepositorioDeTomaMuestra.ListarIncidentesPacientes();
        }

        public IEnumerable<IncumplimientoAnalisisGeneral> ListarIncumplimientoAnalisis()
        {
            return RepositorioDeTomaMuestra.ListarIncumplimientoAnalisis();
        }

        public IEnumerable<PruebasNoRealizadasGeneral> ListarPruebasNoRealizadas()
        {
            return RepositorioDeTomaMuestra.ListarPruebasNoRealizadas();
        }

        public IEnumerable<RecoleccionMuestraGeneral> ListarRecoleccionMuestra()
        {
            return RepositorioDeTomaMuestra.ListarRecoleccionMuestra();
        }

        public IEnumerable<VenopunturasFallidasGeneral> ListarVenopunturasFallidas()
        {
            return RepositorioDeTomaMuestra.ListarVenopunturasFallidas();
        }
    }
}
