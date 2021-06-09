using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AgregarTabla_EvaluacionExamen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "EvaluacionExamen",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAtencion = table.Column<int>(nullable: false),
            //        IdPaciente = table.Column<int>(nullable: false),
            //        Paciente = table.Column<string>(nullable: false),
            //        IdMedico = table.Column<int>(nullable: false),
            //        Medico = table.Column<string>(nullable: false),
            //        TipoEvaluacion = table.Column<string>(nullable: false),
            //        Programa = table.Column<string>(nullable: true),
            //        Estrategia = table.Column<string>(nullable: true),
            //        EstimuloNumero = table.Column<string>(nullable: true),
            //        EstimuloColor = table.Column<string>(nullable: true),
            //        ConfiabilidadOD = table.Column<string>(nullable: true),
            //        ConfiabilidadOI = table.Column<string>(nullable: true),
            //        DefectoCampoVisualOD = table.Column<string>(nullable: true),
            //        DefectoCampoVisualOI = table.Column<string>(nullable: true),
            //        ContraccionGenODSUP = table.Column<string>(nullable: true),
            //        ContraccionGenODINF = table.Column<string>(nullable: true),
            //        ContraccionGenOISUP = table.Column<string>(nullable: true),
            //        ContraccionGenOIINF = table.Column<string>(nullable: true),
            //        ContraccionPerLocODSUP = table.Column<string>(nullable: true),
            //        ContraccionPerLocODINF = table.Column<string>(nullable: true),
            //        ContraccionPerLocOISUP = table.Column<string>(nullable: true),
            //        ContraccionPerLocOIINF = table.Column<string>(nullable: true),
            //        EscotomaAreaArqODSUP = table.Column<string>(nullable: true),
            //        EscotomaAreaArqODINF = table.Column<string>(nullable: true),
            //        EscotomaAreaArqOISUP = table.Column<string>(nullable: true),
            //        EscotomaAreaArqOIINF = table.Column<string>(nullable: true),
            //        EscalonNasalODSUP = table.Column<string>(nullable: true),
            //        EscalonNasalODINF = table.Column<string>(nullable: true),
            //        EscalonNasalOISUP = table.Column<string>(nullable: true),
            //        EscalonNasalOIINF = table.Column<string>(nullable: true),
            //        EscotomaParacentralODSUP = table.Column<string>(nullable: true),
            //        EscotomaParacentralODINF = table.Column<string>(nullable: true),
            //        EscotomaParacentralOISUP = table.Column<string>(nullable: true),
            //        EscotomaParacentralOIINF = table.Column<string>(nullable: true),
            //        EscotomaCentralOD = table.Column<string>(nullable: true),
            //        EscotomaCentralOI = table.Column<string>(nullable: true),
            //        EscotomaCecocentralOD = table.Column<string>(nullable: true),
            //        EscotomaCecocentralOI = table.Column<string>(nullable: true),
            //        IntensidadGlobalOD = table.Column<string>(nullable: true),
            //        IntensidadGlobalOI = table.Column<string>(nullable: true),
            //        DepresionNoEspecOD = table.Column<string>(nullable: true),
            //        DepresionNoEspecOI = table.Column<string>(nullable: true),
            //        AgrandamientoManchaCiegaOD = table.Column<string>(nullable: true),
            //        AgrandamientoManchaCiegaOI = table.Column<string>(nullable: true),
            //        HemianopsiaHomonimaOD = table.Column<string>(nullable: true),
            //        HemianopsiaHomonimaOI = table.Column<string>(nullable: true),
            //        HemianopsiaBitemporalOD = table.Column<string>(nullable: true),
            //        HemianopsiaBitemporalOI = table.Column<string>(nullable: true),
            //        OtrosDefectosOD = table.Column<string>(nullable: true),
            //        OtrosDefectosOI = table.Column<string>(nullable: true),
            //        ComentariosOD = table.Column<string>(nullable: true),
            //        ComentariosOI = table.Column<string>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        IdUsuarioCreacion = table.Column<string>(nullable: true),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        IdUsuarioModificacion = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EvaluacionExamen", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "EvaluacionExamen");
        }
    }
}
