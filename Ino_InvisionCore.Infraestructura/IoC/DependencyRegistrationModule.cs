using Autofac;
using AutofacSerilogIntegration;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.AccidenteDeTrabajo;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Adicional;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Anestesia;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Aplicacion;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Archivo;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Atencion;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.AtencionTrabajador;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.BonoDesempeno;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.CallCenter;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.CitasWeb;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Comunes;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Congreso;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.ConsultaWeb;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.COVID19;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Evaluacion;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Facturacion;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Medico;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Modulo;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.NervioOptico;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.OrdenMedica;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Paciente;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.RecetaMedica;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Reporte;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Seguridad;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Servicios;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.SubModulo;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Ticket;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Tramas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.AccidenteTrabajo;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Adicional;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Anestesia;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Aplicacion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Archivo;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Atencion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.AtencionTrabajador;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.BonoDesempeno;
using Ino_InvisionCore.Dominio.Contratos.Servicios.CallCenter;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Comunes;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Congreso;
using Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultasWeb;
using Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultaWeb;
using Ino_InvisionCore.Dominio.Contratos.Servicios.COVID19;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Evaluacion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Facturacion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Medico;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Modulo;
using Ino_InvisionCore.Dominio.Contratos.Servicios.NervioOptico;
using Ino_InvisionCore.Dominio.Contratos.Servicios.OrdenMedica;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Paciente;
using Ino_InvisionCore.Dominio.Contratos.Servicios.RecetaMedica;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Reporte;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Servicios;
using Ino_InvisionCore.Dominio.Contratos.Servicios.SubModulo;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Ticket;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Tramas;
using Ino_InvisionCore.Dominio.Servicios;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Repositorios;

namespace Ino_InvisionCore.Infraestructura.IoC
{
    public class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLogger(autowireProperties: true);

            builder.RegisterType<InoContext>().As<InoContext>();
            builder.RegisterType<GalenPlusContext>().As<GalenPlusContext>();
            builder.RegisterType<EvaluacionEscritaContext>().As<EvaluacionEscritaContext>();

            // Repositories
            builder.RegisterType<RepositorioDeAdicionales>().As<IRepositorioDeAdicionales>();
            builder.RegisterType<RepositorioDeAplicaciones>().As<IRepositorioDeAplicaciones>();
            builder.RegisterType<RepositorioDeArchivos>().As<IRepositorioDeArchivos>();
            builder.RegisterType<RepositorioDeAtenciones>().As<IRepositorioDeAtenciones>();
            builder.RegisterType<RepositorioDeAtencionesTrabajadores>().As<IRepositorioDeAtencionesTrabajadores>();
            builder.RegisterType<RepositorioDeAuditoria>().As<IRepositorioDeAuditoria>();
            builder.RegisterType<RepositorioDeBonoDesempeno>().As<IRepositorioDeBonoDesempeno>();
            builder.RegisterType<RepositorioDeComunes>().As<IRepositorioDeComunes>();
            builder.RegisterType<RepositorioDeCongreso>().As<IRepositorioDeCongreso>();
            builder.RegisterType<RepositorioDeIndicadoresGestion>().As<IRepositorioDeIndicadoresGestion>();
            builder.RegisterType<RepositorioDeMedicos>().As<IRepositorioDeMedicos>();
            builder.RegisterType<RepositorioDeModulos>().As<IRepositorioDeModulos>();
            builder.RegisterType<RepositorioDeOrdenesMedicas>().As<IRepositorioDeOrdenesMedicas>();
            builder.RegisterType<RepositorioDePacientes>().As<IRepositorioDePacientes>();
            builder.RegisterType<RepositorioDePedidosAnalisis>().As<IRepositorioDePedidosAnalisis>();
            builder.RegisterType<RepositorioDeProcesoAnalitico>().As<IRepositorioDeProcesoAnalitico>();
            builder.RegisterType<RepositorioDeReportes>().As<IRepositorioDeReportes>();
            builder.RegisterType<RepositorioDeRoles>().As<IRepositorioDeRoles>();
            builder.RegisterType<RepositorioDeServicios>().As<IRepositorioDeServicios>();
            builder.RegisterType<RepositorioDeSubModulos>().As<IRepositorioDeSubModulos>();
            builder.RegisterType<RepositorioDeTickets>().As<IRepositorioDeTickets>();
            builder.RegisterType<RepositorioDeTomaMuestra>().As<IRepositorioDeTomaMuestra>();
            builder.RegisterType<RepositorioDeTranscripcionResultados>().As<IRepositorioDeTranscripcionResultados>();
            builder.RegisterType<RepositorioDeUsuarios>().As<IRepositorioDeUsuarios>();
            builder.RegisterType<RepositorioDeRecetasMedicas>().As<IRepositorioDeRecetasMedicas>();
            builder.RegisterType<RepositorioDeAccidentesTrabajo>().As<IRepositorioDeAccidentesTrabajo>();
            builder.RegisterType<RepositorioDeTramas>().As<IRepositorioDeTramas>();
            builder.RegisterType<RepositorioDeConsultaWeb>().As<IRepositorioDeConsultaWeb>();
            builder.RegisterType<RepositorioDeVacunacionCOVID19>().As<IRepositorioDeVacunacionCOVID19>();
            builder.RegisterType<RepositorioDeAnestesias>().As<IRepositorioDeAnestesias>();
            builder.RegisterType<RepositorioDeNervioOptico>().As<IRepositorioDeNervioOptico>();
            builder.RegisterType<RepositorioDeCitasWeb>().As<IRepositorioDeCitasWeb>();
            builder.RegisterType<RepositorioDeEvaluaciones>().As<IRepositorioDeEvaluaciones>();
            builder.RegisterType<RepositorioDeCallCenter>().As<IRepositorioDeCallCenter>();
            builder.RegisterType<RepositorioDeFacturacion>().As<IRepositorioDeFacturacion>();

            // Services
            builder.RegisterType<ServicioDeAdicionales>().As<IServicioDeAdicionales>();
            builder.RegisterType<ServicioDeAplicaciones>().As<IServicioDeAplicaciones>();
            builder.RegisterType<ServicioDeArchivos>().As<IServicioDeArchivos>();
            builder.RegisterType<ServicioDeAtenciones>().As<IServicioDeAtenciones>();
            builder.RegisterType<ServicioDeAtencionesTrabajadores>().As<IServicioDeAtencionesTrabajadores>();
            builder.RegisterType<ServicioDeAuditoria>().As<IServicioDeAuditoria>();
            builder.RegisterType<ServicioDeBonoDesempeno>().As<IServicioDeBonoDesempeno>();
            builder.RegisterType<ServicioDeComunes>().As<IServicioDeComunes>();
            builder.RegisterType<ServicioDeCongreso>().As<IServicioDeCongreso>();
            builder.RegisterType<ServicioDeIndicadoresGestion>().As<IServicioDeIndicadoresGestion>();
            builder.RegisterType<ServicioDeMedicos>().As<IServicioDeMedicos>();
            builder.RegisterType<ServicioDeModulos>().As<IServicioDeModulos>();
            builder.RegisterType<ServicioDeOrdenesMedicas>().As<IServicioDeOrdenesMedicas>();
            builder.RegisterType<ServicioDePacientes>().As<IServicioDePacientes>();
            builder.RegisterType<ServicioDePedidosAnalisis>().As<IServicioDePedidosAnalisis>();
            builder.RegisterType<ServicioDeProcesoAnalitico>().As<IServicioDeProcesoAnalitico>();
            builder.RegisterType<ServicioDeReportes>().As<IServicioDeReportes>();
            builder.RegisterType<ServicioDeRoles>().As<IServicioDeRoles>();
            builder.RegisterType<ServicioDeServicios>().As<IServicioDeServicios>();
            builder.RegisterType<ServicioDeSubModulos>().As<IServicioDeSubModulos>();
            builder.RegisterType<ServicioDeTickets>().As<IServicioDeTickets>();
            builder.RegisterType<ServicioDeTomaMuestra>().As<IServicioDeTomaMuestra>();
            builder.RegisterType<ServicioDeTranscripcionResultados>().As<IServicioDeTranscripcionResultados>();
            builder.RegisterType<ServicioDeUsuarios>().As<IServicioDeUsuarios>();
            builder.RegisterType<ServicioDeRecetasMedicas>().As<IServicioDeRecetasMedicas>();
            builder.RegisterType<ServicioDeAccidentesTrabajo>().As<IServicioDeAccidentesTrabajo>();
            builder.RegisterType<ServicioDeTramas>().As<IServicioDeTramas>();
            builder.RegisterType<ServicioDeConsultaWeb>().As<IServicioDeConsultaWeb>();
            builder.RegisterType<ServicioDeVacunacionCOVID19>().As<IServicioDeVacunacionCOVID19>();
            builder.RegisterType<ServicioDeAnestesias>().As<IServicioDeAnestesias>();
            builder.RegisterType<ServicioDeNervioOptico>().As<IServicioDeNervioOptico>();
            builder.RegisterType<ServicioDeCitasWeb>().As<IServicioDeCitasWeb>();
            builder.RegisterType<ServicioDeEvaluaciones>().As<IServicioDeEvaluaciones>();
            builder.RegisterType<ServicioDeCallCenter>().As<IServicioDeCallCenter>();
            builder.RegisterType<ServicioDeFacturacion>().As<IServicioDeFacturacion>();
        }
    }
}
