using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class SolicitudCitaWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "SolicitudCita",
            //    columns: table => new
            //    {
            //        IdSolicitudCita = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ApellidoPaterno = table.Column<string>(maxLength: 200, nullable: false),
            //        ApellidoMaterno = table.Column<string>(maxLength: 200, nullable: false),
            //        PrimerNombre = table.Column<string>(maxLength: 200, nullable: false),
            //        SegundoNombre = table.Column<string>(maxLength: 200, nullable: false),
            //        IdTipoDocumento = table.Column<int>(nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 30, nullable: false),
            //        CorreoElectronico = table.Column<string>(maxLength: 100, nullable: true),
            //        TelefonoMovil = table.Column<string>(maxLength: 20, nullable: true),
            //        IdEstadoCivil = table.Column<int>(nullable: false),
            //        FechaNacimiento = table.Column<DateTime>(nullable: false),
            //        IdSexo = table.Column<int>(nullable: false),
            //        IdDepartamento = table.Column<int>(nullable: false),
            //        IdProvincia = table.Column<int>(nullable: false),
            //        IdDistrito = table.Column<int>(nullable: false),
            //        Direccion = table.Column<string>(maxLength: 100, nullable: false),
            //        MotivoConsulta = table.Column<string>(maxLength: 500, nullable: false),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        IdEstado = table.Column<int>(nullable: false),
            //        IdUsuarioAcepta = table.Column<int>(nullable: false),
            //        IdUsuarioRechaza = table.Column<int>(nullable: false),
            //        FechaAcepta = table.Column<DateTime>(nullable: true),
            //        FechaRechaza = table.Column<DateTime>(nullable: true),
            //        IdUsuarioAtiende = table.Column<int>(nullable: false),
            //        FechaAtiende = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SolicitudCita", x => x.IdSolicitudCita);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SolicitudCitaDiagnostico",
            //    columns: table => new
            //    {
            //        IdSolicitudDiagnostico = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdSolicitudCita = table.Column<int>(nullable: false),
            //        IdDiagnostico = table.Column<int>(nullable: false),
            //        CodigoCIE10 = table.Column<string>(nullable: true),
            //        Descripcion = table.Column<string>(nullable: true),
            //        TipoDX = table.Column<string>(nullable: true),
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        FechaCreacion = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SolicitudCitaDiagnostico", x => x.IdSolicitudDiagnostico);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "SolicitudCita");

            //migrationBuilder.DropTable(
            //    name: "SolicitudCitaDiagnostico");
        }
    }
}
