using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class Web_SolicitudTeleconsulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "SolicitudTeleconsulta",
            //    columns: table => new
            //    {
            //        IdSolicitud = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdCuentaAtencion = table.Column<int>(nullable: false),
            //        IdCita = table.Column<int>(nullable: false),
            //        FechaCita = table.Column<DateTime>(nullable: false),
            //        HoraCita = table.Column<string>(maxLength: 8, nullable: true),
            //        IdPaciente = table.Column<int>(nullable: false),
            //        Paciente = table.Column<string>(nullable: true),
            //        NombresPaciente = table.Column<string>(nullable: true),
            //        ApellidosPaciente = table.Column<string>(nullable: true),
            //        NroHistoriaClinica = table.Column<string>(maxLength: 20, nullable: true),
            //        Especialidad = table.Column<string>(maxLength: 150, nullable: true),
            //        Turno = table.Column<string>(maxLength: 20, nullable: true),
            //        IdDepartamento = table.Column<int>(nullable: false),
            //        TelefonoMovil = table.Column<string>(maxLength: 20, nullable: true),
            //        CorreoElectronico = table.Column<string>(maxLength: 100, nullable: true),
            //        IdEstado = table.Column<int>(nullable: false),
            //        IdUsuarioAcepta = table.Column<int>(nullable: true),
            //        FechaAcepta = table.Column<DateTime>(nullable: true),
            //        IdUsuarioAtiende = table.Column<int>(nullable: true),
            //        FechaAtiende = table.Column<DateTime>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SolicitudTeleconsulta", x => x.IdSolicitud);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "SolicitudTeleconsulta");
        }
    }
}
