using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class VacunacionCOVID19_Tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ConsentimientoInformadoCOVID19",
            //    columns: table => new
            //    {
            //        IdCI = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdPersonalINO = table.Column<int>(nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 20, nullable: false),
            //        Nombre = table.Column<string>(maxLength: 250, nullable: false),
            //        ApellidoPaterno = table.Column<string>(maxLength: 250, nullable: false),
            //        ApellidoMaterno = table.Column<string>(maxLength: 250, nullable: false),
            //        FechaNacimiento = table.Column<DateTime>(nullable: true),
            //        Telefono = table.Column<string>(maxLength: 20, nullable: true),
            //        ExpCI_P1 = table.Column<bool>(nullable: false),
            //        ExpCI_P2 = table.Column<bool>(nullable: false),
            //        ExpCI_P3 = table.Column<bool>(nullable: false),
            //        DetCV19_P1 = table.Column<bool>(nullable: false),
            //        DetCV19_P2 = table.Column<bool>(nullable: false),
            //        DetCV19_P3 = table.Column<bool>(nullable: false),
            //        DetPrevInm_P1 = table.Column<bool>(nullable: false),
            //        DetPrevInm_P2 = table.Column<bool>(nullable: false),
            //        DetPrevInm_P3 = table.Column<bool>(nullable: false),
            //        DetPrevInm_P4 = table.Column<bool>(nullable: false),
            //        DetPrevInm_P5 = table.Column<bool>(nullable: false),
            //        DetPrevInm_P6 = table.Column<bool>(nullable: false),
            //        DetPrevInm_P7 = table.Column<bool>(nullable: false),
            //        DetPrevInm_P8 = table.Column<bool>(nullable: false),
            //        DetPrevInm_P9 = table.Column<bool>(nullable: false),
            //        Pulso = table.Column<string>(nullable: true),
            //        Saturacion = table.Column<string>(nullable: true),
            //        PresionArterial = table.Column<string>(nullable: true),
            //        FechaRegistro = table.Column<DateTime>(nullable: false),
            //        IdUsuarioRegistro = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ConsentimientoInformadoCOVID19", x => x.IdCI);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PersonalINO",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        TipoDocumento = table.Column<int>(nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 20, nullable: false),
            //        Nombre = table.Column<string>(maxLength: 250, nullable: false),
            //        ApellidoPaterno = table.Column<string>(maxLength: 250, nullable: false),
            //        ApellidoMaterno = table.Column<string>(maxLength: 250, nullable: false),
            //        Sexo = table.Column<string>(maxLength: 20, nullable: true),
            //        FechaNacimiento = table.Column<DateTime>(nullable: true),
            //        Actividad = table.Column<string>(maxLength: 100, nullable: true),
            //        Telefono = table.Column<string>(maxLength: 20, nullable: true),
            //        Direccion = table.Column<string>(maxLength: 250, nullable: true),
            //        Tipo = table.Column<string>(maxLength: 100, nullable: true),
            //        Categoria = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PersonalINO", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "VacunacionCOVID19",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdPersonalINO = table.Column<int>(nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 20, nullable: false),
            //        Nombre = table.Column<string>(maxLength: 250, nullable: false),
            //        ApellidoPaterno = table.Column<string>(maxLength: 250, nullable: false),
            //        ApellidoMaterno = table.Column<string>(maxLength: 250, nullable: false),
            //        FechaNacimiento = table.Column<DateTime>(nullable: true),
            //        Actividad = table.Column<string>(maxLength: 100, nullable: true),
            //        Telefono = table.Column<string>(maxLength: 20, nullable: true),
            //        PrimeraDosisFecha = table.Column<DateTime>(nullable: true),
            //        PrimeraDosisHora = table.Column<string>(maxLength: 10, nullable: true),
            //        PrimeraDosisReaccionesAdversas = table.Column<string>(maxLength: 250, nullable: true),
            //        SegundaDosisFecha = table.Column<DateTime>(nullable: true),
            //        SegundaDosisHora = table.Column<string>(maxLength: 10, nullable: true),
            //        SegundaDosisReaccionesAdversas = table.Column<string>(maxLength: 250, nullable: true),
            //        FechaRegistro = table.Column<DateTime>(nullable: false),
            //        IdUsuarioRegistro = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VacunacionCOVID19", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ConsentimientoInformadoCOVID19");

            //migrationBuilder.DropTable(
            //    name: "PersonalINO");

            //migrationBuilder.DropTable(
            //    name: "VacunacionCOVID19");
        }
    }
}
