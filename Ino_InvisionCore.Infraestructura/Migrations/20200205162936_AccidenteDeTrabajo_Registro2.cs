using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AccidenteDeTrabajo_Registro2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AccidenteDeTrabajo",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdRegistroAccidenteDeTrabajo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        NroTrabajadores_SCTR = table.Column<int>(nullable: false),
            //        NroTrabajadores_NoSCTR = table.Column<int>(nullable: false),
            //        Nombre_Aseguradora = table.Column<string>(maxLength: 500, nullable: true),
            //        TipoVinculacion_Accidentado = table.Column<string>(maxLength: 50, nullable: true),
            //        ApellidoPaterno_Accidentado = table.Column<string>(maxLength: 200, nullable: true),
            //        ApellidoMaterno_Accidentado = table.Column<string>(maxLength: 200, nullable: true),
            //        Nombres_Accidentado = table.Column<string>(maxLength: 200, nullable: true),
            //        FechaNacimiento_Accidentado = table.Column<DateTime>(nullable: false),
            //        Edad_Accidentado = table.Column<int>(nullable: false),
            //        Sexo_Accidentado = table.Column<string>(nullable: false),
            //        TipoDocumento_Accidentado = table.Column<string>(maxLength: 50, nullable: true),
            //        NumeroDocumento_Accidentado = table.Column<string>(maxLength: 10, nullable: true),
            //        Domicilio_Accidentado = table.Column<string>(maxLength: 500, nullable: true),
            //        Distrito_Accidentado = table.Column<string>(maxLength: 50, nullable: true),
            //        Provincia_Accidentado = table.Column<string>(maxLength: 50, nullable: true),
            //        Departamento_Accidentado = table.Column<string>(maxLength: 50, nullable: true),
            //        Referencias_Accidentado = table.Column<string>(maxLength: 200, nullable: true),
            //        TipoOcupacion_Accidentado = table.Column<string>(maxLength: 50, nullable: true),
            //        Ocupacion_Accidentado = table.Column<string>(maxLength: 100, nullable: true),
            //        JornadaTrabajo_Accidentado = table.Column<string>(maxLength: 30, nullable: true),
            //        Area_Accidentado = table.Column<string>(maxLength: 50, nullable: true),
            //        AntiguedadEmpleo_Accidentado = table.Column<string>(maxLength: 20, nullable: true),
            //        TiempoExperiencia_Accidentado = table.Column<string>(maxLength: 20, nullable: true),
            //        NroHorasTrabajadas_Accidentado = table.Column<int>(nullable: false),
            //        Fecha_Accidente = table.Column<DateTime>(nullable: false),
            //        Hora_Accidente = table.Column<string>(maxLength: 10, nullable: true),
            //        Jornada_Accidente = table.Column<string>(maxLength: 30, nullable: true),
            //        EsLaborHabitual_Accidente = table.Column<bool>(nullable: false),
            //        LaborHabitual_Accidente = table.Column<string>(maxLength: 100, nullable: true),
            //        FechaInvestigacion_Accidente = table.Column<DateTime>(nullable: false),
            //        Lugar_Accidente = table.Column<string>(maxLength: 100, nullable: true),
            //        Area_Accidente = table.Column<string>(maxLength: 100, nullable: true),
            //        Gravedad_Accidente = table.Column<string>(maxLength: 50, nullable: true),
            //        Grado_Accidente = table.Column<string>(maxLength: 50, nullable: true),
            //        NroDiasDescanso_Accidente = table.Column<int>(nullable: false),
            //        NroTrabajadoresAfectados_Accidente = table.Column<int>(nullable: false),
            //        DeclaracionAfectado_DescripcionAccidente = table.Column<string>(nullable: true),
            //        HuboTestigos_DescripcionAccidente = table.Column<bool>(nullable: false),
            //        NombreTestigo_DescripcionAccidente = table.Column<string>(maxLength: 200, nullable: true),
            //        CargoTestigo_DescripcionAccidente = table.Column<string>(maxLength: 100, nullable: true),
            //        DocumentoIdentidad_DescripcionAccidente = table.Column<string>(maxLength: 10, nullable: true),
            //        DeclaracionTestigo_DescripcionAccidente = table.Column<string>(nullable: true),
            //        AgenteAccidente_CausaAccidente = table.Column<string>(nullable: true),
            //        MecanismoFormaAccidente_CausaAccidente = table.Column<string>(nullable: true),
            //        TipoLesion_CausaAccidente = table.Column<string>(nullable: true),
            //        ParteCuerpo_CausaAccidente = table.Column<string>(nullable: true),
            //        Descripcion_MedidaCorrectiva = table.Column<string>(nullable: true),
            //        Responsable_MedidaCorrectiva = table.Column<string>(nullable: true),
            //        FechaEjecucion_MedidaCorrectiva = table.Column<string>(nullable: true),
            //        EstadoImplementacion_MedidaCorrectiva = table.Column<string>(nullable: true),
            //        NombreResponsable_RegistroInvestigacion = table.Column<string>(nullable: true),
            //        CargoResponsable_RegistroInvestigacion = table.Column<string>(nullable: true),
            //        Fecha_RegistroInvestigacion = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AccidenteDeTrabajo", x => x.IdRegistroAccidenteDeTrabajo);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AccidenteDeTrabajo");
        }
    }
}
