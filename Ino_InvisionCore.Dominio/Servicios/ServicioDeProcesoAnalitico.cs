using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.CalibracionDeficiente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.CalibracionDeficiente.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoUPS.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoUPS.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MaterialNoCalibrado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MaterialNoCalibrado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MustraHemolizadaLipemica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MustraHemolizadaLipemica.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Respuestas;
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
    public class ServicioDeProcesoAnalitico : IServicioDeProcesoAnalitico
    {
        public IRepositorioDeProcesoAnalitico RepositorioDeProcesoAnalitico { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeProcesoAnalitico(IRepositorioDeProcesoAnalitico repositorioDeProcesoAnalitico, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeProcesoAnalitico = repositorioDeProcesoAnalitico;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD AgregarCalibracionDeficiente(NuevoCalibracionDeficiente nuevoCalibracionDeficiente)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.AgregarCalibracionDeficiente(nuevoCalibracionDeficiente);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "CalibracionDeficiente",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevoCalibracionDeficiente),
                IdUsuario = nuevoCalibracionDeficiente.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;   
        }

        public RespuestaBD AgregarEmpleoReactivo(NuevoEmpleoReactivo nuevoEmpleoReactivo)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.AgregarEmpleoReactivo(nuevoEmpleoReactivo);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "EmpleoReactivo",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevoEmpleoReactivo),
                IdUsuario = nuevoEmpleoReactivo.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD AgregarEquipoMalCalibrado(NuevoEquipoMalCalibrado nuevoEquipoMalCalibrado)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.AgregarEquipoMalCalibrado(nuevoEquipoMalCalibrado);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "EquipoMalCalibrado",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevoEquipoMalCalibrado),
                IdUsuario = nuevoEquipoMalCalibrado.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD AgregarEquipoUPS(NuevoEquipoUPS nuevoEquipoUPS)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.AgregarEquipoUPS(nuevoEquipoUPS);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "EquipoUPS",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevoEquipoUPS),
                IdUsuario = nuevoEquipoUPS.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD AgregarMaterialNoCalibrado(NuevoMaterialNoCalibrado nuevoMaterialNoCalibrado)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.AgregarMaterialNoCalibrado(nuevoMaterialNoCalibrado);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "MaterialNoCalibrado",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevoMaterialNoCalibrado),
                IdUsuario = nuevoMaterialNoCalibrado.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD AgregarMuestraHemolizadaLipemica(NuevoMuestraHemolizadaLipemica nuevoMuestraHemolizadaLipemica)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.AgregarMuestraHemolizadaLipemica(nuevoMuestraHemolizadaLipemica);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "MuestraHemolizadaLipemica",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevoMuestraHemolizadaLipemica),
                    IdUsuario = nuevoMuestraHemolizadaLipemica.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD AgregarPocoFrecuente(NuevoPocoFrecuente nuevoPocoFrecuente)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.AgregarPocoFrecuente(nuevoPocoFrecuente);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "PocoFrecuente",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevoPocoFrecuente),
                IdUsuario = nuevoPocoFrecuente.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD AgregarSueroMalReferenciado(NuevoSueroMalReferenciado nuevoSueroMalReferenciado)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.AgregarSueroMalReferenciado(nuevoSueroMalReferenciado);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "SueroMalReferenciado",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevoSueroMalReferenciado),
                IdUsuario = nuevoSueroMalReferenciado.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public RespuestaBD EditarCalibracionDeficiente(ActualizarCalibracionDeficiente actualizarCalibracionDeficiente)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.EditarCalibracionDeficiente(actualizarCalibracionDeficiente);

            if (respuesta.Id != 0)
            {
                CalibracionDeficiente calibracionDeficiente = RepositorioDeProcesoAnalitico.EncontrarCalibracionDeficiente(actualizarCalibracionDeficiente.IdCalibracionDeficiente);
                string valoresAntiguos = JsonConvert.SerializeObject(calibracionDeficiente);
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "CalibracionDeficiente",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarCalibracionDeficiente),
                    IdUsuario = actualizarCalibracionDeficiente.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarEmpleoReactivo(ActualizarEmpleoReactivo actualizarEmpleoReactivo)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.EditarEmpleoReactivo(actualizarEmpleoReactivo);

            if (respuesta.Id != 0)
            {
                EmpleoReactivo empleoReactivo = RepositorioDeProcesoAnalitico.EncontrarEmpleoReactivo(actualizarEmpleoReactivo.IdEmpleoReactivo);
                string valoresAntiguos = JsonConvert.SerializeObject(empleoReactivo);
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "EmpleoReactivo",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarEmpleoReactivo),
                    IdUsuario = actualizarEmpleoReactivo.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarEquipoMalCalibrado(ActualizarEquipoMalCalibrado actualizarEquipoMalCalibrado)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.EditarEquipoMalCalibrado(actualizarEquipoMalCalibrado);

            if (respuesta.Id != 0)
            {
                EquipoMalCalibrado equipoMalCalibrado = RepositorioDeProcesoAnalitico.EncontrarEquipoMalCalibrado(actualizarEquipoMalCalibrado.IdEquipoMalCalibrado);
                string valoresAntiguos = JsonConvert.SerializeObject(equipoMalCalibrado);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "EquipoMalCalibrado",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarEquipoMalCalibrado),
                    IdUsuario = actualizarEquipoMalCalibrado.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarEquipoUPS(ActualizarEquipoUPS actualizarEquipoUPS)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.EditarEquipoUPS(actualizarEquipoUPS);

            if (respuesta.Id != 0)
            {
                EquipoUPS equipoUPS = RepositorioDeProcesoAnalitico.EncontrarEquipoUPS(actualizarEquipoUPS.IdEquipoUPS);
                string valoresAntiguos = JsonConvert.SerializeObject(equipoUPS);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "EquipoUPS",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarEquipoUPS),
                    IdUsuario = actualizarEquipoUPS.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarMaterialNoCalibrado(ActualizarMaterialNoCalibrado actualizarMaterialNoCalibrado)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.EditarMaterialNoCalibrado(actualizarMaterialNoCalibrado);

            if (respuesta.Id != 0)
            {
                MaterialNoCalibrado materialNoCalibrado = RepositorioDeProcesoAnalitico.EncontrarMaterialNoCalibrado(actualizarMaterialNoCalibrado.IdMaterialNoCalibrado);
                string valoresAntiguos = JsonConvert.SerializeObject(materialNoCalibrado);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "MaterialNoCalibrado",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarMaterialNoCalibrado),
                    IdUsuario = actualizarMaterialNoCalibrado.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarMuestraHemolizadaLipemica(ActualizarMuestraHemolizadaLipemica actualizarMuestraHemolizadaLipemica)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.EditarMuestraHemolizadaLipemica(actualizarMuestraHemolizadaLipemica);

            if (respuesta.Id != 0)
            {
                MuestraHemolizadaLipemica muestraHemolizadaLipemica = RepositorioDeProcesoAnalitico.EncontrarMuestraHemolizaadaLipemica(actualizarMuestraHemolizadaLipemica.IdMuestraHemolizadaLipemica);
                string valoresAntiguos = JsonConvert.SerializeObject(muestraHemolizadaLipemica);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "MuestraHemolizadaLipemica",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarMuestraHemolizadaLipemica),
                    IdUsuario = actualizarMuestraHemolizadaLipemica.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarPocoFrecuente(ActualizarPocoFrecuente actualizarPocoFrecuente)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.EditarPocoFrecuente(actualizarPocoFrecuente);

            if (respuesta.Id != 0)
            {
                PocoFrecuente pocoFrecuente = RepositorioDeProcesoAnalitico.EncontrarPocoFrecuente(actualizarPocoFrecuente.IdPocoFrecuente);
                string valoresAntiguos = JsonConvert.SerializeObject(pocoFrecuente);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "PocoFrecuente",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarPocoFrecuente),
                    IdUsuario = actualizarPocoFrecuente.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD EditarSueroMalReferenciado(ActualizarSueroMalReferenciado actualizarSueroMalReferenciado)
        {
            RespuestaBD respuesta = RepositorioDeProcesoAnalitico.EditarSueroMalReferenciado(actualizarSueroMalReferenciado);

            if (respuesta.Id != 0)
            {
                SueroMalReferenciado sueroMalReferenciado = RepositorioDeProcesoAnalitico.EncontrarSueroMalReferenciado(actualizarSueroMalReferenciado.IdSueroMalReferenciado);
                string valoresAntiguos = JsonConvert.SerializeObject(sueroMalReferenciado);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "SueroMalReferenciado",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(actualizarSueroMalReferenciado),
                    IdUsuario = actualizarSueroMalReferenciado.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<CalibracionDeficienteGeneral> ListarCalibracionDeficiente()
        {
            return RepositorioDeProcesoAnalitico.ListarCalibracionDeficiente();
        }

        public IEnumerable<EmpleoReactivoGeneral> ListarEmpleoReactivo()
        {
            return RepositorioDeProcesoAnalitico.ListarEmpleoReactivo();
        }

        public IEnumerable<EquipoMalCalibradoGeneral> ListarEquipoMalCalibrado()
        {
            return RepositorioDeProcesoAnalitico.ListarEquipoMalCalibrado();
        }

        public IEnumerable<EquipoUPSGeneral> ListarEquipoUPS()
        {
            return RepositorioDeProcesoAnalitico.ListarEquipoUPS();
        }

        public IEnumerable<MaterialNoCalibradoGeneral> ListarMaterialNoCalibrado()
        {
            return RepositorioDeProcesoAnalitico.ListarMaterialNoCalibrado();
        }

        public IEnumerable<MuestraHemolizadaLipemicaGeneral> ListarMuestraHemolizadaLipemica()
        {
            return RepositorioDeProcesoAnalitico.ListarMuestraHemolizadaLipemica();
        }

        public IEnumerable<PocoFrecuenteGeneral> ListarPocoFrecuente()
        {
            return RepositorioDeProcesoAnalitico.ListarPocoFrecuente();
        }

        public IEnumerable<SueroMalReferenciadoGeneral> ListarSueroMalReferenciado()
        {
            return RepositorioDeProcesoAnalitico.ListarSueroMalReferenciado();
        }
    }
}
