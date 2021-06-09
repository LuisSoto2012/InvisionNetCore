using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class SolicitudReprogramacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "SolicitudReprogramacion",
            //    columns: table => new
            //    {
            //        IdSolicitud = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdCuentaAtencion = table.Column<int>(nullable: false),
            //        Apellidos = table.Column<string>(maxLength: 500, nullable: false),
            //        Nombres = table.Column<string>(maxLength: 500, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 20, nullable: false),
            //        TelefonoMovil = table.Column<string>(maxLength: 20, nullable: true),
            //        IdDepartamento = table.Column<int>(nullable: false),
            //        IdProvincia = table.Column<int>(nullable: false),
            //        IdDistrito = table.Column<int>(nullable: false),
            //        MotivoInasistencia = table.Column<string>(maxLength: 500, nullable: false),
            //        IdEstado = table.Column<int>(nullable: false),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        IdUsuarioReprograma = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SolicitudReprogramacion", x => x.IdSolicitud);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "SolicitudReprogramacion");
        }
    }
}
