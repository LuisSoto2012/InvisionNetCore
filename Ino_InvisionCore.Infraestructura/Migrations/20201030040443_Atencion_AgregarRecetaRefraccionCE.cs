using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class Atencion_AgregarRecetaRefraccionCE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "RecetaRefraccion");

            //migrationBuilder.CreateTable(
            //    name: "RecetaRefraccionCE",
            //    columns: table => new
            //    {
            //        IdRecetaRefraccion = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdCita = table.Column<int>(nullable: false),
            //        LSignoOD1 = table.Column<string>(maxLength: 2, nullable: true),
            //        LEsferaOD = table.Column<string>(maxLength: 50, nullable: true),
            //        LSignoOD2 = table.Column<string>(maxLength: 2, nullable: true),
            //        LCilindroOD = table.Column<string>(maxLength: 50, nullable: true),
            //        LEjeOD = table.Column<string>(maxLength: 50, nullable: true),
            //        LSignoOI1 = table.Column<string>(maxLength: 2, nullable: true),
            //        LEsferaOI = table.Column<string>(maxLength: 50, nullable: true),
            //        LSignoOI2 = table.Column<string>(maxLength: 2, nullable: true),
            //        LCilindroOI = table.Column<string>(maxLength: 50, nullable: true),
            //        LEjeOI = table.Column<string>(maxLength: 50, nullable: true),
            //        Ldip = table.Column<string>(maxLength: 100, nullable: true),
            //        Lprisma = table.Column<string>(maxLength: 100, nullable: true),
            //        CSignoOD1 = table.Column<string>(maxLength: 2, nullable: true),
            //        CEsferaOD = table.Column<string>(maxLength: 50, nullable: true),
            //        CSignoOD2 = table.Column<string>(maxLength: 2, nullable: true),
            //        CCilindroOD = table.Column<string>(maxLength: 50, nullable: true),
            //        CEjeOD = table.Column<string>(maxLength: 50, nullable: true),
            //        CSignoOI1 = table.Column<string>(maxLength: 2, nullable: true),
            //        CEsferaOI = table.Column<string>(maxLength: 50, nullable: true),
            //        CSignoOI2 = table.Column<string>(maxLength: 2, nullable: true),
            //        CCilindroOI = table.Column<string>(maxLength: 50, nullable: true),
            //        CEjeOI = table.Column<string>(maxLength: 50, nullable: true),
            //        Cdip = table.Column<string>(maxLength: 100, nullable: true),
            //        Cprisma = table.Column<string>(maxLength: 100, nullable: true),
            //        IdMaterial = table.Column<int>(nullable: true),
            //        IdBifocal = table.Column<int>(nullable: true),
            //        AdicionalMas = table.Column<bool>(nullable: false),
            //        AdicionalMenos = table.Column<bool>(nullable: false),
            //        IdEspecificacion1 = table.Column<int>(nullable: true),
            //        IdEspecificacion2 = table.Column<int>(nullable: true),
            //        IdEspecificacion3 = table.Column<int>(nullable: true),
            //        IdEspecificacion4 = table.Column<int>(nullable: true),
            //        IdEspecificacion5 = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RecetaRefraccionCE", x => x.IdRecetaRefraccion);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "RecetaRefraccionCE");

            //migrationBuilder.CreateTable(
            //    name: "RecetaRefraccion",
            //    columns: table => new
            //    {
            //        IdRecetaRefraccion = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        AdicionalMas = table.Column<bool>(nullable: false),
            //        AdicionalMenos = table.Column<bool>(nullable: false),
            //        CCilindroOD = table.Column<string>(maxLength: 50, nullable: true),
            //        CCilindroOI = table.Column<string>(maxLength: 50, nullable: true),
            //        CEjeOD = table.Column<string>(maxLength: 50, nullable: true),
            //        CEjeOI = table.Column<string>(maxLength: 50, nullable: true),
            //        CEsferaOD = table.Column<string>(maxLength: 50, nullable: true),
            //        CEsferaOI = table.Column<string>(maxLength: 50, nullable: true),
            //        CSignoOD1 = table.Column<string>(maxLength: 2, nullable: true),
            //        CSignoOD2 = table.Column<string>(maxLength: 2, nullable: true),
            //        CSignoOI1 = table.Column<string>(maxLength: 2, nullable: true),
            //        CSignoOI2 = table.Column<string>(maxLength: 2, nullable: true),
            //        Cdip = table.Column<string>(maxLength: 100, nullable: true),
            //        Cprisma = table.Column<string>(maxLength: 100, nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        IdBifocal = table.Column<int>(nullable: true),
            //        IdCita = table.Column<int>(nullable: false),
            //        IdEspecificacion1 = table.Column<int>(nullable: true),
            //        IdEspecificacion2 = table.Column<int>(nullable: true),
            //        IdEspecificacion3 = table.Column<int>(nullable: true),
            //        IdEspecificacion4 = table.Column<int>(nullable: true),
            //        IdEspecificacion5 = table.Column<int>(nullable: true),
            //        IdMaterial = table.Column<int>(nullable: true),
            //        LCilindroOD = table.Column<string>(maxLength: 50, nullable: true),
            //        LCilindroOI = table.Column<string>(maxLength: 50, nullable: true),
            //        LEjeOD = table.Column<string>(maxLength: 50, nullable: true),
            //        LEjeOI = table.Column<string>(maxLength: 50, nullable: true),
            //        LEsferaOD = table.Column<string>(maxLength: 50, nullable: true),
            //        LEsferaOI = table.Column<string>(maxLength: 50, nullable: true),
            //        LSignoOD1 = table.Column<string>(maxLength: 2, nullable: true),
            //        LSignoOD2 = table.Column<string>(maxLength: 2, nullable: true),
            //        LSignoOI1 = table.Column<string>(maxLength: 2, nullable: true),
            //        LSignoOI2 = table.Column<string>(maxLength: 2, nullable: true),
            //        Ldip = table.Column<string>(maxLength: 100, nullable: true),
            //        Lprisma = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RecetaRefraccion", x => x.IdRecetaRefraccion);
            //    });
        }
    }
}
