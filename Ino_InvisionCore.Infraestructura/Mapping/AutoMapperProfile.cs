using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Anestesia.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Anestesia.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.CalibracionDeficiente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.CalibracionDeficiente.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoUPS.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoUPS.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MaterialNoCalibrado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MaterialNoCalibrado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MustraHemolizadaLipemica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MustraHemolizadaLipemica.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Reporte.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Servicios.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Respuestas;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.AccidenteDeTrabajo;
using Ino_InvisionCore.Dominio.Entidades.Anestesia;
using Ino_InvisionCore.Dominio.Entidades.AtencionCE;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Ino_InvisionCore.Dominio.Entidades.ConsultaWeb;
using Ino_InvisionCore.Dominio.Entidades.ConsultaWeb_ConsultaRapida;
using Ino_InvisionCore.Dominio.Entidades.EvaluacionesExamenes;
using Ino_InvisionCore.Dominio.Entidades.IndicadoresGestion;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Ino_InvisionCore.Dominio.Entidades.NervioOptico;
using Ino_InvisionCore.Dominio.Entidades.OrdenMedica;
using Ino_InvisionCore.Dominio.Entidades.RecetaMedica;
using Ino_InvisionCore.Dominio.Entidades.VacunacionCOVID19;
using Ino_InvisionCore.Dominio.EntidadesView;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Ino_InvisionCore.Infraestructura.Extensions;
using Ino_InvisionCore.Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.CitasWeb;
using Ino_InvisionCore.Dominio.Entidades.Evaluacion;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Peticiones;
using Ino_InvisionCore.Dominio.Entidades.CallCenter;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Facturacion;

namespace Ino_InvisionCore.Infraestructura.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Empleado
            CreateMap<NuevoEmpleado, Empleado>()
                            .ForMember(p => p.IdCondicionTrabajo, x => x.MapFrom(p => p.CondicionTrabajo.Id))
                            .ForMember(p => p.IdTipoEmpleado, x => x.MapFrom(p => p.TipoEmpleado.Id))
                            .ForMember(p => p.IdTipoDocumento, x => x.MapFrom(p => p.TipoDocumentoIdentidad.Id));
            CreateMap<NuevoEmpleado, EmpleadoView>()
                            .ForMember(p => p.IdCondicionTrabajo, x => x.MapFrom(p => p.CondicionTrabajo.Id))
                            .ForMember(p => p.IdTipoEmpleado, x => x.MapFrom(p => p.TipoEmpleado.Id))
                            .ForMember(p => p.IdTipoDocumento, x => x.MapFrom(p => p.TipoDocumentoIdentidad.Id));
            CreateMap<ActualizarEmpleado, Empleado>()
                            .ForMember(p => p.IdCondicionTrabajo, x => x.MapFrom(p => p.CondicionTrabajo.Id))
                            .ForMember(p => p.IdTipoEmpleado, x => x.MapFrom(p => p.TipoEmpleado.Id))
                            .ForMember(p => p.IdTipoDocumento, x => x.MapFrom(p => p.TipoDocumentoIdentidad.Id));
            CreateMap<Empleado, UsuarioLogin>()
                            .ForMember(r => r.FechaNacimiento, x => x.MapFrom(p => p.FechaNacimiento.Equals(default(DateTime)) ? string.Empty : p.FechaNacimiento.ToString("dd/MM")));

            CreateMap<EmpleadoGeneral, Empleado>();
            CreateMap<Empleado, EmpleadoGeneral>();

            CreateMap<EmpleadoGeneral, EmpleadoView>();
            CreateMap<EmpleadoView, EmpleadoGeneral>();

            //Incidentes
            CreateMap<IncidentesPacientesGeneral, IncidentesPacientes>();
            CreateMap<IncidentesPacientes, IncidentesPacientesGeneral>();
            //Rol
            CreateMap<NuevoRol, Rol>();
            CreateMap<ActualizarRol, Rol>();
            CreateMap<Rol, RolGeneral>();
            CreateMap<RolGeneral, Rol>();
            //Aplicacion
            CreateMap<NuevaAplicacion, Aplicacion>();
            CreateMap<ActualizarAplicacion, Aplicacion>();
            CreateMap<Aplicacion, AplicacionGeneral>();
            CreateMap<AplicacionGeneral, Aplicacion>();
            //Combos
            CreateMap<CondicionTrabajo, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdCondicionTrabajo))
                            .ForMember(p => p.Descripcion, x => x.MapFrom(p => p.Descripcion));
            CreateMap<TipoEmpleado, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdTipoEmpleado))
                            .ForMember(p => p.Descripcion, x => x.MapFrom(p => p.Descripcion));
            CreateMap<TipoDocumentoIdentidad, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdTipoDocumentoIdentidad))
                            .ForMember(p => p.Descripcion, x => x.MapFrom(p => p.Descripcion));
            CreateMap<AreaLaboratorio, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdAreaLaboratorio))
                            .ForMember(p => p.Descripcion, x => x.MapFrom(p => p.Nombre));
            CreateMap<PruebaLaboratorio, ComboBox>()
                            .ForMember(p => p.Descripcion, x => x.MapFrom(p => p.Nombre));
            CreateMap<Empleado, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdEmpleado))
                            .ForMember(p => p.Descripcion, x => x.MapFrom(p => string.Concat(p.ApellidoPaterno, " ", p.ApellidoMaterno, ", ", p.Nombres)));
            CreateMap<OpcionesOrdenMedica, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdOpcionOrdenMedica));
            CreateMap<OpcionesOrdenMedica, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdOpcionOrdenMedica));
            CreateMap<OpcionesOrdenMedicaView, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdOpcionOrdenMedica));
            CreateMap<TipoOrdenMedica, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdTipoOrdenMedica));
            CreateMap<CodigosRespuestaIndicadoresDesempeno, ComboBox>();
            CreateMap<EscalafonDeLegajos, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdEscalafonDeLegajos))
                            .ForMember(p => p.Descripcion, x => x.MapFrom(p => string.Concat(p.Seccion, " - ", p.Descripcion)));

            CreateMap<ComboBox, CondicionTrabajo>()
                            .ForMember(p => p.IdCondicionTrabajo, x => x.MapFrom(p => p.Id));
            CreateMap<ComboBox, TipoEmpleado>()
                            .ForMember(p => p.IdTipoEmpleado, x => x.MapFrom(p => p.Id));
            CreateMap<ComboBox, TipoDocumentoIdentidad>()
                            .ForMember(p => p.IdTipoDocumentoIdentidad, x => x.MapFrom(p => p.Id));
            CreateMap<ComboBox, OpcionesOrdenMedica>()
                            .ForMember(p => p.IdOpcionOrdenMedica, x => x.MapFrom(p => p.Id));
            //Modulo
            CreateMap<NuevoModulo, Modulo>();
            CreateMap<ActualizarModulo, Modulo>();
            CreateMap<Modulo, ModuloGeneral>();
            CreateMap<ModuloGeneral, Modulo>();
            //SubModulo
            CreateMap<NuevoSubModulo, SubModulo>();
            CreateMap<ActualizarSubModulo, SubModulo>();
            CreateMap<SubModulo, SubModuloGeneral>();
            CreateMap<SubModuloGeneral, SubModulo>();
            //RolSubModulo
            CreateMap<RolSubModuloDto, RolSubModulo>();
            CreateMap<RolSubModulo, RolSubModuloDto>();
            //IncidentesPacientes
            CreateMap<NuevoIncidentesPacientes, IncidentesPacientes>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<ActualizarIncidentesPacientes, IncidentesPacientes>();
            CreateMap<IncidentesPacientes, IncidentesPacientesGeneral>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            CreateMap<IncidentesPacientesGeneral, IncidentesPacientes>();
            //IncumplimientoAnalisis
            CreateMap<NuevoIncumplimientoAnalisis, IncumplimientoAnalisis>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<ActualizarIncumplimientoAnalisis, IncumplimientoAnalisis>();
            CreateMap<IncumplimientoAnalisis, IncumplimientoAnalisisGeneral>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            CreateMap<IncumplimientoAnalisisGeneral, IncumplimientoAnalisis>();
            //PruebasNoRealizadas
            CreateMap<NuevoPruebasNoRealizadas, PruebasNoRealizadas>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<ActualizarPruebasNoRealizadas, PruebasNoRealizadas>();
            CreateMap<PruebasNoRealizadas, PruebasNoRealizadasGeneral>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            CreateMap<PruebasNoRealizadasGeneral, PruebasNoRealizadas>();
            //RecoleccionMuestra
            CreateMap<NuevoRecoleccionMuestra, RecoleccionMuestra>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<ActualizarRecoleccionMuestra, RecoleccionMuestra>();
            CreateMap<RecoleccionMuestra, RecoleccionMuestraGeneral>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            CreateMap<RecoleccionMuestraGeneral, RecoleccionMuestra>();
            //VenopunturasFallidas
            CreateMap<NuevoVenopunturasFallidas, VenopunturasFallidas>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<ActualizarVenopunturasFallidas, VenopunturasFallidas>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<VenopunturasFallidas, VenopunturasFallidasGeneral>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            CreateMap<VenopunturasFallidasGeneral, VenopunturasFallidas>();
            //CalibracionDeficiente
            CreateMap<NuevoCalibracionDeficiente, CalibracionDeficiente>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<CalibracionDeficiente, CalibracionDeficienteGeneral>()
                            .ForMember(p => p.NombreMes, x => x.MapFrom(p => new DateTime(2020, p.NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).FirstCharToUpper()))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //EmpleoReactivo
            CreateMap<NuevoEmpleoReactivo, EmpleoReactivo>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<EmpleoReactivo, EmpleoReactivoGeneral>()
                            .ForMember(p => p.NombreMes, x => x.MapFrom(p => new DateTime(2020, p.NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).FirstCharToUpper()))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));

            //EquipoMalCalibrado
            CreateMap<NuevoEquipoMalCalibrado, EquipoMalCalibrado>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<EquipoMalCalibrado, EquipoMalCalibradoGeneral>()
                            .ForMember(p => p.NombreMes, x => x.MapFrom(p => new DateTime(2020, p.NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).FirstCharToUpper()))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //EquipoUPS
            CreateMap<NuevoEquipoUPS, EquipoUPS>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<EquipoUPS, EquipoUPSGeneral>()
                            .ForMember(p => p.NombreMes, x => x.MapFrom(p => new DateTime(2020, p.NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).FirstCharToUpper()))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //MaterialNoCalibrado
            CreateMap<NuevoMaterialNoCalibrado, MaterialNoCalibrado>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<MaterialNoCalibrado, MaterialNoCalibradoGeneral>()
                            .ForMember(p => p.NombreMes, x => x.MapFrom(p => new DateTime(2020, p.NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).FirstCharToUpper()))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //MuestraHemolizadaLipemica
            CreateMap<NuevoMuestraHemolizadaLipemica, MuestraHemolizadaLipemica>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<MuestraHemolizadaLipemica, MuestraHemolizadaLipemicaGeneral>()
                            .ForMember(p => p.NombreMes, x => x.MapFrom(p => new DateTime(2020, p.NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).FirstCharToUpper()))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //PocoFrecuente
            CreateMap<NuevoPocoFrecuente, PocoFrecuente>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<PocoFrecuente, PocoFrecuenteGeneral>()
                            .ForMember(p => p.NombreMes, x => x.MapFrom(p => new DateTime(2020, p.NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).FirstCharToUpper()))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //SueroMalReferenciado
            CreateMap<NuevoSueroMalReferenciado, SueroMalReferenciado>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<SueroMalReferenciado, SueroMalReferenciadoGeneral>()
                            .ForMember(p => p.NombreMes, x => x.MapFrom(p => new DateTime(2020, p.NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).FirstCharToUpper()))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //SolicitudDatosIncompletos
            CreateMap<NuevoSolicitudDatosIncompletos, SolicitudDatosIncompletos>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<SolicitudDatosIncompletos, SolicitudDatosIncompletosGeneral>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd"))); ;
            //TranscripcionErronea
            CreateMap<NuevoTranscripcionErronea, TranscripcionErronea>()
                            .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<TranscripcionErronea, TranscripcionErroneaGeneral>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //TranscripcionErroneaInoportuna
            CreateMap<NuevoTranscripcionErroneaInoportuna, TranscripcionErroneaInoportuna>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<TranscripcionErroneaInoportuna, TranscripcionErroneaInoportunaGeneral>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //SueroMalReferenciado
            CreateMap<NuevoRendimientoHoraTrabajador, RendimientoHoraTrabajador>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<RendimientoHoraTrabajador, RendimientoHoraTrabajadorGeneral>()
                            .ForMember(p => p.NombreMes, x => x.MapFrom(p => new DateTime(2020, p.NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).FirstCharToUpper()))
                            .ForMember(p => p.AreaLaboratorio, x => x.MapFrom(p => p.AreaLaboratorio.Nombre))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //PacienteSinResultado
            CreateMap<NuevoPacienteSinResultado, PacienteSinResultado>()
                .ForMember(r => r.Origen, x => x.MapFrom(p => p.Origen.Descripcion));
            CreateMap<PacienteSinResultado, PacienteSinResultadoGeneral>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            //Reporte
            CreateMap<Reporte, ReporteGeneral>();
            //Modulo
            CreateMap<NuevoArchivo, Archivo>();

            //EquipoUPS
            CreateMap<AuditoriaGeneral, Auditoria>();
            //TicketConsultaExterna
            CreateMap<NuevoTicketConsultaExterna, TicketConsultaExterna>();
            CreateMap<TicketConsultaExterna, TicketConsultaExternaGeneral>()
                .ForMember(r => r.Numero, x => x.MapFrom(p => 0))
                            .ForMember(r => r.FechaHora, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("dd/MM/yyyy - HH:mm:ss")));
            //ORDENES MEDICAS
            CreateMap<NuevaOrdenMedica, OrdenesMedicas>();
                            //.ForMember(r => r.Fecha, x => x.MapFrom(p => p.Fecha.Add(new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second))));
            CreateMap<OrdenesMedicas, OrdenMedicaGeneral>()
                            .ForMember(r => r.FechaRegistro, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("dd/MM/yyyy HH:mm")))
                            .ForMember(r => r.Fecha, x => x.MapFrom(p => p.Fecha.Equals(default(DateTime)) ? string.Empty : p.Fecha.ToString("yyyy-MM-dd")));

            CreateMap<OrdenMedicaView, OrdenMedicaGeneral>()
                            //.ForMember(r => r.FechaRegistro, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("dd/MM/yyyy HH:mm")))
                            .ForMember(r => r.TipoOrdenMedica,x => x.MapFrom(p => new ComboBox { Id = p.TipoOrdenMedica.IdTipoOrdenMedica, Descripcion = p.TipoOrdenMedica.Descripcion }))
                            .ForMember(r => r.Fecha, x => x.MapFrom(p => p.Fecha.Equals(default(DateTime)) ? string.Empty : p.Fecha));

            CreateMap<NuevaOrdenesMedicasCodigos, OrdenesMedicasCodigos>();
            CreateMap<OrdenesMedicasCodigos, OrdenesMedicasCodigosGeneral>();
            CreateMap<OrdenesMedicasCodigosView, OrdenesMedicasCodigosGeneral>();

            CreateMap<TipoOrdenMedica, TipoOrdenMedicaGeneral>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdTipoOrdenMedica))
                            .ForMember(p => p.Codigo, x => x.MapFrom(p => p.Descripcion.Replace(" ", "")));

            //Procedimiento
            CreateMap<Procedimiento, ProcedimientoDto>();
            //TipoOrdenMedicaRangos
            CreateMap<TipoOrdenMedicaRangos, TipoOrdenMedicaRangosDto>()
                            .ForMember(p => p.Condicionales, x => x.MapFrom(p => p.Condicionales.Split("|", StringSplitOptions.None).OfType<string>().ToList()));

            CreateMap<NuevaAtencionTrabajador, AtencionTrabajador>();
            CreateMap<AtencionTrabajador, AtencionTrabajadorGeneral>();

            //Receta Medica
            CreateMap<RecetaMedicaEstandar, RecetaMedicaEstandarDTO>()
                            .ForMember(r => r.FechaEmision, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.ValidoHasta, x => x.MapFrom(p => p.ValidoHasta.Equals(default(DateTime)) ? string.Empty : p.ValidoHasta.ToString("yyyy-MM-dd")));
            CreateMap<RecetaMedicaEstandar, RecetaMedicaEstandarImprimirDTO>()
                            .ForMember(r => r.ValidoHasta, x => x.MapFrom(p => p.ValidoHasta.Equals(default(DateTime)) ? string.Empty : p.ValidoHasta.ToString("yyyy-MM-dd"))); ;
            CreateMap<NuevaRecetaMedicaEstandar, RecetaMedicaEstandar>();
            CreateMap<AgregarMedicamentoDTO, Medicamento>()
                            .ForMember(r => r.ViaAdministracion, x => x.MapFrom(p => p.Via));
            CreateMap<Medicamento, MedicamentoDTO>()
                            .ForMember(r => r.Via, x => x.MapFrom(p => p.ViaAdministracion));

            //Receta REfraccion

            CreateMap<RegistroRecetaRefraccion, RecetaRefraccionCE>()
                            .ForMember(r => r.LSignoOD1, x => x.MapFrom(p => p.LSignoOD1.Descripcion))
                            .ForMember(r => r.LSignoOD2, x => x.MapFrom(p => p.LSignoOD2.Descripcion))
                            .ForMember(r => r.LSignoOI1, x => x.MapFrom(p => p.LSignoOI1.Descripcion))
                            .ForMember(r => r.LSignoOI2, x => x.MapFrom(p => p.LSignoOI2.Descripcion))
                            .ForMember(r => r.CSignoOD1, x => x.MapFrom(p => p.CSignoOD1.Descripcion))
                            .ForMember(r => r.CSignoOD2, x => x.MapFrom(p => p.CSignoOD2.Descripcion))
                            .ForMember(r => r.CSignoOI1, x => x.MapFrom(p => p.CSignoOI1.Descripcion))
                            .ForMember(r => r.CSignoOI2, x => x.MapFrom(p => p.CSignoOI2.Descripcion))
                            .ForMember(r => r.ListaDeDx, x => x.MapFrom(p => string.Join(',', p.ListaDeDx)))
                            //.ForMember(r => r.IdMaterial, x => x.MapFrom(p => p.Material.Id == 0 ? (int?)null : p.Material.Id))
                            //.ForMember(r => r.IdBifocal, x => x.MapFrom(p => p.Bifocal.Id == 0 ? (int?)null : p.Bifocal.Id))
                            //.ForMember(r => r.IdEspecificacion1, x => x.MapFrom(p => p.Especificacion1.Id == 0 ? (int?)null : p.Especificacion1.Id))
                            //.ForMember(r => r.IdEspecificacion2, x => x.MapFrom(p => p.Especificacion2.Id == 0 ? (int?)null : p.Especificacion2.Id))
                            //.ForMember(r => r.IdEspecificacion3, x => x.MapFrom(p => p.Especificacion3.Id == 0 ? (int?)null : p.Especificacion3.Id))
                            //.ForMember(r => r.IdEspecificacion4, x => x.MapFrom(p => p.Especificacion4.Id == 0 ? (int?)null : p.Especificacion4.Id))
                            //.ForMember(r => r.IdEspecificacion5, x => x.MapFrom(p => p.Especificacion5.Id == 0 ? (int?)null : p.Especificacion5.Id));
                            .ForMember(r => r.Material, x => x.MapFrom(p => string.Join(',', p.Material.Select(s => s.Descripcion))))
                            .ForMember(r => r.Diseno, x => x.MapFrom(p => string.Join(',', p.Diseno.Select(s => s.Descripcion))))
                            .ForMember(r => r.Tratamiento, x => x.MapFrom(p => string.Join(',', p.Tratamiento.Select(s => s.Descripcion))))
                            .ForMember(r => r.Servicio, x => x.MapFrom(p => string.Join(',', p.Servicio.Select(s => s.Descripcion))));

            // Views

            //Repositorio de Congreso
            CreateMap<AsistenciaGeneral, AsistenciaGeneralView>();
            CreateMap<EventoGeneral, EventoGeneralView>();
            CreateMap<ParticipanteGeneral, ParticipanteGeneralView>();

            //Repositorio de Adicionales
            CreateMap<Adicionales, AdicionalesView>();
            CreateMap<AdicionalesView, Adicionales>()
                .ForMember(r => r.FechaAdicional, x => x.MapFrom(p => p.FechaAdicional.ToString("dd/MM/yyyy")))
                .ForMember(r => r.FechaRegistro, x => x.MapFrom(p => p.FechaRegistro.ToString("dd/MM/yyyy")));

            //Reposiorio de Archivos
            CreateMap<ArchivoPorFechaYUsuario, ArchivoPorFechaYUsuarioView>();

            //Repositorio de Atenciones
            CreateMap<AtencionFiltro, AtencionFiltroView>();
            CreateMap<AtencionFiltroView, AtencionFiltro>()
                        .ForMember(r => r.ProximaCita, x => x.MapFrom(p => p.ProximaCita.HasValue ? p.ProximaCita.Value.ToString("yyyy-MM-dd") : ""))
                        .ForMember(r => r.ImagenOjos, x => x.MapFrom(p => Convert.ToBase64String(p.ImagenOjos)));
            CreateMap<CitadosPorFecha, CitadosPorFechaView>();
            CreateMap<CitadosPorFechaMedicoEspecialidad, CitadosPorFechaMedicoEspecialidadView>();
            CreateMap<Diagnostico, DiagnosticoView>();

            //Reposiorio de BonoDesempeno
            CreateMap<DiferimientoCitas, DiferimientoCitasView>();
            CreateMap<TiempoEsperaAtencion, TiempoEsperaAtencionView>();

            //Repositorio de Comunes
            CreateMap<ComboBox, ComboBoxView>();
            CreateMap<PruebaLaboratorio, PruebaLaboratorioView>();

            //Repositorio de Medicos
            CreateMap<MedicoPorEspecialidad, MedicoPorEspecialidadView>();
            CreateMap<MedicoListar, MedicoListarView>();

            //Reposiorio de Pacients
            CreateMap<HistorialAtenciones, HistorialAtencionesView>();
            CreateMap<HistorialCentroQuirurgico, HistorialCentroQuirurgicoView>();
            CreateMap<HistorialEmergencia, HistorialEmergenciaView>();
            CreateMap<HistorialLaboratorio, HistorialLaboratorioView>();
            CreateMap<HistorialRiesgoQuirurgico, HistorialRiesgoQuirurgicoView>();
            CreateMap<PacienteCitado, PacienteCitadoView>();
            CreateMap<PacienteAfiliacion, PacienteAfiliacionView>();
            CreateMap<PacientePorHcDni, PacientePorHcDniView>();
            CreateMap<PacientePorHcDniView, PacientePorHcDni>()
                .ForMember(r => r.EsRefraccion, x => x.Ignore());

            //Repositorio de Servicios
            CreateMap<ServicioPorEspecialidad, ServicioPorEspecialidadView>();

            //Repositorio de Recetas Medicas
            CreateMap<MedicamentoGeneral, MedicamentoView>();

            //Indicadores Gestion
            CreateMap<NuevoExamenAtendidoPorServicio, ExamenAtendidoPorServicioModel>();
            CreateMap<NuevoExamenNoInformadoPorServicio, ExamenNoInformadoPorServicioModel>();
            CreateMap<ExamenAtendidoPorServicioModel, ExamenAtendidoPorServicio>();
            CreateMap<ExamenNoInformadoPorServicioModel, ExamenNoInformadoPorServicio>();
            CreateMap<ExamenAtendidoPorServicio, ExamenAtendidoPorServicioDto>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));
            CreateMap<ExamenNoInformadoPorServicio, ExamenNoInformadoPorServicioDto>()
                            .ForMember(r => r.FechaOcurrencia, x => x.MapFrom(p => p.FechaOcurrencia.Equals(default(DateTime)) ? string.Empty : p.FechaOcurrencia.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.Equals(default(DateTime)) ? string.Empty : p.FechaCreacion.ToString("yyyy-MM-dd")));

            //Accidente de Trabajo
            CreateMap<RegistroAccidenteDeTrabajo, AccidenteDeTrabajo>()
                            .ForMember(r => r.AgenteAccidente_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.MecanismoFormaAccidente_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.ParteCuerpo_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.TipoLesion_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.Descripcion_MedidaCorrectiva, x => x.Ignore())
                            .ForMember(r => r.EstadoImplementacion_MedidaCorrectiva, x => x.Ignore())
                            .ForMember(r => r.FechaEjecucion_MedidaCorrectiva, x => x.Ignore())
                            .ForMember(r => r.Responsable_MedidaCorrectiva, x => x.Ignore())
                            .ForMember(r => r.EsLaborHabitual_Accidente, x => x.MapFrom(p => p.EsLaborHabitual_Accidente == "1" ? true : false))
                            .ForMember(r => r.HuboTestigos_DescripcionAccidente, x => x.MapFrom(p => p.HuboTestigos_DescripcionAccidente == "1" ? true : false));

            CreateMap<ActualizarAccidenteDeTrabajo, AccidenteDeTrabajo>()
                            .ForMember(r => r.AgenteAccidente_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.MecanismoFormaAccidente_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.ParteCuerpo_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.TipoLesion_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.Descripcion_MedidaCorrectiva, x => x.Ignore())
                            .ForMember(r => r.EstadoImplementacion_MedidaCorrectiva, x => x.Ignore())
                            .ForMember(r => r.FechaEjecucion_MedidaCorrectiva, x => x.Ignore())
                            .ForMember(r => r.Responsable_MedidaCorrectiva, x => x.Ignore())
                            .ForMember(r => r.EsLaborHabitual_Accidente, x => x.MapFrom(p => p.EsLaborHabitual_Accidente == "1" ? true : false))
                            .ForMember(r => r.HuboTestigos_DescripcionAccidente, x => x.MapFrom(p => p.HuboTestigos_DescripcionAccidente == "1" ? true : false));

            CreateMap<AccidenteDeTrabajo, AccidenteDeTrabajoDto>()
                            .ForMember(r => r.AgenteAccidente_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.MecanismoFormaAccidente_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.ParteCuerpo_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.TipoLesion_CausaAccidente, x => x.Ignore())
                            .ForMember(r => r.MedidasCorrectivas, x => x.Ignore())
                            .ForMember(r => r.RegistrosInvestigacion, x => x.Ignore())
                            .ForMember(r => r.EsLaborHabitual_Accidente, x => x.MapFrom(p => p.EsLaborHabitual_Accidente ? "1" : "0"))
                            .ForMember(r => r.HuboTestigos_DescripcionAccidente, x => x.MapFrom(p => p.HuboTestigos_DescripcionAccidente ? "1" : "0"))
                            .ForMember(r => r.FechaNacimiento_Accidentado, x => x.MapFrom(p => p.FechaNacimiento_Accidentado.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.Fecha_Accidente, x => x.MapFrom(p => p.Fecha_Accidente.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaInvestigacion_Accidente, x => x.MapFrom(p => p.FechaInvestigacion_Accidente.ToString("yyyy-MM-dd")));

            //Consulta Web - Solicitud Cita
            CreateMap<RegistroSolicitudCita, SolicitudCita>();
            CreateMap<SolicitudCita, SolicitudCitaDto>()
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaAcepta, x => x.MapFrom(p => p.FechaAcepta == null ? "" : p.FechaAcepta.Value.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaRechaza, x => x.MapFrom(p => p.FechaRechaza == null ? "" : p.FechaRechaza.Value.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.FechaAtiende, x => x.MapFrom(p => p.FechaAtiende == null ? "" : p.FechaAtiende.Value.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.CodProc, x => x.MapFrom(p => p.CodProc))
                            .ForMember(r => r.DesProc, x => x.MapFrom(p => p.DesProc))
                            .ForMember(r => r.TipoConsulta, x => x.MapFrom(p => p.TipoConsulta ?? ""));

            CreateMap<CitaCuarentenaView, CitaCuarentenaDto>()
                            .ForMember(r => r.FechaCita, x => x.MapFrom(p => p.FechaCita.ToString("dd/MM/yyyy")));

            CreateMap<RegistroSolicitudReprogramacion, SolicitudReprogramacion>();
            CreateMap<CitaCuarentenaCorreoView, CitaCuarentenaCorreoDto>()
                            .ForMember(r => r.FechaCita, x => x.MapFrom(p => p.FechaCita.ToString("dd/MM/yyyy")));
            CreateMap<SolicitudReprogramacion, SolicitudReprogramacionCitaCuarentenaDto>()
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.ToString("yyyy-MM-dd")))
                            .ForMember(r => r.NuevaFechaReprogramacion, x => x.MapFrom(p => p.NuevaFechaReprogramacion == null ? "" : p.NuevaFechaReprogramacion.Value.ToString("yyyy-MM-dd")));

            CreateMap<CrearSolicitudTeleconsultaDto, SolicitudTeleconsulta>();
            CreateMap<CitaPostCuarentenaView, CitaPostCuarentenaDto>()
                            .ForMember(r => r.FechaCita, x => x.MapFrom(p => p.FechaCita.ToString("dd/MM/yyyy")));

            CreateMap<SolicitudTeleconsulta, SolicitudTeleconsultaDto>()
                            .ForMember(r => r.FechaCita, x => x.MapFrom(p => p.FechaCita.ToString("dd/MM/yyyy")))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.ToString("dd/MM/yyyy")))
                            .ForMember(r => r.FechaAtiende, x => x.MapFrom(p => p.FechaAtiende.HasValue ? p.FechaAtiende.Value.ToString("dd/MM/yyyy") : ""))
                            .ForMember(r => r.FechaAcepta, x => x.MapFrom(p => p.FechaAcepta.HasValue ? p.FechaAcepta.Value.ToString("dd/MM/yyyy") : ""));

            CreateMap<Especificaciones, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdEspecificacion));

            CreateMap<Bifocal, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdBifocal));

            CreateMap<Material, ComboBox>()
                            .ForMember(p => p.Id, x => x.MapFrom(p => p.IdMaterial));

            CreateMap<RecetaRefraccionCE, RecetaRefraccionDto>();

            //Consulta Web - Consulta Rapida
            CreateMap<RegistroSolicitudConsultaRapidaDto, SolicitudConsultaRapida>();
            CreateMap<SolicitudConsultaRapida, SolicitudConsultaRapidaDto>()
                            .ForMember(r => r.FechaEmision, x => x.MapFrom(p => p.FechaEmision.HasValue ?  p.FechaEmision.Value.ToString("dd/MM/yyyy") : ""))
                            .ForMember(r => r.FechaNacimiento, x => x.MapFrom(p => p.FechaNacimiento.ToString("dd/MM/yyyy")))
                            .ForMember(r => r.FechaSolicitud, x => x.MapFrom(p => p.FechaCreacion.ToString("dd/MM/yyyy")))
                            .ForMember(r => r.FechaAcepta, x => x.MapFrom(p => p.FechaAcepta.HasValue ? p.FechaAcepta.Value.ToString("dd/MM/yyyy HH:mm") : ""))
                            .ForMember(r => r.FechaCita, x => x.MapFrom(p => p.FechaCita.HasValue ? p.FechaCita.Value.ToString("dd/MM/yyyy") : ""))
                            .ForMember(r => r.IdMedico, x => x.MapFrom(p => p.IdMedico ?? 0))
                            .ForMember(r => r.Medico, x => x.MapFrom(p => p.Medico ?? ""))
                            .ForMember(r => r.Edad, x => x.MapFrom(p => this.CalculateAgeStr(p.FechaNacimiento,4)))
                            .ForMember(r => r.TipoSeguro, x => x.MapFrom(p => p.TipoSeguro ?? 0))
                            .ForMember(r => r.NumeroReferencia, x => x.MapFrom(p => p.NumeroReferencia ?? ""))
                            .ForMember(r => r.Especialidad, x => x.MapFrom(p => p.IdEspecialidad.HasValue ? new ComboBox { Id = p.IdEspecialidad.Value, Descripcion = p.NombreEspecialidad } : new ComboBox { Id = 0, Descripcion = "<SELECCIONAR>"}))
                            .ForMember(r => r.FechaRechazo, x => x.MapFrom(p => p.FechaRechazo.HasValue ? p.FechaRechazo.Value.ToString("dd/MM/yyyy HH:mm") : ""))
                            .ForMember(r => r.TipoPaciente, x => x.MapFrom(p => string.IsNullOrEmpty(p.NumeroReferencia) ? "OTROS": "SIS"))
                            .ForMember(r => r.ImagenReferencia, x => x.MapFrom(p => (string.IsNullOrEmpty(p.ImagenReferencia)) ? string.Empty : Convert.ToBase64String(File.ReadAllBytes(p.ImagenReferencia))));

            //Vacunacion Covid - 19
            CreateMap<GuardarCIDto, ConsentimientoInformadoCOVID19>();
            CreateMap<GuardarVacDto, VacunacionCOVID19>()
                            .ForMember(r => r.FechaNacimiento, x => x.MapFrom(p => DateTime.ParseExact(p.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

            //Evaluacion de Examenes Computarizados
            CreateMap<RegistrarEvaluacionExamenDto, EvaluacionExamen>()
                            .ForMember(r => r.Programa, x => x.MapFrom(p => string.Join(",",p.Programa)))
                            .ForMember(r => r.Estrategia, x => x.MapFrom(p => string.Join(",", p.Estrategia)))
                            .ForMember(r => r.EstimuloNumero, x => x.MapFrom(p => string.Join(",", p.EstimuloNumero)))
                            .ForMember(r => r.EstimuloColor, x => x.MapFrom(p => string.Join(",", p.EstimuloColor)))
                            .ForMember(r => r.ConfiabilidadOD, x => x.MapFrom(p => p.ConfiabilidadOD.Descripcion))
                            .ForMember(r => r.ConfiabilidadOI, x => x.MapFrom(p => p.ConfiabilidadOI.Descripcion))
                            .ForMember(r => r.DefectoCampoVisualOD, x => x.MapFrom(p => p.DefectoCampoVisualOD.Descripcion))
                            .ForMember(r => r.DefectoCampoVisualOI, x => x.MapFrom(p => p.DefectoCampoVisualOI.Descripcion))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => DateTime.Now))
                            .ForMember(r => r.IdUsuarioCreacion, x => x.MapFrom(p => p.IdUsuarioCreacion))
                            .ForMember(r => r.IdEstado, x => x.MapFrom(p => 1));

            CreateMap<EvaluacionExamen, EvaluacionExamenDto>()
                            .ForMember(r => r.IdEvaluacionExamen, x => x.MapFrom(p => p.Id))
                            .ForMember(r => r.Programa, x => x.MapFrom(p => string.IsNullOrEmpty(p.Programa) ? new string[] { } : p.Programa.Split(',', StringSplitOptions.None)))
                            .ForMember(r => r.Estrategia, x => x.MapFrom(p => string.IsNullOrEmpty(p.Estrategia) ? new string[] { } : p.Estrategia.Split(',', StringSplitOptions.None)))
                            .ForMember(r => r.EstimuloNumero, x => x.MapFrom(p => string.IsNullOrEmpty(p.EstimuloNumero) ? new string[] { } : p.EstimuloNumero.Split(',', StringSplitOptions.None)))
                            .ForMember(r => r.EstimuloColor, x => x.MapFrom(p => string.IsNullOrEmpty(p.EstimuloColor) ? new string[] { } : p.EstimuloColor.Split(',', StringSplitOptions.None)))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.ToString("dd/MM/yyyy HH:mm")))
                            .ForMember(r => r.FechaModificacion, x => x.MapFrom(p => p.FechaModificacion.HasValue ? p.FechaModificacion.Value.ToString("dd/MM/yyyy HH:mm") : ""));

            //Anestesia
            CreateMap<RegistrarEvaluacionPreAnestesica, EvaluacionPreAnestesica>()
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => DateTime.Now))
                            .ForMember(r => r.ClasificacionGOLDMAN, x => x.MapFrom(p => string.Join(",", p.ClasificacionGOLDMAN)))
                            .ForMember(r => r.IdEstado, x => x.MapFrom(p => 1));
            CreateMap<ModificarEvaluacionPreAnestesica, EvaluacionPreAnestesica>()
                            .ForMember(r => r.FechaModificacion, x => x.MapFrom(p => DateTime.Now))
                            .ForMember(r => r.ClasificacionGOLDMAN, x => x.MapFrom(p => string.Join(",", p.ClasificacionGOLDMAN)))
                            .ForMember(r => r.IdEstado, x => x.MapFrom(p => 1));
            CreateMap<EvaluacionPreAnestesica, EvaluacionPreAnestesicaDto>()
                            .ForMember(r => r.LaboratorioImagen_FechaExamen1, x => x.MapFrom(p => p.LaboratorioImagen_FechaExamen1.HasValue ? p.LaboratorioImagen_FechaExamen1.Value.ToString("dd/MM/yyyy") : ""))
                            .ForMember(r => r.LaboratorioImagen_FechaExamen2, x => x.MapFrom(p => p.LaboratorioImagen_FechaExamen2.HasValue ? p.LaboratorioImagen_FechaExamen2.Value.ToString("dd/MM/yyyy") : ""))
                            .ForMember(r => r.LaboratorioImagen_FechaExamen3, x => x.MapFrom(p => p.LaboratorioImagen_FechaExamen3.HasValue ? p.LaboratorioImagen_FechaExamen3.Value.ToString("dd/MM/yyyy") : ""))
                            .ForMember(r => r.LaboratorioImagen_FechaExamen4, x => x.MapFrom(p => p.LaboratorioImagen_FechaExamen4.HasValue ? p.LaboratorioImagen_FechaExamen4.Value.ToString("dd/MM/yyyy") : ""))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.ToString("dd/MM/yyyy")))
                            .ForMember(r => r.FechaModificacion, x => x.MapFrom(p => p.FechaModificacion.HasValue ? p.FechaModificacion.Value.ToString("dd/MM/yyyy") : ""))
                            .ForMember(r => r.ClasificacionGOLDMAN, x => x.MapFrom(p => p.ClasificacionGOLDMAN.Split(',', StringSplitOptions.None)));

            //Nervio Optico
            CreateMap<RegistrarNervioOptico, NervioOptico>()
                            .ForMember(r => r.IdEstado, x => x.MapFrom(p => 1))
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => DateTime.Now));
            CreateMap<ModificarNervioOptico, NervioOptico>()
                            .ForMember(r => r.FechaModificacion, x => x.MapFrom(p => DateTime.Now));
            CreateMap<NervioOptico, NervioOpticoDto>()
                            .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.ToString("dd/MM/yyyy")))
                            .ForMember(r => r.FechaModificacion, x => x.MapFrom(p => p.FechaModificacion.HasValue ? p.FechaModificacion.Value.ToString("dd/MM/yyyy") : ""));
            
            //Citas Web
            CreateMap<CitaWeb, CitaWebDto>()
                .ForMember(r => r.FechaCita, x => x.MapFrom(p => p.Fecha.ToString("dd/MM/yyyy")))
                .ForMember(r => r.FechaEmisionComprobante, x => x.MapFrom(p => p.FechaEmisionComprobante.HasValue ? p.FechaEmisionComprobante.Value.ToString("dd/MM/yyyy") : ""))
                .ForMember(r => r.FechaPago, x => x.MapFrom(p => p.FechaPago.HasValue ? p.FechaPago.Value.ToString("dd/MM/yyyy") : ""))
                .ForMember(r => r.ImagenVoucher, x => x.MapFrom(p => (string.IsNullOrEmpty(p.ImagenVoucher)) ? string.Empty : Convert.ToBase64String(File.ReadAllBytes(p.ImagenVoucher))))
                .ForMember(r => r.Aprobado, x => x.MapFrom(p => p.VoucherValido.HasValue && p.VoucherValido.Value ? 1 : 0));
            
            //Evaluaciones
            CreateMap<RegistrarPreguntaRespuestaDto, EvaluacionPregunta>()
                .ForMember(r => r.IdUsuarioCreacion, x => x.MapFrom(p => p.IdUsuario))
                .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => DateTime.Now))
                .ForMember(r => r.Activo, x => x.MapFrom(p => false))
                .ForMember(r => r.Respuestas, x => x.MapFrom(p => ParseEvalRespuestas(p.Respuestas)));
            CreateMap<ModificarPreguntaRespuestaDto, EvaluacionPregunta>()
                .ForMember(r => r.IdUsuarioModificacion, x => x.MapFrom(p => p.IdUsuario))
                .ForMember(r => r.FechaModificacion, x => x.MapFrom(p => DateTime.Now))
                .ForMember(r => r.Activo, x => x.MapFrom(p => p.Activo == 1 ? true : false))
                .ForMember(r => r.Respuestas, x => x.MapFrom(p => ParseEvalRespuestas(p.Respuestas)));
            CreateMap<RegistrarParticipanteDto, EvaluacionParticipante>()
                .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => DateTime.Now))
                .ForMember(r => r.IdEstado, x => x.MapFrom(p => 1));
            CreateMap<EvaluacionParticipante, EvalParticipanteDto>()
                .ForMember(r => r.FechaEmision, x => x.MapFrom(p => p.FechaEmision.ToString("dd/MM/yyyy")))
                .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => p.FechaCreacion.ToString("dd/MM/yyyy")));

            CreateMap<EvalParticipanteNumPregView, EvalParticipanteNumPregDto>();

            CreateMap<EvalPartCertView, EvalPartCertDto>()
                .ForMember(r => r.FechaEmision, x => x.MapFrom(p => p.FechaEmision.ToString("dd/MM/yyyy")))
                .ForMember(r => r.Certificados, x => x.MapFrom(p => MapCertificates(p)));

            CreateMap<CitaPorDiaView, CitaPorDiaDto>()
                .ForMember(r => r.Fecha, x => x.MapFrom(p => p.Fecha.ToString("dd/MM/yyyy")))
                .ForMember(r => r.NroDocumento, x => x.MapFrom(p => p.NroDocumento.ToString()));
            CreateMap<IngresoPacienteINO, IngresoSalidaDto>()
                .ForMember(r => r.FechaIngreso, x => x.MapFrom(p => p.FechaIngreso.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(r => r.FechaNacimiento, x => x.MapFrom(p => p.FechaNacimiento.HasValue ? p.FechaNacimiento.Value.ToString("dd/MM/yyyy") : ""))
                .ForMember(r => r.FechaSalida, x => x.MapFrom(p => p.FechaSalida.HasValue ? p.FechaSalida.Value.ToString("dd/MM/yyyy HH:mm") : ""))
                .ForMember(r => r.Edad, x => x.MapFrom(p => p.Edad ?? 0))
                .ForMember(r => r.IdUsuarioModifica, x => x.MapFrom(p => p.IdUsuarioModifica ?? 0));

            CreateMap<MedicoCitadosView, MedicoCitadosView>();

            CreateMap<ReprogramacionMedica, ReprogramacionMedicaDto>()
                .ForMember(r => r.FechaReprogramacion, x => x.MapFrom(p => p.FechaReprogramacion.ToString("dd/MM/yyyy HH:mm")));

            CreateMap<CitaGalenosTicketView, CitaGalenosTicketDto>()
                .ForMember(r => r.FechaCita, x => x.MapFrom(p => p.FechaCita.ToString("dd/MM/yyyy")));

            CreateMap<RegistrarCitaCallCenter, CitaCallCenter>()
                .ForMember(r => r.IdUsuarioRegistro, x => x.MapFrom(p => p.IdUsuario))
                .ForMember(r => r.TipoSeguro, x => x.MapFrom(p => p.LlamadaSinRegistro ? null : p.TipoSeguro.Descripcion))
                .ForMember(r => r.Especialidad, x => x.MapFrom(p => p.LlamadaSinRegistro ? null : !p.EsCita ? null : p.Especialidad.Especialidad))
                //.ForMember(r => r.FinLlamada, x => x.MapFrom(p => DateTime.Now.ToString("HH:mm")))
                .ForMember(r => r.FechaCita, x => x.MapFrom(p => p.LlamadaSinRegistro ? (DateTime?)null : !p.EsCita ? (DateTime?)null : p.FechaCita.Value))
                .ForMember(r => r.Turno, x => x.MapFrom(p => p.LlamadaSinRegistro ?  null :!p.EsCita ? null : p.Turno.Descripcion))
                .ForMember(r => r.FechaRegistro, x => x.MapFrom(p => DateTime.Now));

            CreateMap<CitaCallCenter, CitaCallCenterDto>()
                .ForMember(r => r.FechaCita, x => x.MapFrom(p => p.FechaCita.HasValue ? p.FechaCita.Value.ToString("dd/MM/yyyy") : ""))
                .ForMember(r => r.FechaLlamada, x => x.MapFrom(p => p.FechaLlamada.ToString("dd/MM/yyyy")));
            
            //Facturacion
            CreateMap<RegistrarNotaCreditoDebitoDto, FactComprobantesPago>()
                .ForMember(r => r.NroSerie, x => x.MapFrom(p => "B001"))
                .ForMember(r => r.NroDocumento, x => x.MapFrom(p => "00000001"))
                .ForMember(r => r.IgvCalc, x => x.MapFrom(p => 0))
                .ForMember(r => r.Estado, x => x.MapFrom(p => 1))
                .ForMember(r => r.FechaCreacion, x => x.MapFrom(p => DateTime.Now))
                .ForMember(r => r.UsuarioCreacion,  x => x.MapFrom(p => p.Usuario))
                .ForMember(r => r.NroDocumentoProv,  x => x.MapFrom(p => p.NumeroDocumento))
                .ForMember(r => r.NombreProveedor,  x => x.MapFrom(p => p.RazonSocial))
                .ForMember(r => r.TipoOperacionGravada,  x => x.MapFrom(p => p.TipoOperacionGravada))
                .ForMember(r => r.IdTipoDocumento,  x => x.MapFrom(p => p.TipoDocumento.Id))
                .ForMember(r => r.IdTipoOperacion,  x => x.MapFrom(p => p.TipoOperacion.Id))
                .ForMember(r => r.Concepto,  x => x.MapFrom(p => p.Motivo))
                .ForMember(r => r.NroHistoriaClinica,  x => x.MapFrom(p => p.NumeroHistoriaClinica))
                ;

            CreateMap<FactComprobantesPago, ComprobantePagoDto>()
                .ForMember(r => r.FechaEmision,
                    x => x.MapFrom(p => p.FechaEmision.HasValue ? p.FechaEmision.Value.ToString("dd/MM/yyyy") : ""))
                .ForMember(r => r.Documento, x => x.MapFrom(p => p.NroSerie + "-" + p.NroDocumento))
                .ForMember(r => r.TipoDoc, x => x.MapFrom(p => p.IdTipoDocumentoNavigation.Descripcion))
                .ForMember(r => r.TipoDocIdentidad, x => x.MapFrom(p => p.IdTipoDocProv == 1 ? "DNI" : "RUC"))
                .ForMember(r => r.NroDocIdentidad, x => x.MapFrom(p => p.NroDocumentoProv ?? ""))
                .ForMember(r => r.ReceptorRazonSocial, x => x.MapFrom(p => p.NombreProveedor ?? ""))
                .ForMember(r => r.Total, x => x.MapFrom(p => p.Total))
                .ForMember(r => r.Estado, x => x.MapFrom(p => p.EstadoNavigation.Descripcion));
            
            CreateMap<FactTipoOperacion, ComboBox>()
                .ForMember(p => p.Id, x => x.MapFrom(p => p.IdTipoOperacion))
                .ForMember(p => p.Descripcion, x => x.MapFrom(p => p.Codigo + " - " + p.Descripcion));
            CreateMap<ComprobantePagoGalenosView, ComprobantePagoGalenosDto>()
                .ForMember(r => r.Fecha,
                    x => x.MapFrom(p => p.Fecha.ToString("dd/MM/yyyy")))
                ;
        }

        private string CalculateAgeStr(DateTime birthday, int option)
        {
            DateTime date = DateTime.Now;
            TimeSpan diffResult = date.Subtract(birthday);
            string TotalDays = diffResult.Days.ToString();
            string Months = ((diffResult.Days) % 365).ToString();
            string RemainingMonths = (Convert.ToInt32(Months) / 31).ToString();
            string RemainginYears = ((diffResult.Days) / 365).ToString();
            string RemainingDays = (Convert.ToInt32(Months) % 31).ToString();

            string age = "";

            if (option == 1)
                return RemainginYears;
            else if (option == 2)
                return RemainingMonths;
            else if (option == 3)
                return RemainingDays;
            else
                return string.Concat(age, RemainginYears, " años ", RemainingMonths, " meses ", RemainingDays, " días");

        }

        private List<EvalCertFlagDto> MapCertificates(EvalPartCertView eval)
        {
            List<EvalCertFlagDto> lista = new List<EvalCertFlagDto>();
            EvalCertFlagDto dto1 = new EvalCertFlagDto
            {
                Id = 1,
                Enviado = eval.Certificado1 == 1 ? true : false,
                Fecha = eval.FechaCertificado1
            };
            EvalCertFlagDto dto2 = new EvalCertFlagDto
            {
                Id = 2,
                Enviado = eval.Certificado2 == 1 ? true : false,
                Fecha = eval.FechaCertificado2
            };
            EvalCertFlagDto dto3 = new EvalCertFlagDto
            {
                Id = 3,
                Enviado = eval.Certificado3 == 1 ? true : false,
                Fecha = eval.FechaCertificado3
            };
            EvalCertFlagDto dto4 = new EvalCertFlagDto
            {
                Id = 4,
                Enviado = eval.Certificado4 == 1 ? true : false,
                Fecha = eval.FechaCertificado4
            };
            EvalCertFlagDto dto5 = new EvalCertFlagDto
            {
                Id = 5,
                Enviado = eval.Certificado5 == 1 ? true : false,
                Fecha = eval.FechaCertificado5
            };
            lista.Add(dto1);
            lista.Add(dto2);
            lista.Add(dto3);
            lista.Add(dto4);
            lista.Add(dto5);

            return lista;
        }

        private string ParseEvalRespuestas(List<EvalRespuestaDto> respuestas)
        {
            string respuestasStr = "";
            List<String> listaStr = new List<String>();

            foreach (var r in respuestas)
            {
                string str = string.Concat(r.Id, "^", r.Texto, "^", r.EsCorrecto ? "RESP_CORRECTA" : "RESP_INCORRECTA");
                listaStr.Add(str);
            }

            if (listaStr.Count > 0)
                respuestasStr = string.Join('|', listaStr.ToArray());
            return respuestasStr;
        }
    }
}
