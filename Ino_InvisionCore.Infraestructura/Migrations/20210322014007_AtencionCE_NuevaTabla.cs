using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class AtencionCE_NuevaTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AtencionCE",
            //    columns: table => new
            //    {
            //        IdAtencionCE = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAtencionGalenos = table.Column<int>(nullable: false),
            //        MotivoConsulta = table.Column<string>(nullable: true),
            //        TiempoEnfermedad = table.Column<string>(nullable: true),
            //        DesarolloCronologico = table.Column<string>(nullable: true),
            //        Pa = table.Column<string>(nullable: true),
            //        Fc = table.Column<string>(nullable: true),
            //        Fr = table.Column<string>(nullable: true),
            //        T = table.Column<string>(nullable: true),
            //        SatO2 = table.Column<string>(nullable: true),
            //        ProximaCita = table.Column<DateTime>(nullable: true),
            //        PlanDeTrabajo = table.Column<string>(nullable: true),
            //        IdUsuarioRegistro = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaRegistro = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AtencionCE", x => x.IdAtencionCE);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AtencionCE");
        }
    }
}
