using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class CrearSolicitudConsultaRapida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "SolicitudConsultaRapida",
            //    columns: table => new
            //    {
            //        IdSolicitud = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ApellidoPaterno = table.Column<string>(maxLength: 200, nullable: false),
            //        ApellidoMaterno = table.Column<string>(maxLength: 200, nullable: false),
            //        Nombres = table.Column<string>(maxLength: 200, nullable: false),
            //        IdTipoDocumento = table.Column<int>(nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 30, nullable: false),
            //        FechaEmision = table.Column<DateTime>(nullable: false),
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
            //        FechaAcepta = table.Column<DateTime>(nullable: true),
            //        FechaCita = table.Column<DateTime>(nullable: true),
            //        HoraCita = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SolicitudConsultaRapida", x => x.IdSolicitud);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "SolicitudConsultaRapida");
        }
    }
}
