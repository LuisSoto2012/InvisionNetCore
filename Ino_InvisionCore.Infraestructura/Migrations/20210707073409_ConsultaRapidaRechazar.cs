using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class ConsultaRapidaRechazar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaRechazo",
            //    table: "SolicitudConsultaRapida",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IdUsuarioRechaza",
            //    table: "SolicitudConsultaRapida",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "MotivoRechazo",
            //    table: "SolicitudConsultaRapida",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "EvaluacionPreAnestesica",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdPaciente = table.Column<int>(nullable: false),
            //        Paciente = table.Column<string>(nullable: true),
            //        HistoriaClinica = table.Column<string>(nullable: true),
            //        Edad = table.Column<string>(nullable: true),
            //        Sexo = table.Column<string>(nullable: true),
            //        Servicio = table.Column<string>(nullable: true),
            //        Cama = table.Column<string>(nullable: true),
            //        DiagnosticoPreoperatorio = table.Column<string>(nullable: true),
            //        Procedimiento = table.Column<string>(nullable: true),
            //        TipoAtencion = table.Column<string>(nullable: true),
            //        HipertensionArterial_SiNo = table.Column<bool>(nullable: false),
            //        HipertensionArterial_Descripcion = table.Column<string>(nullable: true),
            //        DiabetesMellitus_SiNo = table.Column<bool>(nullable: false),
            //        DiabetesMellitus_Descripcion = table.Column<string>(nullable: true),
            //        Dislipidemias_SiNo = table.Column<bool>(nullable: false),
            //        Dislipidemias_Descripcion = table.Column<string>(nullable: true),
            //        EnfermedadRespiratoria_SiNo = table.Column<bool>(nullable: false),
            //        EnfermedadRespiratoria_Descripcion = table.Column<string>(nullable: true),
            //        EnfermedadCardiaca_SiNo = table.Column<bool>(nullable: false),
            //        EnfermedadCardiaca_Descripcion = table.Column<string>(nullable: true),
            //        EnfermedadRenal_SiNo = table.Column<bool>(nullable: false),
            //        EnfermedadRenal_Descripcion = table.Column<string>(nullable: true),
            //        EnfermedadNeurológica_SiNo = table.Column<bool>(nullable: false),
            //        EnfermedadNeurológica_Descripcion = table.Column<string>(nullable: true),
            //        Hemorragicos_SiNo = table.Column<bool>(nullable: false),
            //        Hemorragicos_Descripcion = table.Column<string>(nullable: true),
            //        RAMs_SiNo = table.Column<bool>(nullable: false),
            //        RAMs_Descripcion = table.Column<string>(nullable: true),
            //        OtrosAntecedentes = table.Column<string>(nullable: true),
            //        OtrosAntecedentes_Descripcion = table.Column<string>(nullable: true),
            //        AntecedentesQuirurgicosAnastesicos = table.Column<string>(nullable: true),
            //        ExamenFisico_PA = table.Column<string>(nullable: true),
            //        ExamenFisico_FC = table.Column<string>(nullable: true),
            //        ExamenFisico_FR = table.Column<string>(nullable: true),
            //        ExamenFisico_T = table.Column<string>(nullable: true),
            //        ExamenFisico_Peso = table.Column<string>(nullable: true),
            //        ExamenFisico_RuidosCard = table.Column<string>(nullable: true),
            //        ExamenFisico_Soplos = table.Column<string>(nullable: true),
            //        ExamenFisico_ToraxPulmones = table.Column<string>(nullable: true),
            //        ExamenFisico_Neurologico = table.Column<string>(nullable: true),
            //        ExamenFisico_ProtesisDental = table.Column<string>(nullable: true),
            //        ExamenFisico_DientesFlojos = table.Column<string>(nullable: true),
            //        ExamenFisico_DistanciaTM = table.Column<string>(nullable: true),
            //        ExamenFisico_MovCervical = table.Column<string>(nullable: true),
            //        ExamenFisico_Mallampati = table.Column<string>(nullable: true),
            //        ExamenFisico_TestGanzouri = table.Column<string>(nullable: true),
            //        ExamenFisico_LaringoscopiaDificil = table.Column<bool>(nullable: false),
            //        ExamenFisico_OtrosHallazgos = table.Column<string>(nullable: true),
            //        LaboratorioImagenImagen_HbHcto = table.Column<string>(nullable: true),
            //        LaboratorioImagen_Glicemia = table.Column<string>(nullable: true),
            //        LaboratorioImagen_TC = table.Column<string>(nullable: true),
            //        LaboratorioImagen_TS = table.Column<string>(nullable: true),
            //        LaboratorioImagen_FechaExamen1 = table.Column<DateTime>(nullable: true),
            //        LaboratorioImagen_Plaquetas = table.Column<string>(nullable: true),
            //        LaboratorioImagen_Crea = table.Column<string>(nullable: true),
            //        LaboratorioImagen_Urea = table.Column<string>(nullable: true),
            //        LaboratorioImagen_FechaExamen2 = table.Column<DateTime>(nullable: true),
            //        LaboratorioImagen_RxTorax = table.Column<string>(nullable: true),
            //        LaboratorioImagen_FechaExamen3 = table.Column<DateTime>(nullable: true),
            //        LaboratorioImagen_Otros = table.Column<string>(nullable: true),
            //        LaboratorioImagen_FechaExamen4 = table.Column<DateTime>(nullable: true),
            //        ClasificacionASA = table.Column<string>(nullable: true),
            //        ClasificacionGOLDMAN = table.Column<string>(nullable: true),
            //        PlanAnestesico_Sedoanalgesia = table.Column<string>(nullable: true),
            //        PlanAnestesico_AnestesiaGeneralBalanceada = table.Column<string>(nullable: true),
            //        PlanAnestesico_AnestesiaGeneralInhalatoria = table.Column<string>(nullable: true),
            //        PlanAnestesico_Otros = table.Column<string>(nullable: true),
            //        ConclusionesRecomendaciones = table.Column<string>(nullable: true),
            //        FechaRegistro = table.Column<DateTime>(nullable: false),
            //        Anestesiologo = table.Column<string>(nullable: true),
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaModificacion = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EvaluacionPreAnestesica", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "EvaluacionPreAnestesica");

            //migrationBuilder.DropColumn(
            //    name: "FechaRechazo",
            //    table: "SolicitudConsultaRapida");

            //migrationBuilder.DropColumn(
            //    name: "IdUsuarioRechaza",
            //    table: "SolicitudConsultaRapida");

            //migrationBuilder.DropColumn(
            //    name: "MotivoRechazo",
            //    table: "SolicitudConsultaRapida");
        }
    }
}
