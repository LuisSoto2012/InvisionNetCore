using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class FechaReceta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaRecetaEmision",
            //    table: "SolicitudCita",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "FechaRecetaValidoHasta",
            //    table: "SolicitudCita",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FechaRecetaEmision",
            //    table: "SolicitudCita");

            //migrationBuilder.DropColumn(
            //    name: "FechaRecetaValidoHasta",
            //    table: "SolicitudCita");
        }
    }
}
