using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.AccidenteDeTrabajo;
using Ino_InvisionCore.Dominio.Entidades.Anestesia;
using Ino_InvisionCore.Dominio.Entidades.AtencionCE;
using Ino_InvisionCore.Dominio.Entidades.CallCenter;
using Ino_InvisionCore.Dominio.Entidades.CitasWeb;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Ino_InvisionCore.Dominio.Entidades.ConsultaWeb;
using Ino_InvisionCore.Dominio.Entidades.ConsultaWeb_ConsultaRapida;
using Ino_InvisionCore.Dominio.Entidades.Evaluacion;
using Ino_InvisionCore.Dominio.Entidades.EvaluacionesExamenes;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Ino_InvisionCore.Dominio.Entidades.NervioOptico;
using Ino_InvisionCore.Dominio.Entidades.OrdenMedica;
using Ino_InvisionCore.Dominio.Entidades.RecetaMedica;
using Ino_InvisionCore.Dominio.Entidades.VacunacionCOVID19;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Ino_InvisionCore.Infraestructura.Contexto.Extensions;
using Ino_InvisionCore.Infraestructura.Models;
using Microsoft.EntityFrameworkCore;

namespace Ino_InvisionCore.Infraestructura.Contexto
{
    public class InoContext : DbContext
    {
        public DbSet<Aplicacion> Aplicaciones { set; get; }
        public DbSet<Empleado> Empleados { set; get; }
        public DbSet<Rol> Roles { set; get; }
        public DbSet<Modulo> Modulo { set; get; }
        public DbSet<SubModulo> SubModulo { set; get; }
        public DbSet<RolSubModulo> RolSubModulo { set; get; }
        public DbSet<CondicionTrabajo> CondicionTrabajo { set; get; }
        public DbSet<TipoEmpleado> TipoEmpleado { set; get; }
        public DbSet<TipoDocumentoIdentidad> TipoDocumentoIdentidad { set; get; }
        public DbSet<RecoleccionMuestra> RecoleccionMuestra { set; get; }
        public DbSet<VenopunturasFallidas> VenopunturasFallidas { set; get; }
        public DbSet<IncidentesPacientes> IncidentesPacientes { set; get; }
        public DbSet<IncumplimientoAnalisis> IncumplimientoAnalisis { set; get; }
        public DbSet<PruebasNoRealizadas> PruebasNoRealizadas { set; get; }
        public DbSet<AreaLaboratorio> AreaLaboratorio { set; get; }
        public DbSet<CalibracionDeficiente> CalibracionDeficiente { set; get; }
        public DbSet<EmpleoReactivo> EmpleoReactivo { set; get; }
        public DbSet<EquipoMalCalibrado> EquipoMalCalibrado { set; get; }
        public DbSet<EquipoUPS> EquipoUPS { set; get; }
        public DbSet<EvaluacionPreAnestesica> EvaluacionesPreAnestesicas { get; set; }
        public DbSet<MaterialNoCalibrado> MaterialNoCalibrado { set; get; }
        public DbSet<MuestraHemolizadaLipemica> MuestraHemolizadaLipemica { set; get; }
        public DbSet<PocoFrecuente> PocoFrecuente { set; get; }
        public DbSet<SueroMalReferenciado> SueroMalReferenciado { set; get; }
        public DbSet<TranscripcionErroneaInoportuna> TranscripcionErroneaInoportuna { set; get; }
        public DbSet<TranscripcionErronea> TranscripcionErronea { set; get; }
        public DbSet<SolicitudDatosIncompletos> SolicitudDatosIncompletos { set; get; }
        public DbSet<RendimientoHoraTrabajador> RendimientoHoraTrabajador { set; get; }
        public DbSet<PacienteSinResultado> PacienteSinResultado { set; get; }
        public DbSet<Reporte> Reporte { set; get; }
        public DbSet<Archivo> Archivos { set; get; }
        public DbSet<Auditoria> Auditoria { set; get; }
        public DbSet<TicketConsultaExterna> TicketConsultaExterna { set; get; }
        public DbSet<Procedimiento> Procedimiento { set; get; }
        public DbSet<OrdenesMedicas> OrdenesMedicas { set; get; }
        public DbSet<OrdenesMedicasCodigos> OrdenesMedicasCodigos { set; get; }
        public DbSet<TipoOrdenMedica> TipoOrdenMedica { set; get; }
        public DbSet<OpcionesOrdenMedica> OpcionesOrdenMedica { set; get; }
        public DbSet<TipoOrdenMedica_Procedimiento> TipoOrdenMedica_Procedimiento { set; get; }
        public DbSet<AtencionTrabajador> AtencionTrabajador { set; get; }
        public DbSet<AtencionTrabajador_Diagnostico> AtencionTrabajador_Diagnostico { set; get; }
        public DbSet<CodigosRespuestaIndicadoresDesempeno> CodigosRespuestaIndicadoresDesempeno { set; get; }
        public DbSet<EscalafonDeLegajos> EscalafonDeLegajos { set; get; }
        public DbSet<RecetaMedicaEstandar> RecetasMedicasEstandar { get; set; }
        public DbSet<TipoAtencion> TipoAtenciones { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<ExamenAtendidoPorServicioModel> ExamenesAtendidosPorServicio { get; set; }
        public DbSet<ExamenNoInformadoPorServicioModel> ExamenesNoInformadosPorServicio { get; set; }
        public DbSet<AccidenteDeTrabajo> AccidentesDeTrabajo { get; set; }
        public DbSet<SolicitudCita> SolicitudesCita { get; set; }
        public DbSet<SolicitudCitaDiagnostico> SolicitudesCitaDiagnosticos { get; set; }
        public DbSet<SolicitudCitaMedicamento> SolicitudesCitaMedicamentos { get; set; }
        public DbSet<SolicitudReprogramacion> SolicitudesReprogramacion { get; set; }
        public DbSet<SolicitudTeleconsulta> SolicitudesTeleconsulta { get; set; }
        public DbSet<RecetaRefraccionCE> RecetasRefraccion { get; set; }
        public virtual DbSet<Especificaciones> Especificaciones { get; set; }
        public virtual DbSet<Material> Materiales { get; set; }
        public virtual DbSet<Bifocal> Bifocales { get; set; }
        public DbSet<SolicitudConsultaRapida> SolicitudesConsultaRapida { get; set; } 
        public DbSet<OrdenesMedicasCodigosOpcionesOrdenMedica> OrdenesMedicasCodigosOpcionesOrdenesMedicas { get; set; }

        public DbSet<PersonalINO> PersonalDelINO { get; set; }
        public DbSet<VacunacionCOVID19> VacunacionesCOVID19 { get; set; }
        public DbSet<ConsentimientoInformadoCOVID19> ConsentimientosInformadosCOVID19 { get; set; }

        public DbSet<AtencionCE> AtencionesCE { get; set; }
        public DbSet<EvaluacionExamen> EvaluacionesExamenes { get; set; }

        public DbSet<NervioOptico> NerviosOpticos { get; set; }
        public DbSet<PacienteCitaWeb> PacientesCitaWeb { get; set; }
        public DbSet<CitaWeb> CitasWeb { get; set; }
        public DbSet<EvaluacionPregunta> EvaluacionPreguntas { get; set; }
        public DbSet<EvaluacionParticipante> EvaluacionParticipantes { get; set; }
        public DbSet<EvaluacionResultado> EvaluacionResultados { get; set; }
        public DbSet<EvaluacionParticipanteCertificado> EvaluacionParticipantseCertificados { get; set; }
        public DbSet<IngresoPacienteINO> IngresoPacientesINO { get; set; }
        public DbSet<ReprogramacionMedica> ReprogramacionesMedicas { get; set; }

        public DbSet<CitaCallCenter> CitasCallCenter { get; set; }
        public DbSet<Personal> NominaPersonal { get; set; }

        public InoContext(DbContextOptions<InoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.RemovePluralizingTableNameConvention();
            base.OnModelCreating(modelBuilder);

            //Query

            //Repositorio de Archivos
            modelBuilder.Query<ArchivoPorFechaYUsuarioView>();

            modelBuilder.Query<EvalParticipanteNumPregView>();
            modelBuilder.Query<EvalPartCertView>();
            modelBuilder.Query<ComboBoxView>();
            //Entity

            //TipoOrdenMedica_Procedimiento
            modelBuilder.Entity<TipoOrdenMedica_Procedimiento>().ToTable("TipoOrdenMedica_Procedimiento").HasKey(ae => new { ae.IdTipoOrdenMedica, ae.IdProcedimiento });

            modelBuilder.Entity<TipoOrdenMedica_Procedimiento>()
                .HasOne(sc => sc.TipoOrdenMedicas)
                .WithMany(s => s.TipoOrdenMedica_Procedimientos)
                .HasForeignKey(sc => sc.IdTipoOrdenMedica)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TipoOrdenMedica_Procedimiento>()
                .HasOne(sc => sc.Procedimientos)
                .WithMany(s => s.TipoOrdenMedica_Procedimientos)
                .HasForeignKey(sc => sc.IdProcedimiento)
                .OnDelete(DeleteBehavior.Restrict);

            //RolSubModulo
            modelBuilder.Entity<RolSubModulo>().ToTable("RolSubModulo").HasKey(ae => new { ae.IdRol, ae.IdSubModulo });

            modelBuilder.Entity<RolSubModulo>()
                .HasOne(sc => sc.Rol)
                .WithMany(s => s.RolSubModulos)
                .HasForeignKey(sc => sc.IdRol)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<RolSubModulo>()
                .HasOne(sc => sc.SubModulo)
                .WithMany(s => s.RolSubModulos)
                .HasForeignKey(sc => sc.IdSubModulo)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TipoOrdenMedica_Procedimiento>().ToTable("TipoOrdenMedica_Procedimiento").HasKey(ae => new { ae.IdTipoOrdenMedica, ae.IdProcedimiento });

            modelBuilder.Entity<TipoOrdenMedica_Procedimiento>()
                .HasOne(sc => sc.TipoOrdenMedicas)
                .WithMany(s => s.TipoOrdenMedica_Procedimientos)
                .HasForeignKey(sc => sc.IdTipoOrdenMedica)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TipoOrdenMedica_Procedimiento>()
                .HasOne(sc => sc.Procedimientos)
                .WithMany(s => s.TipoOrdenMedica_Procedimientos)
                .HasForeignKey(sc => sc.IdProcedimiento)
                .OnDelete(DeleteBehavior.Restrict);

            //AtencionTrabajador_Diagnostico
            modelBuilder.Entity<AtencionTrabajador_Diagnostico>()
                .HasOne(s => s.AtencionTrabajador)
                .WithMany(m => m.AtencionTrabajador_Diagnosticos)
                .HasForeignKey(s => s.IdAtencionTrabajador)
                .OnDelete(DeleteBehavior.Restrict);

            //AplicacionEmpleado (Relacion muchos a muchos)
            modelBuilder.Entity<AplicacionEmpleado>().ToTable("AplicacionEmpleado").HasKey(ae => new { ae.IdAplicacion, ae.IdEmpleado });

            modelBuilder.Entity<AplicacionEmpleado>()
                .HasOne(sc => sc.Aplicacion)
                .WithMany(s => s.AplicacionEmpleados)
                .HasForeignKey(sc => sc.IdAplicacion);


            modelBuilder.Entity<AplicacionEmpleado>()
                .HasOne(sc => sc.Empleado)
                .WithMany(s => s.AplicacionEmpleados)
                .HasForeignKey(sc => sc.IdEmpleado);

            //modelBuilder.Entity<Empleado>()
            //    .HasMany<Aplicacion>(a => a.Aplicaciones)
            //    .WithMany(e => e.Empleado)
            //    .Map(ae =>
            //    {
            //        ae.MapLeftKey("IdEmpleado");
            //        ae.MapRightKey("IdAplicacion");
            //        ae.ToTable("AplicacionEmpleado");
            //    });

            //UsuarioRol
            modelBuilder.Entity<EmpleadoRol>().ToTable("UsuarioRol").HasKey(er => new { er.IdEmpleado, er.IdRol });

            modelBuilder.Entity<EmpleadoRol>()
                .HasOne(sc => sc.Empleado)
                .WithMany(s => s.EmpleadoRoles)
                .HasForeignKey(sc => sc.IdEmpleado);

            modelBuilder.Entity<EmpleadoRol>()
                .HasOne(sc => sc.Rol)
                .WithMany(s => s.EmpleadoRoles)
                .HasForeignKey(sc => sc.IdRol);

            //modelBuilder.Entity<Empleado>()
            //    .HasMany<Rol>(u => u.Roles)
            //    .WithMany(r => r.Empleado)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("IdEmpleado");
            //        cs.MapRightKey("IdRol");
            //        cs.ToTable("UsuarioRol");
            //    });

            //SubModulo (Relacion de uno a muchos)
            modelBuilder.Entity<SubModulo>()
                .HasOne(s => s.Modulo)
                .WithMany(m => m.SubModulos)
                .HasForeignKey(s => s.IdModulo);

            //RecetaMedicaEstandar TipoAtencion (Relacion de uno a uno - transaccional-maestra)
            modelBuilder.Entity<TipoAtencion>()
                .HasOne(w => w.RecetaMedicaEstandar)
                .WithOne(ct => ct.TipoAtencion)
                .HasForeignKey<RecetaMedicaEstandar>(m => m.IdTipoAtencion)
                .IsRequired();

            modelBuilder.Entity<Medicamento>()
                .HasOne(s => s.RecetaMedicaEstandar)
                .WithMany(m => m.Medicamentos)
                .HasForeignKey(s => s.IdRecetaMedica);

            //SubModulo (Relacion de uno a muchos)
            modelBuilder.Entity<SubModulo>()
                .HasOne(s => s.Modulo)
                .WithMany(m => m.SubModulos)
                .HasForeignKey(s => s.IdModulo);


            //Empleado CondicionTrabajo (Relacion de uno a uno - transaccional-maestra)
            modelBuilder.Entity<CondicionTrabajo>()
                .HasOne(w => w.Empleado)
                .WithOne(ct => ct.CondicionTrabajo)
                .HasForeignKey<Empleado>(m => m.IdCondicionTrabajo)
                .IsRequired();

            //Empleado TipoEmpleado
            modelBuilder.Entity<TipoEmpleado>()
                .HasOne(t => t.Empleado)
                .WithOne(te => te.TipoEmpleado)
                .HasForeignKey<Empleado>(m => m.IdTipoEmpleado)
                .IsRequired();

            //Empleado TipoDocumentoIdentidad
            modelBuilder.Entity<TipoDocumentoIdentidad>()
                .HasOne(e => e.Empleado)
                .WithOne(td => td.TipoDocumentoIdentidad)
                .HasForeignKey<Empleado>(m => m.IdTipoDocumento)
                .IsRequired();

            //PocoFrecuente AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.PocoFrecuente)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<PocoFrecuente>(m => m.IdAreaLaboratorio)
                .IsRequired();

            //EquipoUPS AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.EquipoUPS)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<EquipoUPS>(m => m.IdAreaLaboratorio)
                .IsRequired();

            //CalibracionDeficiente AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.CalibracionDeficiente)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<CalibracionDeficiente>(m => m.IdAreaLaboratorio)
                .IsRequired();

            //SueroMalReferenciado AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.SueroMalReferenciado)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<SueroMalReferenciado>(m => m.IdAreaLaboratorio)
                .IsRequired();

            //MaterialNoCalibrado AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.MaterialNoCalibrado)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<MaterialNoCalibrado>(m => m.IdAreaLaboratorio)
                .IsRequired();

            //EquipoMalCalibrado AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.EquipoMalCalibrado)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<EquipoMalCalibrado>(m => m.IdAreaLaboratorio);

            //MuestraHemolizadaLipemica AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.MuestraHemolizadaLipemica)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<MuestraHemolizadaLipemica>(m => m.IdAreaLaboratorio)
                .IsRequired();

            //RendimientoHoraTrabajador AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.RendimientoHoraTrabajador)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<RendimientoHoraTrabajador>(m => m.IdAreaLaboratorio)
                .IsRequired();

            //EmpleoReactivo AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.EmpleoReactivo)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<EmpleoReactivo>(m => m.IdAreaLaboratorio)
                .IsRequired();

            //TranscripcionErroneaInoportuna AreaLaboratorio
            modelBuilder.Entity<AreaLaboratorio>()
                .HasOne(e => e.TranscripcionErroneaInoportuna)
                .WithOne(a => a.AreaLaboratorio)
                .HasForeignKey<TranscripcionErroneaInoportuna>(m => m.IdAreaLaboratorio)
                .IsRequired();

            //SubModulo-AreaLaboratorio
            modelBuilder.Entity<SubModuloAreaLaboratorio>().ToTable("SubModulo_AreaLaboratorio").HasKey(sa => new { sa.IdAreaLaboratorio, sa.IdSubModulo });

            modelBuilder.Entity<SubModuloAreaLaboratorio>()
                .HasOne(sc => sc.SubModulo)
                .WithMany(s => s.SubModuloAreaLaboratorios)
                .HasForeignKey(sc => sc.IdSubModulo);

            modelBuilder.Entity<SubModuloAreaLaboratorio>()
                .HasOne(sc => sc.AreaLaboratorio)
                .WithMany(s => s.SubModuloAreaLaboratorios)
                .HasForeignKey(sc => sc.IdAreaLaboratorio);

            //modelBuilder.Entity<SubModulo>()
            //    .HasMany<AreaLaboratorio>(a => a.AreaLaboratorios)
            //    .WithMany(s => s.SubModulos)
            //    .Map(ae =>
            //    {
            //        ae.MapLeftKey("IdSubModulo");
            //        ae.MapRightKey("IdAreaLaboratorio");
            //        ae.ToTable("SubModulo_AreaLaboratorio");
            //    });

            //SubModulo-Reporte
            modelBuilder.Entity<SubModuloReporte>().ToTable("SubModulo_Reporte").HasKey(sr => new { sr.IdSubModulo, sr.IdReporte });

            modelBuilder.Entity<SubModuloReporte>()
                .HasOne(sc => sc.SubModulo)
                .WithMany(s => s.SubModuloReportes)
                .HasForeignKey(sc => sc.IdSubModulo);


            modelBuilder.Entity<SubModuloReporte>()
                .HasOne(sc => sc.Reporte)
                .WithMany(s => s.SubModuloReportes)
                .HasForeignKey(sc => sc.IdReporte);

            //modelBuilder.Entity<SubModulo>()
            //    .HasMany<Reporte>(r => r.Reportes)
            //    .WithMany(s => s.SubModulos)
            //    .Map(sr =>
            //    {
            //        sr.MapLeftKey("IdSubModulo");
            //        sr.MapRightKey("IdReporte");
            //        sr.ToTable("SubModulo_Reporte");
            //    });

            //OrdenesMedicas TipoOrdenMedica
            modelBuilder.Entity<OrdenesMedicas>()
                .HasOne(e => e.TipoOrdenMedica)
                .WithMany(t => t.OrdenesMedicas)
                .HasForeignKey(m => m.IdTipoOrdenMedica)
                .IsRequired();

            //OrdenesMedicasCodigos
            modelBuilder.Entity<OrdenesMedicasCodigos>()
                .HasOne(s => s.OrdenesMedicas)
                .WithMany(m => m.OrdenesMedicasCodigos)
                .HasForeignKey(s => s.IdOrdenMedica);
            //OrdenesMedicasCodigos Procedimiento
            //modelBuilder.Entity<OrdenesMedicasCodigos>()
            //    .HasOne(p => p.Procedimiento)
            //    .WithOne(om => om.OrdenesMedicasCodigos)
            //    .HasForeignKey<Procedimiento>(m => m.IdProcedimiento)
            //    .IsRequired();
            modelBuilder.Entity<Procedimiento>()
                .HasOne(p => p.OrdenesMedicasCodigos)
                .WithOne(om => om.Procedimiento)
                .HasForeignKey<OrdenesMedicasCodigos>(m => m.IdProcedimiento)
                .IsRequired();
            //OrdenesMedicasCodigos_OpcionesOrdenMedica
            modelBuilder.Entity<OrdenesMedicasCodigosOpcionesOrdenMedica>().ToTable("OrdenesMedicasCodigos_OpcionesOrdenMedica").HasKey(sr => new { sr.IdOpcionOrdenMedica, sr.IdOrdenesMedicasCodigos });

            modelBuilder.Entity<OrdenesMedicasCodigosOpcionesOrdenMedica>()
                .HasOne(sc => sc.OrdenesMedicasCodigos)
                .WithMany(s => s.OrdenesMedicasCodigosOpcionesOrdenMedicas)
                .HasForeignKey(sc => sc.IdOrdenesMedicasCodigos);

            modelBuilder.Entity<OrdenesMedicasCodigosOpcionesOrdenMedica>()
                .HasOne(sc => sc.OpcionesOrdenMedica)
                .WithMany(s => s.OrdenesMedicasCodigosOpcionesOrdenMedicas)
                .HasForeignKey(sc => sc.IdOpcionOrdenMedica);

            //modelBuilder.Entity<OrdenesMedicasCodigos>()
            //    .HasMany<OpcionesOrdenMedica>(a => a.OpcionesOrdenMedica)
            //    .WithMany(e => e.OrdenesMedicasCodigos)
            //    .Map(ae =>
            //    {
            //        ae.MapLeftKey("IdOrdenesMedicasCodigos");
            //        ae.MapRightKey("IdOpcionOrdenMedica");
            //        ae.ToTable("OrdenesMedicasCodigos_OpcionesOrdenMedica");
            //    });

            //TipoOrdenMedicaRangos (Relacion de uno a muchos)
            modelBuilder.Entity<TipoOrdenMedicaRangos>()
                .HasOne(s => s.TipoOrdenMedica)
                .WithMany(m => m.TipoOrdenMedicaRangos)
                .HasForeignKey(s => s.IdTipoOrdenMedica);

            //ExamenAtendidoPorServicio
            modelBuilder.Entity<ExamenAtendidoPorServicioModel>().ToTable("ExamenAtendidoPorServicio");

            //ExamenNoInformadoPorServicio
            modelBuilder.Entity<ExamenNoInformadoPorServicioModel>().ToTable("ExamenNoInformadoPorServicio");

            modelBuilder.Entity<Especificaciones>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<Bifocal>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);
            });
            
            //Empleado CondicionTrabajo (Relacion de uno a uno - transaccional-maestra)
            //modelBuilder.Entity<PacienteCitaWeb>()
            //    .HasOne(w => w.Rol)
            //    .WithOne(ct => ct.PacienteCitaWeb)
            //    .HasForeignKey<PacienteCitaWeb>(m => m.IdRol)
            //    .IsRequired();

            modelBuilder.Entity<PacienteCitaWeb>()
                .HasOne(s => s.Rol)
                .WithMany(m => m.PacientesCitaWeb)
                .HasForeignKey(s => s.IdRol);
            
            modelBuilder.Entity<AtencionCE>()
                .ToTable("AtencionCENew");
        }

    }
}
