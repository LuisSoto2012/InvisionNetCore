using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class SolciitudCitaMedicamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "SolicitudCitaMedicamento",
            //    columns: table => new
            //    {
            //        IdSolicitudMedicamento = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdSolicitudCita = table.Column<int>(nullable: false),
            //        IdMedicamento = table.Column<int>(nullable: false),
            //        Nombre = table.Column<string>(nullable: true),
            //        ForFarm = table.Column<string>(nullable: true),
            //        Cantidad = table.Column<int>(nullable: false),
            //        Ojo = table.Column<string>(nullable: true),
            //        Indicacion = table.Column<string>(nullable: true),
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        FechaCreacion = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SolicitudCitaMedicamento", x => x.IdSolicitudMedicamento);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "SolicitudCitaMedicamento");
        }
    }
}
