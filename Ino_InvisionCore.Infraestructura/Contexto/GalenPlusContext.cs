using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Ino_InvisionCore.Infraestructura.Contexto
{
    public class GalenPlusContext : DbContext
    {
        public GalenPlusContext(DbContextOptions<GalenPlusContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Repositorio de Congreso
            modelBuilder.Query<AsistenciaGeneralView>();
            modelBuilder.Query<EventoGeneralView>();
            modelBuilder.Query<ParticipanteGeneralView>();

            //Repositorio de Adicionales
            modelBuilder.Query<AdicionalesView>();
            modelBuilder.Query<ConsultaExternaAdicionalesPorMedicoRegitrarView>();

            //Repositorio de Archivos
            modelBuilder.Query<ArchivoPorFechaYUsuarioView>();

            //Repositorio de Atenciones
            modelBuilder.Query<AtencionFiltroView>();
            modelBuilder.Query<CitadosPorFechaView>();
            modelBuilder.Query<CitadosPorFechaMedicoEspecialidadView>();
            modelBuilder.Query<DiagnosticoView>();

            //Repositorio de Bono Desempeno
            modelBuilder.Query<DiferimientoCitasView>().ToView("VW_DIFERIMIENTO_CITAS_DIAS");
            modelBuilder.Query<DiferimientoCitasConDiasView>().ToView("VW_DIFERIMIENTO_CITAS_DIAS");
            modelBuilder.Query<TiempoEsperaAtencionView>();

            //Repositorio de Tramas
            modelBuilder.Query<TramaHISMINSAView>().ToView("VW_TRAMAS_HISMINSA_CE_ATENCIONES");

            //Repositorio de Comunes
            modelBuilder.Query<ComboBoxView>();
            modelBuilder.Query<PruebaLaboratorioView>();

            //Repositorio de Congresos
            modelBuilder.Query<EventoAsistenciaRegistrarView>();

            //Repositorio de Medicos
            modelBuilder.Query<MedicoPorEspecialidadView>();
            modelBuilder.Query<MedicoListarView>();

            //Repositorio de Pacientes
            modelBuilder.Query<HistorialAtencionesView>();
            modelBuilder.Query<HistorialCentroQuirurgicoView>();
            modelBuilder.Query<HistorialEmergenciaView>();
            modelBuilder.Query<HistorialLaboratorioView>();
            modelBuilder.Query<HistorialRiesgoQuirurgicoView>();
            modelBuilder.Query<PacienteCitadoView>();
            modelBuilder.Query<PacienteAfiliacionView>();
            modelBuilder.Query<PacientePorHcDniView>();

            //Repositorio de Servicios
            modelBuilder.Query<ServicioPorEspecialidadView>();

            //Repositorio de Tickets
            modelBuilder.Query<ActualizarNroHistoriaClinicaTemporalView>();
            modelBuilder.Query<TicketObtenerEdadPacienteView>();
            modelBuilder.Query<TicketObtenerBoletaFuaView>();

            //Repositorio de Recetas Medicas
            modelBuilder.Query<MedicamentoView>();

            //Repositorio de Cita Web
            modelBuilder.Query<CitaCuarentenaView>();
            modelBuilder.Query<CitaCuarentenaCorreoView>();
            modelBuilder.Query<ConteoCGView>();
            modelBuilder.Query<MedicoDatosView>();

            //Teleconsulta
            modelBuilder.Query<CitaPostCuarentenaView>();
            modelBuilder.Query<AtencionCEView>();

            modelBuilder.Query<ProgramacionMedicaFiltroView>();
            modelBuilder.Query<CuposPorProgramacionView>();
            
            //CitaWeb
            modelBuilder.Query<PacienteCitaWebView>();
        }
    }
}
